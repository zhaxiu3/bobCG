using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bobCG
{
    class CGPoint2D
    {
        private double x;

        public double X
        {
            get { return x; }
            set { x = value; }
        }
        private double y;

        public double Y
        {
            get { return y; }
            set { y = value; }
        }

        public CGPoint2D(double ax, double ay) {
            this.X = ax;
            this.Y = ay;
        }
    }
}
