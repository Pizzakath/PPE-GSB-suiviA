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
using suiviA.UserControls;

namespace suiviA
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public Utilisateur _user { get; set; }

        public MainWindow(Utilisateur utilisateur)
        {
            InitializeComponent();
            _user = utilisateur;

            GridMain.Children.Add(new UserControlStats(_user));
            AfficherOnglets(_user.type);



        }

        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Visible;
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
            ButtonOpenMenu.Visibility = Visibility.Visible;
        }

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UserControl usc = null;
            GridMain.Children.Clear();
            
            switch (((ListViewItem)((ListView)sender).SelectedItem).Name)
            {
                case "ItemVisite":
                    usc = new UserControlVisites(_user);
                    GridMain.Children.Add(usc);
                    break;
                case "ItemCabinet":
                    usc = new UserControlCabinets(_user);
                    GridMain.Children.Add(usc);
                    break;
                case "ItemMedecin":
                    usc = new UserControlMedecins(_user);
                    GridMain.Children.Add(usc);
                    break;
                case "ItemStats":
                    usc = new UserControlStats(_user);
                    GridMain.Children.Add(usc);
                    break;
                case "ItemAffectation":
                    usc = new UserControlAffectation(_user);
                    GridMain.Children.Add(usc);
                    break;
                default:
                    usc = new UserControlStats(_user);
                    GridMain.Children.Add(usc);
                    break;
            }
        }

        private void AfficherOnglets(int typeUtilisateur)
        {
            switch (typeUtilisateur)
            {
                // 1 = Administrateur
                case 0:
                    ItemVisite.Visibility = Visibility.Collapsed;
                    ItemStats.Visibility = Visibility.Visible;
                    ItemMedecin.Visibility = Visibility.Visible;
                    ItemCabinet.Visibility = Visibility.Visible;
                    ItemAffectation.Visibility = Visibility.Visible;
                    break;
                // 2 = Médecin
                case 1:
                    ItemVisite.Visibility = Visibility.Visible;
                    ItemStats.Visibility = Visibility.Visible;
                    ItemMedecin.Visibility = Visibility.Collapsed;
                    ItemCabinet.Visibility = Visibility.Collapsed;
                    ItemAffectation.Visibility = Visibility.Collapsed;
                    break;
                // 3 = Visiteur
                case 2:
                    ItemVisite.Visibility = Visibility.Visible;
                    ItemStats.Visibility = Visibility.Visible;
                    ItemMedecin.Visibility = Visibility.Collapsed;
                    ItemCabinet.Visibility = Visibility.Collapsed;
                    ItemAffectation.Visibility = Visibility.Collapsed;
                    break;
                default:
                    break;
            }
        }
    }
}
