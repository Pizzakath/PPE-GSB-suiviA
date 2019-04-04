using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetRestSharp
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

        public Cabinet GetCabinetByIdMedecin(int id)
        {
            // Id du medecin
            RestRequest req = new RestRequest("/api/cabinets{id}");
            req.AddUrlSegment("id", id);
            var truc = restClient.Get<CabinetData>(req);
            return truc.Data.Cabinet;
        }
        
    }
}
