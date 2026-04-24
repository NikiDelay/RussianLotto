namespace LottoFORM
{
    partial class TitleForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblTitle = new Label();
            lblHint = new Label();
            numPlayerCount = new NumericUpDown();
            flowNames = new FlowLayoutPanel();
            btnStart = new Button();
            btnHelp = new Button();
            ((System.ComponentModel.ISupportInitialize)numPlayerCount).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Showcard Gothic", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = SystemColors.HighlightText;
            lblTitle.Location = new Point(12, 44);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(363, 46);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "🎲 Russian Lotto";
            // 
            // lblHint
            // 
            lblHint.AutoSize = true;
            lblHint.Font = new Font("Showcard Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblHint.ForeColor = SystemColors.HighlightText;
            lblHint.Location = new Point(30, 140);
            lblHint.Name = "lblHint";
            lblHint.Size = new Size(238, 21);
            lblHint.TabIndex = 1;
            lblHint.Text = "Select number of players";
            // 
            // numPlayerCount
            // 
            numPlayerCount.Font = new Font("Segoe UI", 12F);
            numPlayerCount.Location = new Point(274, 133);
            numPlayerCount.Margin = new Padding(3, 4, 3, 4);
            numPlayerCount.Maximum = new decimal(new int[] { 4, 0, 0, 0 });
            numPlayerCount.Minimum = new decimal(new int[] { 2, 0, 0, 0 });
            numPlayerCount.Name = "numPlayerCount";
            numPlayerCount.Size = new Size(69, 34);
            numPlayerCount.TabIndex = 0;
            numPlayerCount.Value = new decimal(new int[] { 2, 0, 0, 0 });
            numPlayerCount.ValueChanged += numPlayerCount_ValueChanged;
            // 
            // flowNames
            // 
            flowNames.FlowDirection = FlowDirection.TopDown;
            flowNames.Location = new Point(46, 193);
            flowNames.Margin = new Padding(3, 4, 3, 4);
            flowNames.Name = "flowNames";
            flowNames.Size = new Size(297, 240);
            flowNames.TabIndex = 1;
            // 
            // btnStart
            // 
            btnStart.BackColor = Color.FromArgb(46, 204, 113);
            btnStart.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnStart.ForeColor = Color.White;
            btnStart.Location = new Point(46, 453);
            btnStart.Margin = new Padding(3, 4, 3, 4);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(297, 53);
            btnStart.TabIndex = 2;
            btnStart.Text = "🚀 Start Game";
            btnStart.UseVisualStyleBackColor = false;
            btnStart.Click += btnStart_Click;
            // 
            // btnHelp
            // 
            btnHelp.BackColor = Color.FromArgb(70, 80, 100);
            btnHelp.Font = new Font("Segoe UI", 10F);
            btnHelp.ForeColor = Color.White;
            btnHelp.Location = new Point(46, 510);
            btnHelp.Name = "btnHelp";
            btnHelp.Size = new Size(297, 40);
            btnHelp.TabIndex = 3;
            btnHelp.Text = "❓ Help & Rules";
            btnHelp.UseVisualStyleBackColor = false;
            btnHelp.Click += btnHelp_Click;
            // 
            // TitleForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 30, 47);
            ClientSize = new Size(389, 560);
            Controls.Add(lblTitle);
            Controls.Add(lblHint);
            Controls.Add(numPlayerCount);
            Controls.Add(flowNames);
            Controls.Add(btnStart);
            Controls.Add(btnHelp);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "TitleForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Game setttings";
            ((System.ComponentModel.ISupportInitialize)numPlayerCount).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblHint;
        private System.Windows.Forms.NumericUpDown numPlayerCount;
        private System.Windows.Forms.FlowLayoutPanel flowNames;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnHelp;
    }
}