using GlobalEvents.Application.Interface.Persistence;
using MediatR;

namespace GlobalEvents.Application.Features.Events.Commands.DeleteEvent
{
    public class DeleteEventCommandHandler: IRequestHandler<DeleteEventCommand, DeleteEventCommandResponse>
    {
        private readonly IEventRepo _eventRepo;

        public DeleteEventCommandHandler(IEventRepo eventRepo)
        {
            this._eventRepo = eventRepo;
        }

        public async Task<DeleteEventCommandResponse> Handle(DeleteEventCommand request, CancellationToken cancellationToken)
        {
            var response = new DeleteEventCommandResponse();

            var eventToDelete = await _eventRepo.GetByIdAsync(request.Id);
            if (eventToDelete != null)
            {
                response.Success = await _eventRepo.DeleteAsync(eventToDelete);
            }
            else
            {
                response.Success = false;
            }

            return response;
        }
    }
}
