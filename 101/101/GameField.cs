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
    public partial class GameField : Form
    {
        GameLogic gameLogic;
        Graphics graphics;

        public delegate void ChangeSuit(int suit);
        public event ChangeSuit SuitHasChanged;
        
        public GameField()
        {
            InitializeComponent();
        }

        private void Player_Button_Click(object sender, EventArgs e)
        {
            if (Player_Button.Text == "Старт")
            {
                gameLogic = new GameLogic();
                graphics = new Graphics(this);
                gameLogic.GameHasStarted += graphics.PrepareInterface;
                gameLogic.CardHasMovedFromOrIntoPlayerDeck += graphics.RedrawDecks;
                gameLogic.CardHasMovedFromOrIntoOriginalDeck += graphics.RedrawBaseDecks;
                gameLogic.ChangeSuitRequired += PlayerChangeSuit;
                graphics.PlayerChoseCard += gameLogic.MakeMove;
                gameLogic.GameHasEnded += ChangeButtonName;
                SuitHasChanged += gameLogic.ChangeSuit;
                gameLogic.ScoreHasChanged += graphics.UpdateScore;
                gameLogic.SuitHasChanged += UpdateCurrentSuitImage;
                gameLogic.StartRound();
                Player_Button.Text = "Взять";
            }
            else if (Player_Button.Text == "Взять")
            {
                gameLogic.PlayerTakeCard();
            }
            else if (Player_Button.Text == "Продолжить")
            {
                gameLogic.RestartGame();
                Player_Button.Text = "Взять";
            }
            else if(Player_Button.Text == "В главное меню")
            {
                this.Close();
            }
        }

        private void ChangeButtonName(int index)
        {
            switch (index)
            {
                case 1:
                    Player_Button.Text = "Взять";
                    break;
                case 2:
                    Player_Button.Text = "Пас";
                    break;
                case 3:
                    Player_Button.Text = "Продолжить";
                    break;
                case 4:
                    Player_Button.Text = "В главное меню";
                    break;
            }

        }

        private void PlayerChangeSuit()
        {
            button_clubs.BringToFront();
            button_diamonds.Visible = true;
            button_hearts.Visible = true;
            button_spades.Visible = true;
            button_clubs.Visible = true;
        }

        private void Button_Suits_Click(object sender, EventArgs e)
        {
            Button TempButton = sender as Button;
            int suit = Convert.ToInt32(TempButton.Tag);
            SuitHasChanged(suit);
            button_diamonds.Visible = false;
            button_hearts.Visible = false;
            button_spades.Visible = false;
            button_clubs.Visible = false;
        }

        void UpdateCurrentSuitImage(int suit)
        {
            switch(suit)
            {
                case 0:
                    CurrentSuit_PB.Image = Properties.Resources.clubs;
                    break;
                case 1:
                    CurrentSuit_PB.Image = Properties.Resources.diamonds;
                    break;
                case 2:
                    CurrentSuit_PB.Image = Properties.Resources.hearts;
                    break;
                case 3:
                    CurrentSuit_PB.Image = Properties.Resources.spades;
                    break;
            }
        }


    }
}
