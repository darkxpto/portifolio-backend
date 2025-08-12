namespace Login.Api.Features.Usuario.Models
{
    public class UsuarioModel
    {
        public string CdUsuario { get; set; } 
        public string NmUsuario { get; set; }
        public string DsEmail { get; set; } 
        public string DsSenha { get; set; }
        public string Salt { get; set; }
        public DateTime DtCadastro { get; set; } 
        public DateTime DtAtualização { get; set; }

        public UsuarioModel(string cdUsuario, string nmUsuario, string dsEmail, string dsSenha, string salt, DateTime dtCadastro, DateTime dtAtualização)
        {
            CdUsuario = cdUsuario;
            NmUsuario = nmUsuario;
            DsEmail = dsEmail;
            DsSenha = dsSenha;
            Salt = salt;
            DtCadastro = dtCadastro;
            DtAtualização = dtAtualização;
        }
    }
}
