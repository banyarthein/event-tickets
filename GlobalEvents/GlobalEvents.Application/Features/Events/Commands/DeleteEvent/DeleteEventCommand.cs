using MediatR;

namespace GlobalEvents.Application.Features.Events.Commands.DeleteEvent
{
    public class DeleteEventCommand: IRequest<DeleteEventCommandResponse>
    {
        public Guid Id { get; set; }
    }
}
