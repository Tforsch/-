namespace WinFormsApp1
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblLevel = new System.Windows.Forms.Label();
            this.lblHp = new System.Windows.Forms.Label();
            this.pbHp = new System.Windows.Forms.ProgressBar();
            this.lblXp = new System.Windows.Forms.Label();
            this.pbXp = new System.Windows.Forms.ProgressBar();
            this.clbHabits = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // lblLevel
            // 
            this.lblLevel.AutoSize = true;
            this.lblLevel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblLevel.Location = new System.Drawing.Point(12, 9);
            this.lblLevel.Name = "lblLevel";
            this.lblLevel.Size = new System.Drawing.Size(68, 21);
            this.lblLevel.TabIndex = 0;
            this.lblLevel.Text = "Level: 1";
            // 
            // lblHp
            // 
            this.lblHp.AutoSize = true;
            this.lblHp.Location = new System.Drawing.Point(12, 40);
            this.lblHp.Name = "lblHp";
            this.lblHp.Size = new System.Drawing.Size(56, 15);
            this.lblHp.TabIndex = 1;
            this.lblHp.Text = "HP: 100 / 100";
            // 
            // pbHp
            // 
            this.pbHp.ForeColor = System.Drawing.Color.Red;
            this.pbHp.Location = new System.Drawing.Point(15, 58);
            this.pbHp.Name = "pbHp";
            this.pbHp.Size = new System.Drawing.Size(200, 23);
            this.pbHp.TabIndex = 2;
            this.pbHp.Value = 100;
            // 
            // lblXp
            // 
            this.lblXp.AutoSize = true;
            this.lblXp.Location = new System.Drawing.Point(12, 94);
            this.lblXp.Name = "lblXp";
            this.lblXp.Size = new System.Drawing.Size(43, 15);
            this.lblXp.TabIndex = 3;
            this.lblXp.Text = "XP: 0 / 100";
            // 
            // pbXp
            // 
            this.pbXp.ForeColor = System.Drawing.Color.Blue;
            this.pbXp.Location = new System.Drawing.Point(15, 112);
            this.pbXp.Name = "pbXp";
            this.pbXp.Size = new System.Drawing.Size(200, 23);
            this.pbXp.TabIndex = 4;
            // 
            // clbHabits
            // 
            this.clbHabits.FormattingEnabled = true;
            this.clbHabits.Location = new System.Drawing.Point(15, 151);
            this.clbHabits.Name = "clbHabits";
            this.clbHabits.Size = new System.Drawing.Size(200, 148);
            this.clbHabits.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(234, 311);
            this.Controls.Add(this.clbHabits);
            this.Controls.Add(this.pbXp);
            this.Controls.Add(this.lblXp);
            this.Controls.Add(this.pbHp);
            this.Controls.Add(this.lblHp);
            this.Controls.Add(this.lblLevel);
            this.Name = "Form1";
            this.Text = "Habit Tracker";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblLevel;
        private System.Windows.Forms.Label lblHp;
        private System.Windows.Forms.ProgressBar pbHp;
        private System.Windows.Forms.Label lblXp;
        private System.Windows.Forms.ProgressBar pbXp;
        private System.Windows.Forms.CheckedListBox clbHabits;
    }
}
