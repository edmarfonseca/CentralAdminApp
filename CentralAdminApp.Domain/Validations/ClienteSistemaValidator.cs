using FluentValidation;
using CentralAdminApp.Domain.Entities;

namespace CentralAdminApp.Domain.Validations
{
    public class ClienteSistemaValidator : AbstractValidator<ClienteSistema>
    {
        public ClienteSistemaValidator()
        {
            RuleFor(u => u.ClienteId)
            .NotEmpty().WithMessage("O código do cliente de Cliente/Sistema é obrigatório.");

            RuleFor(u => u.SistemaId)
                .NotEmpty().WithMessage("O código do sistema de Cliente/Sistema é obrigatório.");
        }
    }
}