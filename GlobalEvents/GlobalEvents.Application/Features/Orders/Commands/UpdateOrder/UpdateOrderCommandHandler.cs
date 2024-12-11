using AutoMapper;
using GlobalEvents.Application.Interface.Persistence;
using GlobalEvents.Domain.Entities;
using MediatR;

namespace GlobalEvents.Application.Features.Orders.Commands.UpdateOrder
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, UpdateOrderCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IOrderRepo _orderRepo;

        public UpdateOrderCommandHandler(IMapper mapper, IOrderRepo orderRepo)
        {
            _mapper = mapper;
            _orderRepo = orderRepo;
        }

        public async Task<UpdateOrderCommandResponse> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var response = new UpdateOrderCommandResponse();

            var validator = new UpdateOrderCommandValidator(_mapper, _orderRepo);
            var results = await validator.ValidateAsync(request);

            if (results.Errors.Count > 0)
            {
                response.Success = false;
                response.ValidationErrors = results.Errors.Select(e => e.ErrorMessage).ToList();
                return response;
            }

            var orderToUpdate = await _orderRepo.GetByIdAsync(request.Id);
            if (orderToUpdate == null)
            {
                response.Success = false;
                response.Message = "Order not found";
                return response;
            }

            _mapper.Map(request.UpdateOrderModel, orderToUpdate, typeof(UpdateOrderModel), typeof(Order));
            var updatedOrder = await _orderRepo.UpdateAsync(orderToUpdate);

            response.UpdateOrderModel = _mapper.Map<UpdateOrderModel>(updatedOrder);
            response.Success = true;

            return response;
        }
    }
}
