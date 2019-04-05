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
        public UserControlVisites(Utilisateur _user)
        {
            InitializeComponent();

            VisiteRepository repoUtilisateur = new VisiteRepository();
            Visites listeVisites = repoUtilisateur.GetVisiteAllByIdVisiteur(_user.id, _user);
            afficherListe(listeVisites.ListeVisites);

        }

        public void afficherListe(List<Visite> listeVisites)
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
    }
}
