namespace Login.Api.Features.Usuario.Models
{
    public class UsuarioModel
    {
        public string CdUsuario { get; set; } 
        public string NmUsuario { get; set; }
        public string DsEmail { get; set; } 
        public string DsSenha { get; set; }
        public string Salt { get; set; } = string.Empty;
        public DateTime DtCadastro { get; set; } 
        public DateTime DtAtualizacao { get; set; }

        public UsuarioModel(string cdUsuario, string nmUsuario, string dsEmail, string dsSenha)
        {
            CdUsuario = cdUsuario;
            NmUsuario = nmUsuario;
            DsEmail = dsEmail;
            DsSenha = dsSenha;
        }
    }
}
