using System;
using System.Text;


namespace Vt.Strings
{
    class VtStrings
    {
        // prevod stringu na pole byte[]
        //
        static public byte[] StringToByteArray(string s)
        {
            byte[] Result = new Byte[s.Length];
            for (int i = 0; i < s.Length; i++)
                Result[i] = (byte)s[i];
            return Result;
        }


        static public byte[] StrToByteArrayCS(string s)
        {
            Encoding Enc = Encoding.Default;    // GetEncoding(1250); 
            return Enc.GetBytes(s);
        }


        static public string BytesToStrCS(byte[] Bytes)
        {
            Encoding Enc = Encoding.Default;    // GetEncoding(1250); 
            return Enc.GetString(Bytes, 0, Bytes.Length - 1);
        }



    }
}
