using AutoMapper;
using GlobalEvents.Application.Exceptions;
using GlobalEvents.Application.Interface.Infrastructure;
using GlobalEvents.Application.Interface.Persistence;
using GlobalEvents.Application.Model.Mail;
using GlobalEvents.Domain.Entities;
using MediatR;


namespace GlobalEvents.Application.Features.Events.Commands.CreateEvent
{
    public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, Event>
    {
        private readonly Mapper _mapper;
        private readonly IEventRepo _eventRepo;
        private readonly IEmailService _emailService;

        public CreateEventCommandHandler(Mapper mapper, IEventRepo eventRepo, IEmailService emailService)
        {
            _mapper = mapper;
            _eventRepo = eventRepo;
            _emailService = emailService;
        }

        public async Task<Event> Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            var singleEvent = _mapper.Map<Event>(request);

            var validator = new CreateEventCommandValidator(_eventRepo);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult != null && validationResult.Errors.Count != 0)
            {
                throw new ValidationException(validationResult);
            }

            singleEvent = await _eventRepo.AddAsync(singleEvent);

            await SendEmail(singleEvent);

            return singleEvent;

        }

        private async Task<bool> SendEmail(Event item)
        {
            var email = new Email
            {
                To = "banyar.lanwork@gmail.com",
                Cc = "banyarthein.mm@gmail.com",
                Subject = $"New Event ({item.Name}) was Created",
                Body = $"A new event has been created: {item.Name}"
            };

            try
            {
                await _emailService.SendEmail(email);
            }
            catch (Exception ex)
            {
                //Do nothing for now
                return false;
            }
            //Send email
            return true;
        }
    }
}
