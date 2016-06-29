using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace PublicClass
{
    public class EnDeCode
    {
        const string KEY_64 = "2A3up9og";//注意了，是8个字符，64位 --  
        const string IV_64 = "r4tupn0k";//可以和上面的不一致 但是一定要是8位  
        public static  string Encode(string data)

        {

            byte[] byKey = Encoding.ASCII.GetBytes(KEY_64);

            byte[] byIV = Encoding.ASCII.GetBytes(IV_64);



            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();

            int i = cryptoProvider.KeySize;

            MemoryStream ms = new MemoryStream();

            CryptoStream cst = new CryptoStream(ms, cryptoProvider.CreateEncryptor(byKey, byIV), CryptoStreamMode.Write);

            StreamWriter sw = new StreamWriter(cst);

            sw.Write(data);

            sw.Flush();

            cst.FlushFinalBlock();

            sw.Flush();

            return Convert.ToBase64String(ms.GetBuffer(), 0, (int)ms.Length);



        }



        public static string Decode(string data)

        {

            byte[] byKey = System.Text.ASCIIEncoding.ASCII.GetBytes(KEY_64);

            byte[] byIV = System.Text.ASCIIEncoding.ASCII.GetBytes(IV_64);

            byte[] byEnc;

            try

            {

                byEnc = Convert.FromBase64String(data);

            }

            catch

            {

                return null;

            }

            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();

            MemoryStream ms = new MemoryStream(byEnc);

            CryptoStream cst = new CryptoStream(ms, cryptoProvider.CreateDecryptor(byKey, byIV), CryptoStreamMode.Read);

            StreamReader sr = new StreamReader(cst);

            return sr.ReadToEnd();

        }
    }
}