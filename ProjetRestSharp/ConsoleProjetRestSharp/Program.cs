using System;
using RestSharp;
using Newtonsoft.Json;
using ProjetRestSharp;
using System.Collections.Generic;

namespace ConsoleProjetRestSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            UtilisateurRepository repoUtilisateur = new UtilisateurRepository();
            VisiteRepository repoVisite = new VisiteRepository();
            Utilisateur user = new Utilisateur("nouveauMdecin", "PrenomNouveauMedecin",
                "identiMede", "pwdpwdM", "10840348", "Medoc@gmail.com", 2);

            Utilisateur userUpdate = new Utilisateur(3, "Wacrenier", "Emilien", "emilienemilien",
                "lololo", "065978", "emilien@gmail", 2);

            Utilisateurs listeMedecins = repoUtilisateur.GetMedecinALl();
            Utilisateur unMedecin = repoUtilisateur.GetMedecinById(3);
            Utilisateurs listeVisiteur = repoUtilisateur.GetVisiteurAll();
            Utilisateur unVisiteur = repoUtilisateur.GetVisiteurById(4);
            //repoUtilisateur.CreateMedecin(user);
            //repoUtilisateur.UpdateMedecin(userUpdate);
            //repoUtilisateur.DeleteMedecin(11);
            Visites listeVisite = repoVisite.GetVisiteAllByIdMedecin(3);

            Console.WriteLine("Instruction DEBUG");
        }
    }
}
