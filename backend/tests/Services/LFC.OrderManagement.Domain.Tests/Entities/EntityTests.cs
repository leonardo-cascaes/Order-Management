using FluentAssertions;
using LFC.OrderManagement.Domain.Tests.Entities.Mocks;

namespace LFC.OrderManagement.Domain.Tests.Entities
{
    public class EntityTests
    {
        [Fact]
        public void Entity_Constructor_ShouldInitializePropertiesCorrectly()
        {
            // Act
            var entity = new TestEntity();

            // Assert
            entity.Id.Should().NotBeEmpty();
            entity.CreatedAt.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromSeconds(1));
            entity.UpdatedAt.Should().BeNull();
        }

        [Fact]
        public void Entity_MarkAsUpdated_ShouldUpdateTimestampCorrectly()
        {
            // Arrange
            var entity = new TestEntity();

            // Act
            entity.MarkAsUpdated();

            // Assert
            entity.UpdatedAt.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromSeconds(1));
        }
    }
}
