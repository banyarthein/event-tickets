using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalEvents.Application.Features.Orders.Commands.CreateOrder
{
    public class CreateOrderModel
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid EventId { get; set; }
        public int TicketsCount { get; set; } = 1;
        public decimal OrderTotal { get; set; } = 0;
        public bool OrderPaid { get; set; } = false;
        public DateTime OrderPlaced { get; set; }

    }
}
