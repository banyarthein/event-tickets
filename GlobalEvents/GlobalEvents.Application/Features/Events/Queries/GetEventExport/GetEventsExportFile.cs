using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalEvents.Application.Features.Events.Queries.GetEventExport
{
    public class GetEventsExportFile
    {
        public string ContentType { get; set; } = string.Empty;
        public string ExportFileName { get; set; } = string.Empty;
        public byte[] Data { get; set; }

    }
}
