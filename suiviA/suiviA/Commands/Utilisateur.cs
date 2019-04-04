using System;
using System.Collections.Generic;
using System.Text;
using RestSharp;
using RestSharp.Deserializers;

namespace suiviA.Commands
{
    public class UtilisateurData
    {
        [DeserializeAs(Name = "data")]
        public Utilisateur Utilisateur { get; set; }
    }

    public class Utilisateur
    {
        [DeserializeAs(Name = "id")]
        public int id { get; set; }

        [DeserializeAs(Name = "nom")]
        public string nom { get; set; }

        [DeserializeAs(Name = "prenom")]
        public string prenom { get; set; }

        [DeserializeAs(Name = "identifiant")]
        public string identifiant { get; set; }

        [DeserializeAs(Name = "password")]
        public string password { get; set; }

        [DeserializeAs(Name = "telephone")]
        public string telephone { get; set; }

        [DeserializeAs(Name = "mail")]
        public string mail { get; set; }

        [DeserializeAs(Name = "type")]
        public int type { get; set; }

        public Utilisateur()
        {

        }

        // Sans ID
        public Utilisateur(string nom, string prenom, string identifiant, string password,
            string telephone, string mail, int type)
        {

            this.nom = nom;
            this.prenom = prenom;
            this.identifiant = identifiant;
            this.password = password;
            this.telephone = telephone;
            this.mail = mail;
            this.type = type;
        }

        public Utilisateur(int id, string nom, string prenom, string identifiant, string password,
    string telephone, string mail, int type)
        {
            this.id = id;
            this.nom = nom;
            this.prenom = prenom;
            this.identifiant = identifiant;
            this.password = password;
            this.telephone = telephone;
            this.mail = mail;
            this.type = type;
        }

        public void afficher()
        {
            Console.WriteLine("id: " + id + " nom: " + nom + " prenom: " + prenom
                + " identifiant: " + identifiant + " password: " + password + " telephone: " + telephone
                + " mail: " + mail + " type: " + type);
        }
    }


    public class Utilisateurs
    {
        [DeserializeAs(Name = "data")]
        public List<Utilisateur> ListeUtilisateurs { get; set; }
    }
}
