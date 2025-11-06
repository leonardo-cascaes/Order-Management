using LFC.OrderManagement.Domain.Entities;

namespace LFC.OrderManagement.Domain.Tests.Entities
{
    public class ProductTests
    {
        [Fact]
        public void Product_UpdateName_ShouldUpdateName()
        {
            // Arrange
            var product = new Product("Product Test", "description test", 10.00m);
            var newName = "New product name";

            // Act
            product.UpdateName(newName);

            // Assert
            Assert.Equal(newName, product.Name);
        }

        [Fact]
        public void Product_UpdateDescription_ShouldUpdateDescription()
        {
            // Arrange
            var product = new Product("Product Test", "description test", 10.00m);
            var newDescription = "New description";

            // Act
            product.UpdateDescription(newDescription);

            // Assert
            Assert.Equal(newDescription, product.Description);
        }

        [Fact]
        public void Product_UpdatePrice_ShouldUpdatePrice()
        {
            // Arrange
            var product = new Product("Product Test", "description test", 10.00m);
            var newPrice = 500.53m;

            // Act
            product.UpdatePrice(newPrice);

            // Assert
            Assert.Equal(newPrice, product.Price);
        }
    }
}
