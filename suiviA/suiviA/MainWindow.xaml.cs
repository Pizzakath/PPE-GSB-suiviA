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

namespace suiviA
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(int role)
        {
            InitializeComponent();
            //AfficherOnglets(role);
            
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
                    usc = new UserControlVisites();
                    GridMain.Children.Add(usc);
                    break;
                case "ItemCabinet":
                    usc = new UserControlCabinets();
                    GridMain.Children.Add(usc);
                    break;
                case "ItemMedecin":
                    usc = new UserControlMedecins();
                    GridMain.Children.Add(usc);
                    break;
                case "ItemVisiteurs":
                    usc = new UserControlVisiteurs();
                    GridMain.Children.Add(usc);
                    break;
                case "ItemStats":
                    usc = new UserControlStats();
                    GridMain.Children.Add(usc);
                    break;
                default:
                    break;
            }
        }

        private void AfficherOnglets(int role)
        {
            switch (role)
            {
                case 0:
                    ItemMedecin.Visibility = Visibility.Collapsed;
                    ItemCabinet.Visibility = Visibility.Collapsed;
                    ItemVisiteurs.Visibility = Visibility.Collapsed;
                    break;
                case 1:
                    ItemVisite.Visibility = Visibility.Collapsed;
                    ItemVisiteurs.Visibility = Visibility.Collapsed;
                    break;
                case 2:
                    ItemVisite.Visibility = Visibility.Collapsed;
                    break;
                default:
                    break;
            }
        }
    }
}
