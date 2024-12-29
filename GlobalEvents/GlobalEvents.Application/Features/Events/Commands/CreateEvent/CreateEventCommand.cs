using GlobalEvents.Domain.Entities;
using MediatR;

namespace GlobalEvents.Application.Features.Events.Commands.CreateEvent
{
    public class CreateEventCommand: IRequest<Event>
    {

        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Artist { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public Guid CategoryId { get; set; }


        public override string ToString()
        {
            return $"Event name: {Name} ; Price: {Price}; By {Artist};" +
                $" on {Date.ToShortDateString()}; Description {Description}";
        }
    }
}
