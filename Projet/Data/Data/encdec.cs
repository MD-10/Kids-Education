using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace Data
{
    class Enc
    {
        private static DESCryptoServiceProvider GenerateKey()
        {
            DESCryptoServiceProvider desCrypto = new DESCryptoServiceProvider();
            byte[] k = { 0, 1, 2, 3, 4, 5, 6, 7 };
            desCrypto.Key = k;
            byte[] iv = { 1, 1, 1, 1, 1, 1, 1, 1 };
            desCrypto.IV = iv;
            return desCrypto;
        }
        public static string Chiffrer(string MotClair)
        {
            if (String.IsNullOrEmpty(MotClair))
                return "??????????";
            DESCryptoServiceProvider cryptoProvider = GenerateKey();
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream,
                cryptoProvider.CreateEncryptor(cryptoProvider.Key, cryptoProvider.IV), CryptoStreamMode.Write);
            StreamWriter writer = new StreamWriter(cryptoStream);
            writer.Write(MotClair);
            writer.Flush();
            cryptoStream.FlushFinalBlock();
            writer.Flush();
            return Convert.ToBase64String(memoryStream.GetBuffer(), 0, (int)memoryStream.Length);
        }
        public static string DeChiffrer(string MotChiffre)
        {
            try
            {
                if (String.IsNullOrEmpty(MotChiffre))
                    return "??????????";
                DESCryptoServiceProvider cryptoProvider = GenerateKey();
                MemoryStream memoryStream = new MemoryStream(Convert.FromBase64String(MotChiffre));
                CryptoStream cryptoStream = new CryptoStream(memoryStream,
                    cryptoProvider.CreateDecryptor(cryptoProvider.Key, cryptoProvider.IV), CryptoStreamMode.Read);
                StreamReader reader = new StreamReader(cryptoStream);
                return reader.ReadToEnd();
            }
            catch
            {
                return "??????????";
            }
        }
    }
}
