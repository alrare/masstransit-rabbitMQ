using MassTransit;
using Producer.Data;
using Producer.DTO;
using SharedModels;

namespace Producer.Service;

public class OrderService : IOrderService
{
    private readonly OrderDbContext _context;
    private readonly IPublishEndpoint _publishEndpoint;

    public OrderService(OrderDbContext context, IPublishEndpoint publishEndpoint)
    {
        _context = context;
        _publishEndpoint = publishEndpoint;
    }

    public async Task SaveOrder(OrderDto orderDto)
    {
        var order = await Save(orderDto);

        if (order is not null)
            await _publishEndpoint.Publish<IOrderCreated>(new
            {
                order.Id,
                order.ProductName,
                order.Quantity,
                order.Price
            });
    }

    private async Task<Order> Save(OrderDto orderDto)
    {
        var order = new Order()
        {
            ProductName = orderDto.ProductName,
            Price = orderDto.Price,
            Quantity = orderDto.Quantity
        };

        _context.Order.Add(order);
        await _context.SaveChangesAsync();

        return order;
    }
}
