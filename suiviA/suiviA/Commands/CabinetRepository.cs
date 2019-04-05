using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace suiviA.Commands
{
    public class CabinetRepository
    {
        private IRestClient restClient;

        // Test
        public CabinetRepository(IRestClient client)
        {
            this.restClient = client;
        }

        public CabinetRepository()
        {
            this.restClient = ClientRestSharp.GetClient();
        }



        public Cabinets GetAll(Utilisateur uCo)
        {
            RestRequest req = new RestRequest("/api/cabinets/{token}");
            req.AddUrlSegment("token", uCo.token);
            return restClient.Get<Cabinets>(req).Data;

        }

        public void SetMedecinCabinet(int idMedecin, int idCabinet, Utilisateur uCo)
        {
            RestRequest req = new RestRequest("/api/medecins/cabinets/{token}/{idCabinet}", Method.POST);
            req.RequestFormat = DataFormat.Json;
            req.AddUrlSegment("token", uCo.token);
            req.AddJsonBody(JsonConvert.SerializeObject(idMedecin));
            restClient.Execute(req);
        }

        public void CreateCabinet(Cabinet cabinet, Utilisateur uCo)
        {
            RestRequest req = new RestRequest("api/cabinets/{token}", Method.POST);
            req.RequestFormat = DataFormat.Json;
            req.AddUrlSegment("token", uCo.token);
            req.AddJsonBody(JsonConvert.SerializeObject(cabinet));
            restClient.Execute(req);
        }

        public Cabinet GetCabinetByIdMedecin(int id, Utilisateur uCo)
        {
            // Id du medecin
            RestRequest req = new RestRequest("/api/cabinets/{token}/{id}");
            req.AddUrlSegment("id", id);
            req.AddUrlSegment("token", uCo.token);
            var truc = restClient.Get<CabinetData>(req);
            return truc.Data.Cabinet;
        }

    }
}
