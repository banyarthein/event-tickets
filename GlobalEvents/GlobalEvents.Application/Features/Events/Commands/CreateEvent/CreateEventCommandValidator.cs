using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalEvents.Application.Features.Events.Commands.CreateEvent
{
    public class CreateEventCommandValidator: AbstractValidator<CreateEventCommand>
    {
        public CreateEventCommandValidator()
        {
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
        }
    }
}
