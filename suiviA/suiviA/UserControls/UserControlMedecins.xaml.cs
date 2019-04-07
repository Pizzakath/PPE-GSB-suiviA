using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
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
using suiviA.Commands;

namespace suiviA.UserControls
{
    /// <summary>
    /// Logique d'interaction pour UserControlMedecins.xaml
    /// </summary>
    public partial class UserControlMedecins : UserControl
    {
        private Utilisateur _user { get; set; }

        public UserControlMedecins(Utilisateur utilisateur)
        {
            _user = utilisateur;
            InitializeComponent();

            UtilisateurRepository repoUtilisateur = new UtilisateurRepository();
            Utilisateurs listeMedecins = repoUtilisateur.GetMedecinAll(_user);

            CabinetRepository cabinetRepository = new CabinetRepository();
            Cabinets listeCabinets = cabinetRepository.GetAll(_user);

            afficherListe(listeMedecins, listeCabinets);

        }

        public void afficherListe( Utilisateurs listeMedecins, Cabinets listeCabinets)
        {
            if(listeMedecins.ListeUtilisateurs != null)
            {
                ObservableCollection<Utilisateur> listMedecins = new ObservableCollection<Utilisateur>();
                foreach(Utilisateur el in listeMedecins.ListeUtilisateurs)
                {
                    Utilisateur medecin = new Utilisateur(
                        el.id,
                        el.nom,
                        el.prenom,
                        el.identifiant,
                        el.password,
                        el.telephone,
                        el.mail,
                        int.Parse(el.type.ToString())
                    );

                    listMedecins.Add(medecin);
                }

                DoctorListView.ItemsSource = listMedecins;
            }

            ObservableCollection<Cabinet> listCabinets = new ObservableCollection<Cabinet>();
            foreach(Cabinet el in listeCabinets.ListeCabinet)
            {
                Cabinet cabinet = new Cabinet(
                    el.id,
                    el.numero,
                    el.rue,
                    el.ville,
                    el.nomRegion,
                    el.nomDepartement
                );
                listCabinets.Add(cabinet);
            }
            cabinetComboBox.ItemsSource = listCabinets;
        }

        private void EditMedecin(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            Utilisateur medecin = b.CommandParameter as Utilisateur;

            // Ouvrir le DialogHost
            medecinDialogHost.IsOpen = true;
            DoctorDialogTitle.Content = "Modifier un Medecin";
            DoctorDialogTitle.Width = 230;
            cabinetComboBox.Visibility = Visibility.Collapsed;

            AjouterDialogButton.Visibility = Visibility.Collapsed;
            ModifierDialogButton.Visibility = Visibility.Visible;


            // Afficher les infos
            idDoctorLabel.Content = medecin.id;
            cabinetComboBox.SelectedItem = medecin.cabinet;
            nomMedecinTextBox.Text = medecin.nom;
            prenomMedecinTextBox.Text = medecin.prenom;
        }


        private void ButtonClick_AjouterMedecinDialog(object sender, RoutedEventArgs e)
        {
            AjouterDialogButton.Visibility = Visibility.Visible;
            ModifierDialogButton.Visibility = Visibility.Collapsed;

            // Ouvrir le DialogHost
            medecinDialogHost.IsOpen = true;
            DoctorDialogTitle.Content = "Ajouter un Medecin";
            DoctorDialogTitle.Width = 220;
            cabinetComboBox.Visibility = Visibility.Visible;

            cabinetComboBox.SelectedItem = "";
            nomMedecinTextBox.Text = "";
            prenomMedecinTextBox.Text = "";
        }

        public void ButtonClick_AjouterMedecin(object sender, RoutedEventArgs e)
        {
            Cabinet cabinet = (Cabinet)cabinetComboBox.SelectedItem;
            int idCabinet = cabinet.id;
            
            int idVisiteur = _user.id;

            Utilisateur nouveauMedecin = new Utilisateur(
                0,
                idCabinet,
                nomMedecinTextBox.Text,
                prenomMedecinTextBox.Text
            );

            UtilisateurRepository utilisateurRepository = new UtilisateurRepository();
            utilisateurRepository.CreateMedecin(nouveauMedecin, _user);

            MessageBox.Show("Medecin créé !");
            
            Utilisateurs listeMedecins = utilisateurRepository.GetMedecinAll(_user);
            CabinetRepository cabinetRepository = new CabinetRepository();
            Cabinets listeCabinets = cabinetRepository.GetAll(_user);

            afficherListe(listeMedecins, listeCabinets);

        }

        public void ButtonClick_ModifierMedecin(object sender, RoutedEventArgs e)
        {
            int idMedecin = int.Parse(idDoctorLabel.Content.ToString());
            

            Utilisateur medecinModif = new Utilisateur(
                idMedecin,
                nomMedecinTextBox.Text,
                prenomMedecinTextBox.Text
            );

            UtilisateurRepository utilisateurRepository = new UtilisateurRepository();
            utilisateurRepository.UpdateMedecin(medecinModif, _user);

            MessageBox.Show("Medecin modifié !");

            Utilisateurs listeMedecins = utilisateurRepository.GetMedecinAll(_user);
            CabinetRepository cabinetRepository = new CabinetRepository();
            Cabinets listeCabinets = cabinetRepository.GetAll(_user);

            afficherListe(listeMedecins, listeCabinets);
        }
    }
}
