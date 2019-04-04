using RestSharp;
using RestSharp.Authenticators;
using RestSharp.Deserializers;
using RestSharp.Serialization;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Cache;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace suiviA.Commands
{
    public class DepartementRepository
    {
        private IRestClient restClient;

        // Test
        public DepartementRepository(IRestClient restClient)
        {
            this.restClient = restClient;
        }


        public DepartementRepository()
        {
            restClient = ClientRestSharp.GetClient();
        }

        public Departements GetAll()
        {
            return restClient.Get<Departements>(new RestRequest("/api/departement")).Data;
        }

        public Departement Get(string id)
        {
            return restClient.Get<Departement>(new RestRequest($"/api/departement/{id}")).Data;
        }
    }
}
