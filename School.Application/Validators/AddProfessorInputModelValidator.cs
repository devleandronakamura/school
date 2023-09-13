using FluentValidation;
using School.Application.InputModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Application.Validators
{
    public class AddProfessorInputModelValidator : AbstractValidator<AddProfessorInputModel>
    {
        public AddProfessorInputModelValidator()
        {
            RuleFor(x => x.Name)
                .MaximumLength(100)
                .WithMessage("O tamanho máximo do nome é de 100 caracteres");


        }
    }
}
