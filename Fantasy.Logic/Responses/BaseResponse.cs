
namespace Fantasy.Logic.Responses
{
    public class BaseResponse
    {
        public bool Success { get; set; }
        public List<ErrorType> ErrorTypes { get; set; } = new();
    }

    public enum ErrorType
    {

    }
}
