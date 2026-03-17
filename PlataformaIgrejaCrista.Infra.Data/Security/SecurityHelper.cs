using System.Security.Cryptography;
using System.Text;

namespace PlataformaRedencao.Infra.Identity.Security
{
    public static class SecurityHelper
    {
        public static string GenerateSecureToken(int size = 64)
        {
            var bytes = RandomNumberGenerator.GetBytes(size);
            return Convert.ToBase64String(bytes);
        }

        public static string ComputeSha256(string input)
        {
            var bytes = SHA256.HashData(Encoding.UTF8.GetBytes(input));
            return Convert.ToBase64String(bytes);
        }
    }
}
