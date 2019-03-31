using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace suiviA
{
    public class SqlRequest
    {

        public class Medecin
        {
            public string Nom{ get; set; }
            public string Prenom { get; set; }
            public Medecin(string prenom, string nom)
            {
                this.Prenom = prenom;
                this.Nom = nom;
            }

        }
    }
}
