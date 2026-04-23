namespace LottoLIB
{
    public class LottoGame
    {
        public List<Player> Players { get; } = new();
        private int currentPlayerIndex = 0;
        private readonly List<int> remainingNumbers = new();
        private readonly Random randomGenerator = new();
        public int LastDrawnNumber { get; private set; }
        public bool IsGameOver { get; private set; }

        public Player CurrentPlayer => Players[currentPlayerIndex];
        public int RemainingCount => remainingNumbers.Count;

        public event Action<int>? NumberDrawn;
        public event Action<Player>? TurnChanged;
        public event Action<List<Player>>? PlayerWon;

        public LottoGame(IEnumerable<string> playerNames)
        {
            foreach (var name in playerNames) Players.Add(new Player(name));
            remainingNumbers.AddRange(Enumerable.Range(1, 90));
            currentPlayerIndex = 0;
            TurnChanged?.Invoke(CurrentPlayer);
        }

        public void DrawNext()
        {
            if (IsGameOver || remainingNumbers.Count == 0) return;

            int index = randomGenerator.Next(remainingNumbers.Count);
            LastDrawnNumber = remainingNumbers[index];
            remainingNumbers.RemoveAt(index);

            foreach (var player in Players) player.MarkNumber(LastDrawnNumber);
            NumberDrawn?.Invoke(LastDrawnNumber);

            var currentWinners = Players.Where(p => !p.HasWon && p.CheckWin()).ToList();

            if (currentWinners.Count > 0)
            {
                IsGameOver = true;
                PlayerWon?.Invoke(currentWinners);
            }
        }

        public void NextTurn()
        {
            if (IsGameOver || Players.Count <= 1) return;
            currentPlayerIndex = (currentPlayerIndex + 1) % Players.Count;
            TurnChanged?.Invoke(CurrentPlayer);
        }

        public void Reset()
        {
            remainingNumbers.Clear();
            remainingNumbers.AddRange(Enumerable.Range(1, 90));
            LastDrawnNumber = 0;
            currentPlayerIndex = 0;
            IsGameOver = false;
            foreach (var player in Players) player.Reset();
            TurnChanged?.Invoke(CurrentPlayer);
        }
    }
}