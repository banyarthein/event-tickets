using MediatR;

namespace GlobalEvents.Application.Features.Orders.Commands.UpdateOrder
{
    public class UpdateOrderCommand: IRequest<UpdateOrderCommandResponse>
    {
        public UpdateOrderModel UpdateOrderModel { get; set; }
    }
}
