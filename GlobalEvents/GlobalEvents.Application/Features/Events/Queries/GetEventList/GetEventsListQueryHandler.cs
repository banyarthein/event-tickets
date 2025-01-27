﻿using AutoMapper;
using GlobalEvents.Application.Interface.Persistence;
using MediatR;

namespace GlobalEvents.Application.Features.Events.Queries.GetEventList
{
    public class GetEventsListQueryHandler : IRequestHandler<GetEventsListQuery, List<EventListModel>>
    {
        private readonly IMapper _mapper;
        private readonly IEventRepo _eventRepo;

        public GetEventsListQueryHandler(IMapper mapper, IEventRepo eventRepo)
        {
            _mapper = mapper;
            _eventRepo = eventRepo;
        }

        public async Task<List<EventListModel>> Handle(GetEventsListQuery request, CancellationToken cancellationToken)
        {
            var allEvents = (await _eventRepo.ListAllAsync()).OrderBy(c => c.Date);
            return _mapper.Map<List<EventListModel>>(allEvents);
        }


    }
}
