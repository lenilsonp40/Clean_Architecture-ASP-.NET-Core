using FluentValidation;
using Sistema_ECommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_ECommerce.Domain.Validator
{
    public class ClientesValidator : AbstractValidator<Clientes>
    {
        public ClientesValidator()
        {
            RuleFor(x => x)
                .NotEmpty()
                .WithMessage("A entidade não pode ser vazia.")

                .NotNull()
                .WithMessage("A entidade não pode ser nula.");

            RuleFor(x => x.Name)
               .NotEmpty()
               .WithMessage("O nome não pode ser vazio.")

               .NotNull()
               .WithMessage("O nome não pode ser nulo.")

               .MinimumLength(3)
               .WithMessage("O nome deve ter no mínimo 3 caracteres.")

               .MaximumLength(80)
               .WithMessage("O nome deve ter no máximo 80 caracteres.");

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("O email não pode ser vazio.")

                .NotNull()
                .WithMessage("O email não pode ser nulo.")

                .MinimumLength(6)
                .WithMessage("O email deve ter no mínimo 6 caracteres.")

                .MaximumLength(180)
                .WithMessage("O email deve ter no máximo 180 caracteres.")

                .Matches(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$")
                .WithMessage("O email informado não é válido.");

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("A senha não pode ser vazio.")

                .NotNull()
                .WithMessage("A semha não pode ser nulo.")

                .MinimumLength(6)
                .WithMessage("A senha deve ter no mínimo 6 caracteres.")

                .MaximumLength(30)
                .WithMessage("A senha deve ter no máximo 30 caracteres.");
        }
    
    }
}
