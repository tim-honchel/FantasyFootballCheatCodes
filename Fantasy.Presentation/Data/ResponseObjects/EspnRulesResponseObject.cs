using Fantasy.Presentation.Data.ViewModels;

namespace Fantasy.Presentation.Data.Responses
{
    public class EspnRulesResponseObject : BaseResponseObject
    {
        public RulesESPNViewModel Rules { get; set; } = new();
    }
}
