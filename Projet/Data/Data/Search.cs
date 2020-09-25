using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml;


namespace Data
{
    public class Search
    {
        public static bool username(string s, out string hash)
        {
            int i = 0;
            DataSet ds;
            ds = new DataSet();
            ds.ReadXml(@"../../Users.xml");
            while (i < ds.Tables["user"].Rows.Count)
            {
                if (ds.Tables["user"].Rows[i]["username"].ToString() == s) { hash = ds.Tables["user"].Rows[i]["password"].ToString(); return true; }
                else i++;
            }
            hash = ""; return false;
        }
        public static bool username(string s)
        {
            string h;
            return username(s, out h);
        }
        public static bool outEmail(string username, out string email)
        {
            int i = 0;
            DataSet ds;
            ds = new DataSet();
            ds.ReadXml(@"../../Users.xml");
            while (i < ds.Tables["user"].Rows.Count)
            {
                if (ds.Tables["user"].Rows[i]["username"].ToString() == username) { email = ds.Tables["user"].Rows[i]["email"].ToString(); return true; }
                else i++;
            }
            email = ""; return false;
        }
        public static bool UseroutRow(string username, out int row)
        {
            int i = 0;
            DataSet ds;
            ds = new DataSet();
            ds.ReadXml(@"../../Users.xml");
            while (i < ds.Tables[0].Rows.Count)
            {
                if (ds.Tables["user"].Rows[i]["username"].ToString() == username) { row = i; return true; }
                else i++;
            }
            row = -1; return false;
        }

        public static bool Email(string email)
        {
            int i = 0;
            DataSet ds;
            ds = new DataSet();
            ds.ReadXml(@"../../Users.xml");
            while (i < ds.Tables["user"].Rows.Count)
            {
                if (ds.Tables["user"].Rows[i]["email"].ToString().ToLower() == email.ToLower()) { return true; }
                else i++;
            }
            { return false; }




        }
        public static bool EmailoutRow(string email, out int row)
        {
            int i = 0;
            DataSet ds;
            ds = new DataSet();
            ds.ReadXml(@"../../Users.xml");
            while (i < ds.Tables["user"].Rows.Count)
            {
                if (ds.Tables["user"].Rows[i]["email"].ToString().ToLower() == email.ToLower()) { row = i; return true; }
                else i++;
            }
            { row = -1; return false; }
        }
        public static bool ChangePass(string username, string newPass, string oldPass)
        {
            int row;
            UseroutRow(username, out row);
            DataSet ds;
            ds = new DataSet();
            ds.ReadXml(@"../../Users.xml");
            
            if (Hashing.CheckPassword(oldPass, ds.Tables["user"].Rows[row]["password"].ToString()) == true)
            {
                ds.Tables["user"].Rows[row]["password"] = Hashing.HashPassword(newPass); return true;
            }
            else return false;
        }
        public static void ChangeForgtnPass(int row, string newPass)
        {
            DataSet ds;
            ds = new DataSet();
            ds.ReadXml(@"../../Users.xml");
            ds.Tables["user"].Rows[row]["password"] = Hashing.HashPassword(newPass);
            ds.WriteXml(@"../../Users.xml");
        }
    }
    //public class searchmaths
    
        
        //public static string[] heure()
        //{
        //    DataSet ds = new DataSet();
        //    ds.ReadXml(@"C:\Users\user\Desktop\dd - Copy (2)\Projet\Users.xml");
        //    return ds.Tables["heure"].ToString().Split(',');
        //}


    }


    

