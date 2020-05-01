using System;
using System.Windows.Forms;

namespace Chess___netanel
{
    public partial class EndOfGameMessages : Form
    {
        UI frm;
        public EndOfGameMessages(string message,string moveStack, UI frm)
        {
            InitializeComponent();
            this.Text = message;
            this.MoveStackText.Text = moveStack;
            this.frm = frm;
        }

        private void EndOfGameMessages_Shown(object sender, EventArgs e)
        {
            
        }

        private void EndOfGameMessages_FormClosing(object sender, FormClosingEventArgs e)
        {
            frm.Close();
        }

        private void EndOfGameMessages_Load(object sender, EventArgs e)
        {

        }
    }
}
