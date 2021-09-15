/*******************************************************
 * Tic Tac Toe Pro
 * 
 * Creator: Augusto Lange
 * 
 * Last Change: 07/03/2012
 * Version: 1.03
 *  
 * ****************************************************/
/*****************************************************
 *  Version 1.01:
 *  
 *  Date: 15/04/2011
 * 
 * - Code the Idea;
 * - Form with the components for Win CE 6.0;
 * - Creation of the Logic of the Game;
 * - Creation of the Player's class;
 * - Using the Picture Box to Display an Image in Windows CE 6.0. 
 * 
 *****************************************************/
/*****************************************************
 *  Version 1.02:
 *  
 *  Date: 18/04/2011
 * 
 * - Correction of Some Bugs:
 *		- Bug Occurs by clicking on a rectangle already marked, then the program pass the turn;
 *		- Bug Occured by still playing after clicking on the button to stop the game.
 * - Changing some colors letters;
 * - Adding the Program Name, Version, Copyright and Author strings.
 * 
 *****************************************************/
/*****************************************************
 *  Version 1.03:
 *  
 *  Date: 07/03/2012
 * 
 * - Added The Total Game Played.
 * 
 *****************************************************/

using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using System.IO;

namespace Tic_Tac_Toe
{
    public partial class frmTTT : Form
    {
        public const int Grid = 3;
        private Graphics MyGraphics;
        private int Largura;
        private int Altura;
        private bool changes;
        private List<Rectangle> lstRectanges;
        private int[] Play;
        private Player Plr1;
        private Player Plr2;
		private int CountGames;
		private String strHistoryFileName;

        private delegate void UpdateStatusDelegate();

        private Thread MyThread;

        public frmTTT()
        {
            InitializeComponent();

			CountGames = 0;

            MyGraphics = this.pbxGame.CreateGraphics();

            LoadImage();

            lblAppVersion.Text = "Version 1.03";

            changes = true;
            btnClose.Enabled = true;
            Play = new int[9];

            //Start();

			//MyThread = new Thread(new ThreadStart(this.threadEntry));
			//MyThread.IsBackground = true;
			//MyThread.Priority = ThreadPriority.Highest;
			//MyThread.Start();
        }

        private void threadEntry()
        {
            while (changes)
            {
                doUpdate();

                Thread.Sleep(16);
            }
        }

        private void doUpdate()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new UpdateStatusDelegate(doUpdate), new object[] { });
                return;
            }

            this.Start();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (btnClose.Enabled)
            {
                //MyThread.Abort();
                this.Close();
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (btnClose.Enabled)
            {
				Plr1 = new Player(true, txtPlr1.Text != String.Empty ? txtPlr1.Text : "Player 1");
				Plr2 = new Player(false, txtPlr2.Text != String.Empty ? txtPlr2.Text : "Player 2");

                Plr1.Letter = "O";
                Plr2.Letter = "X";

                lblScr1.Text = Plr1.Score.ToString();
                lblScr2.Text = Plr2.Score.ToString();

                lblPlr1.Text = Plr1.Name + ":";
                lblPlr2.Text = Plr2.Name + ":";

                txtPlr1.Hide();
                txtPlr2.Hide();

                txtPlr1.Enabled = false;
                txtPlr2.Enabled = false;

                btnClose.Enabled = false;

                btnStart.Text = "Stop Game";

				changes = true;

				CreateHistory();
                Start();
                Victory();
            }
            else
            {
                Play = new int[9];

                txtPlr1.Text = Plr1.Name;
                txtPlr2.Text = Plr2.Name;

                txtPlr1.Enabled = true;
                txtPlr2.Enabled = true;

                txtPlr1.Show();
                txtPlr2.Show();

                btnClose.Enabled = true;

                btnStart.Text = "New Game";

				StringBuilder sbHeader = new StringBuilder();
				sbHeader.AppendFormat("{0} e {1} Finalizaram o Jogo em {2}:\n\n", Plr1.Name, Plr2.Name, DateTime.Today.ToString("dd/MM/yyyy"));
				StreamWriter swHistory = new StreamWriter(strHistoryFileName, true);
				swHistory.WriteLine(sbHeader);
				swHistory.Close();

                LoadImage();
            }
        }

		private void CreateHistory()
		{
			int countFiles = 1;

			strHistoryFileName = "\\SDMMC\\History\\" + Plr1.Name + " VS " + Plr2.Name + " " + countFiles.ToString() + ".txt";

			if (!Directory.Exists("\\SDMMC\\History"))
				Directory.CreateDirectory("\\SDMMC\\History");

			while (File.Exists(strHistoryFileName))
			{
				countFiles++;
				strHistoryFileName = "\\SDMMC\\History\\" + Plr1.Name + " VS " + Plr2.Name + " " + countFiles.ToString() + ".txt";
			}

			StreamWriter swHistory = new StreamWriter(strHistoryFileName, false);
			swHistory.Close();
		}

        private void LoadImage()
        {
            MyGraphics.Clear(Color.Black);

			if (File.Exists("\\SDMMC\\Images\\Pic.jpg"))
			{
				pbxGame.Image = new Bitmap("\\SDMMC\\Images\\Pic.jpg");
				pbxGame.SizeMode = PictureBoxSizeMode.CenterImage;
			}
        }

        private void Start()
        {
            if (changes)
            {
				StringBuilder sbHeader = new StringBuilder();
                Rectangle rect;
                lstRectanges = new List<Rectangle>();

				StreamWriter swHistory = new StreamWriter(strHistoryFileName, true);

                Altura = this.pbxGame.Height / Grid;
                Largura = this.pbxGame.Width / Grid;

                Play = new int[9];

                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        rect = new Rectangle(Largura * j, Altura * i, (Largura * (j + 1)) - (Largura * j) , (Altura * (i + 1)) - (Altura * i));
                        lstRectanges.Add(rect);
                    }
                }

                MyGraphics.Clear(Color.Black);

                MyGraphics.DrawLine(new Pen(Color.Cyan), Largura, 0, Largura, this.pbxGame.Height);
                MyGraphics.DrawLine(new Pen(Color.Cyan), Largura * 2, 0, Largura * 2, this.pbxGame.Height);
                MyGraphics.DrawLine(new Pen(Color.Cyan), 0, Altura, this.pbxGame.Width, Altura);
                MyGraphics.DrawLine(new Pen(Color.Cyan), 0, Altura * 2, this.pbxGame.Width, Altura * 2);

                changes = false;

				sbHeader.AppendFormat("{0} e {1} Iniciaram um Jogo em {2}:\n\n", Plr1.Name, Plr2.Name, DateTime.Today.ToString("dd/MM/yyyy"));
				swHistory.Write(sbHeader);
				swHistory.Close();
            }
        }

        private void Victory()
        {
            int game = 0;

            if ((Play[0] == Play[1]) && (Play[0] == Play[2]) && (Play[1] == Play[2]) && (Play[0] != 0) && (Play[1] != 0) && (Play[2] != 0))
                game = 1;
            else if ((Play[3] == Play[4]) && (Play[3] == Play[5]) && (Play[4] == Play[5]) && (Play[3] != 0) && (Play[4] != 0) && (Play[5] != 0))
                game = 2;
            else if ((Play[6] == Play[7]) && (Play[6] == Play[8]) && (Play[7] == Play[8]) && (Play[6] != 0) && (Play[7] != 0) && (Play[8] != 0))
                game = 3;
            else if ((Play[0] == Play[3]) && (Play[0] == Play[6]) && (Play[3] == Play[6]) && (Play[0] != 0) && (Play[3] != 0) && (Play[6] != 0))
                game = 4;
            else if ((Play[1] == Play[4]) && (Play[1] == Play[7]) && (Play[4] == Play[7]) && (Play[1] != 0) && (Play[4] != 0) && (Play[7] != 0))
                game = 5;
            else if ((Play[2] == Play[5]) && (Play[2] == Play[8]) && (Play[5] == Play[8]) && (Play[2] != 0) && (Play[5] != 0) && (Play[8] != 0))
                game = 6;
            else if ((Play[0] == Play[4]) && (Play[0] == Play[8]) && (Play[4] == Play[8]) && (Play[0] != 0) && (Play[4] != 0) && (Play[8] != 0))
                game = 7;
            else if ((Play[2] == Play[4]) && (Play[2] == Play[6]) && (Play[4] == Play[6]) && (Play[2] != 0) && (Play[4] != 0) && (Play[6] != 0))
                game = 8;
            else if ((Play[0] != 0) && (Play[1] != 0) && (Play[2] != 0) && (Play[3] != 0) && (Play[4] != 0) && (Play[5] != 0) && (Play[6] != 0) && (Play[7] != 0) && (Play[8] != 0))
                game = 9;

            if (game != 0)
            {
                GameFinished(game);
            }
            else
            {
                ChangeTurn();
            }
        }

        private void GameFinished(int game)
        {
			StringBuilder sbHeader = new StringBuilder();
            Pen pencil = new Pen(Color.WhiteSmoke, 15);
            Font fontScore = new Font("Tahoma", 10, FontStyle.Regular);
            Font fontScoreBold = new Font("Tahoma", 10, FontStyle.Bold);
            Point P1, P2;

			StreamWriter swHistory = new StreamWriter(strHistoryFileName, true);

            P1 = new Point();
            P2 = new Point();

            bool draw = false;

            switch (game)
            {
                case 1:
                    P1 = Center(lstRectanges[0]);
                    P2 = Center(lstRectanges[2]);
                    break;
                case 2:
                    P1 = Center(lstRectanges[3]);
                    P2 = Center(lstRectanges[5]);
                    break;
                case 3:
                    P1 = Center(lstRectanges[6]);
                    P2 = Center(lstRectanges[8]);
                    break;
                case 4:
                    P1 = Center(lstRectanges[0]);
                    P2 = Center(lstRectanges[6]);
                    break;
                case 5:
                    P1 = Center(lstRectanges[1]);
                    P2 = Center(lstRectanges[7]);
                    break;
                case 6:
                    P1 = Center(lstRectanges[2]);
                    P2 = Center(lstRectanges[8]);
                    break;
                case 7:
                    P1 = Center(lstRectanges[0]);
                    P2 = Center(lstRectanges[8]);
                    break;
                case 8:
                    P1 = Center(lstRectanges[2]);
                    P2 = Center(lstRectanges[6]);
                    break;
                default:
                case 9:
                    draw = true;
                    break;
            }

            changes = true;

            if (!draw)
            {
                MyGraphics.DrawLine(pencil, P1.X, P1.Y, P2.X, P2.Y);

                if (Plr1.Turn)
                {
                    Plr1.UpdateScore(false);
                    lblScr1.Text = Plr1.Score.ToString();
                    lblScr1.ForeColor = Color.Red;
                    lblScr1.Font = fontScoreBold;
									
					sbHeader.AppendFormat("\n\t\t\t\t{0} Ganhou o Jogo!\n\n", Plr1.Name);
                }
                else if (Plr2.Turn)
                {
                    Plr2.UpdateScore(false);
                    lblScr2.Text = Plr2.Score.ToString();
                    lblScr2.ForeColor = Color.Red;
                    lblScr2.Font = fontScoreBold;

					sbHeader.AppendFormat("\n\t\t\t\t{0} Ganhou o Jogo!\n\n", Plr2.Name);
                }

                Thread.Sleep(1000);

                lblScr1.ForeColor = Color.Black;
                lblScr1.Font = fontScore;

                lblScr2.ForeColor = Color.Black;
                lblScr2.Font = fontScore;

                ChangeTurn();
            }
            else
            {
                Thread.Sleep(1000);

				sbHeader.AppendFormat("\n\t\t\t\tO Jogo Empatou!\n\n");
            }

            Thread.Sleep(1000);

			lblTotalScr.Text = (CountGames++).ToString();

			swHistory.WriteLine(sbHeader);
			swHistory.Close();
            
            Start();
        }

        private void ChangeTurn()
        {
            Font fontTurn = new Font("Tahoma", 10, FontStyle.Bold);
            Font fontNotTurn = new Font("Tahoma", 10, FontStyle.Regular);

            Plr1.Turn = !Plr1.Turn;
            Plr2.Turn = !Plr2.Turn;

            if (Plr1.Turn)
            {
                lblPlr1.ForeColor = Color.Blue;
                lblPlr1.Font = fontTurn;
                
                lblPlr2.ForeColor = Color.Black;
                lblPlr2.Font = fontNotTurn;
            }
            else if (Plr2.Turn)
            {
                lblPlr2.ForeColor = Color.Blue;
                lblPlr2.Font = fontTurn;

                lblPlr1.ForeColor = Color.Black;
                lblPlr1.Font = fontNotTurn;
            }
        }

        private void pbxGame_Click(object sender, EventArgs e)
        {
            if ((!btnClose.Enabled) && (!changes))
            {
                Point mousePt = PointToClient(MousePosition);

                if (pbxGame.ClientRectangle.Contains(mousePt))
                {
                    for (int i = 0; i < 9; i++)
                    {
                        if (lstRectanges[i].Contains(mousePt))
                        {
                            if (Play[i] == 0)
                            {
                                Font font = new Font("Tahoma", 60, FontStyle.Regular);
                                StringFormat sf = new StringFormat();
                                sf.LineAlignment = StringAlignment.Center;
                                sf.Alignment = StringAlignment.Center;

                                if (Plr1.Turn)
                                {
                                    MyGraphics.DrawString(Plr1.Letter, font, new SolidBrush(Color.Blue), lstRectanges[i], sf);
                                    Play[i] = 1;
									TurnLog(Plr1, i);
                                }
                                else if (Plr2.Turn)
                                {
                                    MyGraphics.DrawString(Plr2.Letter, font, new SolidBrush(Color.Red), lstRectanges[i], sf);
                                    Play[i] = 2;
									TurnLog(Plr2, i);
                                }

                                Victory();
                            }
                        }
                    }
                }
            }
        }

		private void TurnLog(Player plr, int rect)
		{
			StringBuilder sbBody = new StringBuilder();
			sbBody.AppendFormat("\t{0} Jogou No ", plr.Name);

			switch (rect)
			{
				case 0:
					sbBody.Append("Canto Superior Esquerdo");
					break;

				case 1:
					sbBody.Append("Centro Superior");
					break;

				case 2:
					sbBody.Append("Canto Superior Direito");
					break;

				case 3:
					sbBody.Append("Centro Esquerdo");
					break;

				case 4:
					sbBody.Append("Centro");
					break;

				case 5:
					sbBody.Append("Centro Direito");
					break;

				case 6:
					sbBody.Append("Canto Inferior Esquerdo");
					break;

				case 7:
					sbBody.Append("Centro Inferior");
					break;

				case 8:
					sbBody.Append("Canto Inferior Direito");
					break;
			}

			StreamWriter swHistory = new StreamWriter(strHistoryFileName, true);
			swHistory.WriteLine(sbBody);
			swHistory.Close();
		}

        public Point Center(Rectangle rect)
        {
            return new Point(rect.Left + rect.Width / 2,
                             rect.Top + rect.Height / 2);
        }
    }
}