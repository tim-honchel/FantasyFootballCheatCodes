using Fantasy.Presentation.Data.ViewModels;

namespace Fantasy.Presentation.Data.Responses
{
    public class ValidRulesResponseObject : BaseResponseObject
    {
        public List<string> ValidationErrors { get; set; } = new();
    }
}
