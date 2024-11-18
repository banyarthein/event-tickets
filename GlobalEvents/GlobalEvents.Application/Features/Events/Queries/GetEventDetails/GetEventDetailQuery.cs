using MediatR;

namespace GlobalEvents.Application.Features.Events.Queries.GetEventDetails
{
    public class GetEventDetailQuery : IRequest<EventDetailModel>
    {
        public Guid Id { get; set; }
    }
}
