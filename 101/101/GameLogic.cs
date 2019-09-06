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
        List<Player> _players = new List<Player>();
        readonly Deck _originalDeck = new Deck();
        Deck _usedCardDeck = new Deck();
        int WhoseTurn;
        int WhoWonPreviousRound = -1;
        public int CurrentDignity = -1;
        public int CurrentSuit = -1;
        private int AmountOfPlayers;

        public delegate void PrepareInterface(Deck OriginalDeck, List<Player> players);
        public delegate void ChagePlayerDeck(Player player, Deck FromOrInToDeck, bool IfFromPlayerDeck);
        public delegate void ChangeUsedCardAndOriginalDeck(Deck OriginalDeck, Deck UsedCardDeck, bool IsFromOriginalDeck);
        public delegate void PlayerChangeSuit();
        public delegate void ChangeSuitImage(int suit);

        public event PrepareInterface GameHasStarted;
        public event ChagePlayerDeck CardHasMovedFromOrIntoPlayerDeck;
        public event ChangeUsedCardAndOriginalDeck CardHasMovedFromOrIntoOriginalDeck;
        public event PlayerChangeSuit ChangeSuitRequired;
        public event ChangeSuitImage SuitHasChanged;

        public List<Player> Players
        {
            get => _players;
        }
        public Deck OriginalDeck
        {
            get => _originalDeck;
        }
        public Deck UsedCardDeck
        {
            get => _usedCardDeck;
        }
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
        void FillOriginalDeck()
        {
            for (int i = 0; i < 36; i++)
            {
                Card card = new Card();
                card.Dignity = i / 4 + 2;
                if (i > 11) card.Dignity++;
                if (card.Dignity == 9) card.Dignity = 0;
                card.Suit = i % 4;
                card.BackImage = Properties.Resources.back;
                string imageName = String.Format("_{0}", i);
                card.FrontImage = (Image)Properties.Resources.ResourceManager.GetObject(imageName);
                _originalDeck.AddCard(card);
            }
            GameHasStarted(_originalDeck, _players);
        }
        void ChooseWhoseTurn()
        {
            Random random = new Random();
            WhoseTurn = (WhoWonPreviousRound < 0) ? random.Next(AmountOfPlayers) : WhoWonPreviousRound;
        }
        void DealCards()
        {
            Random random = new Random();
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < AmountOfPlayers; j++)
                {                   
                    TransferCardFromInto(_originalDeck, _players[j].deck, _originalDeck.Card(random.Next(_originalDeck.Size)));
                    CardHasMovedFromOrIntoPlayerDeck(_players[j], _originalDeck, false);
                }
            }
        }
        void OpenFirstCard()
        {
            Random random = new Random();
            Card card = _players[WhoseTurn].deck.Card(random.Next(_players[WhoseTurn].deck.Size));
            MakeMove(card);
            CardHasMovedFromOrIntoPlayerDeck(_players[WhoseTurn], UsedCardDeck, true);
            ComputerMove();
        }
        void ComputerMove()
        {
            if (_players[WhoseTurn] is Computer)
            {
                if (((Computer)_players[WhoseTurn]).DoComputerHaveSuitableCard(CurrentDignity, CurrentSuit))
                {
                    MakeMove(((Computer)_players[WhoseTurn]).MakeMove(CurrentDignity, CurrentSuit));
                }
                else
                {
                    TakeCard(_players[WhoseTurn]);
                    PassTheMoveToTheNextPlayer();
                }
            }
        }
        void TransferCardFromInto(Deck FromThisDeck, Deck IntoThisDeck, Card card)
        {
            FromThisDeck.RemoveCard(card);
            IntoThisDeck.AddCard(card);
        }
        public void PlayerTakeCard()
        {
            TakeCard(_players[WhoseTurn]);
            if(CurrentDignity != 0)
            {
                PassTheMoveToTheNextPlayer();
            }
            ComputerMove();
        }
        void PassTheMoveToTheNextPlayer()
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
                TransferCardFromInto(_players[WhoseTurn].deck, _usedCardDeck, card);
                CardHasMovedFromOrIntoPlayerDeck(_players[WhoseTurn], _usedCardDeck, true);
                if (_players[WhoseTurn].deck.Size == 0)
                {
                    //CountPoints(card);
                }
                else
                {
                    if (card.Dignity != 0 && card.Dignity != 3)
                        PassTheMoveToTheNextPlayer();
                    if (card.Dignity == 3)
                    {
                        if (_players[WhoseTurn] is Computer)
                            ChangeSuit(((Computer)_players[WhoseTurn]).ChangeSuit());
                        else
                            ChangeSuitRequired();
                    }
                    else if (card.Dignity == 11)
                        PassTheMoveToTheNextPlayer();
                    else if (card.Dignity == 4 && card.Suit == 3)
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            TakeCard(_players[WhoseTurn]);
                        }
                        PassTheMoveToTheNextPlayer();
                    }
                    else if (card.Dignity == 7)
                    {
                        for (int i = 0; i < 2; i++)
                        {
                            TakeCard(_players[WhoseTurn]);
                        }
                        PassTheMoveToTheNextPlayer();
                    }
                    else if (card.Dignity == 6)
                    {
                        TakeCard(_players[WhoseTurn]);
                        PassTheMoveToTheNextPlayer();
                    }
                }
            }
            ComputerMove();
        }
        void TakeCard(Player player)
        {
            Random random = new Random();
            Card card = _originalDeck.Size > 1 ? _originalDeck.Card(random.Next(_originalDeck.Size)) : _originalDeck.Card(0);
            TransferCardFromInto(_originalDeck, player.deck, card);
            CardHasMovedFromOrIntoPlayerDeck(player, _originalDeck, false);
            if (_originalDeck.Size == 0)
            {
                while (UsedCardDeck.Size > 1)
                {
                    TransferCardFromInto(_usedCardDeck, _originalDeck, _usedCardDeck.Card(0));
                    CardHasMovedFromOrIntoOriginalDeck(_originalDeck, _usedCardDeck, false);
                }
            }
        }
        bool IsSuitableCard(Card card)
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
        bool IsSomeoneLoseGame()
        {
            bool IsSomeoneLooser = false;
            foreach ( Player player in Players)
            {
                if (player.IsLoose) IsSomeoneLooser = true;
            }
            return IsSomeoneLooser;
        }


        /*  ToDO : Реализовать конец раунда и начало следующего
         *  Реализовать посчет очков
         *  Реализовать отображение имен и очков около колод игроков  
         *  Запись рекордов
         *  Написать правила
         *  Таблица рекордов
         *  Сделать  CodeReview
         */
    }
}
