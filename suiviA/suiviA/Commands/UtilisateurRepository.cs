using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace suiviA.Commands
{
    public class UtilisateurRepository
    {
        private IRestClient restClient;

        // Test
        public UtilisateurRepository(IRestClient client)
        {
            this.restClient = client;
        }

        public UtilisateurRepository()
        {
            restClient = ClientRestSharp.GetClient();
        }

        // Méthode GET
        public Utilisateurs GetMedecinAll()
        {
            return restClient.Get<Utilisateurs>(new RestRequest("/api/medecins/")).Data;
        }

        public Utilisateur GetMedecinById(int id)
        {
            RestRequest req = new RestRequest("/api/medecins/{id}", Method.GET);
            req.AddUrlSegment("id", id);
            var truc = restClient.Get<UtilisateurData>(req);
            return truc.Data.Utilisateur;
        }

        public Utilisateurs GetVisiteurAll()
        {
            return restClient.Get<Utilisateurs>(new RestRequest("/api/visiteurs/")).Data;
        }

        public Utilisateur GetVisiteurById(int id)
        {
            RestRequest req = new RestRequest("/api/visiteurs/{id}", Method.GET);
            req.AddUrlSegment("id", id);
            var truc = restClient.Get<UtilisateurData>(req);
            return truc.Data.Utilisateur;
        }

        // Méthode POST
        public void CreateMedecin(Utilisateur medecin)
        {
            RestRequest req = new RestRequest("/api/medecins/", Method.POST);
            req.AddJsonBody(JsonConvert.SerializeObject(medecin));
            req.RequestFormat = DataFormat.Json;
            restClient.Execute(req);
        }

        // Méthode PUT
        public void UpdateMedecin(Utilisateur medecin)
        {
            RestRequest req = new RestRequest("api/medecins/", Method.PUT);
            req.RequestFormat = DataFormat.Json;

            req.AddJsonBody(JsonConvert.SerializeObject(medecin));
            restClient.Execute(req);
        }

        // Méthode DELETE
        public void DeleteMedecin(int id)
        {
            RestRequest req = new RestRequest("api/medecins/{id}", Method.DELETE);
            req.AddUrlSegment("id", id);
            restClient.Execute(req);
        }

        
        public void CreateVisiteur(Utilisateur visiteur)
        {
            RestRequest req = new RestRequest("/api/visiteurs/", Method.POST);
            req.AddJsonBody(JsonConvert.SerializeObject(visiteur));
            req.RequestFormat = DataFormat.Json;
            restClient.Execute(req);
        }

        // Méthode PUT
        public void UpdateVisiteur(Utilisateur visiteur)
        {
            RestRequest req = new RestRequest("api/visiteurs/", Method.PUT);
            req.RequestFormat = DataFormat.Json;

            req.AddJsonBody(JsonConvert.SerializeObject(visiteur));
            restClient.Execute(req);
        }

        // Méthode DELETE
        public void DeleteVisiteur(int id)
        {
            RestRequest req = new RestRequest("api/visiteurs/{id}", Method.DELETE);
            req.AddUrlSegment("id", id);
            restClient.Execute(req);
        }

    }
}
