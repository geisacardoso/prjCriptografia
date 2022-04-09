using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
namespace prjCriptografia
{
    class Criptografia
    {
        const string chave = "123";
        public static string Codificar(string texto)
        {
            byte[] Results;
            UTF8Encoding UTF8 = new UTF8Encoding();
            MD5CryptoServiceProvider hashProvider =
                new MD5CryptoServiceProvider();
            byte[] TDESKey = hashProvider.ComputeHash(UTF8.GetBytes(chave));
            TripleDESCryptoServiceProvider TDESalgoritmo = new
            TripleDESCryptoServiceProvider();
            TDESalgoritmo.Key = TDESKey;
            TDESalgoritmo.Mode = CipherMode.ECB;
            TDESalgoritmo.Padding = PaddingMode.PKCS7;
            byte[] dadosaEncriptar = UTF8.GetBytes(texto);
            try
            {
                ICryptoTransform encriptador =
                    TDESalgoritmo.CreateEncryptor();
                Results = encriptador.TransformFinalBlock(dadosaEncriptar,
                    0, dadosaEncriptar.Length);
            }
            finally
            {
                TDESalgoritmo.Clear();
                hashProvider.Clear();
            }
            return Convert.ToBase64String(Results);
        }
        public static string Decodificar(string texto)
        {
            byte[] Results;
            UTF8Encoding UTF8 = new UTF8Encoding();
            MD5CryptoServiceProvider hashProvider =
                new MD5CryptoServiceProvider();
            byte[] TDESKey = hashProvider.ComputeHash(UTF8.GetBytes(chave));
            TripleDESCryptoServiceProvider TDESalgoritmo = new
         TripleDESCryptoServiceProvider();
            TDESalgoritmo.Key = TDESKey;
            TDESalgoritmo.Mode = CipherMode.ECB;
            TDESalgoritmo.Padding = PaddingMode.PKCS7;
            byte[] dadosaDecriptar = Convert.FromBase64String(texto);
            try
            {
                ICryptoTransform Decriptador =
                    TDESalgoritmo.CreateDecryptor();
                Results = Decriptador.TransformFinalBlock(dadosaDecriptar,
                    0, dadosaDecriptar.Length);
            }
            finally
            {
                TDESalgoritmo.Clear();
                hashProvider.Clear();
            }
            return UTF8.GetString(Results);
        }
    }
}