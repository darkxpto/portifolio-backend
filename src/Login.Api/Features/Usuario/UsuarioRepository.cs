using System.Data;

namespace Login.Api.Features.Usuario
{
    public class UsuarioRepository
    {
        private readonly IDbConnection _con;

        public UsuarioRepository(IDbConnection con)
        {
            _con = con;
        }

    }
}
