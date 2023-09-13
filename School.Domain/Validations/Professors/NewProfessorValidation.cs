using FluentValidation;
using School.Domain.Entities;

namespace School.Domain.Validations.Professors;

internal class NewProfessorValidation : AbstractValidator<Professor>
{
    public NewProfessorValidation()
    {
        RuleFor(x => x.ContractType)
                .IsInEnum()
                .WithMessage("Tipo de contrato inválido.");

        RuleFor(x => x.Name)
            .NotNull().NotEmpty().WithMessage("O nome não pode em branco ou nulo");
    }
}
