namespace Casino.Services
{
    public interface ITransactionService
    {
        public void Deposit();
        public void ChangeBet();
        public void CheckBalance();
        public void ReduceBalanceByBetAmount();
        public void AddWinnings(decimal winnings);
    }
}
