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
    /// Logique d'interaction pour UserControlAffectation.xaml
    /// </summary>
    public partial class UserControlAffectation : UserControl
    {
        private Utilisateur _user { get; set; }

        public UserControlAffectation(Utilisateur utilisateur)
        {
            _user = utilisateur;
            InitializeComponent();
            UtilisateurRepository repoUtilisateur = new UtilisateurRepository();
            Utilisateurs listeMedecins = repoUtilisateur.GetMedecinAll(utilisateur);
            Utilisateurs listeVisiteurs = repoUtilisateur.GetVisiteurAll(utilisateur);
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
                        int.Parse(el.type.ToString()))).ToString();
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
                        int.Parse(el.type.ToString()))).ToString();
                }
            }
        }

        private void ButtonAffecter_Click(object sender, RoutedEventArgs e)
        {
            Utilisateur medecin = (Utilisateur) DoctorComboBox.SelectedItem;
            int idMedecin = medecin.id;

            Utilisateur visiteur = (Utilisateur) VisiteurComboBox.SelectedItem;
            int idVisiteur = visiteur.id;
            UtilisateurRepository repoUtilisateur = new UtilisateurRepository();
            repoUtilisateur.SetMedecinVisiteur(idVisiteur, idMedecin, _user);
            MessageBox.Show("Affecté");
        }
    }
}
