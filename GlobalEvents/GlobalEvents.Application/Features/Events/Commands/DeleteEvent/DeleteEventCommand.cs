using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalEvents.Application.Features.Events.Commands.DeleteEvent
{
    public class DeleteEventCommand: IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
