namespace Tic_Tac_Toe
{
    partial class frmTTT
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
			this.pbxGame = new System.Windows.Forms.PictureBox();
			this.btnStart = new System.Windows.Forms.Button();
			this.btnClose = new System.Windows.Forms.Button();
			this.lblJogadores = new System.Windows.Forms.Label();
			this.lblScore = new System.Windows.Forms.Label();
			this.lblPlr1 = new System.Windows.Forms.Label();
			this.lblPlr2 = new System.Windows.Forms.Label();
			this.lblScr2 = new System.Windows.Forms.Label();
			this.lblScr1 = new System.Windows.Forms.Label();
			this.txtPlr1 = new System.Windows.Forms.TextBox();
			this.txtPlr2 = new System.Windows.Forms.TextBox();
			this.lblAppName = new System.Windows.Forms.Label();
			this.lblAppVersion = new System.Windows.Forms.Label();
			this.lblAppAuthor = new System.Windows.Forms.Label();
			this.lblAppCprt = new System.Windows.Forms.Label();
			this.lblTotalPlayed = new System.Windows.Forms.Label();
			this.lblTotalScr = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// pbxGame
			// 
			this.pbxGame.Location = new System.Drawing.Point(0, 0);
			this.pbxGame.Name = "pbxGame";
			this.pbxGame.Size = new System.Drawing.Size(314, 247);
			this.pbxGame.Click += new System.EventHandler(this.pbxGame_Click);
			// 
			// btnStart
			// 
			this.btnStart.Location = new System.Drawing.Point(391, 198);
			this.btnStart.Name = "btnStart";
			this.btnStart.Size = new System.Drawing.Size(82, 20);
			this.btnStart.TabIndex = 1;
			this.btnStart.Text = "New Game";
			this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
			// 
			// btnClose
			// 
			this.btnClose.Location = new System.Drawing.Point(391, 224);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(82, 20);
			this.btnClose.TabIndex = 2;
			this.btnClose.Text = "Close";
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// lblJogadores
			// 
			this.lblJogadores.Location = new System.Drawing.Point(321, 18);
			this.lblJogadores.Name = "lblJogadores";
			this.lblJogadores.Size = new System.Drawing.Size(75, 20);
			this.lblJogadores.Text = "Jogadores:";
			// 
			// lblScore
			// 
			this.lblScore.Location = new System.Drawing.Point(407, 18);
			this.lblScore.Name = "lblScore";
			this.lblScore.Size = new System.Drawing.Size(66, 20);
			this.lblScore.Text = "Score:";
			// 
			// lblPlr1
			// 
			this.lblPlr1.Location = new System.Drawing.Point(336, 48);
			this.lblPlr1.Name = "lblPlr1";
			this.lblPlr1.Size = new System.Drawing.Size(75, 20);
			this.lblPlr1.Text = "Player1:";
			// 
			// lblPlr2
			// 
			this.lblPlr2.Location = new System.Drawing.Point(336, 79);
			this.lblPlr2.Name = "lblPlr2";
			this.lblPlr2.Size = new System.Drawing.Size(75, 20);
			this.lblPlr2.Text = "Player2:";
			// 
			// lblScr2
			// 
			this.lblScr2.Location = new System.Drawing.Point(445, 79);
			this.lblScr2.Name = "lblScr2";
			this.lblScr2.Size = new System.Drawing.Size(28, 20);
			this.lblScr2.Text = "0";
			// 
			// lblScr1
			// 
			this.lblScr1.Location = new System.Drawing.Point(445, 48);
			this.lblScr1.Name = "lblScr1";
			this.lblScr1.Size = new System.Drawing.Size(28, 20);
			this.lblScr1.Text = "0";
			// 
			// txtPlr1
			// 
			this.txtPlr1.Location = new System.Drawing.Point(336, 48);
			this.txtPlr1.MaxLength = 10;
			this.txtPlr1.Name = "txtPlr1";
			this.txtPlr1.Size = new System.Drawing.Size(75, 23);
			this.txtPlr1.TabIndex = 7;
			// 
			// txtPlr2
			// 
			this.txtPlr2.Location = new System.Drawing.Point(336, 79);
			this.txtPlr2.MaxLength = 10;
			this.txtPlr2.Name = "txtPlr2";
			this.txtPlr2.Size = new System.Drawing.Size(75, 23);
			this.txtPlr2.TabIndex = 8;
			// 
			// lblAppName
			// 
			this.lblAppName.Location = new System.Drawing.Point(320, 154);
			this.lblAppName.Name = "lblAppName";
			this.lblAppName.Size = new System.Drawing.Size(152, 20);
			this.lblAppName.Text = "Tic Tac Toe Pro";
			this.lblAppName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// lblAppVersion
			// 
			this.lblAppVersion.Location = new System.Drawing.Point(320, 134);
			this.lblAppVersion.Name = "lblAppVersion";
			this.lblAppVersion.Size = new System.Drawing.Size(152, 20);
			// 
			// lblAppAuthor
			// 
			this.lblAppAuthor.Location = new System.Drawing.Point(320, 175);
			this.lblAppAuthor.Name = "lblAppAuthor";
			this.lblAppAuthor.Size = new System.Drawing.Size(152, 20);
			this.lblAppAuthor.Text = "Augusto Lange";
			// 
			// lblAppCprt
			// 
			this.lblAppCprt.Location = new System.Drawing.Point(320, 198);
			this.lblAppCprt.Name = "lblAppCprt";
			this.lblAppCprt.Size = new System.Drawing.Size(65, 46);
			this.lblAppCprt.Text = "Copyright © 2011";
			// 
			// lblTotalPlayed
			// 
			this.lblTotalPlayed.Location = new System.Drawing.Point(320, 112);
			this.lblTotalPlayed.Name = "lblTotalPlayed";
			this.lblTotalPlayed.Size = new System.Drawing.Size(91, 20);
			this.lblTotalPlayed.Text = "Total Jogado: ";
			// 
			// lblTotalScr
			// 
			this.lblTotalScr.Location = new System.Drawing.Point(444, 112);
			this.lblTotalScr.Name = "lblTotalScr";
			this.lblTotalScr.Size = new System.Drawing.Size(28, 20);
			this.lblTotalScr.Text = "0";
			// 
			// frmTTT
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.SystemColors.ActiveBorder;
			this.ClientSize = new System.Drawing.Size(478, 247);
			this.ControlBox = false;
			this.Controls.Add(this.lblTotalScr);
			this.Controls.Add(this.lblTotalPlayed);
			this.Controls.Add(this.lblAppCprt);
			this.Controls.Add(this.lblAppAuthor);
			this.Controls.Add(this.lblAppVersion);
			this.Controls.Add(this.lblAppName);
			this.Controls.Add(this.txtPlr2);
			this.Controls.Add(this.txtPlr1);
			this.Controls.Add(this.lblScr1);
			this.Controls.Add(this.lblScr2);
			this.Controls.Add(this.lblPlr2);
			this.Controls.Add(this.lblPlr1);
			this.Controls.Add(this.lblScore);
			this.Controls.Add(this.lblJogadores);
			this.Controls.Add(this.btnClose);
			this.Controls.Add(this.btnStart);
			this.Controls.Add(this.pbxGame);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "frmTTT";
			this.Text = "Tic Tac Toe Pro";
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbxGame;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblJogadores;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Label lblPlr1;
        private System.Windows.Forms.Label lblPlr2;
        private System.Windows.Forms.Label lblScr2;
        private System.Windows.Forms.Label lblScr1;
        private System.Windows.Forms.TextBox txtPlr1;
        private System.Windows.Forms.TextBox txtPlr2;
        private System.Windows.Forms.Label lblAppName;
        private System.Windows.Forms.Label lblAppVersion;
        private System.Windows.Forms.Label lblAppAuthor;
        private System.Windows.Forms.Label lblAppCprt;
		private System.Windows.Forms.Label lblTotalPlayed;
		private System.Windows.Forms.Label lblTotalScr;
    }
}

