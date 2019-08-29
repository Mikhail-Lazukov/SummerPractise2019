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
        private int _size = 0;

        public int Size
        {
            get { return _size; }
        }
        
        public int TotalDignity
        {
            get { return _totalDignity; }
        }

        public Card Card (int cardIndex)
        {
            return _deck[cardIndex];
        }

        public void AddCard(Card card)
        {
            _deck.Add(card);
            _totalDignity += card.Dignity;
            _size++;
        }

        public void RemoveCard(Card card)
        {
            _deck.Remove(card);
            _totalDignity -= card.Dignity;
            _size--;
        }

        public void TransferCardTo(Deck anotherDeck, Card card)
        {
            anotherDeck.AddCard(card);
            this.RemoveCard(card);
        }
    }
}
