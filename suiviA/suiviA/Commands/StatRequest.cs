using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace suiviA.Commands
{
    class StatRequest
    {
        public string nom { get; set; }
        public int id { get; set; }
        public DateTime dateDebut { get; set; }
        public DateTime dateFin { get; set; }

        public StatRequest()
        {

        }

        public StatRequest(string nom, int id, DateTime dateDebut)
        {
            this.nom = nom;
            this.id = id;
            this.dateDebut = dateDebut;
        }

        public StatRequest(string nom, int id, DateTime dateDebut, DateTime dateFin)
        {
            this.nom = nom;
            this.id = id;
            this.dateDebut = dateDebut;
            this.dateFin = dateFin;
        }
    }
}
