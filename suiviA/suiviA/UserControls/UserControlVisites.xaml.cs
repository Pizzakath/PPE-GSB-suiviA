using suiviA.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            UtilisateurRepository repoUtilisateur = new UtilisateurRepository();

            if(_user.type == 2)
            {
                DialogHostButton.Visibility = Visibility.Collapsed;
                // TODO: A passer à 1 quand ce sera le nom/prénom et non l'id
                ColHeaderVisiteur.Width = 0;
                VisitListView.Width = double.NaN;
                VisitListView.Margin = new Thickness(370, 0, 0, 0);
                ColHeaderModifBtn.Width = 0;
                ColHeaderDelBtn.Width = 0;
                ColHeaderMedecin.Width = 0;
                Visites listeVisitesMedecin = repoVisite.GetVisiteAllByIdMedecin(_user.id, _user);
                afficherListeByMedecin(listeVisitesMedecin.ListeVisites);
            }
            else
            {
                ColHeaderMedecin.Width = double.NaN;
                ColHeaderVisiteur.Width = 0;
                VisitListView.Margin = new Thickness(170,0,0,0);
                Visites listeVisites = repoVisite.GetVisiteAllByIdVisiteur(_user.id, _user);
                Utilisateurs listeMedecins = repoUtilisateur.GetMedecinVisiteur(_user.id, _user);
                afficherListe(listeVisites.ListeVisites, listeMedecins);
            }


        }

        public void afficherListe(List<Visite> listeVisites, Utilisateurs listeMedecins)
        {
            {
                ObservableCollection<Visite> listVisites = new ObservableCollection<Visite>();

                foreach (Visite el in listeVisites)
                {
                    Visite visite = new Visite(
                        el.id,
                        el.idVisiteur,
                        el.idMedecin,
                        DateTime.Parse(el.date.ToString("yyyy-MM-dd")),
                        bool.Parse(el.surRDV.ToString()),
                        DateTime.Parse(el.heureArrivee.ToString("HH:mm")),
                        DateTime.Parse(el.heureDebut.ToString("HH:mm")),
                        DateTime.Parse(el.heureDepart.ToString("HH:mm")),
                        el.nomMedecin
                    );
                    listVisites.Add(visite);
                }

                VisitListView.ItemsSource = listVisites;

                ObservableCollection<Utilisateur> listMedecins = new ObservableCollection<Utilisateur>();

                foreach (Utilisateur el in listeMedecins.ListeUtilisateurs)
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
                DoctorComboBox.ItemsSource = listMedecins;
            }
        }

        // Si médecin, affiche ses propres visites
        public void afficherListeByMedecin(List<Visite> listeVisitesMedecin)
        {
            ObservableCollection<Visite> listVisites = new ObservableCollection<Visite>();

            foreach (Visite el in listeVisitesMedecin)
            {
                Visite visite = new Visite(
                    el.id,
                    el.idVisiteur,
                    el.idMedecin,
                    DateTime.Parse(el.date.ToString("yyyy-MM-dd")),
                    bool.Parse(el.surRDV.ToString()),
                    DateTime.Parse(el.heureArrivee.ToString("HH:mm")),
                    DateTime.Parse(el.heureDebut.ToString("HH:mm")),
                    DateTime.Parse(el.heureDepart.ToString("HH:mm")),
                    el.nomMedecin
                );
                listVisites.Add(visite);
            }

            VisitListView.ItemsSource = listVisites;
        }

        private void EditVisite(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            Visite visite = b.CommandParameter as Visite;
           
            // Ouvrir le DialogHost
            VisiteDialogHost.IsOpen = true;
            VisiteDialogTitle.Content = "Modifier une Visite";
            VisiteDialogTitle.Width = 250;

            AjouterDialogButton.Visibility = Visibility.Collapsed;
            ModifierDialogButton.Visibility = Visibility.Visible;
            

            // Afficher les infos
            idVisiteLabel.Content = visite.id;
            DoctorComboBox.SelectedItem = visite.idMedecin;
            dateVisiteDatePicker.Text = visite.date.ToString();
            heureArriveeTimePicker.Text = visite.heureArrivee.ToString("HH:mm");
            heureDebutTimePicker.Text = visite.heureDebut.ToString("HH:mm");
            heureDepartTimePicker.Text = visite.heureDepart.ToString("HH:mm");
            rdvComboBox.SelectedItem = visite.surRDV == true ? rdvOuiComboBox : rdvNonComboBox;
        }
        private void DeleteVisite(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            Visite visite = b.CommandParameter as Visite;

            VisiteRepository visiteRepository = new VisiteRepository();
            visiteRepository.DeleteVisite(visite.id, _user);

            Visites listeVisites = visiteRepository.GetVisiteAllByIdVisiteur(_user.id, _user);
            UtilisateurRepository repoUtilisateur = new UtilisateurRepository();
            Utilisateurs listeMedecins = repoUtilisateur.GetMedecinAll(_user);
            afficherListe(listeVisites.ListeVisites, listeMedecins);
        }

        private void ButtonClick_AjouterVisiteDialog(object sender, RoutedEventArgs e)
        {
            AjouterDialogButton.Visibility = Visibility.Visible;
            ModifierDialogButton.Visibility = Visibility.Collapsed;

            // Ouvrir le DialogHost
            VisiteDialogHost.IsOpen = true;
            VisiteDialogTitle.Content = "Ajouter une Visite";
            VisiteDialogTitle.Width = 200;

            idVisiteLabel.Content = "";
            DoctorComboBox.SelectedItem = "";
            dateVisiteDatePicker.Text = "";
            heureArriveeTimePicker.Text = "";
            heureDebutTimePicker.Text = "";
            heureDepartTimePicker.Text = "";
        }

        public void ButtonClick_AjouterVisite(object sender, RoutedEventArgs e)
        {
            if (ValidValues())
            {
                bool isRDV = rdvComboBox.Text == "Oui" ? true : false;
                Utilisateur medecin = (Utilisateur)DoctorComboBox.SelectedItem;
                int idMedecin = medecin.id;

                Visite nouvelleViste = new Visite(
                    _user.id,
                    idMedecin,
                    DateTime.Parse(dateVisiteDatePicker.Text),
                    isRDV,
                    DateTime.Parse(heureArriveeTimePicker.Text),
                    DateTime.Parse(heureDebutTimePicker.Text),
                    DateTime.Parse(heureDepartTimePicker.Text)
                );

                VisiteRepository visiteRepository = new VisiteRepository();
                visiteRepository.CreateVisite(nouvelleViste, _user);

                MessageBox.Show("Visite créée");


                Visites listeVisites = visiteRepository.GetVisiteAllByIdVisiteur(_user.id, _user);
                UtilisateurRepository repoUtilisateur = new UtilisateurRepository();
                Utilisateurs listeMedecins = repoUtilisateur.GetMedecinAll(_user);
                afficherListe(listeVisites.ListeVisites, listeMedecins);
            }
            else
            {
                VisiteDialogHost.IsOpen = true;
            }

        }

        //public bool ValidValues()
        //{
        //    //Utilisateur medecin = (Utilisateur)DoctorComboBox.SelectedItem;
        //    //DateTime dateVisite = DateTime.Parse(dateVisiteDatePicker.Text);
        //    //heureDebutTimePicker
        //    //DateTime heureDepart = DateTime.Parse(heureDepartTimePicker.Text);

        //    if(medecin == null)
        //    {
        //        MessageBox.Show("Sélectionnez un médecin");
        //        return false;
        //    }
        //    if (dateVisite == null)
        //    {
        //        MessageBox.Show("Il faut spécifier la date de visite.");
        //        return false;
        //    }
        //    else if ((heureDebut == null) && (heureDepart != null))
        //    {
        //        MessageBox.Show("Vous ne pouvez pas renseigner d'heure de départ si une heure 'arrivée n'est pas spécifiée.");
        //        return false;
        //    }
        //    else if (heureDepart < heureDebut)
        //    {
        //        MessageBox.Show("Erreur : l'heure de départ du cabinet doit être supérieure à celle de début d'entretien.");
        //        return false;
        //    }
            
        //    return true;
        //}
        public void ButtonClick_ModifierVisite(object sender, RoutedEventArgs e)
        {
            int idVisite = int.Parse(idVisiteLabel.Content.ToString());

            bool isRDV = rdvComboBox.Text == "Oui" ? true : false;
            Utilisateur medecin = (Utilisateur)DoctorComboBox.SelectedItem;
            int idMedecin = medecin.id;
            
            int idVisiteur = _user.id;

            Visite visiteModif = new Visite(
                idVisite,
                idVisiteur, 
                idMedecin,
                DateTime.Parse(dateVisiteDatePicker.Text),
                isRDV,
                DateTime.Parse(heureArriveeTimePicker.Text),
                DateTime.Parse(heureDebutTimePicker.Text),
                DateTime.Parse(heureDepartTimePicker.Text)
            );

            VisiteRepository visiteRepository = new VisiteRepository();
            visiteRepository.UpdateVisite(visiteModif, _user);

            MessageBox.Show("Visite modifiée");

            Visites listeVisites = visiteRepository.GetVisiteAllByIdVisiteur(_user.id, _user);
            UtilisateurRepository repoUtilisateur = new UtilisateurRepository();
            Utilisateurs listeMedecins = repoUtilisateur.GetMedecinAll(_user);
            afficherListe(listeVisites.ListeVisites, listeMedecins);
        }
    }
}
