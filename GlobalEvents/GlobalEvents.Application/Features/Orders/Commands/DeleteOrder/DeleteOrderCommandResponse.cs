using GlobalEvents.Application.Responses;

namespace GlobalEvents.Application.Features.Orders.Commands.DeleteOrder
{
    public class DeleteOrderCommandResponse : BaseResponse
    {
        public DeleteOrderCommandResponse() : base()
        {

        }

        public DeleteOrderModel DeleteOrderModel { get; set; }
    }
}
