using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BobMath;

namespace BobMatrixUnitTest
{
    [TestClass]
    public class UnitTestBobVector3
    {
        BobVector3 v1 = new BobVector3(0, 0, 1);
        BobVector3 v2 = new BobVector3(0, 1, 0);

        [TestMethod]
        public void TestBobVector3()
        {
            Console.WriteLine("v = {0}", BobVector3.one);
            Console.WriteLine("v1 = {0}", v1);
            Console.WriteLine("v2 = {0}", v2);
            Console.WriteLine("v1+v2 = {0}", v1 + v2);
            Console.WriteLine("v1-v2 = {0}", v1 - v2);
            Console.WriteLine("2*v1 = {0}", 2 * v1);
            Console.WriteLine("v1.sqrMag = {0}", v1.sqrMagtitude);
            Console.WriteLine("v1.Mag = {0}", v1.Magtitude);
            Console.WriteLine("v2.Mag = {0}", v2.Magtitude);
            Console.WriteLine("v1.Norm = {0}", v1.Normalized);
            Console.WriteLine("v2.Norm = {0}", v2.Normalized);
            Console.WriteLine("v1 and v2 Dot = {0}", BobVector3.Dot(v1, v2));
            Console.WriteLine("v1.Norm and v2.Norm Dot = {0}", BobVector3.Dot(v1.Normalized, v2.Normalized));
            Console.WriteLine("v1 and v2 Angle in Radians= {0}", BobVector3.Angle(v1, v2));
            Console.WriteLine("v1 and v2 Angle in Degrees= {0}", BobUtility.RadianToAngle(BobVector3.Angle(v1, v2)));
            Console.WriteLine("v1 and v2 Angle in Radians= {0}", BobUtility.AngleToRadian(BobUtility.RadianToAngle(BobVector3.Angle(v1, v2))));
            for (int i = 0; i < 11; i++)
            {
                double t = (double)i * 0.1;
                Console.WriteLine("v1 lerp v2 when t = {0:0.00}, result = {1}", t, BobVector3.Lerp(v1, v2, t));
            }
        }
    }
}
