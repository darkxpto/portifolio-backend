using System.Security.Cryptography;
using System.Text;
using FluentValidation;
using Login.Api.Features.Usuario.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Login.Api.Features.Usuario
{
    [ApiController]
    [Route("usuarios")]
    public class UsuarioController : ControllerBase
    {
        public readonly UsuarioRepository _repoUsuarioRepository;
        public readonly UsuarioService _usuarioService;


        public UsuarioController(UsuarioRepository repoUsuarioRepository, UsuarioService usuarioService)
        {
            _repoUsuarioRepository = repoUsuarioRepository;
            _usuarioService = usuarioService;
        }

        [HttpPost("inserir")]
        [AllowAnonymous]
        public async Task<ActionResult> InserirUsuarioAsync([FromBody] UsuarioCreate usuarioCreate, IValidator<UsuarioCreate> validator)
        {


            UsuarioModel usuarioModel = new(usuarioCreate.CdUsuario, usuarioCreate.NmUsuario, usuarioCreate.DsEmail, usuarioCreate.DsSenha);

            //Preparar informações dos usuários
            usuarioModel.CdUsuario = usuarioModel.CdUsuario.ToUpper();
            usuarioModel.Salt = _usuarioService.GerarSalt(32);
            usuarioModel.DsSenha = _usuarioService.GerarHashSenha(usuarioModel.DsSenha, usuarioModel.Salt);

            var erro = await _repoUsuarioRepository.InserirUsuarioAsync(usuarioModel);

            if (!string.IsNullOrWhiteSpace(erro))
            {
                return BadRequest(new { mensagemErro = erro });
            }

            return Ok();
        }



    }
}
