using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace WindowsFormsApplication1
{
    /// <summary>
    /// Classe statique permettant le cryptage d'une chaîne de caractères
    /// </summary>
    public static class Cryptage
    {
        /// <summary>
        /// Fonction qui retourne une chaîne de caractères cryptée avec l'algorithme SHA1
        /// </summary>
        /// <param name="value">value, la chaîne de caractères que l'on souhaite crypter</param>
        /// <returns>la chaîne de caractères cryptée</returns>
        public static string ConvertSHA1(string value)
        {
            SHA1 sha = SHA1.Create();
            byte[] data = sha.ComputeHash(Encoding.Default.GetBytes(value));
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sb.Append(data[i].ToString("x2"));
            }
            return sb.ToString();
        }
    }
}
