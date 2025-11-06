using LFC.OrderManagement.Domain.Entities;
using LFC.OrderManagement.Domain.Entities.Enums;

namespace LFC.OrderManagement.Domain.Tests.Entities
{
    public class CustomerTests
    {
        [Fact]
        public void Customer_UpdateName_ShouldUpdateName()
        {
            // Arrange
            var customer = new Customer("Test", "test@email.com", "27017775007", CustomerType.Individual);
            var newName = "New name";

            // Act
            customer.UpdateName(newName);

            // Assert
            Assert.Equal(newName, customer.Name);
        }

        [Fact]
        public void Customer_UpdateEmail_ShouldUpdateEmail()
        {
            // Arrange
            var customer = new Customer("Test", "test@email.com", "27017775007", CustomerType.Individual);
            var newEmail = "newemailtest@email.com";

            // Act
            customer.UpdateEmail(newEmail);

            // Assert
            Assert.Equal(newEmail, customer.Email);
        }

        [Fact]
        public void Customer_UpdateDocument_ShouldUpdateDocument()
        {
            // Arrange
            var customer = new Customer("Test", "test@email.com", "27017775007", CustomerType.Individual);
            var newDocument = "65503908007";

            // Act
            customer.UpdateDocument(newDocument);

            // Assert
            Assert.Equal(newDocument, customer.Document);
        }
    }
}
