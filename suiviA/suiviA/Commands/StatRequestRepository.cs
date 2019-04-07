using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json;

namespace suiviA.Commands
{
    class StatRequestRepository
    {
        private IRestClient restClient;

        public StatRequestRepository()
        {
            restClient = ClientRestSharp.GetClient();
        }

        /*
         *
         *      if (request.reqName == "GetVisiteMedecin")
                {
                    return Ok(db.GetStat_GetVisiteMedecin(request));
                }
                if (request.reqName == "GetVisiteVisiteur")
                {
                    return Ok(db.GetStat_GetVisiteVisiteur(request));
                }
                if (request.reqName == "GetAttenteMoy")
                {
                    return Ok(db.GetStat_GetAttenteMoy(request));
                }
                if (request.reqName == "GetDureeVisite")
                {
                    return Ok(db.GetStat_GetDureeVisite(request));
                }
         */

        public int RequeteStat_GetVisiteMedecin(StatRequest statRequete, Utilisateur uCo)
        {
            RestRequest req = new RestRequest("api/stats/{token}", Method.POST);

            statRequete.reqName = "GetVisiteMedecin";

            req.RequestFormat = DataFormat.Json;
            req.AddUrlSegment("token", uCo.token);
            req.AddJsonBody(JsonConvert.SerializeObject(statRequete));
            var truc = restClient.Post<int>(req).Data;
            return truc;
        }

        public int RequeteStat_GetVisiteVisiteur(StatRequest statRequete, Utilisateur uCo)
        {
            RestRequest req = new RestRequest("api/stats/{token}", Method.POST);

            statRequete.reqName = "GetVisiteVisiteur";

            req.RequestFormat = DataFormat.Json;
            req.AddUrlSegment("token", uCo.token);
            req.AddJsonBody(JsonConvert.SerializeObject(statRequete));
            var truc = restClient.Post<int>(req).Data;
            return truc;
        }

        public DateTime RequeteStat_GetAttenteMoy(StatRequest statRequete, Utilisateur uCo)
        {
            RestRequest req = new RestRequest("api/stats/{token}", Method.POST);

            statRequete.reqName = "GetAttenteMoy";

            req.RequestFormat = DataFormat.Json;
            req.AddUrlSegment("token", uCo.token);
            req.AddJsonBody(JsonConvert.SerializeObject(statRequete));
            var truc = restClient.Post<DateTime>(req).Data;
            return truc;
        }

        public DateTime RequeteStat_GetDureeVisite(StatRequest statRequete, Utilisateur uCo)
        {
            RestRequest req = new RestRequest("api/stats/{token}", Method.POST);

            statRequete.reqName = "GetDureeVisite";

            req.RequestFormat = DataFormat.Json;
            req.AddUrlSegment("token", uCo.token);
            req.AddJsonBody(JsonConvert.SerializeObject(statRequete));
            var truc = restClient.Post<DateTime>(req).Data;
            return truc;
        }
    }
}
