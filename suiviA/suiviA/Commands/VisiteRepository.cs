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

        public Visites GetVisiteAllByIdMedecin(int id, Utilisateur uCo)
        {
            RestRequest req = new RestRequest("api/medecins/{token}/visites/{id}");
            req.AddUrlSegment("id", id);
            req.AddUrlSegment("token", uCo.token);
            var truc = restClient.Get<Visites>(req);
            return truc.Data;
        }

        public Visites GetVisiteAllByIdVisiteur(int id, Utilisateur uCo)
        {
            RestRequest req = new RestRequest("api/visiteurs/{token}/visites/{id}");
            req.AddUrlSegment("id", id);
            req.AddUrlSegment("token", uCo.token);
            var truc = restClient.Get<Visites>(req);
            return truc.Data;
        }

        public void CreateVisite(Visite visite, Utilisateur uCo)
        {
            RestRequest req = new RestRequest("api/visites/{token}", Method.POST);
            req.RequestFormat = DataFormat.Json;
            req.AddUrlSegment("token", uCo.token);
            req.AddJsonBody(JsonConvert.SerializeObject(visite));
            restClient.Execute(req);
        }

        public void UpdateVisite(Visite visite, Utilisateur uCo)
        {
            RestRequest req = new RestRequest("api/visites/{token}", Method.PUT);
            req.RequestFormat = DataFormat.Json;
            req.AddUrlSegment("token", uCo.token);
            req.AddJsonBody(JsonConvert.SerializeObject(visite));
            restClient.Execute(req);
        }

        public void DeleteVisite(int id, Utilisateur uCo)
        {
            RestRequest req = new RestRequest("api/visites/{token}/{id}", Method.DELETE);
            req.AddUrlSegment("id", id);
            req.AddUrlSegment("token", uCo.token);
            restClient.Execute(req);
        }
    }
}
