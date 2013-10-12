using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BobMath
{
    public class BobUtility
    {
        public static double RadianToAngle(double rad)
        {
            return 180.0 * rad / Math.PI;
        }

        public static double AngleToRadian(double angle) {
            return Math.PI * angle / 180.0;
        }

        public static double lerp(double from, double to, double t) {
            return from + (to - from) * t;
        }
    }
}
