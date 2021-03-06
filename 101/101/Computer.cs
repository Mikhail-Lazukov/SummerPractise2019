﻿using System.Collections.Generic;
using System.Linq;


namespace _101
{
    class Computer:Player
    {
        public bool DoComputerHaveSuitableCard(int CurrentDignity, int CurrentSuit)
        {
            bool HaveSuitableCard = false;
            for(int i = 0; i<Deck.Size && !HaveSuitableCard; i++)
            {
                if (Deck.Card(i).Dignity == CurrentDignity) HaveSuitableCard = true;
                else if (Deck.Card(i).Suit == CurrentSuit) HaveSuitableCard = true;
                else if (Deck.Card(i).Dignity == 3) HaveSuitableCard = true;
            }
            return HaveSuitableCard;
        }

        public Card MakeMove (int CurrentDignity, int CurrentSuit)
        {
            Card card = new Card();
            for (int i = 0; i < Deck.Size; i++)
            {
                if (Deck.Card(i).Dignity == CurrentDignity || Deck.Card(i).Suit == CurrentSuit || Deck.Card(i).Dignity == 3)
                {
                    card = Deck.Card(i);
                    break;
                }
            }
            return card;
        }

        public int ChangeSuit()
        {
            int suit_0 = 0, suit_1 = 0, suit_2 = 0, suit_3 = 0;
            for (int i = 0; i < Deck.Size; i++)
            {
                switch (Deck.Card(i).Suit)
                {
                    case 0:
                        suit_0++;
                        break;
                    case 1:
                        suit_1++;
                        break;
                    case 2:
                        suit_2++;
                        break;
                    case 3:
                        suit_3++;
                        break;
                }
            }
            List<int> suits = new List<int> { suit_0, suit_1, suit_2, suit_3 };
            int suit = suits.Max();
            if (suit == suit_0) return 0;
            else if (suit == suit_1) return 1;
            else if (suit == suit_2) return 2;
            else return 3;
        }
    }
}
