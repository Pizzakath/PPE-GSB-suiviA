using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace suiviA.Commands
{
    class StatRequest
    {
        public string reqName { get; set; }
        public int id { get; set; }

        // Date de début
        public DateTime date1 { get; set; }
        // Date de fin
        public DateTime date2 { get; set; }

        public StatRequest()
        {

        }

        public StatRequest(string nom, int id, DateTime dateDebut)
        {
            this.reqName = nom;
            this.id = id;
            this.date1 = dateDebut;
        }

        public StatRequest(string nom, int id, DateTime dateDebut, DateTime dateFin)
        {
            this.reqName = nom;
            this.id = id;
            this.date1 = dateDebut;
            this.date2 = dateFin;
        }
    }
}
