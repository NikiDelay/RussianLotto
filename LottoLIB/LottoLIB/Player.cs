namespace LottoLIB
{
    public class Player
    {
        public string Name { get; }
        public LottoCard Card { get; private set; }
        public bool HasWon { get; private set; }
        public int CoveredCount { get; private set; }

        public Player(string name)
        {
            Name = name;
            Card = new LottoCard();
        }

        public void MarkNumber(int number)
        {
            if (!Card.ContainsNumber(number)) return;
            Card.MarkNumber(number);
            UpdateCoveredCount();
        }

        private void UpdateCoveredCount()
        {
            CoveredCount = 0;
            for (int row = 0; row < 3; row++)
                for (int col = 0; col < 9; col++)
                    if (Card.Numbers[row, col] != 0 && Card.Marked[row, col]) CoveredCount++;
        }

        public bool CheckWin()
        {
            HasWon = Card.IsFullyCovered();
            return HasWon;
        }

        public void Reset()
        {
            Card = new LottoCard();
            HasWon = false;
            CoveredCount = 0;
        }
    }
}