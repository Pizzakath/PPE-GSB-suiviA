using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace suiviA.Commands
{
    public class VisiteRepository
    {
        private IRestClient restClient;

        // Test
        public VisiteRepository(IRestClient client)
        {
            this.restClient = client;
        }

        public VisiteRepository()
        {
            restClient = ClientRestSharp.GetClient();
        }

        public Visites GetVisiteAllByIdMedecin(int id)
        {
            RestRequest req = new RestRequest("api/medecins/visites/{id}");
            req.AddUrlSegment("id", id);
            var truc = restClient.Get<Visites>(req);
            return truc.Data;
        }

        public void CreateVisite(Visite visite)
        {
            RestRequest req = new RestRequest("api/visites", Method.POST);
            req.RequestFormat = DataFormat.Json;
            req.AddJsonBody(JsonConvert.SerializeObject(visite));
            restClient.Execute(req);
        }

        public void UpdateVisite(Visite visite)
        {
            RestRequest req = new RestRequest("api/visites", Method.PUT);
            req.RequestFormat = DataFormat.Json;
            req.AddJsonBody(JsonConvert.SerializeObject(visite));
            restClient.Execute(req);
        }

        public void DeleteVisite(int id)
        {
            RestRequest req = new RestRequest("api/visites{id}", Method.DELETE);
            req.AddUrlSegment("id", id);
            restClient.Execute(req);
        }
    }
}
