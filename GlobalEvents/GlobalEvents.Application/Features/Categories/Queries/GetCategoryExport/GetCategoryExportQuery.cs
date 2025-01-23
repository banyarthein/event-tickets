using GlobalEvents.Application.Model.Common;
using MediatR;

namespace GlobalEvents.Application.Features.Categories.Queries.GetCategoryExport
{
    public class GetCategoryExportQuery : IRequest<ExportFile>
    {
    }
}
