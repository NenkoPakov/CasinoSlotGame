using Casino.Models;
using Casino.Services;
using Casino.Wrappers;

namespace Casino.Games.SlotGames
{
    public class FruitSlotGame : SlotGameBase
    {
        private static SlotItem[] slotItems = new SlotItem[]
            {
                new SlotItem(GlobalConstants.APPLE_SYMBOL,0.4m,45),
                new SlotItem(GlobalConstants.BANANA_SYMBOL,0.6m,35),
                new SlotItem(GlobalConstants.PINEAPPLE_SYMBOL,0.8m,15),
                new SlotItem(GlobalConstants.WILDCARD_SYMBOL,0m,5),
            };

        public FruitSlotGame(int rows, int cols, Random numberGenerator, TransactionService transactionService, IConsole console)
            : base(rows, cols, slotItems, numberGenerator, transactionService, console)
        {
        }

    }
}
