namespace Login.Api.Features.Usuario.Models
{
    public class UsuarioUpdate
    {
        public string CdUsuario { get; set; }
        public string NmUsuario { get; set; }
        public string DsEmail { get; set; }
        public DateTime DtAtualizacao { get; set; }

        public UsuarioUpdate(string nmUsuario, string dsEmail, string cdUsuario)
        {
            NmUsuario = nmUsuario;
            DsEmail = dsEmail;
            DtAtualizacao = DateTime.Now;
            CdUsuario = cdUsuario.ToUpper();
            
        }
    }
}
