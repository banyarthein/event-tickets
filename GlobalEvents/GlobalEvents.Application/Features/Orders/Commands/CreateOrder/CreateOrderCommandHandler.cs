using AutoMapper;
using GlobalEvents.Application.Interface.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalEvents.Application.Features.Orders.Commands.CreateOrder
{
    public class CreateOrderCommandHandler: IRequestHandler<CreateOrderCommand, CreateOrderCommandResponse >
    {
        IMapper _mapper;
        IOrderRepo _orderRepo;

        public CreateOrderCommandHandler(IMapper mapper, IOrderRepo orderRepo)
        {
            _mapper = mapper;
            _orderRepo = orderRepo;
        }

        public async Task<CreateOrderCommandResponse> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
