using FluentValidation;

namespace LFC.OrderManagement.Domain.Entities.Validations
{
    public class ProductValidation : AbstractValidator<Product>
    {
        public ProductValidation()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("The {PropertyName} field cannot be empty.")
                .Length(2, 100).WithMessage("The {PropertyName} field must be between {MinLength} and {MaxLength} characters.");

            RuleFor(p => p.Description)
                .MaximumLength(200).WithMessage("The {PropertyName} field cannot exceed {MaxLength} characters.");

            RuleFor(p => p.Price)
                .NotEmpty().WithMessage("The {PropertyName} field cannot be empty.")
                .GreaterThanOrEqualTo(0.0m).WithMessage("The {PropertyName} field must be greater than or equal to $0.00");
        }
    }
}
