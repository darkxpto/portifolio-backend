namespace Login.Api.Features.Usuario.Models
{
    public class UsuarioCreate
    {
        public string CdUsuario { get; set; }
        public string NmUsuario { get; set; }
        public string DsEmail { get; set; }
        public string DsSenha { get; set; }
    }
}
