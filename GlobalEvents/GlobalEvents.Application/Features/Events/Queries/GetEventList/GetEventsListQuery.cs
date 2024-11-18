using MediatR;

namespace GlobalEvents.Application.Features.Events.Queries.GetEventList
{
    public class GetEventsListQuery : IRequest<List<EventListModel>>
    {
        //Empty Parameter since this is created for GetAll

    }
}
