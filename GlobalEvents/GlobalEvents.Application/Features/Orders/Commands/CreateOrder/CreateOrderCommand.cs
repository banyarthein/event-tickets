using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalEvents.Application.Features.Orders.Commands.CreateOrder
{
    public class CreateOrderCommand: IRequest<CreateOrderCommandResponse>
    {
        public CreateOrderModel CreateOrderModel { get; set; }
    }
}
