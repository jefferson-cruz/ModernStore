using FluentValidator;
using ModernStore.Domain.Entities.Enums;
using ModernStore.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ModernStore.Domain.Entities
{
    public class Order : Entity
    {
        private List<OrderItem> orderItems;

        protected Order()
        {

        }

        public Customer Customer { get; private set; }
        public DateTime CreateDate { get; private set; }
        public string Number { get; private set; }
        public OrderStatus Status { get; private set; }
        public ICollection<OrderItem> Items => orderItems;
        public decimal DeliveryFee { get; private set; }
        public decimal Discount { get; set; }

        public Order(Customer customer, decimal deliveryFee, decimal discount)
        {
            Customer = customer;
            CreateDate = DateTime.Now;
            Number = Guid.NewGuid().ToString().Substring(0, 8).ToUpper();
            Status = OrderStatus.Created;
            DeliveryFee = deliveryFee;
            Discount = discount;

            orderItems = new List<OrderItem>();

            new ValidationContract<Order>(this)
                .IsGreaterThan(x => x.DeliveryFee, 0)
                .IsGreaterThan(x => x.Discount, -1);
        }

        public void AddItem(OrderItem item)
        {
            if (item.IsValid())
            {
                orderItems.Add(item);

                return;
            }

            AddNotifications(item.Notifications);
        }

        public decimal Subtotal() => Items.Sum(x => x.Total());
        public decimal Total() => Subtotal() + DeliveryFee - Discount;
    }
}
