﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using suiviA.Commands;

namespace suiviA
{
    /// <summary>
    /// Logique d'interaction pour LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            string user = usernameTextBox.Text;
            string pass = passwordTextBox.Password;

            UtilisateurRepository repoUtilisateur = new UtilisateurRepository();

            Utilisateur utilisateur = repoUtilisateur.Connexion(user, pass);

            utilisateur.token = repoUtilisateur.Connexion(user, pass).token;
            
            
            if (utilisateur != null)
            {
                MainWindow mainWindow = new MainWindow(utilisateur);

                mainWindow.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Adrien est pd car Utilisateur est NULL");
                
            }
        }
    }
}
