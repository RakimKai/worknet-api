using System.Security.Cryptography;

namespace worknet_api.Helpers
{
    public class Salts
    {
        public static string GenerateSalts()
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                byte[] saltBytes = new byte[16];
                rng.GetBytes(saltBytes);
                return Convert.ToBase64String(saltBytes);
            }

        }
    }
}
