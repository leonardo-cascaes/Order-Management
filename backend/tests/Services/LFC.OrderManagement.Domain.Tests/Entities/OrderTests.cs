using LFC.OrderManagement.Domain.Entities;

namespace LFC.OrderManagement.Domain.Tests.Entities
{
    public class OrderTests
    {
        [Fact]
        public void Order_AddItem_ShouldAddItem()
        {
            // Arrange
            var order = new Order(Guid.NewGuid());
            var item = new OrderItem(Guid.NewGuid(), 10, 25.00m);

            // Act
            order.AddItem(item);

            // Assert
            Assert.Single(order.Items);
        }

        [Fact]
        public void Order_RemoveItem_ShouldRemoveItem()
        {
            // Arrange
            var order = new Order(Guid.NewGuid());
            var item = new OrderItem(Guid.NewGuid(), 10, 25.00m);

            // Act
            order.AddItem(item);
            order.RemoveItem(item);

            // Assert
            Assert.Empty(order.Items);
        }

        [Fact]
        public void Order_GetTotalAmount_ShouldReturn250TotalAmount()
        {
            // Arrange
            var order = new Order(Guid.NewGuid());
            var item = new OrderItem(Guid.NewGuid(), 10, 25.00m);

            // Act
            order.AddItem(item);

            // Assert
            Assert.Equal(250.00m, order.GetTotalAmount());
        }

        [Fact]
        public void Order_GetCustomerId_ShouldReturnCustomerId()
        {
            // Arrange
            var customerId = Guid.NewGuid();
            var order = new Order(customerId);
            var item = new OrderItem(Guid.NewGuid(), 10, 25.00m);

            // Act
            order.AddItem(item);

            // Assert
            Assert.Equal(order.CustomerId, customerId);
        }
    }
}
