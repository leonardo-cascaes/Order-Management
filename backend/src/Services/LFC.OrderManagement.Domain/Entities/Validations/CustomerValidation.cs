using FluentValidation;
using LFC.BuildingBlocks.Core.Services;
using LFC.BuildingBlocks.Core.ValueObjects;
using LFC.OrderManagement.Domain.Entities.Enums;

namespace LFC.OrderManagement.Domain.Entities.Validations
{
    public class CustomerValidation : AbstractValidator<Customer>
    {
        public CustomerValidation()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("The {PropertyName} field cannot be empty.")
                .Length(2, 100).WithMessage("The {PropertyName} field must be between {MinLength} and {MaxLength} characters.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("The {PropertyName} field cannot be empty.")
                .Length(2, 200).WithMessage("The {PropertyName} field must be between {MinLength} and {MaxLength} characters.")
                .EmailAddress().WithMessage("The {PropertyName} field must be a valid email address.");

            When(x => x.CustomerType == CustomerType.Individual, () =>
            {
                RuleFor(x => x.Document)
                    .NotEmpty().WithMessage("The {PropertyName} field cannot be empty.")
                    .Length(Cpf.Length).WithMessage("The {PropertyName} field must have {ComparisonValue} characters but {PropertyValue} was provided.")
                    .Must(DocumentValidationService.ValidateCpf).WithMessage("The {PropertyName} field is invalid.");
            });

            When(x => x.CustomerType == CustomerType.Company, () =>
            {
                RuleFor(x => x.Document)
                    .NotEmpty().WithMessage("The {PropertyName} field cannot be empty.")
                    .Length(Cnpj.Length).WithMessage("The {PropertyName} field must have {ComparisonValue} characters but {PropertyValue} was provided.")
                    .Must(DocumentValidationService.ValidateCnpj).WithMessage("The {PropertyName} field is invalid.");
            });
        }
    }
}
