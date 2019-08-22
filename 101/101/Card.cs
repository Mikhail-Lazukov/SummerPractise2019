using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace _101
{
    class Card
    {
        private int _dignity;
        private int _suit;
        private Image _backImage;
        private Image _frontImage;


        public int Dignity
        {
            get { return _dignity; }
            set { _dignity = value; }
        }

        public int Suit
        {
            get { return _suit; }
            set { _suit = value; }
        }

        public Image BackImage
        {
            get { return _backImage; }
            set { _backImage = value; }
        }

        public Image FrontImage
        {
            get { return _frontImage; }
            set { _frontImage = value; }
        }
    }
}
