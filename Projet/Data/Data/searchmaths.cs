using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Data
{
    public class searchmaths
    {
        static string xml = @"../../data.xml";
        static int j;
        static Random n = new Random();
        public static string[] a, b, c;
        public static string expression;
        public static string[] etapes;

        private static void DeCrypNode(XmlNode x)
        {
            if (!x.HasChildNodes)
                x.InnerText = Enc.DeChiffrer(x.InnerText);

            for (int i = 0; i < x.ChildNodes.Count; i++)
            {
                DeCrypNode(x.ChildNodes[i]);
            }
        }
        public static string ChiffreEnLettre()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(xml);
            DeCrypNode(doc.DocumentElement);
            XmlNodeList xmlnode = doc.GetElementsByTagName("chiffre");
            return xmlnode[0].ChildNodes[0].InnerText;
        }





        public static string divsymbol()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(xml);
            DeCrypNode(doc.DocumentElement);
            XmlNodeList xmlnode = doc.GetElementsByTagName("symbol");
            return xmlnode[0].ChildNodes[0].InnerText;
        }
        public static void search2valeur(string operation, int lvl, out string b1text, out string b2text)
        {
            b1text = b2text = null;
            XmlDocument doc = new XmlDocument();
            doc.Load(xml);
            DeCrypNode(doc.DocumentElement);
            XmlNodeList xmlnode = doc.GetElementsByTagName(operation);

            if (operation == "division")
            {
                for (int i = 0; i < xmlnode.Count; i++)
                {
                    if (int.Parse(xmlnode[i].ChildNodes[0].InnerText) == lvl)
                    {
                        b = xmlnode[i].ChildNodes[2].InnerText.Split(',');
                        j = n.Next(b.Length);
                        a = xmlnode[i].ChildNodes[1].InnerText.Split('.')[j].Split(',');
                    }
                }
                b2text = b[j];
                j = n.Next(a.Length);
                b1text = a[j];
            }
            else
            {
                for (int i = 0; i < xmlnode.Count; i++)
                {
                    if (int.Parse(xmlnode[i].ChildNodes[0].InnerText) == lvl)
                    {
                        a = xmlnode[i].ChildNodes[1].InnerText.Split(',');
                        b = xmlnode[i].ChildNodes[2].InnerText.Split(',');

                    }
                }
               j = n.Next(a.Length);
                b1text = a[j];
                j = n.Next(b.Length);
                b2text = b[j];
            }

        }
        public static void search3valeur(string operation, int lvl, out string b1text, out string b2text, out string b3text)
        {
            b1text = b2text = b3text = null;
            XmlDocument doc = new XmlDocument();
            doc.Load(xml);
            DeCrypNode(doc.DocumentElement);
            XmlNodeList xmlnode = doc.GetElementsByTagName(operation);
            for (int i = 0; i < xmlnode.Count; i++)
            {
                if (int.Parse(xmlnode[i].ChildNodes[0].InnerText) == lvl)
                {
                    a = xmlnode[i].ChildNodes[1].InnerText.Split(',');
                    b = xmlnode[i].ChildNodes[2].InnerText.Split(',');
                    c = xmlnode[i].ChildNodes[3].InnerText.Split(',');

                }
            }
            j = n.Next(a.Length);
            b1text = a[j];
            j = n.Next(b.Length);
            b2text = b[j];
            j = n.Next(c.Length);
            b3text = c[j];
        }
        public static void priorite(int lvl, out string expression, out string[] etapes, out string rep)
        {
            expression = rep = null;
            etapes = null;
            XmlDocument doc = new XmlDocument();
            doc.Load(xml);
            DeCrypNode(doc.DocumentElement);
            XmlNodeList xmlnode = doc.GetElementsByTagName("Priorite");
            for (int i = 0; i < xmlnode.Count; i++)
            {
                if (int.Parse(xmlnode[i].ChildNodes[0].InnerText) == lvl)
                {
                    expression = xmlnode[i].ChildNodes[1].InnerText;
                    j = n.Next(expression.Split(',').Length);
                    expression = xmlnode[i].ChildNodes[1].InnerText.Split(',')[j];
                    etapes = xmlnode[i].ChildNodes[2].InnerText.Split('.')[j].Split(',');
                    rep = xmlnode[i].ChildNodes[3].InnerText.Split(',')[j];
                }
            }
        }
        public static void searchPays(out string pays)
        {
            int j;
            pays = null;
            XmlDocument doc = new XmlDocument();
            doc.Load(xml);
            DeCrypNode(doc.DocumentElement);
            XmlNodeList xmlnode = doc.GetElementsByTagName("pays");

            j = n.Next(xmlnode[0].InnerText.Split(',').Length);
            pays = xmlnode[0].InnerText.Split(',')[j];

        }
        public class SearchProp
        {
            static string xml = @"../../data.xml";//change xml
            public static string rep, question, niveau;
            static Random n = new Random();
            public static void DonnerValeur(string niveau, out string rep, out string question)
            {
                rep = question = null;
                int j, k;
                XmlDocument doc = new XmlDocument();
                doc.Load(xml);
                DeCrypNode(doc.DocumentElement);
                XmlNodeList xmlnode = doc.GetElementsByTagName("Proprietedeforme");
                for (int i = 0; i < xmlnode.Count; i++)
                {
                    if (xmlnode[i].ChildNodes[0].InnerText == niveau)
                    {
                        j = n.Next(xmlnode[i].ChildNodes[1].InnerText.Split(',').Length);
                        rep = xmlnode[i].ChildNodes[1].InnerText.Split(',')[j];
                        k = n.Next(xmlnode[i].ChildNodes[2].InnerText.Split('.')[j].Split(',').Length);
                        question = xmlnode[i].ChildNodes[2].InnerText.Split('.')[j].Split(',')[k];
                    }
                }
            }
        }
        public static void search4valeur(out string rep, out string b1text, out string b2text, out string b3text, out string b4text)
        {
            b1text = b2text = b3text = b4text = null;
            XmlDocument doc = new XmlDocument();
            doc.Load(xml);
            DeCrypNode(doc.DocumentElement);
            XmlNodeList xmlnode = doc.GetElementsByTagName("Compteestbon");
            string a;
            string[] b = new string[4];
            int j = n.Next(xmlnode[0].ChildNodes[0].InnerText.Split(',').Length);
            b = xmlnode[0].ChildNodes[0].InnerText.Split(',')[j].Split('.');
            a = xmlnode[0].ChildNodes[1].InnerText.Split(',')[j];
            b1text = b[0];
            b2text = b[1];
            b3text = b[2];
            b4text = b[3];
            rep = a;
        }
    }
}
