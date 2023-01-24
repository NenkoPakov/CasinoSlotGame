using System.Text;
using Casino.Models;
using Casino.Services;
using Casino.Wrappers;

namespace Casino.Games.SlotGames
{
    public abstract class SlotGameBase : Game
    {
        private readonly IConsole _console;
        private readonly int _rows;
        private readonly int _cols;
        private readonly SlotItem[] _items;
        private readonly Dictionary<char, int> _auxiliary;
        private readonly char[][] _slot;
        private readonly Random _numberGenerator;
        private readonly TransactionService _transactionService;
        private decimal _winnings;

        protected SlotGameBase(int rows, int cols, SlotItem[] items, Random numberGenerator, TransactionService transactionService, IConsole console)
            : base(console)
        {
            this._rows = rows;
            this._cols = cols;
            this._items = items;
            this._numberGenerator = numberGenerator;
            this._transactionService = transactionService;
            this._console = console;

            this._slot = new char[this._rows][];
            for (int row = 0; row < this._rows; row++)
            {
                this._slot[row] = new char[this._cols];
            }

            this._auxiliary = new Dictionary<char, int>();

            int threshold = 0;
            foreach (SlotItem item in items)
            {
                char symbol = item.Symbol;
                threshold += item.Probability;

                this._auxiliary.Add(symbol, threshold);
            }
        }

        public override void Play()
        {
            if (_transactionService.Bet > _transactionService.Balance)
            {
                this._console.WriteLine($"{GlobalConstants.INSUFFICIENT_FUNDS} {_transactionService.Balance}");
            }
            else
            {
                _transactionService.ReduceBalanceByBetAmount();
                SpinSlot(this._slot);
                PrintResult(this._slot);
                CheckForWinnings(this._slot);
            }
        }


        private void PrintResult(char[][] slot)
        {
            StringBuilder slotGameResult = new StringBuilder();

            slotGameResult.AppendLine();

            for (int row = 0; row < this._rows; row++)
            {
                for (int col = 0; col < this._cols; col++)
                {
                    slotGameResult.Append(slot[row][col]);
                }

                slotGameResult.AppendLine();
            }

            this._console.WriteLine(slotGameResult.ToString());
        }

        private void CheckForWinnings(char[][] slot)
        {
            decimal currentWinnings = 0;
            for (int row = 0; row < this._rows; row++)
            {
                char[] rowItems = slot[row];

                int wildCardsCount = rowItems.Count(x => x == GlobalConstants.WILDCARD_SYMBOL);
                IEnumerable<char> distinctSymbols = rowItems.Distinct().Where(i => i != GlobalConstants.WILDCARD_SYMBOL);
                int distinctSymbolsCount = distinctSymbols.Count();

                if (distinctSymbolsCount == 1)
                {
                    char symbol = distinctSymbols.FirstOrDefault();
                    decimal coefficient = _items.FirstOrDefault(i => i.Symbol == symbol)!.Coefficient;
                    currentWinnings += (this._cols - wildCardsCount) * coefficient * this._transactionService.Bet;
                }
            }

            if (currentWinnings > 0)
            {
                this._transactionService.AddWinnings(currentWinnings);
                this._winnings += currentWinnings;

                this._console.WriteLine($"{GlobalConstants.WIN_MESSAGE} {currentWinnings}");
            }
            else
            {
                this._console.WriteLine(GlobalConstants.TRY_AGAIN_MESSAGE);
            }

            this._console.WriteLine($"{GlobalConstants.CHECK_BALANCE} {this._transactionService.Balance}");
        }

        private void SpinSlot(char[][] slot)
        {
            for (int row = 0; row < this._rows; row++)
            {
                for (int col = 0; col < this._cols; col++)
                {
                    int currentNumber = this._numberGenerator.Next(1, 101);

                    foreach (var (symbol, threshold) in this._auxiliary)
                    {
                        if (currentNumber < threshold)
                        {
                            slot[row][col] = symbol;
                            break;
                        }
                    }
                }
            }
        }
    }
}
