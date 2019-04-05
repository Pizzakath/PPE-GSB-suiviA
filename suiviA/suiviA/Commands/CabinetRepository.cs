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



        public Cabinets GetAll()
        {
            return restClient.Get<Cabinets>(new RestRequest("/api/cabinets")).Data;
        }

        public void SetMedecinCabinet(int idMedecin, int idCabinet)
        {
            RestRequest req = new RestRequest("/api/medecins/cabinets{idCabinet}", Method.POST);
            req.RequestFormat = DataFormat.Json;
            req.AddJsonBody(JsonConvert.SerializeObject(idMedecin));
            restClient.Execute(req);
        }

        public void CreateCabinet(Cabinet cabinet)
        {
            RestRequest req = new RestRequest("api/cabinets", Method.POST);
            req.RequestFormat = DataFormat.Json;
            req.AddJsonBody(JsonConvert.SerializeObject(cabinet));
            restClient.Execute(req);
        }

        public Cabinet GetCabinetByIdMedecin(int id)
        {
            // Id du medecin
            RestRequest req = new RestRequest("/api/cabinets/{id}");
            req.AddUrlSegment("id", id);
            var truc = restClient.Get<CabinetData>(req);
            return truc.Data.Cabinet;
        }

    }
}
