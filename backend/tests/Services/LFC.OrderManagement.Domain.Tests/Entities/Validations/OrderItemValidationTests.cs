using FluentAssertions;
using FluentValidation.TestHelper;
using LFC.OrderManagement.Domain.Entities;
using LFC.OrderManagement.Domain.Entities.Validations;

namespace LFC.OrderManagement.Domain.Tests.Entities.Validations
{
    public class OrderItemValidationTests
    {
        private readonly OrderItemValidation _validator = new();

        [Fact]
        public void OrderItem_ShouldHaveError_WhenOrderIdIsEmpty()
        {
            // Arrange
            var item = new OrderItem(Guid.Empty, Guid.NewGuid(), 1, 10m);

            // Act
            var result = _validator.TestValidate(item);

            // Assert
            result.ShouldHaveValidationErrorFor(i => i.OrderId);
        }

        [Fact]
        public void OrderItem_ShouldHaveError_WhenProductIdIsEmpty()
        {
            // Arrange
            var item = new OrderItem(Guid.NewGuid(), Guid.Empty, 1, 10m);

            // Act
            var result = _validator.TestValidate(item);

            // Assert
            result.ShouldHaveValidationErrorFor(i => i.ProductId);
        }

        [Fact]
        public void OrderItem_ShouldHaveError_WhenQuantityIsZero()
        {
            // Arrange
            var item = new OrderItem(Guid.NewGuid(), Guid.NewGuid(), 0, 10m);

            // Act
            var result = _validator.TestValidate(item);

            // Assert
            result.ShouldHaveValidationErrorFor(i => i.Quantity);
        }

        [Fact]
        public void OrderItem_ShouldHaveError_WhenUnitPriceIsZero()
        {
            // Arrange
            var item = new OrderItem(Guid.NewGuid(), Guid.NewGuid(), 1, 0m);

            // Act
            var result = _validator.TestValidate(item);

            // Assert
            result.ShouldHaveValidationErrorFor(i => i.UnitPrice);
        }

        [Fact]
        public void OrderItem_ShouldNotHaveError_WhenOrderItemIsValid()
        {
            // Arrange
            var item = new OrderItem(Guid.NewGuid(), Guid.NewGuid(), 2, 10m);

            // Act
            var result = _validator.TestValidate(item);

            // Assert
            result.IsValid.Should().BeTrue();
        }
    }
}
