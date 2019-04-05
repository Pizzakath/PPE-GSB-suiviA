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

        public Utilisateurs GetMedecinAll(Utilisateur uCo)
        {
            RestRequest req = new RestRequest("/api/medecins/{token}");
            req.AddUrlSegment("token", uCo.token);
            return restClient.Get<Utilisateurs>(req).Data;
        }

        public Utilisateur GetMedecinById(int id, Utilisateur uCo)
        {
            RestRequest req = new RestRequest("/api/medecins/{token}/{id}", Method.GET);
            req.AddUrlSegment("id", id);
            req.AddUrlSegment("token", uCo.token);
            var truc = restClient.Get<UtilisateurData>(req);
            return truc.Data.Utilisateur;
        }

        public Utilisateurs GetVisiteurAll(Utilisateur uCo)
        {
            RestRequest req = new RestRequest("/api/visiteurs/{token}");
            req.AddUrlSegment("token", uCo.token);
            return restClient.Get<Utilisateurs>(req).Data;
        }

        public Utilisateur GetVisiteurById(int id, Utilisateur uCo)
        {
            RestRequest req = new RestRequest("/api/visiteurs/{token}/{id}", Method.GET);
            req.AddUrlSegment("id", id);
            req.AddUrlSegment("token", uCo.token);
            var truc = restClient.Get<UtilisateurData>(req);
            return truc.Data.Utilisateur;
        }

        public Utilisateurs GetMedecinVisiteur(int idVisiteur, Utilisateur uCo)
        {
            RestRequest req = new RestRequest("api/visiteurs/{token}/medecins/{id}");
            req.AddUrlSegment("id", idVisiteur);
            req.AddUrlSegment("token", uCo.token);
            return restClient.Get<Utilisateurs>(req).Data;
        }

        public void SetMedecinVisiteur(int idVisiteur, int idMedecin, Utilisateur uCo)
        {
            RestRequest req = new RestRequest("api/visiteurs/{token}/medecins/{id}", Method.POST);
            req.RequestFormat = DataFormat.Json;
            req.AddUrlSegment("token", uCo.token);
            req.AddJsonBody(JsonConvert.SerializeObject(idMedecin));
            restClient.Execute(req);
        }

        
        public void CreateMedecin(Utilisateur medecin, Utilisateur uCo)
        {
            RestRequest req = new RestRequest("/api/medecins/{token}", Method.POST);
            req.AddJsonBody(JsonConvert.SerializeObject(medecin));
            req.AddUrlSegment("token", uCo.token);
            req.RequestFormat = DataFormat.Json;
            restClient.Execute(req);
        }

        // METHODE DE CONNEXION
        public Utilisateur Connexion(string identifiant, string mdp)
        {
            UserConnexion conn = new UserConnexion(identifiant, mdp);
            RestRequest req = new RestRequest("api/auth/", Method.POST);
            req.RequestFormat = DataFormat.Json;
            req.AddJsonBody(JsonConvert.SerializeObject(conn));
            var truc = restClient.Post<Utilisateur>(req).Data;
            return truc;
        }

        public void UpdateMedecin(Utilisateur medecin, Utilisateur uCo)
        {
            RestRequest req = new RestRequest("api/medecins/{token}", Method.PUT);
            req.RequestFormat = DataFormat.Json;
            req.AddUrlSegment("token", uCo.token);
            req.AddJsonBody(JsonConvert.SerializeObject(medecin));
            restClient.Execute(req);
        }

        public void DeleteMedecin(int id, Utilisateur uCo)
        {
            RestRequest req = new RestRequest("api/medecins/{token}/{id}", Method.DELETE);
            req.AddUrlSegment("id", id);
            req.AddUrlSegment("token", uCo.token);
            restClient.Execute(req);
        }

        
        public void CreateVisiteur(Utilisateur visiteur, Utilisateur uCo)
        {
            RestRequest req = new RestRequest("/api/visiteurs/{token}/", Method.POST);
            req.AddJsonBody(JsonConvert.SerializeObject(visiteur));
            req.AddUrlSegment("token", uCo.token);
            req.RequestFormat = DataFormat.Json;
            restClient.Execute(req);
        }

        public void UpdateVisiteur(Utilisateur visiteur, Utilisateur uCo)
        {
            RestRequest req = new RestRequest("api/visiteurs/{token}", Method.PUT);
            req.RequestFormat = DataFormat.Json;
            req.AddUrlSegment("token", uCo.token);
            req.AddJsonBody(JsonConvert.SerializeObject(visiteur));
            restClient.Execute(req);
        }

        public void DeleteVisiteur(int id, Utilisateur uCo)
        {
            RestRequest req = new RestRequest("api/visiteurs/{token}/{id}", Method.DELETE);
            req.AddUrlSegment("token", uCo.token);
            req.AddUrlSegment("id", id);
            restClient.Execute(req);
        }

    }
}
