using AutoMapper;
using GlobalEvents.Application.Interface.Persistence;
using MediatR;

namespace GlobalEvents.Application.Features.Events.Queries.GetEventDetails
{
    public class GetEventDetailQueryHandler : IRequestHandler<GetEventDetailQuery, EventDetailModel>
    {
        private readonly IMapper _mapper;
        private readonly IEventRepo _eventRepo;
        private readonly ICategoryRepo _categoryRepo;

        public GetEventDetailQueryHandler(IMapper mapper, IEventRepo eventRepo, ICategoryRepo categoryRepo)
        {
            _mapper = mapper;
            _eventRepo = eventRepo;
            _categoryRepo = categoryRepo;
        }

        public async Task<EventDetailModel> Handle(GetEventDetailQuery request, CancellationToken cancellationToken)
        {
            var singleEvent = await _eventRepo.GetByIdAsync(request.Id);

            var eventDetailVM = default(EventDetailModel);

            if (singleEvent != null)
            {
                eventDetailVM = _mapper.Map<EventDetailModel>(singleEvent);
                var category = await _categoryRepo.GetByIdAsync(singleEvent.CategoryId);

                if (category != null)
                {
                    eventDetailVM.Category = _mapper.Map<CategoryModel>(category);
                }
            }

            return eventDetailVM;
        }
    }
}
