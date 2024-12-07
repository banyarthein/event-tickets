using GlobalEvents.Application.Responses;

namespace GlobalEvents.Application.Features.Orders.Commands.UpdateOrder
{
    public class UpdateOrderCommandResponse: BaseResponse
    {
        public UpdateOrderCommandResponse(): base()
        {
            
        }

        public UpdateOrderModel UpdateOrderModel { get; set; }
    }
}
