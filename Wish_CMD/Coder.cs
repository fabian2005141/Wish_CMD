using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Wish_CMD
{
    public class Coder
    {
        static void Verschlüsseln(string input)
        {
            byte[] tmpSource;
            byte[] tmpHash;
            string sSourceData = input;
            //Create a byte array from source data.
            tmpSource = ASCIIEncoding.ASCII.GetBytes(sSourceData);
            tmpHash = new MD5CryptoServiceProvider().ComputeHash(tmpSource);
            string ByteArrayToString(byte[] arrInput)
            {
                int i;
                StringBuilder sOutput = new StringBuilder(arrInput.Length);
                for (i=0;i < arrInput.Length; i++)
                {
                    sOutput.Append(arrInput[i].ToString("X2"));
                }
        
                return sOutput.ToString();
            }
      
        }
    }
}