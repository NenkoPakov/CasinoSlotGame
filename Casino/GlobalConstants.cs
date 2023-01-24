namespace Casino
{
    public static class GlobalConstants
    {
        #region Invalid messages
        public const string INVALID_AMOUNT = "The input must be a positive number";
        public const string INVALID_ACTION = "Invalid action!";
        public const string INVALID_BET_AMOUNT = "Invalid bet amount!";
        public const string INVALID_INPUT = "Invalid choice. Please try again.";
        public const string INSUFFICIENT_FUNDS = "Insufficient funds. Your balance is:";
        #endregion

        #region Action messages
        public const string DEPOSIT_MONEY = "Please deposit money you would like to play with:";
        public const string CHANGE_BET_AMOUNT = "Enter stake amount:";
        public const string CHECK_BALANCE = "Current balance is: ";
        public const string QUIT = "Thanks for playing!";
        #endregion

        #region Result messages
        public const string WIN_MESSAGE = "You have won:";
        public const string TRY_AGAIN_MESSAGE = "Try again";
        #endregion

        #region Info messages
        public const string CASINO_WELCOME_MESSAGE = "Welcome to the Casino!";
        #endregion

        #region Symbols
        public const char WILDCARD_SYMBOL = '*';
        public const char APPLE_SYMBOL = 'A';
        public const char BANANA_SYMBOL = 'B';
        public const char PINEAPPLE_SYMBOL = 'P';
        #endregion
    }
}
