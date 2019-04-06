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
                foreach(Utilisateur el in listeMedecins.ListeUtilisateurs)
                {
                    DoctorListView.Items.Add(new Utilisateur(
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
            foreach(Cabinet el in listeCabinets.ListeCabinet)
            {
                cabinetComboBox.Items.Add(new Cabinet(
                    el.id,
                    el.numero,
                    el.rue,
                    el.ville,
                    el.nomRegion,
                    el.nomDepartement
                    ).ToString());
            }
        }

        // Pas possible de créer un utilisateur Médecin avec nom/prénom/cabinet, 
        // Donc pas d'implémentation de la fonctionnalité

        //private void ButtonClick_AjouterMedecin(object sender, RoutedEventArgs e)
        //{
        //    string newMedecinNom = nomMedecinTextBox.Text;
        //    string newMedecinPrenom = prenomMedecinTextBox.Text;

        //    Utilisateur nouveauMedecin = new Utilisateur(newMedecinNom)

        //}


    }
}
