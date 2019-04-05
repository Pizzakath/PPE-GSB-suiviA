using System;
using System.Collections.Generic;
using System.Text;
using RestSharp.Deserializers;

namespace suiviA.Commands
{
    public class CabinetData
    {
        [DeserializeAs(Name = "data")]
        public Cabinet Cabinet { get; set; }
    }

    public class Cabinet
    {
        [DeserializeAs(Name = "id")]
        public int id { get; set; }

        [DeserializeAs(Name = "adresse")]
        public string adresse { get; set; }

        [DeserializeAs(Name = "numero")]
        public int numero { get; set; }

        [DeserializeAs(Name = "rue")]
        public string rue { get; set; }

        [DeserializeAs(Name = "ville")]
        public string ville { get; set; }

        [DeserializeAs(Name = "nomRegion")]
        public string region { get; set; }

        [DeserializeAs(Name = "nomDepartement")]
        public string departement { get; set; }

        public Cabinet(int numero, string rue, string ville, string nomRegion, string nomDepartement)
        {
            this.adresse = numero.ToString() + " " + rue + " " + ville;
            this.numero = numero;
            this.rue = rue;
            this.ville = ville;
            this.region = nomRegion;
            this.departement = nomDepartement;
        }
        //[DeserializeAs(Name = "commune")]



    }

    public class Cabinets
    {
        [DeserializeAs(Name = "data")]
        public List<Cabinet> ListeCabinet { get; set; }
    }
}
