using FluentValidation;
using GlobalEvents.Application.Interface.Persistence;

namespace GlobalEvents.Application.Features.Events.Commands.CreateEvent
{
    public class CreateEventCommandValidator: AbstractValidator<CreateEventCommand>
    {
        private readonly IEventRepo _eventRepo;

        public CreateEventCommandValidator(IEventRepo eventRepo)
        {
            _eventRepo = eventRepo;

            int nameMaxLength = 50;
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is requried.")
                .NotNull()
                .MaximumLength(nameMaxLength).WithMessage("{PropertyName} must not exceed "+ nameMaxLength.ToString() + " characters");

            RuleFor(p => p.Date)
                .NotEmpty().WithMessage("{PropertyName} is requried.")
                .NotNull()
                .GreaterThan(DateTime.Now);

            RuleFor(p => p.Price)
                .NotEmpty().WithMessage("{PropertyName} is requried.")
                .GreaterThan(0);

            RuleFor(p => p)
                .MustAsync(EventNameAndDateUnique)
                .WithMessage("An event with the same name and date already exists.");
        }

        private async Task<bool> EventNameAndDateUnique(CreateEventCommand e, CancellationToken token)
        {
            return (!(await _eventRepo.IsEventNameAndDateUniqueAsync(e.Name, e.Date)));
        }
    }
}
