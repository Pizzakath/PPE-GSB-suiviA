using System;
using RestSharp;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

namespace ProjetRestSharp
{
    public class ClientRestSharp
    {
        private static RestClient client = new RestClient("https://api.salombo.eu");

        public static IRestClient GetClient()
        {
            ClientRestSharp.client.RemoteCertificateValidationCallback = ClientRestSharp.validationCertificat();
            return client;
        }

        private static RemoteCertificateValidationCallback validationCertificat()
        {
            Func<object, X509Certificate, X509Chain, SslPolicyErrors, bool> validFakeCertificate = (sender, certificate, chain, sslPolicyErrors) => true;
            return new RemoteCertificateValidationCallback(validFakeCertificate);
        }

    }    
}
