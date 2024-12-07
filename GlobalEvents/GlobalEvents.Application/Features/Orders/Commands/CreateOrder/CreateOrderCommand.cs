using MediatR;

namespace GlobalEvents.Application.Features.Orders.Commands.CreateOrder
{
    public class CreateOrderCommand: IRequest<CreateOrderCommandResponse>
    {
        public CreateOrderModel CreateOrderModel { get; set; }
    }
}
