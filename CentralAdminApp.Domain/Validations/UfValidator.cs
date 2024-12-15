using CentralAdminApp.Domain.Entities;
using FluentValidation;

namespace CentralAdminApp.Domain.Validations
{
    public class UfValidator : AbstractValidator<Uf>
    {
        public UfValidator()
        {
            RuleFor(u => u.Sigla)
                .NotEmpty().WithMessage("A sigla da UF é obrigatória.")
                .Matches("^[A-Z]{2}$").WithMessage("A sigla da UF deve conter exatamente 2 letras maiúsculas.");

            RuleFor(u => u.Descricao)
                .NotEmpty().WithMessage("A descrição da UF é obrigatória.")
                .MaximumLength(50).WithMessage("A descrição da UF deve conter, no máximo, 50 caracteres.");
        }
    }
}