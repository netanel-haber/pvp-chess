using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess___netanel
{
    public partial class PromotionDialog : Form
    {
        UI UIForm;
        public PromotionDialog(UI form,Colors color)
        {
            InitializeComponent();
            UIForm = form;
            PromoteToQueenBtn.BackgroundImage = (Image)Properties.Resources.ResourceManager.
                GetObject(color.ToString()[0] + "_" + PieceType.Queen.ToString());
            PromoteToRookBtn.BackgroundImage = (Image)Properties.Resources.ResourceManager.
                GetObject(color.ToString()[0] + "_" + PieceType.Rook.ToString());
            PromoteToBishopBtn.BackgroundImage = (Image)Properties.Resources.ResourceManager.
                GetObject(color.ToString()[0] + "_" + PieceType.Bishop.ToString());
            PromoteToKnightBtn.BackgroundImage = (Image)Properties.Resources.ResourceManager.
                GetObject(color.ToString()[0] + "_" + PieceType.Knight.ToString());

        }

        private void PromoteToQueenBtn_Click(object sender, EventArgs e)
        {
            UIForm.RelayPromotionInfoToAdmin(PieceType.Queen);
            this.Close();
        }

        private void PromoteToBishopBtn_Click(object sender, EventArgs e)
        {
            UIForm.RelayPromotionInfoToAdmin(PieceType.Bishop);
            this.Close();
        }

        private void PromoteToKnightBtn_Click(object sender, EventArgs e)
        {
            UIForm.RelayPromotionInfoToAdmin(PieceType.Knight);
            this.Close();
        }

        private void PromoteToRookButton_Click(object sender, EventArgs e)
        {
            UIForm.RelayPromotionInfoToAdmin(PieceType.Rook);
            this.Close();
        }

        private void PromotionPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
