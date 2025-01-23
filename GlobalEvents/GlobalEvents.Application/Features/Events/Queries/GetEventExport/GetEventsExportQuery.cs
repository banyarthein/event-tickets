using GlobalEvents.Application.Model.Common;
using MediatR;

namespace GlobalEvents.Application.Features.Events.Queries.GetEventExport
{
    public class GetEventsExportQuery: IRequest<ExportFile>
    {
    }
}
