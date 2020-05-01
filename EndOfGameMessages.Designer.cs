namespace Chess___netanel
{
    partial class EndOfGameMessages
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.MoveStackText = new System.Windows.Forms.TextBox();
            this.TitleLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // MoveStackText
            // 
            this.MoveStackText.BackColor = System.Drawing.Color.LightGray;
            this.MoveStackText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.MoveStackText.Location = new System.Drawing.Point(56, 65);
            this.MoveStackText.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MoveStackText.Multiline = true;
            this.MoveStackText.Name = "MoveStackText";
            this.MoveStackText.ReadOnly = true;
            this.MoveStackText.Size = new System.Drawing.Size(580, 561);
            this.MoveStackText.TabIndex = 0;
            // 
            // TitleLbl
            // 
            this.TitleLbl.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.TitleLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TitleLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.TitleLbl.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.TitleLbl.Location = new System.Drawing.Point(196, 15);
            this.TitleLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.TitleLbl.Name = "TitleLbl";
            this.TitleLbl.Size = new System.Drawing.Size(292, 45);
            this.TitleLbl.TabIndex = 1;
            this.TitleLbl.Text = "Moves in game:";
            this.TitleLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // EndOfGameMessages
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(707, 656);
            this.Controls.Add(this.TitleLbl);
            this.Controls.Add(this.MoveStackText);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "EndOfGameMessages";
            this.Text = "---";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EndOfGameMessages_FormClosing);
            this.Load += new System.EventHandler(this.EndOfGameMessages_Load);
            this.Shown += new System.EventHandler(this.EndOfGameMessages_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox MoveStackText;
        private System.Windows.Forms.Label TitleLbl;
    }
}