using Casino.Services;
using Casino.Wrappers;

namespace Casino
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            ConsoleWrapper consoleWrapper = new ConsoleWrapper();
            TransactionService transactionService = new TransactionService(consoleWrapper);
            GameManager gameManager = new GameManager(transactionService, consoleWrapper);

            gameManager.BeginPlay(args, transactionService);
        }
    }
}