using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace _101
{
    class Player
    {
        private int score;
        public Deck deck = new Deck();
        public int deckLocationY;
        private bool _isLoose;

        protected Player ()
        {
            score = 0;
            _isLoose = false;
        }

        public bool IsLoose
        {
            get
            {
                if (score > 101) _isLoose = true;
                return _isLoose;
            }
        }


    }
}
