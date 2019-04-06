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

        public int RequeteStat(StatRequest statRequete, Utilisateur uCo)
        {
            RestRequest req = new RestRequest("api/stats/{token}", Method.POST);
            req.RequestFormat = DataFormat.Json;
            req.AddUrlSegment("token", uCo.token);
            req.AddJsonBody(JsonConvert.SerializeObject(statRequete));
            var truc = restClient.Post<int>(req).Data;
            return truc;
        }
    }
}
