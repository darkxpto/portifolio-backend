using Login.Api.Features.Usuario.Models;

namespace Login.Api.Features.Usuario
{
    public static class UsuarioQueries
    {
        public static string InserirUsuario(UsuarioModel usuario)
        {
            return @"
                    INSERT INTO usuarios 
                    (cd_usuario, nm_usuario, ds_email, ds_senha, salt, dt_cadastro, dt_atualizacao)
                    VALUES (@CdUsuario, @NmUsuario, @DsEmail, @DsSenha, @Salt, @DtCadastro, @DtAtualizacao)";
        }

        public static string ObterPraInsercao(string cdUsuario)
        {
            return @"
                SELECT cd_usuario cdUsuario, nm_usuario nmUsuario,
                       ds_email dsEmail,     ds_senha dsSenha
                FROM usuarios 
                WHERE cd_usuario = @CdUsuario";
        }
    }
}
