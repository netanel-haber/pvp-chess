namespace Chess___netanel
{
    partial class UI
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
            this.BlackGrp = new System.Windows.Forms.GroupBox();
            this.BlackTimerLbl = new System.Windows.Forms.Label();
            this.WhiteGrp = new System.Windows.Forms.GroupBox();
            this.WhiteTimerLbl = new System.Windows.Forms.Label();
            this.ResignBtn = new System.Windows.Forms.Button();
            this.RequestDrawBtn = new System.Windows.Forms.Button();
            this.TurnLabelTitleLbl = new System.Windows.Forms.Label();
            this.TurnLbl = new System.Windows.Forms.Label();
            this.DrawRequestTitleLbl = new System.Windows.Forms.Label();
            this.YesToDrawRequestBtn = new System.Windows.Forms.Button();
            this.NoToDrawRequestBtn = new System.Windows.Forms.Button();
            this.DrawRequestPanel = new System.Windows.Forms.Panel();
            this.PieceCurrentlyGrabbedLbl = new System.Windows.Forms.Label();
            this.PieceCurrentlyGrabbedTitleLbl = new System.Windows.Forms.Label();
            this.Board = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BlackGrp.SuspendLayout();
            this.WhiteGrp.SuspendLayout();
            this.DrawRequestPanel.SuspendLayout();
            this.Board.SuspendLayout();
            this.SuspendLayout();
            // 
            // BlackGrp
            // 
            this.BlackGrp.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BlackGrp.Controls.Add(this.BlackTimerLbl);
            this.BlackGrp.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.BlackGrp.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.BlackGrp.Location = new System.Drawing.Point(659, 12);
            this.BlackGrp.Name = "BlackGrp";
            this.BlackGrp.Size = new System.Drawing.Size(123, 67);
            this.BlackGrp.TabIndex = 5;
            this.BlackGrp.TabStop = false;
            this.BlackGrp.Text = "Black Status";
            // 
            // BlackTimerLbl
            // 
            this.BlackTimerLbl.AutoSize = true;
            this.BlackTimerLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.BlackTimerLbl.Location = new System.Drawing.Point(32, 30);
            this.BlackTimerLbl.Name = "BlackTimerLbl";
            this.BlackTimerLbl.Size = new System.Drawing.Size(55, 24);
            this.BlackTimerLbl.TabIndex = 0;
            this.BlackTimerLbl.Text = "30:00";
            // 
            // WhiteGrp
            // 
            this.WhiteGrp.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.WhiteGrp.Controls.Add(this.WhiteTimerLbl);
            this.WhiteGrp.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.WhiteGrp.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.WhiteGrp.Location = new System.Drawing.Point(660, 587);
            this.WhiteGrp.Name = "WhiteGrp";
            this.WhiteGrp.Size = new System.Drawing.Size(122, 67);
            this.WhiteGrp.TabIndex = 6;
            this.WhiteGrp.TabStop = false;
            this.WhiteGrp.Text = "White Status";
            // 
            // WhiteTimerLbl
            // 
            this.WhiteTimerLbl.AutoSize = true;
            this.WhiteTimerLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.WhiteTimerLbl.Location = new System.Drawing.Point(31, 28);
            this.WhiteTimerLbl.Name = "WhiteTimerLbl";
            this.WhiteTimerLbl.Size = new System.Drawing.Size(55, 24);
            this.WhiteTimerLbl.TabIndex = 0;
            this.WhiteTimerLbl.Text = "30:00";
            // 
            // ResignBtn
            // 
            this.ResignBtn.BackColor = System.Drawing.Color.Silver;
            this.ResignBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ResignBtn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ResignBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.ResignBtn.ForeColor = System.Drawing.Color.Transparent;
            this.ResignBtn.Location = new System.Drawing.Point(672, 320);
            this.ResignBtn.Name = "ResignBtn";
            this.ResignBtn.Size = new System.Drawing.Size(172, 33);
            this.ResignBtn.TabIndex = 3;
            this.ResignBtn.TabStop = false;
            this.ResignBtn.Text = "Resign!";
            this.ResignBtn.UseVisualStyleBackColor = false;
            this.ResignBtn.Click += new System.EventHandler(this.ResignBtn_Click);
            // 
            // RequestDrawBtn
            // 
            this.RequestDrawBtn.BackColor = System.Drawing.Color.Transparent;
            this.RequestDrawBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.RequestDrawBtn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.RequestDrawBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.RequestDrawBtn.Location = new System.Drawing.Point(671, 366);
            this.RequestDrawBtn.Name = "RequestDrawBtn";
            this.RequestDrawBtn.Size = new System.Drawing.Size(172, 33);
            this.RequestDrawBtn.TabIndex = 4;
            this.RequestDrawBtn.TabStop = false;
            this.RequestDrawBtn.Text = "Request Draw";
            this.RequestDrawBtn.UseVisualStyleBackColor = false;
            this.RequestDrawBtn.Click += new System.EventHandler(this.RequestDrawButton_Click);
            // 
            // TurnLabelTitleLbl
            // 
            this.TurnLabelTitleLbl.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.TurnLabelTitleLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TurnLabelTitleLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.TurnLabelTitleLbl.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.TurnLabelTitleLbl.Location = new System.Drawing.Point(671, 203);
            this.TurnLabelTitleLbl.Name = "TurnLabelTitleLbl";
            this.TurnLabelTitleLbl.Size = new System.Drawing.Size(90, 29);
            this.TurnLabelTitleLbl.TabIndex = 0;
            this.TurnLabelTitleLbl.Text = "To Move:";
            this.TurnLabelTitleLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TurnLbl
            // 
            this.TurnLbl.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.TurnLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TurnLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.TurnLbl.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.TurnLbl.Location = new System.Drawing.Point(775, 203);
            this.TurnLbl.Name = "TurnLbl";
            this.TurnLbl.Size = new System.Drawing.Size(68, 29);
            this.TurnLbl.TabIndex = 12;
            this.TurnLbl.Text = "White";
            this.TurnLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DrawRequestTitleLbl
            // 
            this.DrawRequestTitleLbl.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.DrawRequestTitleLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DrawRequestTitleLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.DrawRequestTitleLbl.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.DrawRequestTitleLbl.Location = new System.Drawing.Point(9, 5);
            this.DrawRequestTitleLbl.Name = "DrawRequestTitleLbl";
            this.DrawRequestTitleLbl.Size = new System.Drawing.Size(90, 58);
            this.DrawRequestTitleLbl.TabIndex = 1;
            this.DrawRequestTitleLbl.Text = "Agree to draw?";
            this.DrawRequestTitleLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // YesToDrawRequestBtn
            // 
            this.YesToDrawRequestBtn.BackColor = System.Drawing.Color.Silver;
            this.YesToDrawRequestBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.YesToDrawRequestBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.YesToDrawRequestBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.YesToDrawRequestBtn.ForeColor = System.Drawing.Color.Black;
            this.YesToDrawRequestBtn.Location = new System.Drawing.Point(105, 20);
            this.YesToDrawRequestBtn.Name = "YesToDrawRequestBtn";
            this.YesToDrawRequestBtn.Size = new System.Drawing.Size(35, 35);
            this.YesToDrawRequestBtn.TabIndex = 2;
            this.YesToDrawRequestBtn.Text = "Y";
            this.YesToDrawRequestBtn.UseVisualStyleBackColor = false;
            this.YesToDrawRequestBtn.Click += new System.EventHandler(this.YesToDrawRequestBtn_Click);
            // 
            // NoToDrawRequestBtn
            // 
            this.NoToDrawRequestBtn.BackColor = System.Drawing.Color.Silver;
            this.NoToDrawRequestBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.NoToDrawRequestBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.NoToDrawRequestBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.NoToDrawRequestBtn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.NoToDrawRequestBtn.Location = new System.Drawing.Point(146, 20);
            this.NoToDrawRequestBtn.Name = "NoToDrawRequestBtn";
            this.NoToDrawRequestBtn.Size = new System.Drawing.Size(35, 35);
            this.NoToDrawRequestBtn.TabIndex = 0;
            this.NoToDrawRequestBtn.Text = "N";
            this.NoToDrawRequestBtn.UseVisualStyleBackColor = false;
            this.NoToDrawRequestBtn.Click += new System.EventHandler(this.NoToDrawRequestBtn_Click);
            // 
            // DrawRequestPanel
            // 
            this.DrawRequestPanel.BackColor = System.Drawing.Color.Red;
            this.DrawRequestPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DrawRequestPanel.Controls.Add(this.NoToDrawRequestBtn);
            this.DrawRequestPanel.Controls.Add(this.YesToDrawRequestBtn);
            this.DrawRequestPanel.Controls.Add(this.DrawRequestTitleLbl);
            this.DrawRequestPanel.Location = new System.Drawing.Point(662, 402);
            this.DrawRequestPanel.Name = "DrawRequestPanel";
            this.DrawRequestPanel.Size = new System.Drawing.Size(188, 70);
            this.DrawRequestPanel.TabIndex = 20;
            this.DrawRequestPanel.Visible = false;
            // 
            // PieceCurrentlyGrabbedLbl
            // 
            this.PieceCurrentlyGrabbedLbl.BackColor = System.Drawing.Color.LightCyan;
            this.PieceCurrentlyGrabbedLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PieceCurrentlyGrabbedLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.PieceCurrentlyGrabbedLbl.Location = new System.Drawing.Point(744, 280);
            this.PieceCurrentlyGrabbedLbl.Name = "PieceCurrentlyGrabbedLbl";
            this.PieceCurrentlyGrabbedLbl.Size = new System.Drawing.Size(32, 27);
            this.PieceCurrentlyGrabbedLbl.TabIndex = 21;
            this.PieceCurrentlyGrabbedLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.PieceCurrentlyGrabbedLbl.Click += new System.EventHandler(this.PieceCurrentlyGrabbed_Click);
            // 
            // PieceCurrentlyGrabbedTitleLbl
            // 
            this.PieceCurrentlyGrabbedTitleLbl.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.PieceCurrentlyGrabbedTitleLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PieceCurrentlyGrabbedTitleLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.PieceCurrentlyGrabbedTitleLbl.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.PieceCurrentlyGrabbedTitleLbl.Location = new System.Drawing.Point(671, 246);
            this.PieceCurrentlyGrabbedTitleLbl.Name = "PieceCurrentlyGrabbedTitleLbl";
            this.PieceCurrentlyGrabbedTitleLbl.Size = new System.Drawing.Size(172, 29);
            this.PieceCurrentlyGrabbedTitleLbl.TabIndex = 22;
            this.PieceCurrentlyGrabbedTitleLbl.Text = "Piece currently grabbed:";
            this.PieceCurrentlyGrabbedTitleLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Board
            // 
            this.Board.BackColor = System.Drawing.Color.Transparent;
            this.Board.BackgroundImage = global::Chess___netanel.Properties.Resources.Board;
            this.Board.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Board.Controls.Add(this.label13);
            this.Board.Controls.Add(this.label14);
            this.Board.Controls.Add(this.label15);
            this.Board.Controls.Add(this.label16);
            this.Board.Controls.Add(this.label11);
            this.Board.Controls.Add(this.label12);
            this.Board.Controls.Add(this.label10);
            this.Board.Controls.Add(this.label9);
            this.Board.Controls.Add(this.label7);
            this.Board.Controls.Add(this.label8);
            this.Board.Controls.Add(this.label5);
            this.Board.Controls.Add(this.label6);
            this.Board.Controls.Add(this.label3);
            this.Board.Controls.Add(this.label4);
            this.Board.Controls.Add(this.label2);
            this.Board.Controls.Add(this.label1);
            this.Board.Location = new System.Drawing.Point(12, 12);
            this.Board.Name = "Board";
            this.Board.Size = new System.Drawing.Size(642, 642);
            this.Board.TabIndex = 14;
            this.Board.Click += new System.EventHandler(this.Board_Click);
            this.Board.Paint += new System.Windows.Forms.PaintEventHandler(this.Board_Paint);
            this.Board.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Board_MouseClick);
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label13.Location = new System.Drawing.Point(4, 50);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(21, 20);
            this.label13.TabIndex = 34;
            this.label13.Text = "8";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label14.Location = new System.Drawing.Point(3, 123);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(21, 20);
            this.label14.TabIndex = 33;
            this.label14.Text = "7";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label15.Location = new System.Drawing.Point(4, 202);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(21, 20);
            this.label15.TabIndex = 32;
            this.label15.Text = "6";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label16.Location = new System.Drawing.Point(3, 275);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(21, 20);
            this.label16.TabIndex = 31;
            this.label16.Text = "5";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label11.Location = new System.Drawing.Point(3, 350);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(21, 20);
            this.label11.TabIndex = 30;
            this.label11.Text = "4";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label12.Location = new System.Drawing.Point(2, 423);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(21, 20);
            this.label12.TabIndex = 29;
            this.label12.Text = "3";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label10.Location = new System.Drawing.Point(3, 502);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(21, 20);
            this.label10.TabIndex = 28;
            this.label10.Text = "2";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label9.Location = new System.Drawing.Point(2, 575);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(21, 20);
            this.label9.TabIndex = 27;
            this.label9.Text = "1";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label7.Location = new System.Drawing.Point(574, 619);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(21, 20);
            this.label7.TabIndex = 26;
            this.label7.Text = "h";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label8.Location = new System.Drawing.Point(500, 619);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(21, 20);
            this.label8.TabIndex = 25;
            this.label8.Text = "g";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label5.Location = new System.Drawing.Point(424, 619);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 20);
            this.label5.TabIndex = 24;
            this.label5.Text = "f";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label6.Location = new System.Drawing.Point(350, 619);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(21, 20);
            this.label6.TabIndex = 23;
            this.label6.Text = "e";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label3.Location = new System.Drawing.Point(274, 619);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 20);
            this.label3.TabIndex = 22;
            this.label3.Text = "d";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label4.Location = new System.Drawing.Point(200, 619);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 20);
            this.label4.TabIndex = 21;
            this.label4.Text = "c";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label2.Location = new System.Drawing.Point(122, 619);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 20);
            this.label2.TabIndex = 20;
            this.label2.Text = "b";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.Location = new System.Drawing.Point(48, 619);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 20);
            this.label1.TabIndex = 19;
            this.label1.Text = "a";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Sienna;
            this.ClientSize = new System.Drawing.Size(863, 666);
            this.Controls.Add(this.PieceCurrentlyGrabbedTitleLbl);
            this.Controls.Add(this.PieceCurrentlyGrabbedLbl);
            this.Controls.Add(this.BlackGrp);
            this.Controls.Add(this.DrawRequestPanel);
            this.Controls.Add(this.TurnLbl);
            this.Controls.Add(this.TurnLabelTitleLbl);
            this.Controls.Add(this.RequestDrawBtn);
            this.Controls.Add(this.ResignBtn);
            this.Controls.Add(this.WhiteGrp);
            this.Controls.Add(this.Board);
            this.Name = "UI";
            this.Text = "Chess PVP";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UI_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.UI_Shown);
            this.BlackGrp.ResumeLayout(false);
            this.BlackGrp.PerformLayout();
            this.WhiteGrp.ResumeLayout(false);
            this.WhiteGrp.PerformLayout();
            this.DrawRequestPanel.ResumeLayout(false);
            this.Board.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox BlackGrp;
        private System.Windows.Forms.Label BlackTimerLbl;
        private System.Windows.Forms.GroupBox WhiteGrp;
        private System.Windows.Forms.Label WhiteTimerLbl;
        private System.Windows.Forms.Button ResignBtn;
        private System.Windows.Forms.Button RequestDrawBtn;
        private System.Windows.Forms.Label TurnLabelTitleLbl;
        private System.Windows.Forms.Label TurnLbl;
        private System.Windows.Forms.Panel Board;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label DrawRequestTitleLbl;
        private System.Windows.Forms.Button YesToDrawRequestBtn;
        private System.Windows.Forms.Button NoToDrawRequestBtn;
        private System.Windows.Forms.Panel DrawRequestPanel;
        private System.Windows.Forms.Label PieceCurrentlyGrabbedLbl;
        private System.Windows.Forms.Label PieceCurrentlyGrabbedTitleLbl;
    }
}

