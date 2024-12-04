using GlobalEvents.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalEvents.Application.Features.Orders.Commands.CreateOrder
{
    public class CreateOrderCommandResponse: BaseResponse
    {
        public CreateOrderCommandResponse(): base()
        {
            
        }

        public CreateOrderModel CreateOrderModel { get; set; }
    }
}
