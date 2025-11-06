using FluentValidation;
using LFC.OrderManagement.Domain.Entities.Enums;
using LFC.Shared.Core.Services;
using LFC.Shared.Core.ValueObjects;

namespace LFC.OrderManagement.Domain.Entities.Validations
{
    public class CustomerValidation : AbstractValidator<Customer>
    {
        public CustomerValidation()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("The {PropertyName} field cannot be empty.")
                .Length(2, 100).WithMessage("The {PropertyName} field must be between {MinLength} and {MaxLength} characters.");

            RuleFor(c => c.Email)
                .NotEmpty().WithMessage("The {PropertyName} field cannot be empty.")
                .Length(2, 200).WithMessage("The {PropertyName} field must be between {MinLength} and {MaxLength} characters.")
                .EmailAddress().WithMessage("The {PropertyName} field must be a valid email address.");

            When(c => c.CustomerType == CustomerType.Individual, () =>
            {
                RuleFor(c => c.Document)
                    .NotEmpty().WithMessage("The {PropertyName} field cannot be empty.")
                    .Length(Cpf.Length).WithMessage("The {PropertyName} field must have {ComparisonValue} characters but {PropertyValue} was provided.")
                    .Must(DocumentValidationService.ValidateCpf).WithMessage("The {PropertyName} field is invalid.");
            });

            When(c => c.CustomerType == CustomerType.Company, () =>
            {
                RuleFor(c => c.Document)
                    .NotEmpty().WithMessage("The {PropertyName} field cannot be empty.")
                    .Length(Cnpj.Length).WithMessage("The {PropertyName} field must have {ComparisonValue} characters but {PropertyValue} was provided.")
                    .Must(DocumentValidationService.ValidateCnpj).WithMessage("The {PropertyName} field is invalid.");
            });
        }
    }
}
