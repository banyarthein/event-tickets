using CsvHelper;
using GlobalEvents.Application.Interface.Infrastructure;
using System.Text;

namespace GlobalEvents.Infrastructure.Export
{
    public class CSVExporter<T> : ICSVExporter<T> where T : class
    {
        public byte[] ExportToCSV(List<T> dataToExport)
        {
            using MemoryStream memoryStream = new MemoryStream();
            using (StreamWriter streamWriter = new StreamWriter(memoryStream, Encoding.UTF8))
            {
                using var csvWriter = new CsvWriter(streamWriter, System.Globalization.CultureInfo.CurrentCulture);
                csvWriter.WriteRecords(dataToExport);
            }

            return memoryStream.ToArray();
        }
    }

}
