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
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblHint = new System.Windows.Forms.Label();
            this.numPlayerCount = new System.Windows.Forms.NumericUpDown();
            this.flowNames = new System.Windows.Forms.FlowLayoutPanel();
            this.btnStart = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numPlayerCount)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(40, 30);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Text = "🎲 Русское Лото";
            // 
            // lblHint
            // 
            this.lblHint.AutoSize = true;
            this.lblHint.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblHint.Location = new System.Drawing.Point(40, 70);
            this.lblHint.Name = "lblHint";
            this.lblHint.Text = "Выберите количество игроков:";
            // 
            // numPlayerCount
            // 
            this.numPlayerCount.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.numPlayerCount.Location = new System.Drawing.Point(40, 100);
            this.numPlayerCount.Maximum = 4;
            this.numPlayerCount.Minimum = 2;
            this.numPlayerCount.Name = "numPlayerCount";
            this.numPlayerCount.Size = new System.Drawing.Size(60, 29);
            this.numPlayerCount.TabIndex = 0;
            this.numPlayerCount.Value = 2;
            this.numPlayerCount.ValueChanged += new System.EventHandler(this.numPlayerCount_ValueChanged);
            // 
            // flowNames
            // 
            this.flowNames.Location = new System.Drawing.Point(40, 145);
            this.flowNames.Name = "flowNames";
            this.flowNames.Size = new System.Drawing.Size(260, 180);
            this.flowNames.TabIndex = 1;
            this.flowNames.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnStart.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnStart.ForeColor = System.Drawing.Color.White;
            this.btnStart.Location = new System.Drawing.Point(40, 340);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(260, 40);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "🚀 Начать игру";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // StartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(47)))));
            this.ClientSize = new System.Drawing.Size(340, 400);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblHint);
            this.Controls.Add(this.numPlayerCount);
            this.Controls.Add(this.flowNames);
            this.Controls.Add(this.btnStart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "StartForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Настройка игры";
            ((System.ComponentModel.ISupportInitialize)(this.numPlayerCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblHint;
        private System.Windows.Forms.NumericUpDown numPlayerCount;
        private System.Windows.Forms.FlowLayoutPanel flowNames;
        private System.Windows.Forms.Button btnStart;
    }
}