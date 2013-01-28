using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;
using System.Configuration;

namespace WindowsFormsApplication1
{
    /// <summary>
    /// Classe Ticket qui permet la gestion d'un ticket d'incident
    /// </summary>
    public class Ticket
    {
        /// <summary>
        /// id, l'identifiant d'un ticket d'incident
        /// </summary>
        private int id;
        /// <summary>
        /// titre, le titre donné au ticket d'incident
        /// </summary>
        private String titre;
        /// <summary>
        /// contenu, le contenu du ticket d'incident
        /// </summary>
        private String contenu;
        /// <summary>
        /// date, la date à laquelle le ticket d'incident a été créé
        /// </summary>
        private String date;
        /// <summary>
        /// id_prio, l'identifiant correspondant à la priorité du ticket d'incident
        /// </summary>
        private int id_prio;
        /// <summary>
        /// id_user, l'identifiant correspondant à l'utilisateur ayant créé le ticket d'incident
        /// </summary>
        private int id_user;
        /// <summary>
        /// id_categorie, l'identifiant correspondant à la catégorie du ticket d'incident
        /// </summary>
        private int id_categorie;

        /// <summary>
        /// Constructeur vide de la classe Ticket
        /// </summary>
        public Ticket() { }

        /// <summary>
        /// Constructeur de la classe Ticket
        /// </summary>
        /// <param name="id">id, l'identifiant d'un ticket d'incident</param>
        /// <param name="titre">titre, le titre donné au ticket d'incident</param>
        /// <param name="contenu">contenu, le contenu du ticket d'incident</param>
        /// <param name="date">date, la date à laquelle le ticket d'incident a été créé</param>
        /// <param name="id_prio">id_prio, l'identifiant correspondant à la priorité du ticket d'incident</param>
        /// <param name="id_user">id_user, l'identifiant correspondant à l'utilisateur ayant créé le ticket d'incident</param>
        /// <param name="id_categorie">id_categorie, l'identifiant correspondant à la catégorie du ticket d'incident</param>
        public Ticket(int id, String titre, String contenu, String date, int id_prio, int id_user, int id_categorie)
        {
            this.id = id;
            this.titre = titre;
            this.contenu = contenu;
            this.date = date;
            this.id_prio = id_prio;
            this.id_user = id_user;
            this.id_categorie = id_categorie;
        }

        /// <summary>
        /// Accesseur pour l'identifiant du ticket d'incident
        /// </summary>
        /// <returns>id, l'identifiant du ticket d'incident</returns>
        public int GetId() { return this.id; }
        /// <summary>
        /// Accesseur pour le titre donné au ticket d'incident
        /// </summary>
        /// <returns>titre, le titre donné au ticket d'incident</returns>
        public String GetTitre() { return this.titre; }
        /// <summary>
        /// Accesseur pour le contenu du ticket d'incident
        /// </summary>
        /// <returns>contenu, le contenu du ticket d'incident</returns>
        public String GetContenu() { return this.contenu; }
        /// <summary>
        /// Accesseur pour la date à laquelle le ticket d'incident a été créé
        /// </summary>
        /// <returns>date, la date à laquelle le ticket d'incident a été créé</returns>
        public String GetDate() { return this.date; }
        /// <summary>
        /// Accesseur pour l'identifiant correspondant à la priorité du ticket d'incident
        /// </summary>
        /// <returns>id_prio, l'identifiant correspondant à la priorité du ticket d'incident</returns>
        public int GetIdPrio() { return this.id_prio; }
        /// <summary>
        /// Accesseur pour l'identifiant correspondant à la catégorie du ticket d'incident
        /// </summary>
        /// <returns>id_categorie, l'identifiant correspondant à la catégorie du ticket d'incident</returns>
        public int GetIdCategorie() { return this.id_categorie; }
        /// <summary>
        /// Accesseur pour l'identifiant correspondant à l'utilisateur ayant créé le ticket d'incident
        /// </summary>
        /// <returns>id_user, l'identifiant correspondant à l'utilisateur ayant créé le ticket d'incident</returns>
        public int GetIdUser() { return this.id_user; }

        /// <summary>
        /// Modificateur de l'identifiant du ticket d'incident
        /// </summary>
        /// <param name="id">id, l'identifiant du ticket d'incident</param>
        public void SetId(int id) { this.id = id; }
        /// <summary>
        /// Modificateur du titre du ticket d'incident
        /// </summary>
        /// <param name="titre">titre, le titre du ticket d'incident</param>
        public void SetTitre(String titre) { this.titre = titre; }
        /// <summary>
        /// Modificateur pour le contenu du ticket d'incident
        /// </summary>
        /// <param name="contenu">contenu, le contenu du ticket d'incident</param>
        public void SetContenu(String contenu) { this.contenu = contenu; }
        /// <summary>
        /// Modificateur pour la date de création du ticket d'incident
        /// </summary>
        /// <param name="date">date, la date de création du ticket d'incident</param>
        public void SetDate(String date) { this.date = date; }
        /// <summary>
        /// Modificateur pour l'identifiant de la priorité du ticket d'incident
        /// </summary>
        /// <param name="id_prio">id_prio, l'identifiant de la priorité du ticket d'incident</param>
        public void SetIdPrio(int id_prio) { this.id_prio = id_prio; }
        /// <summary>
        /// Modificateur pour l'identifiant du créateur du ticket d'incident
        /// </summary>
        /// <param name="id_user">id_user, l'identifiant de l'utilisateur à l'origine de la création du ticket d'incident</param>
        public void SetIdUser(int id_user) { this.id_user = id_user; }
        /// <summary>
        /// Modificateur pour l'identifiant de la catégorie du ticket d'incident
        /// </summary>
        /// <param name="id_categorie">id_categorie, l'identifiant de la catégorie du ticket d'incident</param>
        public void SetIdCategorie(int id_categorie) { this.id_categorie = id_categorie; }

        /// <summary>
        /// Fonction qui retourne la priorité d'un ticket sous forme de chaîne de caractères
        /// </summary>
        /// <returns>priorite, le nom de la priorité sous forme de chaîne de caractères</returns>
        public String GetPriorite()
        {
            String priorite = "";
            try
            {
                MySqlConnection connexion = new MySqlConnection(ConfigurationManager.ConnectionStrings["gsb"].ConnectionString);
                connexion.Open();
                String query = "Select nom_priorite From gsb_priorite where id_priorite= "+this.id_prio;
                MySqlCommand sqlCommand = new MySqlCommand(query, connexion);
                IDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                        priorite = reader.GetString(0);
                }
                reader.Close();
                connexion.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            return priorite;
        }

        /// <summary>
        /// Fonction qui retourne la catégorie d'un ticket sous forme de chaîne de caractères
        /// </summary>
        /// <returns>categorie, le nom de la catégorie sous forme de chaîne de caractères</returns>
        public String GetCategorie() 
        {
            String categorie = "";
            try
            {
                MySqlConnection connexion = new MySqlConnection(ConfigurationManager.ConnectionStrings["gsb"].ConnectionString);
                connexion.Open();
                String query = "Select nom_categorie From gsb_categorie where id_categorie= " + this.id_categorie;
                MySqlCommand sqlCommand = new MySqlCommand(query, connexion);
                IDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    categorie = reader.GetString(0);
                }
                reader.Close();
                connexion.Close();
            }             
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            return categorie;
        }

        public String GetStatut()
        {
            String statut = "";
            try
            {
                MySqlConnection connexion = new MySqlConnection(ConfigurationManager.ConnectionStrings["gsb"].ConnectionString);
                connexion.Open();
                String query = "Select nom_etat From gsb_etat Natural Join gsb_avoir where id_ticket= " + this.id + " Order by date_etat Desc Limit 1";
                MySqlCommand sqlCommand = new MySqlCommand(query, connexion);
                IDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    statut = reader.GetString(0);
                }
                reader.Close();
                connexion.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            return statut;
        }

        /// <summary>
        /// Fonction qui effectue l'insertion d'un ticket dans la base de données
        /// </summary>
        /// <returns>true si l'insertion s'est faite correctement, false si l'insertion ne s'est pas faite</returns>
        public Boolean InsertTicket()
        {
            int result = 0;
            try
            {
                MySqlConnection connexion = new MySqlConnection(ConfigurationManager.ConnectionStrings["gsb"].ConnectionString);
                connexion.Open();
                String query = "INSERT INTO gsb_ticket VALUES(default,\"" + this.GetTitre() + "\",\"" + this.GetContenu() + "\",\"" + this.GetDate() + "\"," + this.GetIdCategorie().ToString() + "," + this.GetIdPrio().ToString() + "," + this.GetIdUser().ToString() + ")";
                MySqlCommand sqlCommand = new MySqlCommand(query, connexion);
                result += sqlCommand.ExecuteNonQuery();
                String query2 = "INSERT INTO gsb_avoir VALUES(" + sqlCommand.LastInsertedId + ",1,\"" + this.GetDate() +"\")";
                MySqlCommand sqlCommand2 = new MySqlCommand(query2, connexion);
                result += sqlCommand2.ExecuteNonQuery();
                connexion.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            if (result != 0) return (true);
            return (false);
        }

        /// <summary>
        /// Méthode qui récupère un ticket en fonction de l'identifiant
        /// </summary>
        /// <param name="Id">Id, l'identifiant du ticket</param>
        public void GetTicket(int Id)
        {
            try
            {
                MySqlConnection connexion = new MySqlConnection(ConfigurationManager.ConnectionStrings["gsb"].ConnectionString);
                connexion.Open();
                String query = "SELECT * FROM gsb_ticket WHERE id_ticket = " + Id.ToString();
                MySqlCommand sqlCommand = new MySqlCommand(query, connexion);
                IDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    this.SetId(Id);
                    this.SetTitre(reader.GetString(1));
                    this.SetContenu(reader.GetString(2));
                    this.SetDate(reader.GetString(3));
                    this.SetIdPrio(reader.GetInt16(4));
                    this.SetIdUser(reader.GetInt16(5));
                    this.SetIdCategorie(reader.GetInt16(6));
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
        /// Fonction qui retourne l'historique des tickets en fonction de l'identifiant envoyé en paramètre
        /// </summary>
        /// <param name="Id">Id, l'identifiant de l'utilisateur</param>
        /// <returns>lesTickets, la liste des tickets correspondant à l'utilisateur</returns>
        public static List<Ticket> GetAllTicket(int Id)
        {
            List<Ticket> lesTickets = new List<Ticket>();
            try
            {
                MySqlConnection connexion = new MySqlConnection(ConfigurationManager.ConnectionStrings["gsb"].ConnectionString);
                connexion.Open();
                String query = "Select * From gsb_ticket Where id_utilisateur = " + Id.ToString() + " Order by date_creation_ticket Desc";
                MySqlCommand sqlCommand = new MySqlCommand(query, connexion);
                IDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    lesTickets.Add(new Ticket(reader.GetInt16(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetInt16(4), reader.GetInt16(5), reader.GetInt16(6)));
                }
                reader.Close();
                connexion.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            return lesTickets;
        }
    }
}