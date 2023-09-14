namespace Fantasy.Presentation.Data.ViewModels
{
    public class RuleValidityViewModel
    {
        public bool IsValid { get; set; }
        public List<string> ReasonsNotSupported { get; set; } = new();
    }
}
