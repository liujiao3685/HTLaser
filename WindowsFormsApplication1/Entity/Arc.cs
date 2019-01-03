using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDIPaint
{
    public class Arc
    {
        public int StartX { set; get; }

        public int StartY { set; get; }

        public int Width { set; get; }

        public int Height { set; get; }

        public float StartAngle { set; get; }

        public float EndAngle { set; get; }

        public Rectangle Rectangle { set; get; }

    }
}
