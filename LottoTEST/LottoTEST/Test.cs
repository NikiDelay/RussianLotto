using LottoLIB;

namespace LottoTests
{
    [TestClass]
    public class LottoCardTests
    {
        [TestMethod]
        public void GenerateCard_ShouldHaveCorrectDimensions()
        {
            var card = new LottoCard();
            Assert.AreEqual(3, card.Numbers.GetLength(0));
            Assert.AreEqual(9, card.Numbers.GetLength(1));
        }

        [TestMethod]
        public void GenerateCard_ShouldHaveExactly15Numbers()
        {
            var card = new LottoCard();
            int count = 0;
            for (int r = 0; r < 3; r++)
                for (int c = 0; c < 9; c++)
                    if (card.Numbers[r, c] != 0) count++;

            Assert.AreEqual(15, count);
        }

        [TestMethod]
        public void GenerateCard_NumbersShouldBeInCorrectRanges()
        {
            var card = new LottoCard();
            for (int c = 0; c < 9; c++)
                for (int r = 0; r < 3; r++)
                {
                    int num = card.Numbers[r, c];
                    if (num == 0) continue;

                    if (c == 0) Assert.IsTrue(num is >= 1 and <= 10);
                    else if (c == 8) Assert.IsTrue(num is >= 80 and <= 90);
                    else Assert.IsTrue(num >= c * 10 && num < (c + 1) * 10);
                }
        }

        [TestMethod]
        public void ContainsNumber_ShouldReturnTrueForExistingNumber()
        {
            var card = new LottoCard();
            int testNum = GetFirstNonZeroNumber(card.Numbers);
            Assert.IsTrue(card.ContainsNumber(testNum));
        }

        [TestMethod]
        public void ContainsNumber_ShouldReturnFalseForMissingNumber()
        {
            var card = new LottoCard();
            Assert.IsFalse(card.ContainsNumber(99));
        }

        [TestMethod]
        public void MarkNumber_ShouldMarkCorrectCell()
        {
            var card = new LottoCard();
            int testNum = GetFirstNonZeroNumber(card.Numbers);
            card.MarkNumber(testNum);

            bool isMarked = false;
            for (int r = 0; r < 3; r++)
                for (int c = 0; c < 9; c++)
                    if (card.Numbers[r, c] == testNum && card.Marked[r, c]) isMarked = true;

            Assert.IsTrue(isMarked);
        }

        [TestMethod]
        public void IsFullyCovered_ShouldReturnFalseInitially()
        {
            Assert.IsFalse(new LottoCard().IsFullyCovered());
        }

        [TestMethod]
        public void IsFullyCovered_ShouldReturnTrueWhenAllMarked()
        {
            var card = new LottoCard();
            for (int r = 0; r < 3; r++)
                for (int c = 0; c < 9; c++)
                    if (card.Numbers[r, c] != 0) card.MarkNumber(card.Numbers[r, c]);

            Assert.IsTrue(card.IsFullyCovered());
        }

        private int GetFirstNonZeroNumber(int[,] numbers)
        {
            for (int r = 0; r < numbers.GetLength(0); r++)
                for (int c = 0; c < numbers.GetLength(1); c++)
                    if (numbers[r, c] != 0) return numbers[r, c];

            throw new InvalidOperationException("Card contains no numbers.");
        }
    }
    [TestClass]
    public class PlayerTests
    {
        [TestMethod]
        public void Player_ShouldInitializeWithNameAndCard()
        {
            var player = new Player("Alice");
            Assert.AreEqual("Alice", player.Name);
            Assert.IsNotNull(player.Card);
            Assert.IsFalse(player.HasWon);
            Assert.AreEqual(0, player.CoveredCount);
        }

        [TestMethod]
        public void MarkNumber_ShouldIncreaseCoveredCount()
        {
            var player = new Player("Bob");
            int num = GetFirstNonZeroNumber(player.Card.Numbers);
            player.MarkNumber(num);
            Assert.AreEqual(1, player.CoveredCount);
        }

        [TestMethod]
        public void MarkNumber_ShouldNotIncreaseForMissingNumber()
        {
            var player = new Player("Bob");
            int initial = player.CoveredCount;
            player.MarkNumber(99);
            Assert.AreEqual(initial, player.CoveredCount);
        }

        [TestMethod]
        public void CheckWin_ShouldReturnFalseWhenNotCovered()
        {
            var player = new Player("Charlie");
            Assert.IsFalse(player.CheckWin());
            Assert.IsFalse(player.HasWon);
        }

        [TestMethod]
        public void CheckWin_ShouldReturnTrueWhenFullyCovered()
        {
            var player = new Player("Charlie");
            for (int r = 0; r < 3; r++)
                for (int c = 0; c < 9; c++)
                    if (player.Card.Numbers[r, c] != 0)
                        player.Card.MarkNumber(player.Card.Numbers[r, c]);

            Assert.IsTrue(player.CheckWin());
            Assert.IsTrue(player.HasWon);
        }

        [TestMethod]
        public void Reset_ShouldClearState()
        {
            var player = new Player("Dave");
            for (int r = 0; r < 3; r++)
                for (int c = 0; c < 9; c++)
                    if (player.Card.Numbers[r, c] != 0)
                        player.Card.MarkNumber(player.Card.Numbers[r, c]);

            player.CheckWin();
            Assert.IsTrue(player.HasWon);

            player.Reset();

            Assert.AreEqual(0, player.CoveredCount);
            Assert.IsFalse(player.HasWon);
            Assert.IsNotNull(player.Card);
        }

        private int GetFirstNonZeroNumber(int[,] numbers)
        {
            for (int r = 0; r < numbers.GetLength(0); r++)
                for (int c = 0; c < numbers.GetLength(1); c++)
                    if (numbers[r, c] != 0) return numbers[r, c];

            throw new InvalidOperationException("Card contains no numbers.");
        }
    }
    [TestClass]
    public class LottoGameTests
    {
        [TestMethod]
        public void Game_ShouldInitializeWithPlayers()
        {
            // Arrange & Act
            var game = new LottoGame(new[] { "P1", "P2" });

            // Assert
            Assert.AreEqual(2, game.Players.Count);
            Assert.AreEqual(90, game.RemainingCount);
            Assert.IsFalse(game.IsGameOver);
        }

        [TestMethod]
        public void DrawNext_ShouldDecreaseRemainingCount()
        {
            // Arrange
            var game = new LottoGame(new[] { "P1" });
            int before = game.RemainingCount;

            // Act
            game.DrawNext();

            // Assert
            Assert.AreEqual(before - 1, game.RemainingCount);
            Assert.AreNotEqual(0, game.LastDrawnNumber);
        }

        [TestMethod]
        public void DrawNext_ShouldMarkNumbersOnAllCards()
        {
            // Arrange
            var game = new LottoGame(new[] { "P1", "P2" });
            game.DrawNext();
            int drawn = game.LastDrawnNumber;

            // Assert
            foreach (var p in game.Players)
            {
                if (p.Card.ContainsNumber(drawn))
                {
                    bool marked = false;
                    for (int r = 0; r < 3; r++)
                        for (int c = 0; c < 9; c++)
                            if (p.Card.Numbers[r, c] == drawn && p.Card.Marked[r, c]) marked = true;
                    Assert.IsTrue(marked, $"Player {p.Name} should have {drawn} marked");
                }
            }
        }

        [TestMethod]
        public void DrawNext_ShouldTriggerWinAndStopGame()
        {
            // Arrange
            var game = new LottoGame(new[] { "Winner" });
            var player = game.Players[0];
            // Force win by marking all
            for (int r = 0; r < 3; r++)
                for (int c = 0; c < 9; c++)
                    if (player.Card.Numbers[r, c] != 0) player.Card.MarkNumber(player.Card.Numbers[r, c]);

            // Act
            bool eventFired = false;
            game.PlayerWon += winners => eventFired = true;
            game.DrawNext(); // Any number will trigger check

            // Assert
            Assert.IsTrue(eventFired);
            Assert.IsTrue(game.IsGameOver);
            Assert.IsTrue(player.HasWon);
        }

        [TestMethod]
        public void DrawNext_ShouldHandleTie()
        {
            // Arrange
            var game = new LottoGame(new[] { "P1", "P2" });
            foreach (var p in game.Players)
                for (int r = 0; r < 3; r++)
                    for (int c = 0; c < 9; c++)
                        if (p.Card.Numbers[r, c] != 0) p.Card.MarkNumber(p.Card.Numbers[r, c]);

            // Act
            System.Collections.Generic.List<Player> winners = null;
            game.PlayerWon += w => winners = w;
            game.DrawNext();

            // Assert
            Assert.IsNotNull(winners);
            Assert.AreEqual(2, winners.Count);
            Assert.IsTrue(game.IsGameOver);
        }

        [TestMethod]
        public void NextTurn_ShouldRotatePlayers()
        {
            // Arrange
            var game = new LottoGame(new[] { "P1", "P2", "P3" });
            var first = game.CurrentPlayer;

            // Act
            game.NextTurn();
            var second = game.CurrentPlayer;
            game.NextTurn();
            var third = game.CurrentPlayer;
            game.NextTurn();
            var fourth = game.CurrentPlayer; // Back to first

            // Assert
            Assert.AreNotEqual(first.Name, second.Name);
            Assert.AreNotEqual(second.Name, third.Name);
            Assert.AreEqual(first.Name, fourth.Name);
        }

        [TestMethod]
        public void Reset_ShouldRestoreInitialState()
        {
            // Arrange
            var game = new LottoGame(new[] { "P1" });
            game.DrawNext();
            game.NextTurn();

            // Act
            game.Reset();

            // Assert
            Assert.AreEqual(90, game.RemainingCount);
            Assert.AreEqual(0, game.LastDrawnNumber);
            Assert.IsFalse(game.IsGameOver);
            Assert.AreEqual(0, game.Players[0].CoveredCount);
        }
    }
}