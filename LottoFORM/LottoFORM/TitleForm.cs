using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace LottoFORM
{
    public partial class TitleForm : Form
    {
        public TitleForm()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            EnableDoubleBuffering(flowNames);
            this.FormClosing += (s, e) => Environment.Exit(0);
            UpdateNameInputs();
        }

        private void EnableDoubleBuffering(Control ctrl)
        {
            var prop = ctrl.GetType().GetProperty("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance);
            prop?.SetValue(ctrl, true, null);
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
                    Text = $"Player {i + 1}",
                    Font = new Font("Segoe UI", 10F)
                };
                flowNames.Controls.Add(txt);
            }
        }

        private void numPlayerCount_ValueChanged(object sender, EventArgs e) => UpdateNameInputs();

        private void btnStart_Click(object sender, EventArgs e)
        {
            var playerNames = new List<string>();
            foreach (Control ctrl in flowNames.Controls)
            {
                if (ctrl is TextBox txt && !string.IsNullOrWhiteSpace(txt.Text))
                    playerNames.Add(txt.Text.Trim());
            }

            if (playerNames.Count < 2)
            {
                MessageBox.Show("Please enter names for all players (minimum 2).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var gameForm = new MainForm();
            gameForm.InitializeGame(playerNames, () =>
            {
                this.Show();
                gameForm.Close();
            });

            gameForm.Show(this);
            this.Hide();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            string helpText = "🎲 Russian Lotto Rules\n\n" +
                              "• Each player gets a 3×9 card with 15 random numbers (1–90).\n" +
                              "• Players take turns. Click 'Draw Number' ONCE per turn.\n" +
                              "• Matching numbers are automatically marked in green.\n" +
                              "• First to cover ALL numbers wins.\n" +
                              "• If multiple players finish simultaneously → Draw.\n" +
                              "• Use 'Next Player' to pass the turn.\n\n" +
                              "🍀 Good luck!";
            MessageBox.Show(helpText, "Game Rules", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}