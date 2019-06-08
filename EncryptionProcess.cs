using System.Security.Cryptography;
using System.Text;

namespace Oyku
{
    public class EncryptionProcess
    {  /// <summary>
       /// MD5 Şifreleme yapar
       /// </summary>
       /// <param name="value">String Değer</param>
       /// <returns></returns>
        public static string ConvertMD5(string value)
        {

            MD5 md5Hasher = MD5.Create();
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(value));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
             
            return sBuilder.ToString();

        }
    }
}
