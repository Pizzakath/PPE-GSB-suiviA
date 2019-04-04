using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetRestSharp
{
    public class Departement
    {
        [DeserializeAs(Name = "dpt_Num")]
        public string Dpt_Num { get; set; }
        [DeserializeAs(Name = "dpt_Nom")]
        public string Dpt_Nom { get; set; }
        [DeserializeAs(Name = "dpt_Region")]
        public string Dpt_Region { get; set; }
        public Departement() { }

        public Departement(string Num, string Nom, string Region)
        {
            this.Dpt_Num = Num;
            this.Dpt_Nom = Nom;
            this.Dpt_Region = Region;
        }

        public void afficher()
        {
            Console.WriteLine("Num: " + this.Dpt_Num + " Nom: " + Dpt_Nom + " Region: " + Dpt_Region);
        }
    }

    public class Departements
    {
        [DeserializeAs(Name = "data")]
        public List<Departement> ListeDepartements { get; set; }
    }
}
