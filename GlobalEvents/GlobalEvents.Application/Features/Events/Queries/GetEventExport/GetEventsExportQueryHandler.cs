using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalEvents.Application.Features.Events.Queries.GetEventExport
{
    public class GetEventsExportQueryHandler : IRequestHandler<GetEventsExportQuery, GetEventsExportFile>
    {
        public Task<GetEventsExportFile> Handle(GetEventsExportQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
