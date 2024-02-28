using FluentValidation;

namespace Application.Features.Customers.Commands.CreateCustomerCommand
{
    public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerCommandValidator()
        {
            RuleFor(p => p.Nombre)
                .NotEmpty().WithMessage("{PropertyName} no puede estar vacio.")
                .MaximumLength(80).WithMessage("{PropertyName} no exceder de {MaxLength} caracteres");

            RuleFor(p => p.Apellido)
            .NotEmpty().WithMessage("{PropertyName} no puede estar vacio.")
            .MaximumLength(80).WithMessage("{PropertyName} no exceder de {MaxLength} caracteres");

            RuleFor(p => p.FechaNacimiento)
                .NotEmpty().WithMessage("Fecha de Nacimiento no puede estar vacio.");
            
            RuleFor(p => p.Telefono)
                .NotEmpty().WithMessage("{PropertyName} no puede estar vacio.")
                .Matches(@"^\d{4}-\d{4}$").WithMessage("{PropertyName} debe cumplir el formato 0000-0000")
                .MaximumLength(9).WithMessage("{PropertyName} no exceder de {MaxLength} caracteres");

            RuleFor(p => p.Email)
                .NotEmpty().WithMessage("{PropertyName} no puede estar vacio.")
                .EmailAddress().WithMessage("{PropertyName} debe ser una dirección de email valida")
                .MaximumLength(100).WithMessage("{PropertyName} no debe exceder de {MaxLength} caracteres");

            RuleFor(p => p.Direccion)
                .NotEmpty().WithMessage("{PropertyName} no puede estar vacio.")
                .MaximumLength(120).WithMessage("{PropertyName} no debe exceder de {MaxLength} caracteres");

        }
    }
}
