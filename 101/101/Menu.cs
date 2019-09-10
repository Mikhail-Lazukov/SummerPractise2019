using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _101
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void Button_StartGame_Click(object sender, EventArgs e)
        {
            GameField gameField = new GameField();
            this.Hide();
            gameField.ShowDialog();
            this.Show();
        }

        private void Button_Rules_Click(object sender, EventArgs e)
        {
            Label_Rules_Head.Visible = true;
            Label_Text_Of_Rules.Visible = true;
            Button_Close_Rules.Visible = true;
        }

        private void Button_Statistics_Click(object sender, EventArgs e)
        {

        }

        private void Button_Close_Rules_Click(object sender, EventArgs e)
        {
            Label_Rules_Head.Visible = false;
            Label_Text_Of_Rules.Visible = false;
            Button_Close_Rules.Visible = false;
        }
    }
}
