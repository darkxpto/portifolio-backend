namespace Login.Api.Features.Usuario.Models
{
    public class UsuarioModel
    {
        public string CdUsuario { get; set; } 
        public string NmUsuario { get; set; }
        public string DsEmail { get; set; } 
        public string DsSenha { get; set; }
        public string? Salt { get; set; } 
        public DateTime DtCadastro { get; set; } 
        public DateTime DtAtualizacao { get; set; }

    }

}
