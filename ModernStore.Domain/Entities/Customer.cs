using ModernStore.Domain.ValueObjects;
using ModernStore.Shared.Entities;
using System;

namespace ModernStore.Domain.Entities
{
    public class Customer : Entity
    {
        protected Customer() { }

        public Customer(string firstName, string lastName, string documentNumber) :
            this(Guid.NewGuid(), firstName, lastName, documentNumber)
        {
            Id = Guid.NewGuid();
            Name = new Name(firstName, lastName);
            BirthDate = null;
            Document = new Document(documentNumber);
            CreatedDate = DateTime.Now;

            AddNotifications(Name.Notifications);
            AddNotifications(Document.Notifications);
        }

        public Customer(Guid id, string firstName, string lastName, string documentNumber)
        {
            Id = id;
            Name = new Name(firstName, lastName);
            BirthDate = null;
            Document = new Document(documentNumber);
            CreatedDate = DateTime.Now;
          
            AddNotifications(Name.Notifications);
            AddNotifications(Document.Notifications);
        }

        public void Update(string firstName, string lastName, DateTime? birthDate)
        {
            Name = new Name(firstName, lastName);
            BirthDate = birthDate;

            AddNotifications(Name.Notifications);
            AddNotifications(Document.Notifications);
        }

        public Guid Id { get; private set; }
        public Name Name { get; private set; }
        public DateTime? BirthDate { get; private set; }
        public Document Document { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public User User { get; private set; }
    }
}
