using System.Security.Cryptography;
using System.Text;

namespace CentralAdminApp.Domain.Helpers
{
    public class AesGcmHelper
    {
        private static string key = "9C3CDD48160D4B51B225347596B97FC0";

        public static string Decrypt(string encryptedBase64, string ivBase64)
        {
            byte[] encryptedBytes = Convert.FromBase64String(encryptedBase64);
            byte[] ivBytes = Convert.FromBase64String(ivBase64);
            byte[] keyBytes = Encoding.UTF8.GetBytes(key);
            byte[] decryptedBytes = new byte[encryptedBytes.Length];

            using (AesGcm aesGcm = new AesGcm(keyBytes))
            {
                aesGcm.Decrypt(ivBytes, encryptedBytes, null, decryptedBytes);
            }

            return Encoding.UTF8.GetString(decryptedBytes);
        }
    }
}