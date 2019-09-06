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

        }

        private void Button_Records_Click(object sender, EventArgs e)
        {

        }
    }
}
