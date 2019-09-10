using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace _101
{
    class Graphics
    {
        GameField gameField;
        Dictionary<Card, PictureBox> CardToPictureBox = new Dictionary<Card, PictureBox>();
        Dictionary<PictureBox, Card> PictureBoxToCard = new Dictionary<PictureBox, Card>();
        Dictionary<Player, Point> PlayerToDeckCoord = new Dictionary<Player, Point>();
        Size PictureBoxes_Size = new Size(60, 90);
        Point OriginalCardDeck_Location;
        Point UsedCardDeck_Location;

        public delegate void TryToMove(Card card);
        public event TryToMove PlayerChoseCard;
        public Graphics(GameField gameField)
        {
            this.gameField = gameField;
            OriginalCardDeck_Location = new Point(gameField.ClientSize.Width / 2 - PictureBoxes_Size.Width - 20,
                                                  gameField.ClientSize.Height / 2 - PictureBoxes_Size.Height / 2);

            UsedCardDeck_Location = new Point(gameField.ClientSize.Width / 2 + 20,
                                              gameField.ClientSize.Height / 2 - PictureBoxes_Size.Height / 2);
        }
        public void PrepareInterface(Deck OriginalDeck, List<Player> players)
        {
            for (int i = 0; i < players.Count; i++)
            {

                PlayerToDeckCoord.Add(players[i], new Point(gameField.ClientSize.Width / 5,
                                            (i % 2 == 1) ?  gameField.Height / 6 :
                                                            gameField.ClientSize.Height * 5 / 6 - PictureBoxes_Size.Height));
            }
            for (int i = 0; i < OriginalDeck.Size; i++)
            {
                //Создание PB для каждой карты
                PictureBox TempPB = new PictureBox();
                TempPB.Location = OriginalCardDeck_Location;
                TempPB.Image = OriginalDeck.Card(i).BackImage;
                TempPB.Size = PictureBoxes_Size;
                TempPB.SizeMode = PictureBoxSizeMode.StretchImage;
                TempPB.Click += new EventHandler(CardPB_Click);
                TempPB.Enabled = false;
                TempPB.Visible = true;
                TempPB.BringToFront();
                gameField.Controls.Add(TempPB);

                // Привязка PB к словарям для быстрого доступа
                CardToPictureBox.Add(OriginalDeck.Card(i), TempPB);
                PictureBoxToCard.Add(TempPB, OriginalDeck.Card(i));           
            }
        }
        
        void CardPB_Click (object sender, EventArgs e)
        {
            PictureBox TempPB = sender as PictureBox;
            Card card = PictureBoxToCard[TempPB];
            PlayerChoseCard(card);
        }

        public void RedrawDecks(Player player, Deck FromOrInroPlayerDeck, bool IsFromPlayerDeck) // Сделать отдельно перерисовку колоды и колоды игроков, а потом вызывать
        {
            RedrawPlayerDeck(player);
            RedrawOriginalOrUsedCardDeck(FromOrInroPlayerDeck, !IsFromPlayerDeck);
        }

        public void RedrawBaseDecks(Deck OriginalDeck, Deck UsedCardDeck, bool IsFromOriginalDeck)
        {
            RedrawOriginalOrUsedCardDeck(OriginalDeck, true);
            RedrawOriginalOrUsedCardDeck(UsedCardDeck, false);
        }

        void RedrawPlayerDeck (Player player)
        {
            Point PlayerDeckCoord = PlayerToDeckCoord[player];
            int widthForPB = (player.deck.Size > 0) ? gameField.ClientSize.Width * 3 / 5 / player.deck.Size : 0;
            int y = PlayerDeckCoord.Y;
            for (int i = 0; i < player.deck.Size; i++)
            {
                int x = ((widthForPB >= PictureBoxes_Size.Width) ? ((gameField.ClientSize.Width * 3 / 5 - player.deck.Size * PictureBoxes_Size.Width) / 2
                                                                    + i * PictureBoxes_Size.Width + PlayerDeckCoord.X) :
                                                                    (i * widthForPB + PlayerDeckCoord.X));
                PictureBox CardPictureBox = CardToPictureBox[player.deck.Card(i)];
                CardPictureBox.Visible = true;
                CardPictureBox.BringToFront();
                CardPictureBox.Image = (player is Computer) ? player.deck.Card(i).BackImage : player.deck.Card(i).FrontImage;
                CardPictureBox.Enabled = (player is Computer) ? false : true;
                MovePB(CardPictureBox, new Point(x, y));
            }
        }

        void RedrawOriginalOrUsedCardDeck(Deck deck, bool IsOriginalDeck)
        {
            for (int i = 0; i < deck.Size; i++)
            {
                PictureBox CardPictureBox = CardToPictureBox[deck.Card(i)];
                CardPictureBox.Visible = true;
                CardPictureBox.BringToFront();
                CardPictureBox.Image = (IsOriginalDeck) ? deck.Card(i).BackImage : deck.Card(i).FrontImage;
                CardPictureBox.Enabled = false;
                MovePB(CardPictureBox, (IsOriginalDeck) ? OriginalCardDeck_Location : UsedCardDeck_Location);
            }
        }
        void MovePB(PictureBox CardPictureBox, Point ToThisLocation)
        {
            if (CardPictureBox.Location != ToThisLocation)
            {
                CardPictureBox.Location = ToThisLocation;               
            }
        }

        public void UpdateScore(List<Player> players)
        {
            foreach(var player in players)
            {
                if(player is Computer)
                {
                    gameField.Label_Computer_Score.Text = String.Format("Счет: {0}",player.Score);
                }
                else
                {
                    gameField.Label_Player_Score.Text = String.Format("Счет: {0}", player.Score);
                }
            }
        }

    }
}
