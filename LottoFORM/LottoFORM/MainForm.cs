using LottoLIB;

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

        public MainForm()
        {
            InitializeComponent();
        }

        public void InitializeGame(IEnumerable<string> playerNames)
        {
            if (playerNames == null) throw new ArgumentNullException(nameof(playerNames));

            SetupCardLabels();
            ApplyTheme();

            game = new LottoGame(playerNames);
            game.NumberDrawn += OnNumberDrawn;
            game.TurnChanged += OnTurnChanged;
            game.PlayerWon += OnPlayerWon;

            UpdateTurnDisplay();

            btnDraw.Enabled = true;
            btnNext.Enabled = true;
        }

        private void SetupCardLabels()
        {
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
                        Margin = new Padding(2)
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
            lblTurn.Text = $"👤 Ходит: {game.CurrentPlayer.Name}";
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

        private void btnDraw_Click(object sender, EventArgs e) => game.DrawNext();
        private void btnNext_Click(object sender, EventArgs e) => game.NextTurn();
        private void btnReset_Click(object sender, EventArgs e) => this.Close();

        private void OnNumberDrawn(int num)
        {
            this.Invoke(new Action(() =>
            {
                lblCurrentNum.Text = num.ToString("D2");
                lstHistory.Items.Insert(0, num.ToString("D2"));
                if (lstHistory.Items.Count > 50) lstHistory.Items.RemoveAt(50);
                UpdateCardGrid();
                bool hasMatch = game.CurrentPlayer.Card.ContainsNumber(num);
                lblStatus.Text = hasMatch ? "✅ Совпадение!" : "❌ Нет совпадения";
            }));
        }

        private void OnTurnChanged(Player player)
        {
            this.Invoke(new Action(() => UpdateTurnDisplay()));
        }

        private void OnPlayerWon(Player player)
        {
            this.Invoke(new Action(() =>
            {
                btnDraw.Enabled = false;
                btnNext.Enabled = false;
                lblStatus.Text = $"🏆 {player.Name} ВЫИГРАЛ!";
                lblStatus.ForeColor = success;
                MessageBox.Show($"Поздравляем! {player.Name} полностью закрыл карточку!", "Победа", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }));
        }
    }
}