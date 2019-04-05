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
        public UserControlStats()
        {
            InitializeComponent();
            UtilisateurRepository repoUtilisateur = new UtilisateurRepository();
            Utilisateurs listeMedecins = repoUtilisateur.GetMedecinAll();
            Utilisateurs listeVisiteurs = repoUtilisateur.GetVisiteurAll();
            afficherMedecins(listeMedecins, listeVisiteurs);

            string debutPeriode = DebutPeriodeDatePicker.Text;
            string finPeriode = FinPeriodeDatePicker.Text;

            string jourDeVisite = JourVisiteVisiteurDatePicker.Text;



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

        private void DebutPeriodeDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            string debutPeriode = DebutPeriodeDatePicker.Text;
            string finPeriode = FinPeriodeDatePicker.Text;
            string nomMedecin = DoctorComboBox.Text;
            StatRequestRepository repoStats = new StatRequestRepository();
           
            
          // StatRequest statRequest = repoStats.RequeteStat;
            

        }

        private void FinPeriodeDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void DoctorComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //sender
        }
    }
}
