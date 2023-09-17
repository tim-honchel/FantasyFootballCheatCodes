namespace Fantasy.Presentation.Data.Exceptions
{
    public class NullContentException : Exception
    {
        public NullContentException()
        {
        }

        public NullContentException(string message)
            : base(message)
        {
        }

        public NullContentException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
