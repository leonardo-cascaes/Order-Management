using FluentValidation.TestHelper;
using LFC.OrderManagement.Domain.Entities;
using LFC.OrderManagement.Domain.Entities.Validations;

namespace LFC.OrderManagement.Domain.Tests.Entities.Validations
{
    public class ProductValidationTest
    {
        private readonly ProductValidation _validator = new();

        [Fact]
        public void Product_ShouldHaveValidationError_WhenNameIsEmpty()
        {
            // Arrange
            var product = new Product("", "description test", 10.00m);

            // Act
            var result = _validator.TestValidate(product);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Name);
        }

        [Fact]
        public void Product_ShouldHaveValidationError_WhenDescriptionExceedsMaxLength()
        {
            // Arrange
            var product = new Product("Product xyz", new string('a', 201), 10.00m);

            // Act
            var result = _validator.TestValidate(product);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Description);
        }

        [Fact]
        public void Product_ShouldHaveValidationError_WhenPriceIsLowerThanZero()
        {
            // Arrange
            var product = new Product("Product xyz", "description test", -10.00m);

            // Act
            var result = _validator.TestValidate(product);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Price);
        }
    }
}
