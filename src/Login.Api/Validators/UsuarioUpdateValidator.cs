using FluentValidation;
using Login.Api.Features.Usuario.Models;
using System.Text.RegularExpressions;

namespace Login.Api.Validators
{
    public class UsuarioUpdateValidator : AbstractValidator<UsuarioUpdate>
    {
        public UsuarioUpdateValidator()
        {

            RuleFor(x => x.NmUsuario)
                .NotEmpty().WithMessage("O nome é obrigatório.")
                .Length(3, 200).WithMessage("O nome deve ter entre 3 e 200 caracteres.");

            RuleFor(p => p.DsEmail)
                .EmailAddress()
                .WithMessage("E-mail não válido!");

            RuleFor(p => p.DsSenha)
                .Must(SenhaValida)
                .WithMessage("Senha deve conter pelo menos 8 caracteres, um número, uma letra maiúscula, uma minúscula, e um caractere especial");
        }

        public bool SenhaValida(string password)
        {
            var regex = new Regex(@"^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%^&+=]).*$");

            return regex.IsMatch(password);
        }
    }
}
