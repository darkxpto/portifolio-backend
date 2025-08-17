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
        public async Task<ActionResult> InserirUsuarioAsync([FromBody] UsuarioCreate usuarioCreate)
        {

            UsuarioModel usuarioModel = new()
            {
                CdUsuario = usuarioCreate.CdUsuario.ToUpper(),
                NmUsuario = usuarioCreate.NmUsuario,
                DsEmail = usuarioCreate.DsEmail,
                Salt = _usuarioService.GerarSalt(32),
                DtAtualizacao = DateTime.Now,
                DtCadastro = DateTime.Now
            };

            usuarioModel.DsSenha = _usuarioService.GerarHashSenha(usuarioCreate.DsSenha, usuarioModel.Salt);

            var erro = await _repoUsuarioRepository.InserirUsuarioAsync(usuarioModel);

            if (!string.IsNullOrWhiteSpace(erro))
            {
                return BadRequest(new { mensagemErro = erro });
            }

            return Ok();
        }

        [HttpPut("alterar")]
        [AllowAnonymous]
        public async Task<ActionResult> AlterarUsuarioAsync([FromBody] UsuarioUpdate usuarioUpdate)
        {

            var erro = await _repoUsuarioRepository.AlterarUsuarioAsync(usuarioUpdate);

            if (!string.IsNullOrWhiteSpace(erro))
            {
                return BadRequest(new { mensagemErro = erro });
            }

            return Ok();
        }



    }
}
