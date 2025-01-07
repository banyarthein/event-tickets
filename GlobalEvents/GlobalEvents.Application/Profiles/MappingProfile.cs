using AutoMapper;
using GlobalEvents.Application.Features.Categories.Commands.CreateCategory;
using GlobalEvents.Application.Features.Categories.Commands.UpdateCategory;
using GlobalEvents.Application.Features.Categories.Queries.GetCategoryDetails;
using GlobalEvents.Application.Features.Categories.Queries.GetCategoryList;
using GlobalEvents.Application.Features.Categories.Queries.GetCategoryListWithEvents;
using GlobalEvents.Application.Features.Events.Commands.CreateEvent;
using GlobalEvents.Application.Features.Events.Commands.UpdateEvent;
using GlobalEvents.Application.Features.Events.Queries.GetEventDetails;
using GlobalEvents.Application.Features.Events.Queries.GetEventList;
using GlobalEvents.Application.Features.Orders.Commands.CreateOrder;
using GlobalEvents.Application.Features.Orders.Commands.UpdateOrder;
using GlobalEvents.Domain.Entities;

namespace GlobalEvents.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Event, EventListModel>().ReverseMap();
            CreateMap<Event, EventDetailModel>().ReverseMap();
            CreateMap<Event, UpdateEventCommand>().ReverseMap();
            CreateMap<Event, CreateEventCommand>().ReverseMap();
            CreateMap<Order, CreateOrderModel>().ReverseMap();
            CreateMap<Order, UpdateOrderModel>().ReverseMap();
            CreateMap<Event, CreateEventCommand>().ReverseMap();



            CreateMap<Category, CategoryEventModel>().ReverseMap();
            CreateMap<Category, CategoryEventListModel>().ReverseMap();
            CreateMap<Category, CategoryModel>().ReverseMap();
            CreateMap<Category, CategoryListModel>().ReverseMap();
            CreateMap<Category, CreateCategoryModel>().ReverseMap();
            CreateMap<Category, UpdateCategoryModel>().ReverseMap();
            CreateMap<Category, CategoryDetailModel>().ReverseMap();
            CreateMap<Category, UpdateCategoryCommand>().ReverseMap();







        }

    }
}
