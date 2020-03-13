using System;
using System.Windows.Forms;
using System.IO;

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
            int AmountOfGames = 0;
            int AmountOfWins = 0;
            if (!File.Exists(@"Statistics.txt")) File.Create(@"Statistics.txt").Close();
            else
            {
                StreamReader Res = new StreamReader(@"Statistics.txt");
                while (true)
                {
                    try
                    {
                        string[] Date = Res.ReadLine().Split(';');
                        if (Date[0] != "") AmountOfGames = int.Parse(Date[0]);
                        if (Date[1] != "") AmountOfWins = int.Parse(Date[1]);
                    }
                    catch (NullReferenceException)
                    {
                        break;
                    }
                }
                Res.Close();
            }
            MessageBox.Show
                (
                String.Format("Количество игр: {0} Количество побед: {1}", AmountOfGames, AmountOfWins),
                "Статистика",
                 MessageBoxButtons.OK,
                 MessageBoxIcon.Information,
                 MessageBoxDefaultButton.Button1,
                 MessageBoxOptions.DefaultDesktopOnly
                 );
        }

        private void Button_Close_Rules_Click(object sender, EventArgs e)
        {
            Label_Rules_Head.Visible = false;
            Label_Text_Of_Rules.Visible = false;
            Button_Close_Rules.Visible = false;
        }
    }
}
