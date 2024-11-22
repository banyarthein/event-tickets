namespace GlobalEvents.Application.Responses
{
    public class BaseResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;

        public List<string> ValidationErrors { get; set; } = new List<string>();

        public BaseResponse()
        {
            Success = true;
        }

        public BaseResponse(bool success)
        {
            Success = success;
        }

        public BaseResponse(bool success, string message)
        {
            Success = success;
            Message = message;
        }
    }
}
