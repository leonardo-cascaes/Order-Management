using LFC.Shared.Core.Entities;

namespace LFC.OrderManagement.Domain.Entities
{
    public class Order : Entity
    {
        private readonly List<OrderItem> _items = new();

        public Guid CustomerId { get; private set; }
        public IReadOnlyCollection<OrderItem> Items => _items.AsReadOnly();

        protected Order() { }

        public Order(Guid customerId)
        {
            CustomerId = customerId;
        }

        public void AddItem(OrderItem item)
        {
            _items.Add(item);
        }

        public void RemoveItem(OrderItem item)
        {
            _items.Remove(item);
        }

        public decimal GetTotalAmount() => _items.Sum(i => i.GetTotal());
    }
}
