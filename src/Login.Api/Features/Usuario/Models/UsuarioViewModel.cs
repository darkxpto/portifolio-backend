namespace Login.Api.Features.Usuario.Models
{
    public class UsuarioViewModel
    {
        public string CdUsuario { get; set; }
        public string NmUsuario { get; set; }
        public string DsEmail { get; set; }

        public UsuarioViewModel(string cdUsuario, string nmUsuario, string dsEmail)
        {
            CdUsuario = cdUsuario;
            NmUsuario = nmUsuario;
            DsEmail = dsEmail;
        }
    }
}
