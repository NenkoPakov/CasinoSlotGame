namespace Casino.Models
{
    public class SlotItem
    {
        public char Symbol { get; init; }
        public decimal Coefficient { get; init; }
        public int Probability { get; init; }

        public SlotItem(char symbol, decimal coefficient, int probability)
        {
            this.Symbol = symbol;
            this.Coefficient = coefficient;
            this.Probability = probability;
        }
    }
}
