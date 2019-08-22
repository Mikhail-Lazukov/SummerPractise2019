using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _101
{
    class Deck
    {
        private List<Card> _deck = new List<Card>();
        private int _totalDignity;
        private int _deckSize = 0;

        public int DeckSize
        {
            get { return _deckSize; }
        }
        
        public int TotalDignity
        {
            get { return _totalDignity; }
        }

        public Card GetCard (int cardIndex)
        {
            return _deck[cardIndex];
        }

        public void AddCard(Card card)
        {
            _deck.Add(card);
            _totalDignity += card.Dignity;
            _deckSize++;
        }

        public void RemoveCard(int cardIndex)
        {
            _deck.Remove(this.GetCard(cardIndex));
            _totalDignity -= this.GetCard(cardIndex).Dignity;
            _deckSize--;
        }

        public void TransferCardTo(Deck anotherDeck, int cardIndex)
        {
            anotherDeck.AddCard(this.GetCard(cardIndex));
            this.RemoveCard(cardIndex);
        }
    }
}
