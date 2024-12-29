using AutoMapper;
using GlobalEvents.Application.Interface.Persistence;
using GlobalEvents.Domain.Entities;
using GlobalEvents.Application.Exceptions;
using MediatR;

namespace GlobalEvents.Application.Features.Events.Commands.UpdateEvent
{
    public class UpdateEventCommandHandler: IRequestHandler<UpdateEventCommand, Event>
    {
        private readonly IMapper _mapper;
        private readonly IEventRepo _eventRepo;

        public UpdateEventCommandHandler(IMapper mapper, IEventRepo eventRepo)
        {
            _mapper = mapper;
            _eventRepo = eventRepo;
        }

        public async Task<Event> Handle(UpdateEventCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateEventCommandValidator(_eventRepo);
            var validationResult = await validator.ValidateAsync(request);
            if (validationResult != null && validationResult.Errors.Count != 0)
            {
                throw new ValidationException(validationResult);
            }

            var eventToUpdate = await _eventRepo.GetByIdAsync(request.Id);
            if (eventToUpdate == null)
            {
                return null;
            }

            _mapper.Map(request, eventToUpdate, typeof(UpdateEventCommand), typeof(Event));


            var updatedEvent = await _eventRepo.UpdateAsync(eventToUpdate);

            if(updatedEvent != null)
            {
                return updatedEvent;
            }
            else
            {
                return null;
            }
        }
    }
}
