using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;
using System.Configuration;
using System.Security.Cryptography;

namespace WindowsFormsApplication1
{
    public static class User
    {
        private static int id;
        private static String surname;
        private static String lastname;
        private static String mail;
        private static String password;

        public static int GetId() { return id; }
        public static String GetSurname() { return surname; }
        public static String GetLastname() { return lastname; }
        public static String GetMail() { return mail; }
        public static String GetPassword() { return password; }

        public static void SetId(int Id) { id = Id; }
        public static void SetSurname(String Surname) { surname = Surname; }
        public static void SetLastname(String Lastname) { lastname = Lastname; }
        public static void SetMail(String Mail) { mail = Mail; }
        public static void SetPassword(String Password) { password = Password; }

        public static void GetUser(int Id)
        {
            MySqlConnection connexion = new MySqlConnection(ConfigurationManager.ConnectionStrings["gsb"].ConnectionString);
            connexion.Open();
            String query = "Select * From gsb_utilisateur Where id_utilisateur = " + Id.ToString();
            MySqlCommand sqlCommand = new MySqlCommand(query, connexion);
            IDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                SetId(Id);
                SetSurname(reader.GetString(1));
                SetLastname(reader.GetString(2));
                SetMail(reader.GetString(3));
                SetPassword(reader.GetString(4));
            }
            reader.Close();
        }

        public static void ResetUser()
        {
            SetId(0);
            SetSurname(null);
            SetLastname(null);
            SetMail(null);
            SetPassword(null);
        }

        public static Boolean UpdatePw(int Id, String Pw)
        {
            MySqlConnection connexion = new MySqlConnection(ConfigurationManager.ConnectionStrings["gsb"].ConnectionString);
            connexion.Open();
            String query = "Update gsb_utilisateur Set mdp_utilisateur = '" + Cryptage.ConvertSHA1(Pw) + "' Where id_utilisateur = " + Id.ToString();
            MySqlCommand sqlCommand = new MySqlCommand(query, connexion);
            int result = sqlCommand.ExecuteNonQuery(); 
            if (result == 1) return (true);
            else return (false);
        }

        public static Boolean CheckMail(String Mail)
        {
            MySqlConnection connexion = new MySqlConnection(ConfigurationManager.ConnectionStrings["gsb"].ConnectionString);
            connexion.Open();
            String query = "Select id_utilisateur From gsb_utilisateur Where mail_utilisateur = '" + Mail + "'";
            MySqlCommand sqlCommand = new MySqlCommand(query, connexion);
            IDataReader reader = sqlCommand.ExecuteReader();
            if(reader.Read())
            {
                SetId(reader.GetInt16(0));
                return (true);
            }
            return (false);
        }

        public static Boolean CheckUser(String Mail, String Pw)
        {
            MySqlConnection connexion = new MySqlConnection(ConfigurationManager.ConnectionStrings["gsb"].ConnectionString);
            connexion.Open();
            String query = "Select * From gsb_utilisateur Where mdp_utilisateur ='" + Cryptage.ConvertSHA1(Pw) + "' And mail_utilisateur = '" + Mail + "'";
            MySqlCommand sqlCommand = new MySqlCommand(query, connexion);
            IDataReader reader = sqlCommand.ExecuteReader();
            if (reader.Read())
            {
                SetId(reader.GetInt16(0));
                SetSurname(reader.GetString(1));
                SetLastname(reader.GetString(2));
                SetMail(reader.GetString(3));
                SetPassword(reader.GetString(4));
                return (true);
            }
            return (false);
        }
    }
}
