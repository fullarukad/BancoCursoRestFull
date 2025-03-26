﻿using FluentValidation;

namespace Application.Feautres.Clientes.Commands.CreateClienteCommand
{
    public class CreateClienteCommandValidator : AbstractValidator<CreateClienteCommand>
    {
        public CreateClienteCommandValidator()
        {
            RuleFor(p => p.Nombre)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacio.")
                .MaximumLength(80).WithMessage("{PropertyName} no debe exceder de {MaxLenght} caracteres");

            RuleFor(p => p.Apellido)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacio.")
                .MaximumLength(80).WithMessage("{PropertyName} no debe exceder de {MaxLenght} caracteres");

            RuleFor(p => p.FechaNacimiento)
                .NotEmpty().WithMessage("Fecha de Nacimiento no puede ser vacio.");

            RuleFor(p => p.Telefono)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacio.")
                .Matches(@"^\d{4}-\d{4}$").WithMessage("{PropertyName} debe cumplir el formato 0000-0000")
                .MaximumLength(9).WithMessage("{PropertyName} no debe exceder de {MaxLenght} caracteres");

            RuleFor(p => p.Email)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacio.")
                .EmailAddress().WithMessage("PropertyName debe ser un direccion de email valida")
                .MaximumLength(100).WithMessage("{PropertyName} no debe exceder de {MaxLenght} caracteres");

            RuleFor(p => p.Direccion)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacio.")
                .MaximumLength(120).WithMessage("{PropertyName} no debe exceder de {MaxLenght} caracteres");


        }
    }
}
