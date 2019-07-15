using FluentValidator;
using ModernStore.Domain.Commands.Inputs;
using ModernStore.Domain.Commands.Results;
using ModernStore.Domain.Entities;
using ModernStore.Domain.Repositories;
using ModernStore.Shared.Commands;

namespace ModernStore.Domain.Commands.Handlers
{
    public class OrderCommandHandler : Notifiable, 
        ICommandHandler<RegisterOrderCommand, RegisterOrderCommandResult>
    {
        private readonly ICustomerRepository customerRepository;
        private readonly IProductRepository productRepository;
        private readonly IOrderRepository orderRepository;

        public OrderCommandHandler(
            ICustomerRepository customerRepository,
            IProductRepository productRepository,
            IOrderRepository orderRepository)
        {
            this.customerRepository = customerRepository;
            this.productRepository = productRepository;
            this.orderRepository = orderRepository;
        }

        public RegisterOrderCommandResult Handle(RegisterOrderCommand command)
        {
            var customer = customerRepository.GetById(command.Customer);

            var order = new Order(customer, command.DeliveryFee, command.Discount);

            foreach(var item in command.Items)
            {
                var product = productRepository.GetById(item.Product);

                order.AddItem(new OrderItem(product, item.Quantity));
            }

            AddNotifications(order.Notifications);

            if(order.IsValid())
            {
                orderRepository.Save(order);
            }

            return new RegisterOrderCommandResult(order.Number);
        }
    }
}
