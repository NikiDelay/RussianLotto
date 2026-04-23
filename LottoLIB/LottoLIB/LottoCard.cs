namespace LottoLIB
{
    public class LottoCard
    {
        public int[,] Numbers { get; private set; } = new int[3, 9];
        public bool[,] Marked { get; private set; } = new bool[3, 9];

        public LottoCard() => Generate();

        private void Generate()
        {
            var rnd = new Random();
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 9; j++) { Numbers[i, j] = 0; Marked[i, j] = false; }

            var colPools = new List<int>[9];
            for (int j = 0; j < 9; j++)
            {
                int start = j == 0 ? 1 : j * 10;
                int count = j == 8 ? 11 : 10;
                colPools[j] = Enumerable.Range(start, count).ToList();
            }

            for (int i = 0; i < 3; i++)
            {
                var cols = Enumerable.Range(0, 9).OrderBy(x => rnd.Next()).Take(5).ToList();
                foreach (int c in cols)
                {
                    int idx = rnd.Next(colPools[c].Count);
                    Numbers[i, c] = colPools[c][idx];
                    colPools[c].RemoveAt(idx);
                }
            }
        }

        public bool ContainsNumber(int number)
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 9; j++)
                    if (Numbers[i, j] == number) return true;
            return false;
        }

        public void MarkNumber(int number)
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 9; j++)
                    if (Numbers[i, j] == number) Marked[i, j] = true;
        }

        public bool IsFullyCovered()
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 9; j++)
                    if (Numbers[i, j] != 0 && !Marked[i, j]) return false;
            return true;
        }
    }
}