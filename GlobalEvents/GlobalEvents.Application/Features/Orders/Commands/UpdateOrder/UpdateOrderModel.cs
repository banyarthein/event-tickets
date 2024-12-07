namespace GlobalEvents.Application.Features.Orders.Commands.UpdateOrder
{
    public class UpdateOrderModel
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
