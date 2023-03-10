using Casino.Games.Interfaces;
using Casino.Games.SlotGames;
using Casino.Services;
using Casino.Wrappers;

namespace Casino
{
    public class GameManager
    {
        private readonly IConsole _console;
        private readonly Random _numberGenerator = new Random();
        private readonly TransactionService _transactionService;

        public GameManager(TransactionService transactionService, IConsole console)
        {
            this._transactionService = transactionService;
            this._console = console;
        }

        public void BeginPlay(string[] args, TransactionService transactionService)
        {
            try
            {
                IGame game = StartGame(args);

                PlayProcess(game);
            }
            catch (Exception ex)
            {
                this._console.WriteLine(ex.Message);
            }
        }

        private IGame StartGame(string[] args)
        {
            this._console.WriteLine(GlobalConstants.CASINO_WELCOME_MESSAGE);
            int defaultRows = 4;
            int defaultCols = 3;

            int rows = args.Length == 0 ? defaultRows : int.Parse(args[0]);
            int cols = args.Length == 0 ? defaultCols : int.Parse(args[1]);

            return new FruitSlotGame(rows, cols, this._numberGenerator, this._transactionService, this._console);
        }

        private void PlayProcess(IGame choosenGame)
        {
            while (true)
            {
                try
                {
                    if (this._transactionService.Balance == 0)
                    {
                        this._transactionService.Deposit();
                    }

                    this._transactionService.ChangeBet();

                    choosenGame.Play();

                    if (this._transactionService.Balance == 0)
                    {
                        choosenGame.Quit();
                        break;
                    }
                }
                catch (Exception ex)
                {
                    this._console.WriteLine(ex.Message);
                }
            }
        }
    }
}
