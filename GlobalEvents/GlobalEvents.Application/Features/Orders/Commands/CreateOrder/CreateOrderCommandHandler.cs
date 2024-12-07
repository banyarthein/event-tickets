using AutoMapper;
using GlobalEvents.Application.Interface.Persistence;
using GlobalEvents.Domain.Entities;
using MediatR;

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
            var response = new CreateOrderCommandResponse();

            var validator = new CreateOrderCommandValidator();
            var results = await validator.ValidateAsync(request);

            if (results.Errors.Count > 0)
            {
                response.Success = false;
                response.ValidationErrors = results.Errors.Select(e => e.ErrorMessage).ToList();
                return response;
            }


            var order = _mapper.Map<Order>(request.CreateOrderModel);
            order = await _orderRepo.AddAsync(order);
            response.CreateOrderModel = _mapper.Map<CreateOrderModel>(order);
            response.Success = true;
            

            return response;
        }
    }
}
