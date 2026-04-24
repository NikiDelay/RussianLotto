using LottoLIB;
using System.Reflection;

namespace LottoFORM
{
    public partial class MainForm : Form
    {
        private static readonly Color bgDark = Color.FromArgb(30, 30, 47);
        private static readonly Color bgPanel = Color.FromArgb(42, 42, 61);
        private static readonly Color accent = Color.FromArgb(0, 180, 216);
        private static readonly Color success = Color.FromArgb(46, 204, 113);

        private LottoGame game;
        private List<Label> cardLabels = new List<Label>();
        private Action onReturnToMenu;
        private bool currentTurnDrawn = false;
        private bool isReturningToMenu = false;

        public MainForm()
        {
            InitializeComponent();

            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            this.UpdateStyles();

            EnableDoubleBuffering(tblCard);
            EnableDoubleBuffering(pnlHeader);
            EnableDoubleBuffering(pnlRight);
            EnableDoubleBuffering(pnlButtons);
        }

        private void EnableDoubleBuffering(Control ctrl)
        {
            var prop = ctrl.GetType().GetProperty("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance);
            prop?.SetValue(ctrl, true, null);
        }

        public void InitializeGame(IEnumerable<string> playerNames, Action onReturnToMenuCallback)
        {
            if (playerNames == null) throw new ArgumentNullException(nameof(playerNames));
            onReturnToMenu = onReturnToMenuCallback;

            SetupCardLabels();
            ApplyTheme();

            game = new LottoGame(playerNames);
            game.NumberDrawn += OnNumberDrawn;
            game.TurnChanged += OnTurnChanged;
            game.PlayerWon += OnPlayerWon;

            currentTurnDrawn = false;
            UpdateTurnDisplay();

            btnDraw.Enabled = true;
            btnNext.Enabled = true;
        }

        private void SetupCardLabels()
        {
            // 1. Сбрасываем старые стили и контролы
            tblCard.ColumnStyles.Clear();
            tblCard.RowStyles.Clear();
            tblCard.Controls.Clear();
            cardLabels.Clear();

            // 2. Задаём равномерное процентное распределение
            // 9 колонок = каждая ~11.11%, 3 строки = каждая ~33.33%
            for (int i = 0; i < 9; i++)
                tblCard.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f / 9f));
            for (int i = 0; i < 3; i++)
                tblCard.RowStyles.Add(new RowStyle(SizeType.Percent, 100f / 3f));

            tblCard.SuspendLayout();

            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    var lbl = new Label
                    {
                        Dock = DockStyle.Fill,
                        Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                        BackColor = Color.FromArgb(50, 50, 70),
                        ForeColor = Color.Silver,
                        TextAlign = ContentAlignment.MiddleCenter,
                        Margin = new Padding(1) // Минимальный отступ для чёткой сетки
                    };
                    tblCard.Controls.Add(lbl, col, row);
                    cardLabels.Add(lbl);
                }
            }
            tblCard.ResumeLayout(true);
        }

        private void ApplyTheme()
        {
            this.BackColor = bgDark;
            pnlHeader.BackColor = bgPanel;
            pnlRight.BackColor = bgPanel;
            tblCard.BackColor = bgPanel;
            lblTurn.ForeColor = accent;
            lblCurrentNum.ForeColor = Color.White;
            lblStatus.ForeColor = Color.White;
            lstHistory.BackColor = Color.FromArgb(35, 35, 52);
            lstHistory.ForeColor = Color.LightGray;
            pnlButtons.BackColor = bgDark;
            btnDraw.BackColor = accent;
            btnDraw.ForeColor = Color.White;
            btnNext.BackColor = Color.FromArgb(255, 193, 7);
            btnNext.ForeColor = Color.White;
            btnReset.BackColor = Color.FromArgb(231, 76, 60);
            btnReset.ForeColor = Color.White;
        }

        private void UpdateTurnDisplay()
        {
            lblTurn.Text = $"👤 Turn: {game.CurrentPlayer.Name}";
            currentTurnDrawn = false;
            UpdateCardGrid();
        }

        private void UpdateCardGrid()
        {
            int i = 0;
            foreach (var lbl in cardLabels)
            {
                int row = i / 9;
                int col = i % 9;
                int num = game.CurrentPlayer.Card.Numbers[row, col];
                bool marked = game.CurrentPlayer.Card.Marked[row, col];

                lbl.Text = num == 0 ? "" : num.ToString();
                lbl.BackColor = marked ? success : (num == game.LastDrawnNumber && num != 0 ? accent : Color.FromArgb(50, 50, 70));
                lbl.ForeColor = marked ? Color.White : Color.Silver;
                i++;
            }
        }

        private void btnDraw_Click(object sender, EventArgs e)
        {
            if (game.IsGameOver) return;

            if (currentTurnDrawn)
            {
                MessageBox.Show("You have already drawn a number this turn! Pass the turn to the next player.", "Turn Completed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            currentTurnDrawn = true;
            game.DrawNext();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (game.IsGameOver) return;
            game.NextTurn();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            isReturningToMenu = true;
            onReturnToMenu?.Invoke();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (!isReturningToMenu)
            {
                if (game != null)
                {
                    game.NumberDrawn -= OnNumberDrawn;
                    game.TurnChanged -= OnTurnChanged;
                    game.PlayerWon -= OnPlayerWon;
                }
                Environment.Exit(0);
            }
        }

        private void OnNumberDrawn(int num)
        {
            this.Invoke(new Action(() =>
            {
                lblCurrentNum.Text = num.ToString("D2");
                lstHistory.Items.Insert(0, num.ToString("D2"));
                if (lstHistory.Items.Count > 50) lstHistory.Items.RemoveAt(50);
                UpdateCardGrid();
                bool hasMatch = game.CurrentPlayer.Card.ContainsNumber(num);
                lblStatus.Text = hasMatch ? "✅ Match!" : "❌ No match";
            }));
        }

        private void OnTurnChanged(Player player)
        {
            this.Invoke(new Action(() => UpdateTurnDisplay()));
        }

        private void OnPlayerWon(List<Player> winners)
        {
            this.Invoke(new Action(() =>
            {
                btnDraw.Enabled = false;
                btnNext.Enabled = false;

                string winnerNames = string.Join(" and ", winners.Select(w => w.Name));
                bool isTie = winners.Count > 1;

                lblStatus.Text = isTie
                    ? $"🏆 Draw! {winnerNames} won!"
                    : $"🏆 {winners[0].Name} WINS!";
                lblStatus.ForeColor = success;

                string message = isTie
                    ? $"Congratulations! {winnerNames} completed their cards simultaneously with number {game.LastDrawnNumber}."
                    : $"Congratulations! {winners[0].Name} has completed the card!";

                MessageBox.Show(message, isTie ? "Draw!" : "Victory!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }));
        }
    }
}