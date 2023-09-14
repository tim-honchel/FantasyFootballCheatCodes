namespace Fantasy.Presentation.Data.Exceptions
{
    public class LeagueNotFoundException : Exception
    {
        public LeagueNotFoundException()
        {
        }

        public LeagueNotFoundException(string message)
            : base(message)
        {
        }

        public LeagueNotFoundException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
