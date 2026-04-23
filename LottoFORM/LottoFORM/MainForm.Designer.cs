namespace LottoFORM
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pnlHeader = new Panel();
            lblTurn = new Label();
            lblCurrentNum = new Label();
            pnlRight = new Panel();
            lstHistory = new ListBox();
            lblStatus = new Label();
            pnlButtons = new Panel();
            btnDraw = new Button();
            btnNext = new Button();
            btnReset = new Button();
            tblCard = new TableLayoutPanel();
            pnlHeader.SuspendLayout();
            pnlRight.SuspendLayout();
            pnlButtons.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.Controls.Add(lblTurn);
            pnlHeader.Controls.Add(lblCurrentNum);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Margin = new Padding(3, 4, 3, 4);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Padding = new Padding(11, 13, 11, 13);
            pnlHeader.Size = new Size(1284, 80);
            pnlHeader.TabIndex = 0;
            // 
            // lblTurn
            // 
            lblTurn.Dock = DockStyle.Left;
            lblTurn.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTurn.Location = new Point(11, 13);
            lblTurn.Name = "lblTurn";
            lblTurn.Size = new Size(343, 54);
            lblTurn.TabIndex = 0;
            lblTurn.Text = "Ходит: ";
            lblTurn.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblCurrentNum
            // 
            lblCurrentNum.Dock = DockStyle.Right;
            lblCurrentNum.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblCurrentNum.Location = new Point(930, 13);
            lblCurrentNum.Name = "lblCurrentNum";
            lblCurrentNum.Size = new Size(343, 54);
            lblCurrentNum.TabIndex = 1;
            lblCurrentNum.Text = "00";
            lblCurrentNum.TextAlign = ContentAlignment.MiddleRight;
            // 
            // pnlRight
            // 
            pnlRight.Controls.Add(lstHistory);
            pnlRight.Controls.Add(lblStatus);
            pnlRight.Dock = DockStyle.Right;
            pnlRight.Location = new Point(1092, 80);
            pnlRight.Margin = new Padding(3, 4, 3, 4);
            pnlRight.Name = "pnlRight";
            pnlRight.Padding = new Padding(11, 13, 11, 13);
            pnlRight.Size = new Size(192, 620);
            pnlRight.TabIndex = 1;
            // 
            // lstHistory
            // 
            lstHistory.Dock = DockStyle.Fill;
            lstHistory.Font = new Font("Consolas", 11F);
            lstHistory.FormattingEnabled = true;
            lstHistory.Location = new Point(11, 53);
            lstHistory.Margin = new Padding(3, 4, 3, 4);
            lstHistory.Name = "lstHistory";
            lstHistory.SelectionMode = SelectionMode.None;
            lstHistory.Size = new Size(170, 554);
            lstHistory.TabIndex = 0;
            // 
            // lblStatus
            // 
            lblStatus.Dock = DockStyle.Top;
            lblStatus.Font = new Font("Segoe UI", 11F);
            lblStatus.Location = new Point(11, 13);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(170, 40);
            lblStatus.TabIndex = 1;
            lblStatus.Text = "Ожидание...";
            lblStatus.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlButtons
            // 
            pnlButtons.Controls.Add(btnDraw);
            pnlButtons.Controls.Add(btnNext);
            pnlButtons.Controls.Add(btnReset);
            pnlButtons.Location = new Point(0, 544);
            pnlButtons.Margin = new Padding(3, 4, 3, 4);
            pnlButtons.Name = "pnlButtons";
            pnlButtons.Padding = new Padding(11, 13, 11, 13);
            pnlButtons.Size = new Size(1097, 161);
            pnlButtons.TabIndex = 2;
            // 
            // btnDraw
            // 
            btnDraw.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnDraw.Location = new Point(11, 17);
            btnDraw.Margin = new Padding(3, 4, 3, 4);
            btnDraw.Name = "btnDraw";
            btnDraw.Size = new Size(297, 47);
            btnDraw.TabIndex = 0;
            btnDraw.Text = "🎲 Вытянуть число";
            btnDraw.UseVisualStyleBackColor = true;
            btnDraw.Click += btnDraw_Click;
            // 
            // btnNext
            // 
            btnNext.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnNext.Location = new Point(11, 67);
            btnNext.Margin = new Padding(3, 4, 3, 4);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(297, 47);
            btnNext.TabIndex = 1;
            btnNext.Text = "🔄 Следующий игрок";
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += btnNext_Click;
            // 
            // btnReset
            // 
            btnReset.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnReset.Location = new Point(320, 13);
            btnReset.Margin = new Padding(3, 4, 3, 4);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(297, 100);
            btnReset.TabIndex = 2;
            btnReset.Text = "🔙 Выйти в меню";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += btnReset_Click;
            // 
            // tblCard
            // 
            tblCard.Anchor = AnchorStyles.None;
            tblCard.CellBorderStyle = TableLayoutPanelCellBorderStyle.OutsetDouble;
            tblCard.ColumnCount = 9;
            tblCard.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 112F));
            tblCard.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 127F));
            tblCard.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 101F));
            tblCard.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 104F));
            tblCard.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 115F));
            tblCard.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 122F));
            tblCard.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 138F));
            tblCard.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 136F));
            tblCard.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 48F));
            tblCard.Location = new Point(0, 80);
            tblCard.Margin = new Padding(3, 4, 3, 4);
            tblCard.Name = "tblCard";
            tblCard.RowCount = 3;
            tblCard.RowStyles.Add(new RowStyle(SizeType.Absolute, 148F));
            tblCard.RowStyles.Add(new RowStyle(SizeType.Absolute, 158F));
            tblCard.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tblCard.Size = new Size(1097, 463);
            tblCard.TabIndex = 3;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1284, 700);
            Controls.Add(pnlButtons);
            Controls.Add(pnlRight);
            Controls.Add(tblCard);
            Controls.Add(pnlHeader);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "🎲 Лото | Мультиплеер";
            pnlHeader.ResumeLayout(false);
            pnlRight.ResumeLayout(false);
            pnlButtons.ResumeLayout(false);
            ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlHeader, pnlRight, pnlButtons;
        private System.Windows.Forms.Label lblTurn, lblCurrentNum, lblStatus;
        private System.Windows.Forms.ListBox lstHistory;
        private System.Windows.Forms.Button btnDraw, btnNext, btnReset;
        private System.Windows.Forms.TableLayoutPanel tblCard;
    }
}