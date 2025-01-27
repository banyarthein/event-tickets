﻿using FluentValidation;
using GlobalEvents.Application.Interface.Persistence;

namespace GlobalEvents.Application.Features.Events.Commands.UpdateEvent
{
    public class UpdateEventCommandValidator : AbstractValidator<UpdateEventCommand>
    {
        private readonly IEventRepo _eventRepo;

        public UpdateEventCommandValidator(IEventRepo eventRepo)
        {
            _eventRepo = eventRepo;

            int nameMaxLength = 50;
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is requried.")
                .NotNull()
                .MaximumLength(nameMaxLength).WithMessage("{PropertyName} must not exceed " + nameMaxLength.ToString() + " characters");

            RuleFor(p => p.Date)
                .NotEmpty().WithMessage("{PropertyName} is requried.")
                .NotNull()
                .GreaterThan(DateTime.Now);

            RuleFor(p => p)
                .MustAsync(IsEventNameAndDateUnique)
                .WithMessage("An event with the same name and date already exists.");


            RuleFor(p => p.Price)
                .NotEmpty().WithMessage("{PropertyName} is requried.")
                .GreaterThan(0);

        }

        private async Task<bool> IsEventNameAndDateUnique(UpdateEventCommand e, CancellationToken token)
        {
            return !await _eventRepo.IsEventNameAndDateUniqueForUpdateAsync(e.Id, e.Name, e.Date);
        }
    }
}
