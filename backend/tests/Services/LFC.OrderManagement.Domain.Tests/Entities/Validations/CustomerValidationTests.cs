using FluentValidation.TestHelper;
using LFC.OrderManagement.Domain.Entities;
using LFC.OrderManagement.Domain.Entities.Enums;
using LFC.OrderManagement.Domain.Entities.Validations;

namespace LFC.OrderManagement.Domain.Tests.Entities.Validations
{
    public class CustomerValidationTests
    {
        private readonly CustomerValidation _validator = new();

        [Fact]
        public void Customer_ShouldHaveValidationError_WhenNameIsEmpty()
        {
            // Arrange
            var customer = new Customer("", "test@email.com", "27017775007", CustomerType.Individual);

            // Act
            var result = _validator.TestValidate(customer);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Name);
        }

        [Fact]
        public void Customer_ShouldHaveValidationError_WhenEmailIsInvalid()
        {
            // Arrange
            var customer = new Customer("Mario", "invalid-email", "27017775007", CustomerType.Individual);

            // Act
            var result = _validator.TestValidate(customer);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Email);
        }

        [Fact]
        public void Customer_ShouldHaveValidationError_WhenCPFIsInvalid()
        {
            // Arrange
            var customer = new Customer("Mario", "test@email.com", "123123123", CustomerType.Individual);

            // Act
            var result = _validator.TestValidate(customer);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Document);
        }

        [Fact]
        public void Customer_ShouldNotHaveValidationError_WhenCPFIsValid()
        {
            // Arrange
            var customer = new Customer("Mario", "test@email.com", "27017775007", CustomerType.Individual);

            // Act
            var result = _validator.TestValidate(customer);

            // Assert
            result.ShouldNotHaveValidationErrorFor(x => x.Document);
        }

        [Fact]
        public void Customer_ShouldHaveValidationError_WhenCNPJIsInvalid()
        {
            // Arrange
            var customer = new Customer("Mario", "test@email.com", "12312312312", CustomerType.Company);

            // Act
            var result = _validator.TestValidate(customer);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Document);
        }

        [Fact]
        public void Customer_ShouldNotHaveValidationError_WhenCNPJIsValid()
        {
            // Arrange
            var customer = new Customer("Mario", "test@email.com", "12808733000136", CustomerType.Company);

            // Act
            var result = _validator.TestValidate(customer);

            // Assert
            result.ShouldNotHaveValidationErrorFor(x => x.Document);
        }
    }
}
