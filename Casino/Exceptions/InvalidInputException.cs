namespace Casino.Exceptions
{
    public class InvalidInputException : Exception
    {
        public InvalidInputException(string message = GlobalConstants.INVALID_INPUT)
            : base(message)
        { }

        public InvalidInputException(string message, int input)
            : base($"{message}: {input}")
        { }

        public InvalidInputException(int input)
            : base($"{GlobalConstants.INVALID_INPUT}: {input}")
        { }

        public InvalidInputException(string message, Exception inner)
            : base(message, inner)
        { }
    }
}
