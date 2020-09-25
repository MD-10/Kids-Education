using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
namespace Data
{
    
    public class SearchFrs
    {
         static string xml = @"..\..\data.xml";
        private static void DeCrypNode(XmlNode x)
        {
            if (!x.HasChildNodes)
                x.InnerText = Enc.DeChiffrer(x.InnerText);

            for (int i = 0; i < x.ChildNodes.Count; i++)
            {
                DeCrypNode(x.ChildNodes[i]);
            }
        }
        public static string ConfusionDeSonMot(string lettre)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(xml);
            DeCrypNode(doc.DocumentElement);
            XmlNodeList xmlnode = doc.GetElementsByTagName(lettre);
            string[] mots = xmlnode[0].InnerText.Split(',');
            Random gen = new Random();
            int i = gen.Next(mots.Length);
            return mots[i];

        }
        public static string Dictee()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(xml);
            DeCrypNode(doc.DocumentElement);
            XmlNodeList xmlnode = doc.GetElementsByTagName("dictee");
            string[] mots = xmlnode[0].InnerText.Split(',');
            Random gen = new Random();
            int i = gen.Next(mots.Length);
            return mots[i];

        }
        public static string Dictee2()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(xml);
            DeCrypNode(doc.DocumentElement);
            XmlNodeList xmlnode = doc.GetElementsByTagName("dictee2");
            string[] mots = xmlnode[0].InnerText.Split(',');
            Random gen = new Random();
            int i = gen.Next(mots.Length);
            return mots[i];

        }
        public static string Conjugaison(string infinitif,int tmp,int suj)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(xml);
            DeCrypNode(doc.DocumentElement);
            XmlNodeList xmlnode = doc.GetElementsByTagName(infinitif);
            string[] verbs= xmlnode[0].ChildNodes[tmp].InnerText.Split(',');
            return verbs[suj];
        }
        public static string  VerbsChoix(string infinitif)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(xml);
            DeCrypNode(doc.DocumentElement);
            XmlNodeList xmlnode = doc.GetElementsByTagName(infinitif);
            string s="";
            int i;
            for (i = 0; i < xmlnode[0].ChildNodes.Count; i++)
            {
                s += xmlnode[0].ChildNodes[i].InnerText;
            }
            return s;
        }
        public static string[] Lecture(int level)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(xml);
            DeCrypNode(doc.DocumentElement);
            XmlNodeList xmlnode = doc.GetElementsByTagName("lecture");
            string[] cases;
            cases = xmlnode[0].ChildNodes[level-1].InnerText.Split('$');
            return cases;
        }
        public static string allWords()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(xml);
            DeCrypNode(doc.DocumentElement);
            string mots = "";
            string[] lettres = { "B", "p", "v", "f", "d", "t", "g", "C" };
            for (int i = 0; i < 8; i++)
            {
                XmlNodeList xmlnode = doc.GetElementsByTagName(lettres[i]);
                mots+=xmlnode[0].InnerText.ToString()+",";
            }
            return mots.Substring(0,mots.Length-1);
        }
    }
}
