using AutoMapper;
using GlobalEvents.Application.Interface.Persistence;
using MediatR;

namespace GlobalEvents.Application.Features.Orders.Commands.DeleteOrder
{
    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand, DeleteOrderCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IOrderRepo _orderRepo;

        public DeleteOrderCommandHandler(IMapper mapper, IOrderRepo orderRepo)
        {
            _mapper = mapper;
            _orderRepo = orderRepo;
        }

        public Task<DeleteOrderCommandResponse> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
