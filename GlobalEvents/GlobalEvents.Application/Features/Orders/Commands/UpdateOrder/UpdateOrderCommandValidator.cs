using AutoMapper;
using FluentValidation;
using GlobalEvents.Application.Interface.Persistence;

namespace GlobalEvents.Application.Features.Orders.Commands.UpdateOrder
{
    public class UpdateOrderCommandValidator : AbstractValidator<UpdateOrderCommand>
    {
        private readonly IMapper _mapper;
        private readonly IOrderRepo _orderRepo;

        public UpdateOrderCommandValidator(IMapper mapper, IOrderRepo orderRepo)
        {

            _mapper = mapper;
            _orderRepo = orderRepo;

            RuleFor(p => p.UpdateOrderModel.Id)
                .NotNull().WithMessage("{PropertyName} is required.");

            RuleFor(p => p.Id)
                .MustAsync(isValidId).WithMessage("{PropertyName} to delete was not found");


            RuleFor(p => p.UpdateOrderModel.EventId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();


            RuleFor(p => p.UpdateOrderModel.UserId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();


            RuleFor(p => p.UpdateOrderModel.OrderPlaced)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .LessThanOrEqualTo(DateTime.Now).WithMessage("{PropertyName} should not be future date.");


            RuleFor(p => p.UpdateOrderModel.OrderTotal)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .GreaterThan(0);


            RuleFor(p => p.UpdateOrderModel.TicketsCount)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .GreaterThan(0).WithMessage("{PropertyName} should be valid number and greater than 0.");
        }


        private async Task<bool> isValidId(Guid id, CancellationToken token)
        {
            return await _orderRepo.IsIDExists(id);
        }
    }
}
