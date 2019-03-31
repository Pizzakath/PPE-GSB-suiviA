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

namespace suiviA
{
    /// <summary>
    /// Logique d'interaction pour UserControlMedecins.xaml
    /// </summary>
    public partial class UserControlMedecins : UserControl
    {
        public UserControlMedecins()
        {
            InitializeComponent();
            SqlRequest.Medecin medecin1 = new SqlRequest.Medecin("Jean", "Fil");
            SqlRequest.Medecin medecin2 = new SqlRequest.Medecin("Jean", "Fil");
            SqlRequest.Medecin medecin3 = new SqlRequest.Medecin("Jean", "Fil");
            SqlRequest.Medecin medecin4 = new SqlRequest.Medecin("Jean", "Fil");
            SqlRequest.Medecin medecin5 = new SqlRequest.Medecin("Jean", "Fil");
            SqlRequest.Medecin medecin6 = new SqlRequest.Medecin("Jean", "Fil");
            SqlRequest.Medecin medecin7 = new SqlRequest.Medecin("Jean", "TO");
            SqlRequest.Medecin medecin8 = new SqlRequest.Medecin("Jean", "Fil");
            SqlRequest.Medecin medecin9 = new SqlRequest.Medecin("Jean", "Fil");

            List<SqlRequest.Medecin> medicList = new List<SqlRequest.Medecin>
            {
                new SqlRequest.Medecin("Jean", "Fil"),
                new SqlRequest.Medecin("Jean", "Fil"),
                new SqlRequest.Medecin("Jean", "Fil"),
                new SqlRequest.Medecin("Jean", "Fil"),
                new SqlRequest.Medecin("Jean", "Fil"),
                new SqlRequest.Medecin("Jean", "Fil"),
                new SqlRequest.Medecin("Jean", "TO")
            };

            for(int i=0; i <= medicList.Count; i++)
            {
                MedicListView.Items.Add(medicList[i]);
            }
            
        }

    }
}
