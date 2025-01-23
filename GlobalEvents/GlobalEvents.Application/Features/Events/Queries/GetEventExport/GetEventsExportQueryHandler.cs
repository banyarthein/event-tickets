using AutoMapper;
using GlobalEvents.Application.Interface.Infrastructure;
using GlobalEvents.Application.Interface.Persistence;
using GlobalEvents.Application.Model.Common;
using MediatR;

namespace GlobalEvents.Application.Features.Events.Queries.GetEventExport
{
    public class GetEventsExportQueryHandler : IRequestHandler<GetEventsExportQuery, ExportFile>
    {
        private readonly IMapper _mapper;
        private readonly IEventRepo _eventRepo;
        private readonly ICSVExporter<GetEventsExportModel> _csvExporter;

        public GetEventsExportQueryHandler(IMapper mapper, IEventRepo eventRepo, ICSVExporter<GetEventsExportModel> csvExporter)
        {
            _mapper = mapper;
            _eventRepo = eventRepo;
            _csvExporter = csvExporter;
        }

        public async Task<ExportFile> Handle(GetEventsExportQuery request, CancellationToken cancellationToken)
        {
            var allEvents = (await _eventRepo.ListAllAsync()).OrderByDescending(c => c.Date);

            var eventsToExport = _mapper.Map(allEvents, new List<GetEventsExportModel>());

            var fileData = _csvExporter.ExportToCSV(eventsToExport);

            ExportFile exportFile = new ExportFile() { ContentType = "text/csv", Data = fileData, FileName = $"EventData_{DateTime.Now.ToString("yyyy-MM-dd_hh-mm-ss")}.csv" };

            return exportFile;

        }
    }
}
