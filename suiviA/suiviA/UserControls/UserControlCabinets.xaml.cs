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
                foreach (Cabinet el in listeCabinets.ListeCabinet)
                {
                    CabinetListView.Items.Add(new Cabinet(
                        el.id,
                        el.numero,
                        el.rue,
                        el.ville,
                        el.nomRegion,
                        el.nomDepartement
                        ));
                }
            }
        }

        private void ButtonAjouterCabinet_Click(object sender, RoutedEventArgs e)
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
                CabinetListView.Items.Clear();
                afficherListe(listeCabinets);
            }
            else
            {
                MessageBox.Show("Un champ est manquant ou mal renseigné");
            }

        }
    }
}
