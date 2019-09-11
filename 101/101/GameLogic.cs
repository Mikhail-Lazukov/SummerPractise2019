using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Timers;
using System.IO;

namespace _101
{
    class GameLogic
    {
        List<Player> Players = new List<Player>();
        Deck OriginalDeck = new Deck();
        Deck UsedCardDeck = new Deck();
        int WhoseTurn;
        int WhoWonPreviousRound = -1;
        int WhoLoseGame = -1;
        int CurrentDignity = -1;
        int CurrentSuit = -1;
        int AmountOfPlayers;
        bool IsTheRoundOver = false;

        public delegate void PrepareInterface(Deck OriginalDeck, List<Player> players);
        public delegate void ChagePlayerDeck(Player player, Deck FromOrInToDeck, bool IfFromPlayerDeck);
        public delegate void ChangeUsedCardAndOriginalDeck(Deck OriginalDeck, Deck UsedCardDeck);
        public delegate void PlayerChangeSuit();
        public delegate void ChangeSuitImage(int suit);
        public delegate void EndGame(int index);
        public delegate void ShowScore(List<Player> players);

        public event PrepareInterface GameHasStarted;
        public event ChagePlayerDeck CardHasMovedFromOrIntoPlayerDeck;
        public event ChangeUsedCardAndOriginalDeck CardHasMovedIntoOriginalDeck;
        public event PlayerChangeSuit ChangeSuitRequired;
        public event ChangeSuitImage SuitHasChanged;
        public event EndGame RoundHasEnded;
        public event ShowScore ScoreHasChanged;

        public GameLogic()
        {
            AmountOfPlayers = 2;            
            Players.Add(new Player());
            for (int i = 0; i < AmountOfPlayers - 1; i++)
            {
                Players.Add(new Computer());
            }
        }

        public void StartRound()
        {
            FillOriginalDeck();
            ChooseWhoseTurn();
            DealCards();
            OpenFirstCard();
        }

        private void FillOriginalDeck()
        {
            for (int i = 0; i < 36; i++)
            {
                Card card = new Card();
                card.Dignity = i / 4 + 2;
                if (i > 11) card.Dignity++; // 2 - валет, 3 - дама, 4 - король, 6 - 6 из-за этого необходимо добавлять ценность
                if (card.Dignity == 9) card.Dignity = 0; // т.к. у девятки ценность 0
                card.Suit = i % 4; // 0 - крести, 1 - буби, 2 - черви, 3 - пики
                card.BackImage = Properties.Resources.back;
                string imageName = String.Format("_{0}", i);
                card.FrontImage = (Image)Properties.Resources.ResourceManager.GetObject(imageName);
                OriginalDeck.AddCard(card);
            }
            GameHasStarted(OriginalDeck, Players);
            ScoreHasChanged(Players);
        }

        private void ChooseWhoseTurn()
        {
            Random random = new Random();
            WhoseTurn = (WhoWonPreviousRound == -1) ? random.Next(AmountOfPlayers) : WhoWonPreviousRound;
        }

        private void DealCards()
        {
            Random random = new Random();
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < AmountOfPlayers; j++)
                {                   
                    TransferCardFromInto(OriginalDeck, Players[j].Deck, OriginalDeck.Card(random.Next(OriginalDeck.Size)));
                    CardHasMovedFromOrIntoPlayerDeck(Players[j], OriginalDeck, false);
                }
            }
        }

        private void OpenFirstCard()
        {
            Random random = new Random();
            Card card = Players[WhoseTurn].Deck.Card(random.Next(Players[WhoseTurn].Deck.Size));
            MakeMove(card);
            CardHasMovedFromOrIntoPlayerDeck(Players[WhoseTurn], UsedCardDeck, true);
        }

        private void ComputerMove()
        {
            if (Players[WhoseTurn] is Computer)
            {
                if (((Computer)Players[WhoseTurn]).DoComputerHaveSuitableCard(CurrentDignity, CurrentSuit))
                {
                    MakeMove(((Computer)Players[WhoseTurn]).MakeMove(CurrentDignity, CurrentSuit));
                }
                else
                {
                    TakeCard(Players[WhoseTurn]);
                    if (CurrentDignity != 0) PassTheMoveToTheNextPlayer();
                    else ComputerMove();
                }
            }
        }

        private void TransferCardFromInto(Deck FromThisDeck, Deck IntoThisDeck, Card card)
        {
            FromThisDeck.RemoveCard(card);
            IntoThisDeck.AddCard(card);
        }

        public void PlayerTakeCard()
        {
            TakeCard(Players[WhoseTurn]);
            if(CurrentDignity != 0)
            {
                PassTheMoveToTheNextPlayer();
                ComputerMove();
            }
        }

        private void PassTheMoveToTheNextPlayer()
        {
            WhoseTurn++;
            if (WhoseTurn == AmountOfPlayers) WhoseTurn = 0;
        }

        public void MakeMove(Card card)
        {
            if (IsSuitableCard(card))
            {
                CurrentDignity = card.Dignity;
                CurrentSuit = card.Suit;
                SuitHasChanged(card.Suit);

                TransferCardFromInto(Players[WhoseTurn].Deck, UsedCardDeck, card);
                CardHasMovedFromOrIntoPlayerDeck(Players[WhoseTurn], UsedCardDeck, true);

                if (Players[WhoseTurn].Deck.Size == 0)
                {
                    IsTheRoundOver = true;
                    WhoWonPreviousRound = WhoseTurn;                   
                }

                if (card.Dignity != 0 && card.Dignity != 3)
                {
                    PassTheMoveToTheNextPlayer();
                }

                if (card.Dignity == 3)
                {
                    if (Players[WhoseTurn] is Computer)
                        ChangeSuit(((Computer)Players[WhoseTurn]).ChangeSuit());
                    else
                        ChangeSuitRequired();
                }
                else if (card.Dignity == 11)
                    PassTheMoveToTheNextPlayer();
                else if (card.Dignity == 4 && card.Suit == 3)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        TakeCard(Players[WhoseTurn]);
                    }
                    PassTheMoveToTheNextPlayer();
                }
                else if (card.Dignity == 7)
                {
                    for (int i = 0; i < 2; i++)
                    {
                        TakeCard(Players[WhoseTurn]);
                    }
                    PassTheMoveToTheNextPlayer();
                }
                else if (card.Dignity == 6)
                {
                    TakeCard(Players[WhoseTurn]);
                    PassTheMoveToTheNextPlayer();
                }
                if (!IsTheRoundOver) ComputerMove();
                else EndThisRound(card);
            }
        }

        private void TakeCard(Player player)
        {
            if (OriginalDeck.Size == 0)
            {
                while (UsedCardDeck.Size > 1)
                {
                    TransferCardFromInto(UsedCardDeck, OriginalDeck, UsedCardDeck.Card(0));
                    CardHasMovedIntoOriginalDeck(OriginalDeck, UsedCardDeck);
                }
                if (OriginalDeck.Size > 0) TakeCard(player);
            }
            else
            {
                Random random = new Random();
                Card card = OriginalDeck.Card(random.Next(OriginalDeck.Size));
                TransferCardFromInto(OriginalDeck, player.Deck, card);
                CardHasMovedFromOrIntoPlayerDeck(player, OriginalDeck, false);
            }
        }

        private bool IsSuitableCard(Card card)
        {
            if (CurrentDignity == -1 || CurrentDignity == card.Dignity || CurrentSuit == card.Suit || card.Dignity == 3)
                return true;
            else
                return false;
        }

        public void ChangeSuit(int Suit)
        {
            CurrentSuit = Suit;
            SuitHasChanged(Suit);
            PassTheMoveToTheNextPlayer();
            ComputerMove();
        }   

        private void EndThisRound(Card card)
        {
            bool GameHasEnd = false;
            if (card.Dignity == 3)
                Players[WhoWonPreviousRound].Score -= 20;
            foreach(Player player in Players)
            {
                player.Score += player.Deck.TotalDignity;
                if (player.IsLoose)
                {
                    GameHasEnd = true;
                    WhoLoseGame = Players.IndexOf(player);
                }
            }
            if (!GameHasEnd)
            {
                RoundHasEnded(3);
                WhoseTurn = -1;
                CurrentDignity = -1;
                CurrentSuit = -1;
                ScoreHasChanged(Players);
            }
            else
            {
                ScoreHasChanged(Players);
                WriteStatistics();
                RoundHasEnded(4);
            }
        }

        public void RestartGame()
        {
            foreach(Player player in Players)
            {
                while(player.Deck.Size > 0)
                { 
                    TransferCardFromInto(player.Deck, UsedCardDeck, player.Deck.Card(0));
                    CardHasMovedFromOrIntoPlayerDeck(player, UsedCardDeck, true);
                }
            }
            while(UsedCardDeck.Size > 0)
            { 
                TransferCardFromInto(UsedCardDeck, OriginalDeck, UsedCardDeck.Card(0));
                CardHasMovedIntoOriginalDeck(OriginalDeck, UsedCardDeck);
            }
            IsTheRoundOver = false;
            ChooseWhoseTurn();
            DealCards();
            OpenFirstCard();
        }

        private void WriteStatistics()
        {
            int AmountOfGames = 0;
            int AmountOfWins = 0;
            if (!File.Exists(@"Statistics.txt")) File.Create(@"Statistics.txt").Close();
            else
            {
                StreamReader reader = new StreamReader(@"Statistics.txt");
                string[] Date = reader.ReadLine().Split(';');
                if (Date[0] != "") AmountOfGames = int.Parse(Date[0]);
                if (Date[1] != "") AmountOfWins = int.Parse(Date[1]);
                reader.Close();
            }
            AmountOfGames++;
            if (Players[WhoLoseGame] is Computer) AmountOfWins++;
            File.WriteAllText(@"Statistics.txt", String.Format("{0};{1}", AmountOfGames, AmountOfWins));
        }
    }
}
