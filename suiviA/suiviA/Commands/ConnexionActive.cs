using System;
using System.Collections.Generic;
using System.Text;
using RestSharp;
using RestSharp.Deserializers;


namespace suiviA.Commands
{
    public class ConnexionActive
    {
        public static IRestClient restClient = ClientRestSharp.GetClient();

        [DeserializeAs(Name = "id")]
        public static int id { get; set; }

        public static void Connexion()
        {
            RestRequest req = new RestRequest("/api/medecins/{id}", Method.GET);
            req.AddUrlSegment("id", id);
            var truc = restClient.Get<UtilisateurData>(req);
        }


    }
}
