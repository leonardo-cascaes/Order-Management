using LFC.OrderManagement.Domain.Entities.Enums;
using LFC.Shared.Core.Entities;

namespace LFC.OrderManagement.Domain.Entities
{
    public class Customer : Entity
    {
        public string Name { get; private set; } = default!;
        public string Email { get; private set; } = default!;
        public string Document { get; private set; } = default!;
        public CustomerType CustomerType { get; private set; }

        protected Customer() { }

        public Customer(string name, string email, string document, CustomerType customerType)
        {
            Name = name;
            Email = email;
            Document = document;
            CustomerType = customerType;
        }

        public void UpdateName(string newName)
        {
            Name = newName;
        }

        public void UpdateEmail(string newEmail)
        {
            Email = newEmail;
        }

        public void UpdateDocument(string newDocument)
        {
            Document = newDocument;
        }
    }
}
