using GlobalEvents.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
