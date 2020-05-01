namespace Chess___netanel
{
    partial class PromotionDialog
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
            this.PromotePromptTitleLbl = new System.Windows.Forms.Label();
            this.PromoteToQueenBtn = new System.Windows.Forms.Button();
            this.PromoteToRookBtn = new System.Windows.Forms.Button();
            this.PromoteToBishopBtn = new System.Windows.Forms.Button();
            this.PromoteToKnightBtn = new System.Windows.Forms.Button();
            this.PromotionPanel = new System.Windows.Forms.Panel();
            this.PromotionPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // PromotePromptTitleLbl
            // 
            this.PromotePromptTitleLbl.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.PromotePromptTitleLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PromotePromptTitleLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.PromotePromptTitleLbl.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.PromotePromptTitleLbl.Location = new System.Drawing.Point(11, 32);
            this.PromotePromptTitleLbl.Name = "PromotePromptTitleLbl";
            this.PromotePromptTitleLbl.Size = new System.Drawing.Size(90, 76);
            this.PromotePromptTitleLbl.TabIndex = 17;
            this.PromotePromptTitleLbl.Text = "Promote pawn to:";
            this.PromotePromptTitleLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PromoteToQueenBtn
            // 
            this.PromoteToQueenBtn.BackColor = System.Drawing.Color.Silver;
            this.PromoteToQueenBtn.BackgroundImage = global::Chess___netanel.Properties.Resources.B_Queen;
            this.PromoteToQueenBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PromoteToQueenBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.PromoteToQueenBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.PromoteToQueenBtn.ForeColor = System.Drawing.Color.Black;
            this.PromoteToQueenBtn.Location = new System.Drawing.Point(105, 76);
            this.PromoteToQueenBtn.Name = "PromoteToQueenBtn";
            this.PromoteToQueenBtn.Size = new System.Drawing.Size(49, 47);
            this.PromoteToQueenBtn.TabIndex = 20;
            this.PromoteToQueenBtn.UseVisualStyleBackColor = false;
            this.PromoteToQueenBtn.Click += new System.EventHandler(this.PromoteToQueenBtn_Click);
            // 
            // PromoteToRookBtn
            // 
            this.PromoteToRookBtn.BackColor = System.Drawing.Color.Silver;
            this.PromoteToRookBtn.BackgroundImage = global::Chess___netanel.Properties.Resources.B_Rook;
            this.PromoteToRookBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PromoteToRookBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.PromoteToRookBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.PromoteToRookBtn.ForeColor = System.Drawing.Color.Black;
            this.PromoteToRookBtn.Location = new System.Drawing.Point(160, 76);
            this.PromoteToRookBtn.Name = "PromoteToRookBtn";
            this.PromoteToRookBtn.Size = new System.Drawing.Size(48, 47);
            this.PromoteToRookBtn.TabIndex = 21;
            this.PromoteToRookBtn.UseVisualStyleBackColor = false;
            this.PromoteToRookBtn.Click += new System.EventHandler(this.PromoteToRookButton_Click);
            // 
            // PromoteToBishopBtn
            // 
            this.PromoteToBishopBtn.BackColor = System.Drawing.Color.Silver;
            this.PromoteToBishopBtn.BackgroundImage = global::Chess___netanel.Properties.Resources.B_Bishop;
            this.PromoteToBishopBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PromoteToBishopBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.PromoteToBishopBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.PromoteToBishopBtn.ForeColor = System.Drawing.Color.Black;
            this.PromoteToBishopBtn.Location = new System.Drawing.Point(105, 23);
            this.PromoteToBishopBtn.Name = "PromoteToBishopBtn";
            this.PromoteToBishopBtn.Size = new System.Drawing.Size(49, 47);
            this.PromoteToBishopBtn.TabIndex = 22;
            this.PromoteToBishopBtn.UseVisualStyleBackColor = false;
            this.PromoteToBishopBtn.Click += new System.EventHandler(this.PromoteToBishopBtn_Click);
            // 
            // PromoteToKnightBtn
            // 
            this.PromoteToKnightBtn.BackColor = System.Drawing.Color.Silver;
            this.PromoteToKnightBtn.BackgroundImage = global::Chess___netanel.Properties.Resources.B_Knight;
            this.PromoteToKnightBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PromoteToKnightBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.PromoteToKnightBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.PromoteToKnightBtn.ForeColor = System.Drawing.Color.Black;
            this.PromoteToKnightBtn.Location = new System.Drawing.Point(159, 23);
            this.PromoteToKnightBtn.Name = "PromoteToKnightBtn";
            this.PromoteToKnightBtn.Size = new System.Drawing.Size(49, 47);
            this.PromoteToKnightBtn.TabIndex = 23;
            this.PromoteToKnightBtn.UseVisualStyleBackColor = false;
            this.PromoteToKnightBtn.Click += new System.EventHandler(this.PromoteToKnightBtn_Click);
            // 
            // PromotionPanel
            // 
            this.PromotionPanel.BackColor = System.Drawing.Color.Red;
            this.PromotionPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PromotionPanel.Controls.Add(this.PromoteToKnightBtn);
            this.PromotionPanel.Controls.Add(this.PromoteToBishopBtn);
            this.PromotionPanel.Controls.Add(this.PromoteToRookBtn);
            this.PromotionPanel.Controls.Add(this.PromoteToQueenBtn);
            this.PromotionPanel.Controls.Add(this.PromotePromptTitleLbl);
            this.PromotionPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PromotionPanel.Location = new System.Drawing.Point(0, 0);
            this.PromotionPanel.Name = "PromotionPanel";
            this.PromotionPanel.Size = new System.Drawing.Size(220, 146);
            this.PromotionPanel.TabIndex = 22;
            this.PromotionPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.PromotionPanel_Paint);
            // 
            // PromotionDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(220, 146);
            this.Controls.Add(this.PromotionPanel);
            this.Name = "PromotionDialog";
            this.Text = "Promote";
            this.PromotionPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label PromotePromptTitleLbl;
        private System.Windows.Forms.Button PromoteToQueenBtn;
        private System.Windows.Forms.Button PromoteToRookBtn;
        private System.Windows.Forms.Button PromoteToBishopBtn;
        private System.Windows.Forms.Button PromoteToKnightBtn;
        private System.Windows.Forms.Panel PromotionPanel;
    }
}