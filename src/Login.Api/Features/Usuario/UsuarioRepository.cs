using System.Data;
using Dapper;
using Login.Api.Features.Usuario.Models;

namespace Login.Api.Features.Usuario
{
    public class UsuarioRepository
    {
        private readonly IDbConnection _con;

        public UsuarioRepository(IDbConnection con)
        {
            _con = con;
        }

        public async Task<string?> InserirUsuarioAsync(UsuarioModel usuarioModel)
        {
            string? erro = null;

            try
            {
                //Verificar a existencia do usuário
                string query = UsuarioQueries.ObterUsuarioPorId();
                var usuario = await _con.QueryFirstOrDefaultAsync<UsuarioModel>(
                    query,
                    new { CdUsuario = usuarioModel.CdUsuario }
                );

                if (usuario != null)
                    return "Usuário já existe";


                //Inserir
                query = UsuarioQueries.InserirUsuario();

                await _con.ExecuteAsync(query, usuarioModel);
                return erro;

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<string?> AlterarUsuarioAsync(UsuarioUpdate usuarioUpdate)
        {
            string? erro = null;

            try
            {
                //Verificar a existencia do usuário
                string query = UsuarioQueries.ObterUsuarioPorId();
                var usuario = await _con.QueryFirstOrDefaultAsync<UsuarioModel>(
                    query,
                    new { CdUsuario = usuarioUpdate.CdUsuario }
                );

                if (usuario == null)
                    return "Usuário NÃO existe";

                //Atualizar
                query = UsuarioQueries.AlterarUsuario();

                await _con.ExecuteAsync(query, usuarioUpdate);
                return erro;

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

    }
}
