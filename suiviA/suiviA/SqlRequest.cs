using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace suiviA
{
    public class Medecin
    {
        private readonly List<Medecin> _items;

        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Cabinet { get; set; }

        public Medecin(string _nom, string _prenom, string _cabinet)
        {
            this.Nom = _nom;
            this.Prenom = _prenom;
            this.Cabinet = _cabinet;
        }

        public List<Medecin> Items = new List<Medecin> { new Medecin("J", "J", "K"), new Medecin("A", "B", "C") };
          
        

    }
}
