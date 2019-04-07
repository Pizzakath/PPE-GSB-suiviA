using System;
using System.Collections.Generic;
using System.Text;
using RestSharp.Deserializers;

namespace suiviA.Commands
{
    public class VisiteData
    {
        [DeserializeAs(Name = "data")]
        public Visite Visite { get; set; }
    }

    public class Visite
    {
        [DeserializeAs(Name = "id")]
        public int id { get; set; }

        [DeserializeAs(Name = "idVisiteur")]
        public int idVisiteur { get; set; }

        [DeserializeAs(Name = "idMedecin")]
        public int idMedecin { get; set; }

        [DeserializeAs(Name = "date")]
        public DateTime date { get; set; }

        // Voir type
        [DeserializeAs(Name = "surRDV")]
        public bool surRDV { get; set; }

        // Voir type
        [DeserializeAs(Name = "heureArrivee")]
        public DateTime heureArrivee { get; set; }

        // Voir type
        [DeserializeAs(Name = "heureDebut")]
        public DateTime heureDebut { get; set; }

        // Voir type
        [DeserializeAs(Name = "heureDepart")]
        public DateTime heureDepart { get; set; }

        // Nom du médecin
        [DeserializeAs(Name = "nomMedecin")]
        public string nomMedecin { get; set; }


        public Visite()
        {
            // Default
        }

        public Visite(int id, int idVisiteur, int idMedecin, DateTime date, bool surRDV, DateTime heureArrivee
            , DateTime heureDebut, DateTime heureDepart)
        {
            this.id = id;
            this.idMedecin = idMedecin;
            this.idVisiteur = idVisiteur;
            this.date = date;
            this.surRDV = surRDV;
            this.heureArrivee = heureArrivee;
            this.heureDebut = heureDebut;
            this.heureDepart = heureDepart;
        }

        public Visite(int idVisiteur, int idMedecin, DateTime date, bool surRDV, DateTime heureArrivee
            , DateTime heureDebut, DateTime heureDepart)
        {
            this.idMedecin = idMedecin;
            this.idVisiteur = idVisiteur;
            this.date = date;
            this.surRDV = surRDV;
            this.heureArrivee = heureArrivee;
            this.heureDebut = heureDebut;
            this.heureDepart = heureDepart;
        }

        public Visite(int id, int idVisiteur, int idMedecin, DateTime date, bool surRDV, DateTime heureArrivee
            , DateTime heureDebut, DateTime heureDepart, string nomMedecin)
        {
            this.id = id;
            this.idMedecin = idMedecin;
            this.idVisiteur = idVisiteur;
            this.date = date;
            this.surRDV = surRDV;
            this.heureArrivee = heureArrivee;
            this.heureDebut = heureDebut;
            this.heureDepart = heureDepart;
            this.nomMedecin = nomMedecin;
        }


        public void afficher()
        {
            // A implementer pour test
        }
    }

    public class Visites
    {
        // J'ai ajouté PUBLIC ;)
        [DeserializeAs(Name = "data")]
        public List<Visite> ListeVisites { get; set; }
    }
}
