using System.Data;
using System.Security.Cryptography;
using System.Text;

namespace Login.Api.Features.Usuario
{
    public class UsuarioService
    {

        public string GerarSalt(int size = 32)
        {
            byte[] saltBytes = new byte[size];

            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(saltBytes);
            }

            return Convert.ToBase64String(saltBytes);
        }

        public string GerarHashSenha(string? senha, string? salt)
        {
            using (var sha256 = SHA256.Create())
            {
                var senhaComSalt = senha + salt;

                var senhaBytes = Encoding.UTF8.GetBytes(senhaComSalt);
                var hashBytes = sha256.ComputeHash(senhaBytes);

                return Convert.ToBase64String(hashBytes);
            }

        }

    }
}
