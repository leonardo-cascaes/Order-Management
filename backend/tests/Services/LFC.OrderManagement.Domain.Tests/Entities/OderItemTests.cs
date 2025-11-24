using FluentAssertions;
using LFC.OrderManagement.Domain.Entities;

namespace LFC.OrderManagement.Domain.Tests.Entities
{
    public class OderItemTests
    {
        [Fact]
        public void Constructor_ShouldSetPropertiesCorrectly()
        {
            // Arrange
            var orderId = Guid.NewGuid();
            var productId = Guid.NewGuid();
            int quantity = 2;
            decimal price = 10m;

            // Act
            var item = new OrderItem(orderId, productId, quantity, price);

            // Assert
            item.OrderId.Should().Be(orderId);
            item.ProductId.Should().Be(productId);
            item.Quantity.Should().Be(quantity);
            item.UnitPrice.Should().Be(price);
        }

        [Fact]
        public void OrderItem_GetTotal_ShouldReturnCorrectValue()
        {
            // Arrange
            var item = new OrderItem(Guid.NewGuid(), Guid.NewGuid(), 3, 5m);

            // Act
            var total = item.GetTotal();

            // Assert
            total.Should().Be(15m);
        }
    }
}
