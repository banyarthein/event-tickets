namespace GlobalEvents.Application.Interface.Infrastructure
{
    public interface ICSVExporter<T> where T : class
    {
        byte[] ExportToCSV(List<T> dataToExport);
    }
}
