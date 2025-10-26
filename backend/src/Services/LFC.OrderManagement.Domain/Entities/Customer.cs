using LFC.OrderManagement.Domain.Entities.Enums;

namespace LFC.OrderManagement.Domain.Entities
{
    public class Customer : Entity
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Document { get; private set; }
        public CustomerType CustomerType { get; private set; }

        public Customer(string name, string email, string document, CustomerType customerType)
        {
            Name = name;
            Email = email;
            Document = document;
            CustomerType = customerType;
        }
    }
}
