using MediatR;

namespace GlobalEvents.Application.Features.Events.Commands.DeleteEvent
{
    public class DeleteEventCommand: IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
