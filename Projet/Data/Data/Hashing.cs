using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Data
{

    public class Hashing
    {
        static string salt = "0edd29a061ae4a9e9942ec672cba517a";
        private static string HashString(string toHash)
        {
            using (SHA512CryptoServiceProvider sha = new SHA512CryptoServiceProvider())
            {
                byte[] dataToHash = Encoding.UTF8.GetBytes(toHash);
                byte[] hashed = sha.ComputeHash(dataToHash);
                return Convert.ToBase64String(hashed);
            }
        }
        public static string HashPassword(string password)
        {
            string combined = password + salt;
            return HashString(combined);
        }
        public static bool CheckPassword(string password, string hash)
        {
            return HashPassword(password) == hash;
        }

        public static void HashAndAdd(string user, string pass)
        {

            string hash;
            DataSet ds = new DataSet();
            ds.ReadXml(@"..\..\Users.xml");
            DataRow dr = ds.Tables["user"].NewRow();
            ds.Tables["user"].Rows.Add(dr);
            hash = HashPassword(pass);
            dr["username"] = user;
            dr["password"] = hash;
            ds.WriteXml(@"..\..\Users.xml");//xml file
        }

    }
}

