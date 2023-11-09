using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Media;

namespace Lotto
{
    internal class SnowInfo
    {
        private Image flake;
        public Image Flake
        {
            get { return flake;}
            set { flake = value; }
        }
        private double velocityY;
        public double VelocityY
        {
            get { return velocityY; }
            set { velocityY = value; }
        }
        private double velocityX;
        public double VelocityX
        {
            get { return velocityX; }
            set { velocityX = value; }
        }
        public int Radius { get; set; }

        public SnowInfo(Image flake, double velocityY, int radius)
        {
            VelocityY = velocityY;
            Flake = flake;
            flake.Width = radius;
            this.Radius = radius;
        }
    }
}