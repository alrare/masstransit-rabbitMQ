using Producer.DTO;

namespace Producer.Service;

public interface IOrderService
{
    Task SaveOrder(OrderDto orderDto);
}
