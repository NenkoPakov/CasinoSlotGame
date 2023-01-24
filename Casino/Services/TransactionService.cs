using Casino.Exceptions;
using Casino.Wrappers;

namespace Casino.Services
{
    public class TransactionService : ITransactionService
    {
        public decimal Balance { get; private set; }
        public decimal Bet { get; private set; } = 0.1m;
        private readonly IConsole _console;

        public TransactionService(IConsole console)
        {
            this._console = console;
        }

        public void Deposit()
        {
            this._console.WriteLine(GlobalConstants.DEPOSIT_MONEY);
            decimal deposit;
            bool isValid = decimal.TryParse(this._console.ReadLine(), out deposit);

            if (!isValid)
            {
                throw new InvalidAmountException();
            }

            if (deposit <= 0)
            {
                throw new InvalidAmountException(deposit);
            }

            this.Balance += deposit;
        }

        public void ChangeBet()
        {
            this._console.WriteLine(GlobalConstants.CHANGE_BET_AMOUNT);

            decimal newBet;
            bool isValid = decimal.TryParse(this._console.ReadLine(), out newBet);

            if (!isValid)
            {
                throw new InvalidAmountException(GlobalConstants.INVALID_BET_AMOUNT);
            }

            if (newBet <= 0)
            {
                throw new InvalidAmountException(GlobalConstants.INVALID_BET_AMOUNT, newBet);
            }

            Bet = newBet;
        }

        public void CheckBalance()
        {
            this._console.WriteLine($"{GlobalConstants.CHECK_BALANCE} {this.Balance}");
        }

        public void ReduceBalanceByBetAmount()
        {
            this.Balance -= this.Bet;
        }

        public void AddWinnings(decimal winnings)
        {
            this.Balance += winnings;
        }
    }
}
