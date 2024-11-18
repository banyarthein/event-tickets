using AutoMapper;
using GlobalEvents.Application.Interface.Persistence;
using GlobalEvents.Domain.Entities;
using MediatR;

namespace GlobalEvents.Application.Features.Events.Commands.CreateEvent
{
    public class CreateEventCommandHandler: IRequestHandler<CreateEventCommand, Event>
    {
        private readonly Mapper _mapper;
        private readonly IEventRepo _eventRepo;

        public CreateEventCommandHandler(Mapper mapper, IEventRepo eventRepo)
        {
            _mapper = mapper;
            _eventRepo = eventRepo;
        }

        public async Task<Event> Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            var singleEvent = _mapper.Map<Event>(request);

            var validator = new CreateEventCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            singleEvent = await _eventRepo.AddAsync(singleEvent);
            return singleEvent;
        }
    }
}
