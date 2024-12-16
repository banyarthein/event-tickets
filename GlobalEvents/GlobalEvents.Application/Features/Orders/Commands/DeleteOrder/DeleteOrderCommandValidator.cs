using AutoMapper;
using FluentValidation;
using GlobalEvents.Application.Interface.Persistence;

namespace GlobalEvents.Application.Features.Orders.Commands.DeleteOrder
{
    public class DeleteOrderCommandValidator : AbstractValidator<DeleteOrderCommand>
    {

        private readonly IMapper _mapper;
        private readonly IOrderRepo _orderRepo;

        public DeleteOrderCommandValidator(IMapper mapper, IOrderRepo orderRepo)
        {
            _mapper = mapper;
            _orderRepo = orderRepo;
        }

        public DeleteOrderCommandValidator()
        {
            RuleFor(p => p.Id)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .NotEqual(Guid.Empty).WithMessage("{PropertyName} is required.");

            RuleFor(p => p.Id)
                .MustAsync(isValidId).WithMessage("{PropertyName} to delete was not found");

        }

        private async Task<bool> isValidId(Guid id, CancellationToken token)
        {
            return await _orderRepo.IsIDExists(id);
        }

    }
}
