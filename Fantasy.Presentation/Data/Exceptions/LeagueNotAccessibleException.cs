namespace Fantasy.Presentation.Data.Exceptions
{
    public class LeagueNotAccessibleException : Exception
    {
        public LeagueNotAccessibleException()
        {
        }

        public LeagueNotAccessibleException(string message)
            : base(message)
        {
        }

        public LeagueNotAccessibleException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
