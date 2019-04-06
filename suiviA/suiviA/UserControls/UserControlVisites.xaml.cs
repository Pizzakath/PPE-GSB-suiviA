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
    /// Logique d'interaction pour UserControlVisites.xaml
    /// </summary>
    public partial class UserControlVisites : UserControl
    {
        private Utilisateur _user { get; set; }
        public UserControlVisites(Utilisateur utilisateur)
        {
            InitializeComponent();
            _user = utilisateur;
            VisiteRepository repoVisite = new VisiteRepository();
            Visites listeVisites = repoVisite.GetVisiteAllByIdVisiteur(utilisateur.id, utilisateur);

            UtilisateurRepository repoUtilisateur = new UtilisateurRepository();
            Utilisateurs listeMedecins = repoUtilisateur.GetMedecinAll(utilisateur);


            afficherListe(listeVisites.ListeVisites, listeMedecins);

        }

        public void afficherListe(List<Visite> listeVisites, Utilisateurs listeMedecins)
        {
            {
                foreach (Visite el in listeVisites)
                {
                    VisitListView.Items.Add(new Visite(
                        el.id,
                        el.idVisiteur,
                        el.idMedecin,
                        DateTime.Parse(el.date.ToString()),
                        bool.Parse(el.surRDV.ToString()),
                        DateTime.Parse(el.heureArrivee.ToString()),
                        DateTime.Parse(el.heureDebut.ToString()),
                        DateTime.Parse(el.heureDepart.ToString()))
                        );
                }

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
                        int.Parse(el.type.ToString())));
                }
            }
        }

        public void afficherListeVisites(List<Visite> listeVisites)
        {
            {
                foreach (Visite el in listeVisites)
                {
                    VisitListView.Items.Add(new Visite(
                        el.id,
                        el.idVisiteur,
                        el.idMedecin,
                        DateTime.Parse(el.date.ToString()),
                        bool.Parse(el.surRDV.ToString()),
                        DateTime.Parse(el.heureArrivee.ToString()),
                        DateTime.Parse(el.heureDebut.ToString()),
                        DateTime.Parse(el.heureDepart.ToString()))
                        );
                }
            }
        }

        public void ButtonClick_AjouterVisite(object sender, RoutedEventArgs e)
        {
            bool isRDV = rdvComboBox.Text == "Oui" ? true : false;
            Utilisateur medecin = (Utilisateur)DoctorComboBox.SelectedItem;
            int idMedecin = medecin.id;

            int idVisiteur = _user.id;
            Visite nouvelleViste = new Visite(
             idVisiteur, 
             idMedecin,
             DateTime.Parse(dateVisiteDatePicker.Text),
             isRDV,
             DateTime.Parse(heureArriveeTimePicker.Text),
             DateTime.Parse(heureDebutTimePicker.Text),
             DateTime.Parse(heureFinTimePicker.Text)
                );

            VisiteRepository visiteRepository = new VisiteRepository();
            visiteRepository.CreateVisite(nouvelleViste, _user);

            MessageBox.Show("Visite créée");

            Visites listeVisites = visiteRepository.GetVisiteAllByIdVisiteur(_user.id, _user);
            VisitListView.Items.Clear();
            UtilisateurRepository repoUtilisateur = new UtilisateurRepository();
            Utilisateurs listeMedecins = repoUtilisateur.GetMedecinAll(_user);
            afficherListe(listeVisites.ListeVisites, listeMedecins);


        }
    }
}
