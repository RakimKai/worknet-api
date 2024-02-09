using System.Security.Cryptography;

namespace worknet_api.Helpers
{
    public class Hashing
    {
        public static string HashPassword(string password, string salt)
        {
            int iterations = 1000;
            byte[] saltBytes = Convert.FromBase64String(salt);

            using (var rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, saltBytes, iterations))
            {
                byte[] hashBytes = rfc2898DeriveBytes.GetBytes(256 / 8);
                return Convert.ToBase64String(hashBytes);
            }
        }
    }
}
