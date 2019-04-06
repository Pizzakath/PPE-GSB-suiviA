using suiviA.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace suiviA.UserControls
{
    /// <summary>
    /// Logique d'interaction pour UserControlStats.xaml
    /// </summary>
    public partial class UserControlStats : UserControl
    {
        private Utilisateur _user {get;set;}
        public UserControlStats(Utilisateur _utilisateur)
        {
            _user = _utilisateur;
            InitializeComponent();
            UtilisateurRepository repoUtilisateur = new UtilisateurRepository();
            Utilisateurs listeMedecins = repoUtilisateur.GetMedecinAll(_user);
            Utilisateurs listeVisiteurs = repoUtilisateur.GetVisiteurAll(_user);
            afficherMedecins(listeMedecins, listeVisiteurs);
        }

        public void afficherMedecins(Utilisateurs listeMedecins, Utilisateurs listeVisiteurs)
        {
            if ((listeMedecins.ListeUtilisateurs != null) || (listeVisiteurs.ListeUtilisateurs != null))
            {
                foreach (Utilisateur el in listeMedecins.ListeUtilisateurs)
                {
                    DoctorComboBox.Items.Add(new Utilisateur(
                        el.id,
                        el.nom,
                        el.prenom,
                        el.identifiant,
                        el.password,
                        el.telephone,
                        el.mail,
                        int.Parse(el.type.ToString())))
                        .ToString();
                }

                foreach (Utilisateur el in listeVisiteurs.ListeUtilisateurs)
                {
                    VisiteurComboBox.Items.Add(new Utilisateur(
                        el.id,
                        el.nom,
                        el.prenom,
                        el.identifiant,
                        el.password,
                        el.telephone,
                        el.mail,
                        int.Parse(el.type.ToString())))
                        .ToString();
                }
            }
        }

        #region SelectedChanges
        private void DebutPeriodeDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            get_NbVisitesParJourParMedecin();
        }

        private void FinPeriodeDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            get_NbVisitesParJourParMedecin();
        }

        private void DoctorComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            get_NbVisitesParJourParMedecin();
        }

        private void VisiteurComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            get_NombreVisiteParVisiteurParJour();
        }

        private void JourVisiteVisiteurDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            get_NombreVisiteParVisiteurParJour();
        }

        #endregion


        #region RecupValeursStats

        private void get_NbVisitesParJourParMedecin()
        {
            if (DebutPeriodeDatePicker.Text != string.Empty && FinPeriodeDatePicker.Text != string.Empty && DoctorComboBox.Text != string.Empty)
            {
                string debutPeriode = DebutPeriodeDatePicker.Text;
                string finPeriode = FinPeriodeDatePicker.Text;

                Utilisateur medecin = (Utilisateur)DoctorComboBox.SelectedItem;
                int idMedecin = medecin.id;

                StatRequestRepository repoStats = new StatRequestRepository();
                StatRequest statRequest = new StatRequest("GetVisiteMedecin", idMedecin, DateTime.Parse(debutPeriode), DateTime.Parse(finPeriode));

                int nombreVisitesParJourParMedecin = repoStats.RequeteStat(statRequest, _user);
                NbVisitesMedecinLabel.Content = nombreVisitesParJourParMedecin.ToString();
            }
        }

        private void get_NombreVisiteParVisiteurParJour()
        {
            if(VisiteurComboBox.Text != string.Empty && JourVisiteVisiteurDatePicker.Text != null)
            {
                Utilisateur visiteur = (Utilisateur)VisiteurComboBox.SelectedItem;
                int idVisiteur = visiteur.id;

                StatRequestRepository repoStats = new StatRequestRepository();
                StatRequest statRequest = new StatRequest("GetVisiteVisiteur", idVisiteur, DateTime.Parse(JourVisiteVisiteurDatePicker.Text));

                int nombreVisitesParVisiteurParJour = repoStats.RequeteStat(statRequest, _user);
                TempsMoyenEntretienLabel.Content = nombreVisitesParVisiteurParJour.ToString();
            }
        }

        #endregion

    }
}
