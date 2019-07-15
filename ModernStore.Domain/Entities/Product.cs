using FluentValidator;
using ModernStore.Shared.Entities;
using System;

namespace ModernStore.Domain.Entities
{
    public class Product : Entity
    {
        protected Product() { }

        public Product(string title, decimal price, int quantityOnHand, string image)
        {
            Id = Guid.NewGuid();
            Title = title;
            Price = price;
            QuantityOnHand = quantityOnHand;
            Image = image;

            new ValidationContract<Product>(this)
                .HasMinLenght(x => x.Title, 3)
                .IsGreaterThan(x => x.Price, 1)
                .IsGreaterThan(x => x.QuantityOnHand, 1)
                .IsGreaterThan(x => x.Image.Length, 0);
        }

        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public decimal Price { get; private set; }
        public int QuantityOnHand { get; private set; }
        public string Image { get; private set; }
    }
}
