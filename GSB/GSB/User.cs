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
    /// <summary>
    /// Classe statique User, correspondant à une variable de session qui permet la gestion d'un utilisateur 
    /// </summary>
    public static class User
    {
        /// <summary>
        /// id, l'identifiant de l'utilisateur
        /// </summary>
        private static int id;
        /// <summary>
        /// surname, le nom de l'utilisateur
        /// </summary>
        private static String surname;
        /// <summary>
        /// lastname, le prénom de l'utilisateur
        /// </summary>
        private static String lastname;
        /// <summary>
        /// mail, l'adresse e-mail de l'utilisateur
        /// </summary>
        private static String mail;
        /// <summary>
        /// password, le mot de passe de l'utilisateur
        /// </summary>
        private static String password;

        /// <summary>
        /// Accesseur pour l'identifiant de l'utilisateur
        /// </summary>
        /// <returns>id, l'identifiant de l'utilisateur </returns>
        public static int GetId() { return id; }
        /// <summary>
        /// Accesseur pour le nom de l'utilisateur
        /// </summary>
        /// <returns>surname, le nom de l'utilisateur</returns>
        public static String GetSurname() { return surname; }
        /// <summary>
        /// Accesseur pour le prénom de l'utilisateur
        /// </summary>
        /// <returns>lastname, le prénom de l'utilisateur</returns>
        public static String GetLastname() { return lastname; }
        /// <summary>
        /// Accesseur pour l'adresse e-mail de l'utilisateur
        /// </summary>
        /// <returns>mail, l'adresse e-mail de l'utilisateur</returns>
        public static String GetMail() { return mail; }
        /// <summary>
        /// Accesseur pour le mot de passe de l'utilisateur
        /// </summary>
        /// <returns>password, le mot de passe de l'utilisateur</returns>
        public static String GetPassword() { return password; }

        /// <summary>
        /// Modificateur pour l'identifiant de l'utilisateur 
        /// </summary>
        /// <param name="Id">Id, l'identifiant de l'utilisateur</param>
        public static void SetId(int Id) { id = Id; }
        /// <summary>
        /// Modificateur pour le nom de l'utilisateur
        /// </summary>
        /// <param name="Surname">Surname, le nom de l'utilisateur</param>
        public static void SetSurname(String Surname) { surname = Surname; }
        /// <summary>
        /// Modificateur pour le prénom de l'utilisateur
        /// </summary>
        /// <param name="Lastname">Lastname, le prénom de l'utilisateur</param>
        public static void SetLastname(String Lastname) { lastname = Lastname; }
        /// <summary>
        /// Modificateur pour l'adresse e-mail de l'utilisateur
        /// </summary>
        /// <param name="Mail">Mail, l'adresse e-mail de l'utilisateur</param>
        public static void SetMail(String Mail) { mail = Mail; }
        /// <summary>
        /// Modificateur pour le mot de passe de l'utilisateur
        /// </summary>
        /// <param name="Password">Password, le mot de passe de l'utilisateur</param>
        public static void SetPassword(String Password) { password = Password; }

        /// <summary>
        /// Méthode qui permet de récupérer les informations d'un utilisateur
        /// </summary>
        /// <param name="Id">Id, l'identifiant de l'utilisateur</param>
        public static void GetUser(int Id)
        {
            try
            {
                MySqlConnection connexion = new MySqlConnection(ConfigurationManager.ConnectionStrings["gsb"].ConnectionString);
                connexion.Open();
                String query = "SELECT * FROM gsb_utilisateur WHERE id_utilisateur = " + Id.ToString();
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
                connexion.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        /// <summary>
        /// Méthode qui permet de réinitialiser tous les attributs de la classe
        /// </summary>
        public static void ResetUser()
        {
            SetId(0);
            SetSurname(null);
            SetLastname(null);
            SetMail(null);
            SetPassword(null);
        }

        /// <summary>
        /// Fonction qui permet à l'utilisateur de changer son mot de passe
        /// </summary>
        /// <param name="Mail">Mail, l'adresse e-mail de l'utilisateur</param>
        /// <param name="Pw">Pw, le nouveau mot de passe de l'utilisateur</param>
        /// <returns>true si le changement a été fait, sinon false</returns>
        public static Boolean UpdatePw(String Mail, String Pw)
        {
            try
            {
                MySqlConnection connexion = new MySqlConnection(ConfigurationManager.ConnectionStrings["gsb"].ConnectionString);
                connexion.Open();
                String query = "UPDATE gsb_utilisateur SET mdp_utilisateur = \"" + Cryptage.ConvertSHA1(Pw) + "\" WHERE mail_utilisateur = \"" + Mail +"\"";
                MySqlCommand sqlCommand = new MySqlCommand(query, connexion);
                int result = sqlCommand.ExecuteNonQuery();
                connexion.Close();
                if (result == 1) return (true);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            return (false);
        }

        /// <summary>
        /// Fonction qui vérifie si une adresse e-mail existe bien dans la base de données
        /// </summary>
        /// <param name="Mail">Mail, l'adresse e-mail de l'utilisateur</param>
        /// <returns>true si l'adresse e-mail existe, sinon false</returns>
        public static Boolean CheckMail(String Mail)
        {
            try
            {
                MySqlConnection connexion = new MySqlConnection(ConfigurationManager.ConnectionStrings["gsb"].ConnectionString);
                connexion.Open();
                String query = "SELECT id_utilisateur FROM gsb_utilisateur WHERE mail_utilisateur = '" + Mail + "'";
                MySqlCommand sqlCommand = new MySqlCommand(query, connexion);
                IDataReader reader = sqlCommand.ExecuteReader();
                if (reader.Read())
                {
                    SetId(reader.GetInt16(0));
                    return (true);
                }
                reader.Close();
                connexion.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            return (false);
        }

        /// <summary>
        /// Fonction qui vérifie qu'un utilisateur existe bien dans la base de données
        /// </summary>
        /// <param name="Mail">Mail, l'adresse e-mail de l'utilisateur</param>
        /// <param name="Pw">Pw, le mot de passe de l'utilisateur</param>
        /// <returns>true si l'utilisateur existe, false s'il n'existe pas</returns>
        public static Boolean CheckUser(String Mail, String Pw)
        {
            try
            {
                MySqlConnection connexion = new MySqlConnection(ConfigurationManager.ConnectionStrings["gsb"].ConnectionString);
                connexion.Open();
                String query = "SELECT * FROM gsb_utilisateur WHERE mdp_utilisateur ='" + Cryptage.ConvertSHA1(Pw) + "' AND mail_utilisateur = '" + Mail + "'";
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
                reader.Close();
                connexion.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            return (false);
        }
    }
}
