using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class User
    {
        int row;//form1.row
        DataSet ds = new DataSet(); 
        DataRow dr;
        public User(int ro)//log in 
        { ds.ReadXml(@"../../Users.xml");
            dr = ds.Tables["user"].Rows[ro];
            row = ro;
        }
        public User(string username, string email, DateTime date, string gender, string p)//sign up
        {
            Search.UseroutRow(username, out row);
            //DataSet ds = new DataSet();
            ds.ReadXml(@"../../Users.xml");
            dr = ds.Tables["user"].NewRow();
            dr[0] = username;
            dr[1] = email;
            dr[2] = date;
            dr[3] = gender;
            dr[4] = Hashing.HashPassword(p);
            for (int i = 5; i < 22; i++)
            {
                dr[i] = 1;
            }
            ds.Tables["user"].Rows.Add(dr);
            ds.WriteXml(@"../../Users.xml");
            //ds.ReadXml(@"../../Users.xml");
            //dr = ds.Tables[0].NewRow();
            //dr = ds.Tables[0].Rows[row];
        }
        public static void ChangeForgtnPass(int row, string newPass)
        {
            DataSet ds;
            ds = new DataSet();
            ds.ReadXml(@"../../Users.xml");
            ds.Tables["user"].Rows[row]["password"] = Hashing.HashPassword(newPass);
            ds.WriteXml(@"../../Users.xml");
        }
    
        public int addLvl
        {
            get { return int.Parse(dr["addLvl"].ToString()); }
            set
            {
                ds.Tables["user"].Rows[row]["addLvl"] = value;
                ds.WriteXml(@"../../Users.xml");
            }
        }
        
        public int sousLvl
        {
            get { return int.Parse(dr["sousLvl"].ToString()); }
            set
            {
                ds.Tables["user"].Rows[row]["sousLvl"] = value;
                ds.WriteXml(@"../../Users.xml");
            }
        }
        public int foisLvl
        {
            get { return int.Parse(dr["foisLvl"].ToString()); }
            set
            {
                ds.Tables["user"].Rows[row]["foisLvl"] = value;
                ds.WriteXml(@"../../Users.xml");
            }
        }
        public int divLvl
        {
            get { return int.Parse(dr["divLvl"].ToString()); }
            set
            {
                ds.Tables["user"].Rows[row]["divLvl"] = value;
                ds.WriteXml(@"../../Users.xml");
            }
        }
        public int doubleMoitieLvl
        {
            get { return int.Parse(dr["doubleMoitieLvl"].ToString()); }
            set
            {
                ds.Tables["user"].Rows[row]["doubleMoitieLvl"] = value;
                ds.WriteXml(@"../../Users.xml");
            }
        }
        public int comparaisonLvl
        {
            get { return int.Parse(dr["comparaisonLvl"].ToString()); }
            set
            {
                ds.Tables["user"].Rows[row]["comparaisonLvl"] = value;
                ds.WriteXml(@"../../Users.xml");
            }
        }
        public int complementLvl
        {
            get { return int.Parse(dr["complementLvl"].ToString()); }
            set
            {
                ds.Tables["user"].Rows[row]["complementLvl"] = value;
                ds.WriteXml(@"../../Users.xml");
            }
        }
        public int prioriteLvl
        {
            get { return int.Parse(dr["prioriteLvl"].ToString()); }
            set
            {
                ds.Tables["user"].Rows[row]["prioriteLvl"] = value;
                ds.WriteXml(@"../../Users.xml");
            }
        }
        public int suiteLvl
        {
            get { return int.Parse(dr["suiteLvl"].ToString()); }
            set
            {
                ds.Tables["user"].Rows[row]["suiteLvl"] = value;
                ds.WriteXml(@"../../Users.xml");
            }
        }
        public int addFractLvl
        {
            get { return int.Parse(dr["addFractLvl"].ToString()); }
            set
            {
                ds.Tables["user"].Rows[row]["addFractLvl"] = value;
                ds.WriteXml(@"../../Users.xml");
            }
        }
        public int sousFractLvl
        {
            get { return int.Parse(dr["sousFractLvl"].ToString()); }
            set
            {
                ds.Tables["user"].Rows[row]["sousFractLvl"] = value;
                ds.WriteXml(@"../../Users.xml");
            }
        }
        public int foisFractLvl
        {
            get { return int.Parse(dr["foisFractLvl"].ToString()); }
            set
            {
                ds.Tables["user"].Rows[row]["foisFractLvl"] = value;
                ds.WriteXml(@"../../Users.xml");
            }
        }
        public int divFractLvl
        {
            get { return int.Parse(dr["divFractLvl"].ToString()); }
            set
            {
                ds.Tables["user"].Rows[row]["divFractLvl"] = value;
                ds.WriteXml(@"../../Users.xml");
            }
        }
        public int heureLvl
        {
            get { return int.Parse(dr["heureLvl"].ToString()); }
            set
            {
                ds.Tables["user"].Rows[row]["heureLvl"] = value;
                ds.WriteXml(@"../../Users.xml");
            }
        }
        public int chiffreLvl
        {
            get { return int.Parse(dr["chiffreLvl"].ToString()); }
            set
            {
                ds.Tables["user"].Rows[row]["chiffreLvl"] = value;
                ds.WriteXml(@"../../Users.xml");
            }
        }
        public int ordreLvl
        {
            get { return int.Parse(dr["ordreLvl"].ToString()); }
            set
            {
                ds.Tables["user"].Rows[row]["ordreLvl"] = value;
                ds.WriteXml(@"../../Users.xml");
            }
        }
        public int Row { get => row;}
        public int multGameLvl
        {
            get { return int.Parse(dr["multGameLvl"].ToString()); }
            set
            {
                ds.Tables["user"].Rows[row]["multGameLvl"] = value;
                ds.WriteXml(@"../../Users.xml");
            }
        }
        //public int Row { get => row; }
    }
}
