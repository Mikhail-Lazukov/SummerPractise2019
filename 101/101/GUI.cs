using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace _101
{
    class GUI
    {
        Dictionary<Card, PictureBox> CardToPictureBox = new Dictionary<Card, PictureBox>();
        Dictionary<PictureBox, Card> PictureBoxToCard = new Dictionary<PictureBox, Card>();
        Form1 GameField;
        Size PictureBoxes_Size = new Size(80, 120);
        Point OriginalDeckLocation;
        Point UsedCardDeckLocation;
        int GameField_Width;
        int GameField_Height;
        PictureBox OriginalDeckPB = new PictureBox();
        PictureBox UsedCardDeckPB = new PictureBox();
        public GUI (Deck OriginalDeck , Deck UsedCardDeck, Form1 GameField)
        {
            this.GameField = GameField;
            OriginalDeckLocation = new Point(GameField.ClientSize.Width / 2 - PictureBoxes_Size.Width - 20 , GameField.ClientSize.Height / 2 - PictureBoxes_Size.Height / 2);
            UsedCardDeckLocation = new Point(GameField.ClientSize.Width / 2 + 20, GameField.ClientSize.Height / 2 - PictureBoxes_Size.Height / 2);
            GameField_Width = GameField.Width;
            GameField_Height = GameField.Height;
            for (int i = 0; i < OriginalDeck.Size; i++)
            {
                PictureBox TempPB = new PictureBox();
                TempPB.Location = OriginalDeckLocation;
                TempPB.Image = OriginalDeck.Card(i).FrontImage;
                TempPB.Size = PictureBoxes_Size;
                TempPB.SizeMode = PictureBoxSizeMode.StretchImage;
                TempPB.Click += new EventHandler(TempPB_Click);
                CardToPictureBox.Add(OriginalDeck.Card(i), TempPB);
                PictureBoxToCard.Add(TempPB, OriginalDeck.Card(i));
                TempPB.Visible = false;
                GameField.Controls.Add(TempPB);              
            }
            ShowOriginalAndUsedCardDeck(OriginalDeck, UsedCardDeck);
        }      

        public void ShowOriginalAndUsedCardDeck(Deck OriginalDeck, Deck UsedCardDeck)
        {
            OriginalDeckPB.Location = OriginalDeckLocation;
            OriginalDeckPB.Image = Properties.Resources.back;
            OriginalDeckPB.Size = PictureBoxes_Size;
            OriginalDeckPB.SizeMode = PictureBoxSizeMode.StretchImage;
            OriginalDeckPB.Click += new EventHandler(TempPB_Click);
            GameField.Controls.Add(OriginalDeckPB);

            UsedCardDeckPB.Location = UsedCardDeckLocation;
            UsedCardDeckPB.Image = (UsedCardDeck.Size > 0 ) ? UsedCardDeck.Card(UsedCardDeck.Size-1).FrontImage : null;
            UsedCardDeckPB.Size = PictureBoxes_Size;
            UsedCardDeckPB.SizeMode = PictureBoxSizeMode.StretchImage;
            UsedCardDeckPB.Click += new EventHandler(TempPB_Click);
            GameField.Controls.Add(UsedCardDeckPB);

        }
        void TempPB_Click(object sender, EventArgs e)
        {
            PictureBox pb = sender as PictureBox;
            pb.Visible = false;
        }

        public void ShowPlayerDeck(Player player)
        {
            bool deckIsVisible = (player is Computer) ? false : true;
            int widthForPB = GameField.ClientSize.Width / player.deck.Size;
            int y = player.deckLocationY;
            for (int i = 0; i < player.deck.Size; i++)
            { 
                int x = ((widthForPB >= PictureBoxes_Size.Width)? (GameField.ClientSize.Width - player.deck.Size * PictureBoxes_Size.Width) / 2 + i * PictureBoxes_Size.Width : i*widthForPB);
                PictureBox tempPB = CardToPictureBox[player.deck.Card(i)];
                tempPB.Location = new Point(x, y);
                tempPB.BringToFront();
                if( !deckIsVisible )
                {
                    tempPB.Image = player.deck.Card(i).BackImage;
                }
            }
        }
    }
}
