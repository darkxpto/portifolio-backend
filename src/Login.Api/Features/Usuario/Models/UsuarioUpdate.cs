namespace Login.Api.Features.Usuario.Models
{
    public class UsuarioUpdate
    {
        public string NmUsuario { get; set; }
        public string DsEmail { get; set; }
        public string DsSenha { get; set; }

        public UsuarioUpdate(string nmUsuario, string dsEmail, string dsSenha)
        {
            NmUsuario = nmUsuario;
            DsEmail = dsEmail;
            DsSenha = dsSenha;
        }
    }
}
