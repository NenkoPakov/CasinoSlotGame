using Casino.Attributes;

namespace Casino.Enums
{
    public enum Actions
    {
        DepositMoney = 1,
        [StringValue("Withdraw money")]
        WithdrawMoney = 2,
        ChangeBetAmount = 3,
        [StringValue("Spin the rotary")]
        Spin = 4,
        [StringValue("Check balance")]
        CheckBalance = 5,
        [StringValue("Quit")]
        Quit = 6,
        Unknown = 0,
    }
}
