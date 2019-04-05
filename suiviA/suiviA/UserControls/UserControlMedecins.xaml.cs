using System;
using System.Collections.Generic;
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
        public UserControlMedecins()
        {
            InitializeComponent();

            UtilisateurRepository repoUtilisateur = new UtilisateurRepository();
            Utilisateurs listeMedecins = repoUtilisateur.GetMedecinAll();
            afficherListe(listeMedecins);

        }

        public void afficherListe( Utilisateurs listeMedecins)
        {
            if(listeMedecins.ListeUtilisateurs != null)
            {
                foreach(Utilisateur el in listeMedecins.ListeUtilisateurs)
                {
                    DoctorListView.Items.Add(new Utilisateur(
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


    }
}
