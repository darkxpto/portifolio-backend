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
                string query = UsuarioQueries.ObterPraInsercao(usuarioModel.CdUsuario);
                var usuario = await _con.QueryFirstOrDefaultAsync<UsuarioModel>(
                    query,
                    new { CdUsuario = usuarioModel.CdUsuario }
                );

                if (usuario != null)
                    return "Usuário já existe";

                //preencher datas
                usuarioModel.DtCadastro = DateTime.Now;
                usuarioModel.DtAtualizacao = DateTime.Now;

                //Inserir
                query = UsuarioQueries.InserirUsuario(usuarioModel);

                await _con.ExecuteAsync(query, usuarioModel);
                return erro;

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

    }
}
