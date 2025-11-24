using FluentValidation.TestHelper;
using LFC.OrderManagement.Domain.Entities;
using LFC.OrderManagement.Domain.Entities.Validations;

namespace LFC.OrderManagement.Domain.Tests.Entities.Validations
{
    public class OderValidationTests
    {

        private readonly OrderValidation _validator = new();

        [Fact]
        public void Order_ShouldHaveValidationError_WhenCustomerIdIsEmpty()
        {
            // Arrange
            var order = new Order(Guid.Empty);

            // Act
            var result = _validator.TestValidate(order);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.CustomerId);
        }

        [Fact]
        public void Order_ShouldHaveError_WhenOrderHasNoItems()
        {
            // Arrange
            var order = new Order(Guid.NewGuid());

            // Act
            var result = _validator.TestValidate(order);

            // Assert
            result.ShouldHaveValidationErrorFor(o => o.Items);
        }

        [Fact]
        public void Order_ShouldNotHaveError_WhenOrderIsValid()
        {
            // Arrange
            var order = new Order(Guid.NewGuid());
            order.AddItem(new OrderItem(order.Id, Guid.NewGuid(), 1, 10));

            // Act
            var result = _validator.TestValidate(order);

            // Assert
            result.ShouldNotHaveValidationErrorFor(o => o.CustomerId);
            result.ShouldNotHaveValidationErrorFor(o => o.Items);
        }
    }
}
