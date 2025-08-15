namespace Login.Api.Features.Usuario.Models
{
    public class UsuarioCreate
    {
        public string CdUsuario { get; set; }
        public string NmUsuario { get; set; }
        public string DsEmail { get; set; }
        public string DsSenha { get; set; }

        public UsuarioCreate(string cdUsuario, string nmUsuario, string dsEmail, string dsSenha)
        {
            CdUsuario = cdUsuario;
            NmUsuario = nmUsuario;
            DsEmail = dsEmail;
            DsSenha = dsSenha;
        }
    }
}
