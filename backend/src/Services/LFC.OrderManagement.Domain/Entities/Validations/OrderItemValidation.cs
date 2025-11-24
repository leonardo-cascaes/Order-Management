using FluentValidation;

namespace LFC.OrderManagement.Domain.Entities.Validations
{
    public class OrderItemValidation : AbstractValidator<OrderItem>
    {
        public OrderItemValidation()
        {
            RuleFor(o => o.OrderId)
                .NotEmpty().WithMessage("The {PropertyName} field cannot be empty.");

            RuleFor(o => o.ProductId)
                .NotEmpty().WithMessage("The {PropertyName} field cannot be empty.");

            RuleFor(o => o.Quantity)
                .NotEmpty().WithMessage("The {PropertyName} field cannot be empty.")
                .GreaterThan(0).WithMessage("The {PropertyName} field must contain at least one item.");

            RuleFor(o => o.UnitPrice)
                .NotEmpty().WithMessage("The {PropertyName} field cannot be empty.");
        }
    }
}
