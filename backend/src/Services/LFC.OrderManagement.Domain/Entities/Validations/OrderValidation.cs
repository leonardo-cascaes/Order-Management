using FluentValidation;

namespace LFC.OrderManagement.Domain.Entities.Validations
{
    public class OrderValidation : AbstractValidator<Order>
    {
        public OrderValidation()
        {
            RuleFor(o => o.CustomerId)
                .NotEmpty().WithMessage("The {PropertyName} field cannot be empty.");

            RuleFor(o => o.Items)
                .NotEmpty().WithMessage("The {PropertyName} field must contain at least one item.");
        }
    }
}
