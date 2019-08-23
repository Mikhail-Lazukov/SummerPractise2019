using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace _101
{
    class GameLogic
    {
        public Deck OriginalDeck = new Deck();
        public void FillOriginalDeck ()
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
        
    }
}
