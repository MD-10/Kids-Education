using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using static Data.Search;
using static Data.Hashing;
using Data;


namespace BusinessLayer
{
   public class Maths
    {
        static int j;//remove
        static Random n = new Random();//remove
        public static string operation, b1text, b2text, b3text, rep, r1, r2, r3, r4;//remove xmlfile
        public static string bsuite1, bsuite2, bsuite3, bsuite4, bsuite5;//suite
        public static string bcomparaison1, bcomparaison2;
        public static string expression;
        public static string[] etapes;
        public static int lvl;

        public static void operate(string b1text, string b2text, string operation, out string rep)
        {
            rep = null;
            switch (operation)
            {
                case "addition":
                    { rep = (int.Parse(b1text) + int.Parse(b2text)).ToString(); }
                    break;
                case "soustraction":
                    { rep = (int.Parse(b1text) - int.Parse(b2text)).ToString(); }
                    break;
                case "multiplication":
                    { rep = (int.Parse(b1text) * int.Parse(b2text)).ToString(); }
                    break;
                case "division":
                    { rep = (int.Parse(b1text) / int.Parse(b2text)).ToString(); }
                    break;
            }
        }
        public static void operate(string b1text, string b2text, string b3text, string operation, out string rep)
        {
            rep = null;
            switch (operation)
            {
                case "addition":
                    { rep = (int.Parse(b1text) + int.Parse(b2text) + int.Parse(b3text)).ToString(); }
                    break;
                case "soustraction":
                    { rep = (int.Parse(b1text) - int.Parse(b2text) - int.Parse(b3text)).ToString(); }
                    break;
                case "multiplication":
                    { rep = (int.Parse(b1text) * int.Parse(b2text) * int.Parse(b3text)).ToString(); }
                    break;
                case "division":
                    { rep = (int.Parse(b1text) / int.Parse(b2text) / int.Parse(b3text)).ToString(); }
                    break;
            }
        }
        public static void DonnerChoix(string rep, out string r1, out string r2, out string r3, out string r4)
        {
            int ss = int.Parse(Maths.rep);
            r1 = r2 = r3 = r4 = null;
            j = n.Next(1, 5);
            if ((ss == 0) || (ss == 1) || (ss == -1))
            {
                do
                {
                    switch (j)
                    {
                        case 1:
                            { r1 = rep; r2 = (ss - n.Next(-4, 4)).ToString(); r3 = (ss - n.Next(-4, 4)).ToString(); r4 = (ss - n.Next(-4, 4)).ToString(); }
                            break;
                        case 2:
                            { r2 = rep; r1 = (ss - n.Next(-4, 4)).ToString(); r3 = (ss - n.Next(-4, 4)).ToString(); r4 = (ss - n.Next(-4, 4)).ToString(); }
                            break;
                        case 3:
                            { r3 = rep; r2 = (ss - n.Next(-4, 4)).ToString(); r1 = (ss - n.Next(-4, 4)).ToString(); r4 = (ss - n.Next(-4, 4)).ToString(); }
                            break;
                        case 4:
                            {
                                r4 = rep; r2 = (ss - n.Next(-4, 4)).ToString(); r3 = (ss - n.Next(-4, 4)).ToString(); r1 = (ss - n.Next(-4, 4)).ToString();
                            }
                            break;
                    }
                } while ((r1 == r2) || (r1 == r3) || (r1 == r4) || (r2 == r3) || (r2 == r4) || (r3 == r4));
            }
            else
            {
                if (ss < 0)
                {
                    do
                    {
                        switch (j)
                        {
                            case 1:
                                { r1 = rep; r2 = (ss - n.Next(ss, -ss)).ToString(); r3 = (ss - n.Next(ss, -ss)).ToString(); r4 = (ss - n.Next(ss, -ss)).ToString(); }
                                break;
                            case 2:
                                { r2 = rep; r1 = (ss - n.Next(ss, -ss)).ToString(); r3 = (ss - n.Next(ss, -ss)).ToString(); r4 = (ss - n.Next(ss, -ss)).ToString(); }
                                break;
                            case 3:
                                { r3 = rep; r2 = (ss - n.Next(ss, -ss)).ToString(); r1 = (ss - n.Next(ss, -ss)).ToString(); r4 = (ss - n.Next(ss, -ss)).ToString(); }
                                break;
                            case 4:
                                {
                                    r4 = rep; r2 = (ss - n.Next(ss, -ss)).ToString(); r3 = (ss - n.Next(ss, -ss)).ToString(); r1 = (ss - n.Next(ss, -ss)).ToString();
                                }
                                break;
                        }
                    } while ((r1 == r2) || (r1 == r3) || (r1 == r4) || (r2 == r3) || (r2 == r4) || (r3 == r4));
                }
                else {
                    do
                    {
                        switch (j)
                        {
                            case 1:
                                { r1 = rep; r2 = (ss - n.Next(-ss, ss)).ToString(); r3 = (ss - n.Next(-ss, ss)).ToString(); r4 = (ss - n.Next(-ss, ss)).ToString(); }
                                break;
                            case 2:
                                { r2 = rep; r1 = (ss - n.Next(-ss, ss)).ToString(); r3 = (ss - n.Next(-ss, ss)).ToString(); r4 = (ss - n.Next(-ss, ss)).ToString(); }
                                break;
                            case 3:
                                { r3 = rep; r2 = (ss - n.Next(-ss, ss)).ToString(); r1 = (ss - n.Next(-ss, ss)).ToString(); r4 = (ss - n.Next(-ss, ss)).ToString(); }
                                break;
                            case 4:
                                {
                                    r4 = rep; r2 = (ss - n.Next(-ss, ss)).ToString(); r3 = (ss - n.Next(-ss, ss)).ToString(); r1 = (ss - n.Next(-ss, ss)).ToString();
                                }
                                break;
                        }
                    } while ((r1 == r2) || (r1 == r3) || (r1 == r4) || (r2 == r3) || (r2 == r4) || (r3 == r4));
                }
            }
        
        }
        public static void suite(int lvl, out string bsuite1, out string bsuite2, out string bsuite3, out string bsuite4, out string bsuite5)
        {
            Random n = new Random();
            bsuite1 = bsuite2 = bsuite3 = bsuite4 = bsuite5 = null;
            int initiateur, j, k;
            switch (lvl)
            {//lvl= user.suitelvl
                case 1:
                    { initiateur = n.Next(5); j = n.Next(1, 3); bsuite1 = initiateur.ToString(); bsuite2 = (initiateur + j).ToString(); bsuite3 = (initiateur + j * 2).ToString(); bsuite4 = (initiateur + j * 3).ToString(); bsuite5 = (initiateur + j * 4).ToString(); }
                    break;
                case 2:
                    { initiateur = n.Next(10); j = n.Next(1, 9); bsuite1 = initiateur.ToString(); bsuite2 = (initiateur + j).ToString(); bsuite3 = (initiateur + j * 2).ToString(); bsuite4 = (initiateur + j * 3).ToString(); bsuite5 = (initiateur + j * 4).ToString(); }
                    break;
                case 3:
                    { initiateur = n.Next(1, 5); j = n.Next(2, 5); bsuite1 = initiateur.ToString(); bsuite2 = (initiateur * j).ToString(); bsuite3 = (initiateur * j * j).ToString(); bsuite4 = (initiateur * j * j * j).ToString(); bsuite5 = (initiateur * Math.Pow(j, 4)).ToString(); }
                    break;
                case 4:
                    {
                        k = n.Next(2);
                        if (k == 0) { initiateur = n.Next(20); j = n.Next(1, 10); bsuite1 = initiateur.ToString(); bsuite2 = (initiateur + j).ToString(); bsuite3 = (initiateur + j * 2).ToString(); bsuite4 = (initiateur + j * 3).ToString(); bsuite5 = (initiateur + j * 4).ToString(); }
                        else { initiateur = n.Next(6); j = n.Next(1, 4); bsuite1 = initiateur.ToString(); bsuite2 = (initiateur * j).ToString(); bsuite3 = (initiateur * Math.Pow(j, 2)).ToString(); bsuite4 = (initiateur + Math.Pow(j, 3)).ToString(); bsuite5 = (initiateur + Math.Pow(j, 4)).ToString(); }
                    }
                    break;
            }
        }
        public static void comparaison(int lvl, out string bcomparaison1, out string bcomparaison2)
        {
            bcomparaison1 = bcomparaison2 = null;
            switch (lvl)
            {
                case 1:
                    { do { bcomparaison1 = n.Next(1, 8).ToString(); j = int.Parse(bcomparaison1); bcomparaison2 = (j + n.Next(-j, j)).ToString(); } while (int.Parse(bcomparaison1) == int.Parse(bcomparaison2)); if (int.Parse(bcomparaison1) > int.Parse(bcomparaison2)) { Maths.rep = ">"; } else { Maths.rep = "<"; } }
                    break;
                case 2:
                    { do { bcomparaison1 = n.Next(10, 50).ToString(); j = int.Parse(bcomparaison1); bcomparaison2 = (j + n.Next(-j, j)).ToString(); } while (int.Parse(bcomparaison1) == int.Parse(bcomparaison2)); if (int.Parse(bcomparaison1) > int.Parse(bcomparaison2)) { Maths.rep = ">"; } else { Maths.rep = "<"; } }
                    break;
                case 3:
                    { do { bcomparaison1 = n.Next(-20, -10).ToString(); j = int.Parse(bcomparaison1); bcomparaison2 = (j + n.Next(-9, 9)).ToString(); } while (int.Parse(bcomparaison1) == int.Parse(bcomparaison2)); if (int.Parse(bcomparaison1) > int.Parse(bcomparaison2)) { Maths.rep = ">"; } else { Maths.rep = "<"; } }
                    break;
            }

        }
        public static void priorite()
        {
            searchmaths.priorite(Maths.lvl, out Maths.expression, out Maths.etapes, out Maths.rep);
        }


    }

}
