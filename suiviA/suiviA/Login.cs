using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace suiviA
{
    class Login
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public int Role { get; set; }

        public Login(string user, string pass, int role)
        {
            this.Username = user;
            this.Password = pass;
            this.Role = role;
        }

        private void ClearTexts(string user, string pass)
        {
            user = String.Empty;
            pass = String.Empty;
        }

        //method to check if elegible to be logged in 
        internal bool IsLoggedIn(string user, string pass)
        {
            if (Username != user)
            {
                MessageBox.Show("User name is incorrect!");
                ClearTexts(user, pass);
                return false;
            }
            //check password
            else
            {
                if (Password != pass)
                {
                    MessageBox.Show("Password is incorrect");
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
    }


}

