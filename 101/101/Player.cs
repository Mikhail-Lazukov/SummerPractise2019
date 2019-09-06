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
        private int score;
        public Deck deck = new Deck();
        private bool _isLoose;

        public Player()
        {
            score = 0;
            _isLoose = false;
        }

        public bool IsLoose
        {
            get
            {
                if (score > 101) _isLoose = true;
                else if (score == 101) score = 0;
                return _isLoose;
            }
        }


    }
}
