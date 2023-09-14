
namespace Fantasy.Logic.Models
{
    public class RuleValidity
    {
        public bool IsValid { get; set; }
        public List<string> ReasonsNotSupported { get; set; } = new();
    }
}
