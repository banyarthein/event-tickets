using AutoMapper;
using GlobalEvents.Application.Features.Categories.Queries.GetCategoryListWithEvents;
using GlobalEvents.Application.Features.Events.Commands.CreateEvent;
using GlobalEvents.Application.Features.Events.Queries.GetEventDetails;
using GlobalEvents.Application.Features.Events.Queries.GetEventList;
using GlobalEvents.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalEvents.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Event, EventListModel>().ReverseMap();
            CreateMap<Event, EventDetailModel>().ReverseMap();
            
            CreateMap<Category, CategoryEventModel>().ReverseMap();
            CreateMap<Category, CategoryEventListModel>().ReverseMap();

            CreateMap<Event, CreateEventCommand>().ReverseMap();
        }

    }
}
