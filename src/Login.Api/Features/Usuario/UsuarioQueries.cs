namespace Login.Api.Features.Usuario
{
    public static class UsuarioQueries
    {
        public static string InserirUsuario()
        {
            return @"
                    INSERT INTO usuarios 
                                (cd_usuario, nm_usuario, ds_email, ds_senha, salt,  dt_cadastro, dt_atualizacao)
                         VALUES (@CdUsuario, @NmUsuario, @DsEmail, @DsSenha, @Salt, @DtCadastro, @DtAtualizacao)";
        }

        public static string ObterUsuarioPorId()
        {
            return @"
                SELECT cd_usuario cdUsuario, nm_usuario nmUsuario,
                       ds_email dsEmail,     ds_senha dsSenha,
                       salt salt
                  FROM usuarios 
                 WHERE cd_usuario = @CdUsuario";
        }

        public static string AlterarUsuario()
        {
            return @"
                UPDATE usuarios
                   SET nm_usuario     = @NmUsuario,
                       ds_email       = @DsEmail,
                       dt_atualizacao = @DtAtualizacao
                 WHERE cd_usuario = @CdUsuario";
        }
    }
}
