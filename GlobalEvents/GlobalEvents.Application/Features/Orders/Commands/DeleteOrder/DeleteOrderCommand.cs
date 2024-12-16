using MediatR;

namespace GlobalEvents.Application.Features.Orders.Commands.DeleteOrder
{
    public class DeleteOrderCommand : IRequest<DeleteOrderCommandResponse>
    {
        public Guid Id { get; set; }
    }
}
