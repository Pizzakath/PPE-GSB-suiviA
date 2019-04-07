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
using suiviA.Commands;

namespace suiviA.UserControls
{
    /// <summary>
    /// Logique d'interaction pour UserControlCabinets.xaml
    /// </summary>
    public partial class UserControlCabinets : UserControl
    {
        private Utilisateur _user { get; set; }

        public UserControlCabinets(Utilisateur utilisateur)
        {
            InitializeComponent();
            _user = utilisateur;
            CabinetRepository cabinetRepository = new CabinetRepository();
            Cabinets listeCabinets = cabinetRepository.GetAll(_user);

            afficherListe(listeCabinets);

        }

        public void afficherListe(Cabinets listeCabinets)
        {
            if (listeCabinets.ListeCabinet != null)
            {
                ObservableCollection<Cabinet> listCabinets = new ObservableCollection<Cabinet>();

                foreach (Cabinet el in listeCabinets.ListeCabinet)
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

                CabinetListView.ItemsSource = listCabinets;
            }
        }

        private void EditCabinet(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            Cabinet cabinet = b.CommandParameter as Cabinet;
            
            // Ouvrir le DialogHost
            CabinetDialogHost.IsOpen = true;
            DialogCabinetTitle.Content = "Modifier un Cabinet";

            AjouterDialogButton.Visibility = Visibility.Collapsed;
            ModifierDialogButton.Visibility = Visibility.Visible;

            
            // Afficher les infos
            idCabinetLabel.Content = cabinet.id;
            numeroCabinetTextBox.Text = cabinet.numero.ToString();
            rueCabinetTextBox.Text = cabinet.rue;
            villeCabinetTextBox.Text = cabinet.ville;
            regionCabinetTextBox.Text = cabinet.nomRegion;
            departementCabinetTextBox.Text = cabinet.nomDepartement;
        }

        private void ButtonClick_AjouterCabinetDialog(object sender, RoutedEventArgs e)
        {
            AjouterDialogButton.Visibility = Visibility.Visible;
            ModifierDialogButton.Visibility = Visibility.Collapsed;

            // Ouvrir le DialogHost
            CabinetDialogHost.IsOpen = true;
            DialogCabinetTitle.Content = "Ajouter un Cabinet";

            numeroCabinetTextBox.Text = "";
            rueCabinetTextBox.Text = "";
            villeCabinetTextBox.Text = "";
            regionCabinetTextBox.Text = "";
            departementCabinetTextBox.Text = "";
        }

        private void ButtonClick_AjouterCabinet(object sender, RoutedEventArgs e)
        {
            if((numeroCabinetTextBox.Text != null) && (rueCabinetTextBox != null) 
                && (villeCabinetTextBox != null) && (regionCabinetTextBox != null) 
                && (departementCabinetTextBox != null) 
                )
            {
                Cabinet nouveauCabinet = new Cabinet(
                    int.Parse(numeroCabinetTextBox.Text),
                    rueCabinetTextBox.Text,
                    villeCabinetTextBox.Text,
                    regionCabinetTextBox.Text,
                    departementCabinetTextBox.Text
                );

                CabinetRepository cabinetRepository = new CabinetRepository();
                cabinetRepository.CreateCabinet(nouveauCabinet, _user);

                MessageBox.Show("Cabinet créé !");

                Cabinets listeCabinets = cabinetRepository.GetAll(_user);
                CabinetDialogHost.IsOpen = false;
                afficherListe(listeCabinets);
            }
            else
            {
                MessageBox.Show("Un champ est manquant ou mal renseigné");
            }

        }

        public void ButtonClick_ModifierCabinet(object sender, RoutedEventArgs e)
        {
            int idCabinet = int.Parse(idCabinetLabel.Content.ToString());

            if ((numeroCabinetTextBox.Text != null) && (rueCabinetTextBox != null)
                && (villeCabinetTextBox != null) && (regionCabinetTextBox != null)
                && (departementCabinetTextBox != null)
                )
            {
                Cabinet nouveauCabinet = new Cabinet(
                    idCabinet,
                    int.Parse(numeroCabinetTextBox.Text),
                    rueCabinetTextBox.Text,
                    villeCabinetTextBox.Text,
                    regionCabinetTextBox.Text,
                    departementCabinetTextBox.Text
                );

                CabinetRepository cabinetRepository = new CabinetRepository();
                cabinetRepository.UpdateCabinet(nouveauCabinet, _user);

                MessageBox.Show("Cabinet modifié !");

                Cabinets listeCabinets = cabinetRepository.GetAll(_user);
                afficherListe(listeCabinets);
            }
            else
            {
                MessageBox.Show("Un champ est manquant ou mal renseigné");
            }
        }
    }
}
