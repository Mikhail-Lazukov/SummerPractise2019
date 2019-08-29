using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Timers;

namespace _101
{
    class GameLogic
    {
        public Deck OriginalDeck = new Deck();
        public Deck UsedCardDeck = new Deck();
        List<Player> Players = new List<Player>();
        public int CurrentDignity;
        public int CurrentSuit;
        private int AmountOfPlayers;
        Player WhoseTurn;
        Player WhoWonPreviousRound = null;
        bool IsSomeoneWonRound = false;
        bool IsPlayerMoved = false;
        GameLogic(List<Player> Players)
        {
            this.Players = Players;
            AmountOfPlayers = Players.Count;
        }
        void StartGame()
        {
            while(IsSomeoneLoseGame())
            {
                StartRound();
                while(!IsSomeoneWonRound)
                {
                    ChooseCardForMove(WhoseTurn);
                }
                CountRoundResults();
            }
        }

        void CountRoundResults()
        {

        }
        void ChooseCardForMove (Player player)
        {
            Card NewLastUsedCard;
            if ( player is Computer)
            {
                NewLastUsedCard = ((Computer)player).MakeMove(CurrentSuit, CurrentDignity);
            }
            else
            {
                Wait();
            }
        }

        void MakeMove (Card card)
        {
            if (IsItCorrectCard(card))
            {
                if (card.Dignity == 9)
                {

                }
                else if (card.Dignity == 2)
                {

                }
                else
                {

                }
            }                   
        }

        bool IsItCorrectCard(Card card)
        {

        }
        void Wait()
        {
            Timer WaitForPlayerMove = new Timer();
            WaitForPlayerMove.Interval = 1000;
            WaitForPlayerMove.AutoReset = true;
            WaitForPlayerMove.Elapsed += HavePlayerMoved;
            WaitForPlayerMove.Start();            
        }

        void PlayerMoved()
        {
            IsPlayerMoved = true;
        }
        void HavePlayerMoved (Object source, System.Timers.ElapsedEventArgs e)
        {
            Timer WaitForPlayerMove = source as Timer;
            if (IsPlayerMoved) WaitForPlayerMove.Enabled = false;           
        }
        void CheckSpecialCardsAndMakeMove (Player player)
        {
            if (CurrentDignity == 11) // любой туз
            {
                PassTheMoveToTheNextPlayer();
            }
            else if (CurrentDignity == 4 && CurrentSuit == 3) // король пик
            {
                for (int i = 0; i < 4; i++)
                {
                    TakeCard(player);
                }
                PassTheMoveToTheNextPlayer();
            }
            else if (CurrentDignity == 7) // любая семерка
            {
                for (int i = 0; i < 2; i++)
                {
                    TakeCard(player);
                }
                PassTheMoveToTheNextPlayer();
            }
            else if (CurrentDignity == 6) // любая шестерка
            {
                TakeCard(player);
                PassTheMoveToTheNextPlayer();
            }
            else
            {
                MakeMove(player);
            }
        }

        void PassTheMoveToTheNextPlayer()
        {
            int CurrentIntdexOfPlayer = Players.IndexOf(WhoseTurn);
            WhoseTurn = (CurrentIntdexOfPlayer == Players.Count - 1) ? Players[0] : Players[CurrentIntdexOfPlayer + 1];
        }

        bool IsSomeoneLoseGame()
        {
            bool IsSomeoneLooser = false;
            foreach ( Player player in Players)
            {
                if (player.IsLoose) IsSomeoneLooser = true;
            }
            return IsSomeoneLooser;
        }
        void StartRound()
        {
            FillOriginalDeck();
            DealCards();
            OpenFirstCard();
            ChooseWhoseTurn();  
        }

        void FillOriginalDeck ()
        {
            for (int i = 0; i < 36; i++)
            {
                Card card = new Card();
                card.Dignity =  i/4  + 2;
                if (i > 11) card.Dignity++;
                if (card.Dignity == 9) card.Dignity = 0;
                card.Suit = i % 4;
                card.BackImage = Properties.Resources.back;
                string imageName = String.Format("_{0}", i);
                card.FrontImage = (Image)Properties.Resources.ResourceManager.GetObject(imageName);
                OriginalDeck.AddCard(card);
            }
        }
        void OpenFirstCard()
        {
            Random random = new Random();
            Card card = OriginalDeck.Card(random.Next(OriginalDeck.Size - 1));
            OriginalDeck.TransferCardTo(OriginalDeck, card);
            CurrentDignity = card.Dignity;
            CurrentSuit = card.Suit;
        }

        void ChooseWhoseTurn()
        {
            Random random = new Random();
            WhoseTurn = (WhoWonPreviousRound == null) ? Players[random.Next(AmountOfPlayers)] : WhoWonPreviousRound;
        }
        public void DealCards ()
        {
            Random random = new Random();
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < AmountOfPlayers; j++)
                {
                    OriginalDeck.TransferCardTo(Players[i].deck, OriginalDeck.Card(random.Next(OriginalDeck.Size - 1)));
                }
            }          
        }
        
        public void TakeCard(Player player)
        {
            if (OriginalDeck.Size == 0)
            {
                while (UsedCardDeck.Size > 1)
                {
                    UsedCardDeck.TransferCardTo(OriginalDeck, UsedCardDeck.Card(0));
                }
            }
            Random random = new Random();
            Card card = OriginalDeck.Size > 1 ? OriginalDeck.Card(random.Next(OriginalDeck.Size - 1)) : OriginalDeck.Card(0);
            OriginalDeck.TransferCardTo(player.deck, card);
        }

        public void HitTheCard(Player player, Card card)
        {
            player.deck.TransferCardTo(UsedCardDeck, card);
        }
    }
}
