using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using static Chess___netanel.ChessUtilities;

namespace Chess___netanel
{
    public partial class UI : Form
    {
        public Dictionary<Point, PictureBox> PieceUIMap;
        int[] indicesOfPieceCurrentlyClicked = { -1, -1 };
        Admin admin;

        public UI()
        {
            InitializeComponent();
            // Admin admin = new Admin(this); Moved to form_shown event because of invoking problems from admin
            PieceUIMap = new Dictionary<Point, PictureBox>();
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void AnnouncementLbl_Click(object sender, EventArgs e)
        {

        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Board_MouseClick(object sender, MouseEventArgs e)
        {
            int xIndex = (e.X - 21) / 75;
            int yIndex = (e.Y - 21) / 75;

            if (indicesOfPieceCurrentlyClicked[0] != -1)
            {
                sendMoveToAdminPort(indicesOfPieceCurrentlyClicked[0], indicesOfPieceCurrentlyClicked[1], xIndex, yIndex);
            }
        }

        private void RequestDrawButton_Click(object sender, EventArgs e)
        {
            admin.DrawRequested();
        }

        public void ToggleVisibilityDrawRequestPanel(string message)
        {
            DrawRequestTitleLbl.Text = message + ", agree to draw?";
            DrawRequestPanel.Visible = !DrawRequestPanel.Visible;
        }

        private void Board_Click(object sender, EventArgs e)
        {

        }

        private void PictureBoxPiece_Click(object sender, EventArgs e)
        {

            //if a piece wasn't grabbed when this piece was clicked
            if (indicesOfPieceCurrentlyClicked[0] == -1)
            {
                indicesOfPieceCurrentlyClicked = ConvertLocationToIndices((sender as PictureBox).Location);
                PieceCurrentlyGrabbedLbl.Text = ConvertLocationToRankAndFile((sender as PictureBox).Location);
                return;
            }

            //else, if a piece was already grabbed, send pieces to admin for processing
            int[] indicesOfFinalLocation = ConvertLocationToIndices((sender as PictureBox).Location);
            sendMoveToAdminPort(indicesOfPieceCurrentlyClicked[0], indicesOfPieceCurrentlyClicked[1],
                indicesOfFinalLocation[0], indicesOfFinalLocation[1]);
        }

        private void sendMoveToAdminPort(int currentXIndex, int currentYIndex, int finalXIndex, int finalYIndex)
        {
            if ((currentXIndex == finalXIndex) && (currentYIndex == finalYIndex)) //if same sqaure was clicked twice...
                return;
            try
            {
                admin.HandleMove(currentXIndex, currentYIndex, finalXIndex, finalYIndex);
            }
            catch (NotYourTurnException)
            {
                MessageBox.Show("Not your turn!");
            }
            catch (YouCannotOverrideYourOwnPieceException)
            {
                MessageBox.Show("You cannot override your own piece!");
            }
            catch (YouCannotPassThroughAPieceException)
            {
                MessageBox.Show("You cannot pass through a piece!");
            }
            catch (PawnException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (RookException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (BishopException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (QueenException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (KingException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (KnightException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (IllegalMoveException)
            {
                MessageBox.Show("Illegal move!");
            }
            finally
            {
                resetCurrentPieceClicked();
            }
        }
        private void Board_Paint(object sender, PaintEventArgs e)
        {

        }



        //populate whole board when game starts
        public void PopulateBoard(Dictionary<Point, ChessPiece> map)
        {           
            foreach (Point p in map.Keys)
                AnimatePieceWithIndices(p.X, p.Y, map[p].Type, map[p].Color);
        }


        //Animate One Chess Piece
        public void AnimatePieceWithLocation(int TopLeftX, int TopLeftY, PieceType piece, Colors color)
        {
            Point Location = new Point(TopLeftX, TopLeftY);
            PictureBox pb = new PictureBox();

            pb.Location = Location;

            pb.Size = new Size(75, 75);
            pb.SizeMode = PictureBoxSizeMode.CenterImage;

            string ResourceName = color.ToString()[0] + "_" + piece.ToString();
            pb.Image = (Image)Properties.Resources.ResourceManager.GetObject(ResourceName);

            pb.Click += PictureBoxPiece_Click;

            Board.Controls.Add(pb);

            //add location to ui board - for future reference and moving pieces
            PieceUIMap[Location] = pb;
        }

        public void ToggleBoardEnable()
        {
            Board.Enabled = !Board.Enabled;
        }

        public void AnimatePieceWithIndices(int xIndex, int yIndex, PieceType piece, Colors color)
        {
            Point location = ConvertIndicesToLocation(xIndex, yIndex);
            AnimatePieceWithLocation(location.X, location.Y, piece, color);
        }

        public void ChangePiece(int TopLeftX, int TopLeftY, PieceType newType, Colors color)
        {
            PieceUIMap[new Point(TopLeftX, TopLeftY)].Image = (Image)Properties.Resources.ResourceManager.GetObject(color.ToString()[0] + "_" + newType.ToString());
        }


        //gets: rank and file of current location, rank and file of final location. does: moves piece to said location
        public void MovePiece(Rank firstRank, int firstFile, Rank secondRank, int secondFile)
        {
            MovePiece((int)firstRank, 8 - firstFile, (int)secondRank, 8 - secondFile);
        }

        //gets: index of current piece location and final location. does: moes piece to said location. 
        //Will not accept occupied spot - removePiece must be used beforhand in order to simulate eating
        public void MovePiece(int firstXIndex, int firstYIndex, int secondXIndex, int secondYIndex)
        {
            if (!ChessUtilities.isIndexInBounds(firstXIndex, firstYIndex, secondXIndex, secondYIndex))
                throw new ArgumentOutOfRangeException();

            PictureBox pieceAtLocation;
            Point locationNow = ConvertIndicesToLocation(firstXIndex, firstYIndex);
            Point finalLocation = ConvertIndicesToLocation(secondXIndex, secondYIndex);

            PieceUIMap.TryGetValue(locationNow, out pieceAtLocation);

            if (pieceAtLocation == null)
                throw new PieceDoesntExistAtThatLocationException();
            if (PieceUIMap.ContainsKey(finalLocation))
                throw new PieceAlreadyAtLocationConflictException();

            pieceAtLocation.Visible = false;
            //physically animate piece to new location
            pieceAtLocation.Location = finalLocation;

            //remove old location pair from UIMap
            PieceUIMap.Remove(locationNow);

            //add new location pair to UIMap
            PieceUIMap[finalLocation] = pieceAtLocation;
            pieceAtLocation.Visible = true;

            resetCurrentPieceClicked();
        }

        private void resetCurrentPieceClicked()
        {
            indicesOfPieceCurrentlyClicked = new int[] { -1, -1 };
            PieceCurrentlyGrabbedLbl.Text = "";
        }

        public void RemovePiece(int xIndex, int yIndex)
        {
            if (!isIndexInBounds(xIndex, yIndex))
                throw new ArgumentOutOfRangeException();

            PictureBox pieceAtLocation;
            Point location = ConvertIndicesToLocation(xIndex, yIndex);
            PieceUIMap.TryGetValue(location, out pieceAtLocation);

            if (pieceAtLocation == null)
                throw new PieceDoesntExistAtThatLocationException();

            Board.Controls.Remove(pieceAtLocation);
            PieceUIMap.Remove(location);
        }

        public void RemovePiece(Rank rank, int file)
        {
            RemovePiece((int)rank, 8 - file);
        }


        //Change turn label
        public void ToggleTurnLabel()
        {
            TurnLbl.Text = (TurnLbl.Text[0] == 'B') ? "White" : "Black";
        }

        

        public void OpenMessageBox(string message)
        {
            MessageBox.Show(message);
        }

        public void UpdateTimer(string UpdatedTime, Colors color)
        {
            if (color.ToString()[0] == 'B')
                BlackTimerLbl.Text = UpdatedTime;
            else
                WhiteTimerLbl.Text = UpdatedTime;
        }




        private void UI_Shown(object sender, EventArgs e)
        {
            admin = new Admin(this);
        }

        public void TriggerEndGameForm(EndGamePackage package)
        {
            EndGamePackage egp = package as EndGamePackage;
            MessageBox.Show(egp.Message);
            EndOfGameMessages frm = new EndOfGameMessages(egp.Message, egp.MoveList, this);
            frm.Show();
            this.Hide();
        }

        private void ResignBtn_Click(object sender, EventArgs e)
        {
            admin.GameEndsOnResign();
        }

        private void NoToDrawRequestBtn_Click(object sender, EventArgs e)
        {
            DrawRequestPanel.Visible = false;
        }

        private void YesToDrawRequestBtn_Click(object sender, EventArgs e)
        {
            admin.DrawAccepted();

        }

        private void AdminSaysLbl_Click(object sender, EventArgs e)
        {

        }

        private void PieceCurrentlyGrabbed_Click(object sender, EventArgs e)
        {

        }

        public void OpenPromotionDialogAndWaitForResponse(Colors color)
        {
            PromotionDialog pd = new PromotionDialog(this, color);
            pd.ShowDialog();
        }

        public void RelayPromotionInfoToAdmin(PieceType PromotedType)
        {
            admin.RecievePromotionPieceTypeFromUI(PromotedType);
        }

        private void PromoteToQueenBtn_Click(object sender, EventArgs e)
        {

        }

        private void PromoteToBishopBtn_Click(object sender, EventArgs e)
        {

        }

        private void PromoteToRookButton_Click(object sender, EventArgs e)
        {

        }

        private void PromoteToKnightBtn_Click(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            admin.undoMove();
        }

        private void UI_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }



    public class EndGamePackage
    {
        public string Message { get; set; }
        public string MoveList { get; set; }
    }
    public enum PieceType { Pawn, Rook, Queen, King, Bishop, Knight, }
    public enum Colors { White, Black }
    public enum Rank { a, b, c, d, e, f, g, h }
    class PieceDoesntExistAtThatLocationException : Exception { }


    class PieceAlreadyAtLocationConflictException : Exception { }

}
