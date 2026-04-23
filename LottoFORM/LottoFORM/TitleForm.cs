namespace LottoFORM
{
    public partial class TitleForm : Form
    {
        public TitleForm()
        {
            InitializeComponent();
            UpdateNameInputs();
        }

        private void UpdateNameInputs()
        {
            flowNames.Controls.Clear();
            int count = (int)numPlayerCount.Value;
            for (int i = 0; i < count; i++)
            {
                var txt = new TextBox
                {
                    Width = 220,
                    Margin = new Padding(5),
                    Text = $"Игрок {i + 1}",
                    Font = new Font("Segoe UI", 10F)
                };
                flowNames.Controls.Add(txt);
            }
        }

        private void numPlayerCount_ValueChanged(object sender, EventArgs e) => UpdateNameInputs();

        private void btnStart_Click(object sender, EventArgs e)
        {
            // 1. Объявляем переменную здесь, чтобы она существовала в контексте
            var playerNames = new List<string>();
            foreach (Control ctrl in flowNames.Controls)
            {
                if (ctrl is TextBox txt && !string.IsNullOrWhiteSpace(txt.Text))
                    playerNames.Add(txt.Text.Trim());
            }

            // 2. Проверка
            if (playerNames.Count < 2)
            {
                MessageBox.Show("Введите имена для всех игроков (минимум 2).", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 3. Создание формы и передача данных
            var gameForm = new MainForm();
            gameForm.InitializeGame(playerNames); // Вызываем наш метод
            gameForm.Show();
            this.Hide();
            gameForm.FormClosed += (s, args) => this.Close();
        }
    }
}