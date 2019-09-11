using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace _101
{
    public class Player
    {
        private int _score;
        private Deck _deck = new Deck();
        private bool _isLoose;

        public Player()
        {
            _score = 0;
            _isLoose = false;
        }

        public Deck Deck
        {
            get { return _deck; }
        }

        public int Score
        {
            get { return _score; }
            set { _score = value; }
        }

        public bool IsLoose
        {
            get
            {
                if (_score > 101) _isLoose = true;
                else if (_score == 101) _score = 0;
                return _isLoose;
            }
        }


    }
}
