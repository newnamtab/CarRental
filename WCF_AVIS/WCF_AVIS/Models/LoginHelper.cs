using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Runtime.Serialization;
using System.Security.Cryptography;

namespace WCF_AVIS.Models
{
    [DataContract]
    [Serializable]
    public class LoginHelper
    {
        public string CreateSalt()
        {
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZÆØÅabcdefghijklmnopqrstuvwxyzæøå";
            char[] reSalt = new char[5];
            Random rand = new Random();
            for (int i = 0; i < reSalt.Length; i++)
            {
                reSalt[i] = chars[rand.Next(chars.Length)];
            }
            return new string(reSalt);
        }
        public string Hasher(string pass, string salt)
        {
            StringBuilder sb = new StringBuilder();
            HashAlgorithm hasher = MD5.Create();
            foreach (byte b in hasher.ComputeHash(Encoding.UTF8.GetBytes(pass + salt)))
            {
                sb.Append(b.ToString("x2"));
            }
            return sb.ToString();
        }
    }
}
