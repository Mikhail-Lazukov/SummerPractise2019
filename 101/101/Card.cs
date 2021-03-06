﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace _101
{
    public class Card
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

        public bool Equals(Card other)
        {
            if (other != null)
            {
                bool _isEquals = false;
                if (other.Dignity == this.Dignity && other.Suit == this.Suit)
                    _isEquals = true;
                return _isEquals;
            }
            else return false;
        }
    }
}
