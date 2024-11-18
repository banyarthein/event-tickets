using GlobalEvents.Application.Interface.Persistence;
using MediatR;

namespace GlobalEvents.Application.Features.Events.Commands.DeleteEvent
{
    public class DeleteEventCommandHandler: IRequestHandler<DeleteEventCommand, bool>
    {
        private readonly IEventRepo _eventRepo;

        public DeleteEventCommandHandler(IEventRepo eventRepo)
        {
            this._eventRepo = eventRepo;
        }

        public async Task<bool> Handle(DeleteEventCommand request, CancellationToken cancellationToken)
        {
            var eventToDelete = await _eventRepo.GetByIdAsync(request.Id);
            if (eventToDelete != null)
            {
                return await _eventRepo.DeleteAsync(eventToDelete);
            }
            else
            {
                return false;
            }
        }
    }
}
