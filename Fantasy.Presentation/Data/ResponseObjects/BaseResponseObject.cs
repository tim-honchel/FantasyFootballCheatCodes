
namespace Fantasy.Presentation.Data.Responses
{
    public class BaseResponseObject
    {
        public bool Success { get; set; }
        public List<ErrorType> ErrorTypes { get; set; } = new();
    }

    public enum ErrorType
    {

    }
}
