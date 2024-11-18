using AutoMapper;
using GlobalEvents.Application.Interface.Persistence;
using GlobalEvents.Domain.Entities;
using MediatR;

namespace GlobalEvents.Application.Features.Events.Commands.UpdateEvent
{
    public class UpdateEventCommandHandler: IRequestHandler<UpdateEventCommand, Event>
    {
        private readonly Mapper _mapper;
        private readonly IEventRepo _eventRepo;

        public UpdateEventCommandHandler(Mapper mapper, IEventRepo eventRepo)
        {
            _mapper = mapper;
            _eventRepo = eventRepo;
        }

        public async Task<Event> Handle(UpdateEventCommand request, CancellationToken cancellationToken)
        {
            var eventToUpdate = await _eventRepo.GetByIdAsync(request.Id);
            if (eventToUpdate == null)
            {
                return null;
            }

            _mapper.Map(request, eventToUpdate, typeof(UpdateEventCommand), typeof(Event));
            var singleEvent = _mapper.Map<Event>(request);

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
