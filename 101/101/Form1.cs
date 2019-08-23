using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _101
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            PictureBox pb = new PictureBox();
            pb.Location = new Point(0, 0);
            GameLogic gl = new GameLogic();
            gl.FillOriginalDeck();
            pb.Size = new Size(100, 150);
            pb.Image = gl.OriginalDeck.GetCard(35).FrontImage;
            pb.Visible = true;
            pb.Name = "pb";
            pb.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Controls.Add(pb);
        }

        
    }
}
