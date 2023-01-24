namespace Casino.Exceptions
{
    public class InvalidAmountException : Exception
    {
        public InvalidAmountException(string message = GlobalConstants.INVALID_AMOUNT)
               : base(message)
        { }
        public InvalidAmountException(decimal amount)
            : base($"{GlobalConstants.INVALID_AMOUNT}: {amount}")
        { }

        public InvalidAmountException(string message, decimal amount)
            : base($"{message}: {amount}")
        { }

        public InvalidAmountException(string message, Exception inner)
            : base(message, inner)
        { }
    }
}
