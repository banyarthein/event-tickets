namespace GlobalEvents.Application.Model.Common
{
    public class ExportFile
    {
        public string ContentType { get; set; } = string.Empty;
        public string FileName { get; set; } = string.Empty;
        public byte[] Data { get; set; }

    }
}
