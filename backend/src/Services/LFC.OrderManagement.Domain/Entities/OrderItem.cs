using LFC.Shared.Core.Entities;

namespace LFC.OrderManagement.Domain.Entities
{
    public class OrderItem : Entity
    {
        public Guid OrderId { get; private set; }
        public Guid ProductId { get; private set; }
        public int Quantity { get; private set; }
        public decimal UnitPrice { get; private set; }

        protected OrderItem() { }

        public OrderItem(Guid productId, int quantity, decimal unitPrice)
        {
            ProductId = productId;
            Quantity = quantity;
            UnitPrice = unitPrice;
        }

        public void UpdateProduct(Guid newProductId)
        {
            ProductId = newProductId;
        }

        public void UpdateQuantity(int newQuantity)
        {
            Quantity = newQuantity;
        }

        public void UpdateUnitPrice(decimal newUnitPrice)
        {
            UnitPrice = newUnitPrice;
        }

        public decimal GetTotal() => Quantity * UnitPrice;
    }
}
