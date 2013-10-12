using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BobMath;
namespace BobMatrixUnitTest
{
    [TestClass]
    public class UnitTestBobVector2
    {
        BobVector2 v1 = new BobVector2(3, 4);
        BobVector2 v2 = new BobVector2(5, 2);
        [TestMethod]
        public void TestBobVector2Operators()
        {
            Console.WriteLine("v1+v2 = {0}", v1 + v2);
            Console.WriteLine("v1-v2 = {0}", v1 - v2);
            Console.WriteLine("2*v1 = {0}", 2 * v1);
            Console.WriteLine("v1.sqrMag = {0}", v1.sqrMagtitude);
            Console.WriteLine("v1.Mag = {0}", v1.Magtitude);
            Console.WriteLine("v2.Mag = {0}",v2.Magtitude);
            Console.WriteLine("v1.Norm = {0}",v1.Normalized);
            Console.WriteLine("v2.Norm = {0}",v2.Normalized);
            Console.WriteLine("v1 and v2 Dot = {0}", BobVector2.Dot(v1, v2));
            Console.WriteLine("v1.Norm and v2.Norm Dot = {0}", BobVector2.Dot(v1.Normalized, v2.Normalized));
            Console.WriteLine("v1 and v2 Angle in Radians= {0}", BobVector2.Angle(v1, v2));
            Console.WriteLine("v1 and v2 Angle in Degrees= {0}", BobUtility.RadianToAngle(BobVector2.Angle(v1, v2)));
            Console.WriteLine("v1 and v2 Angle in Radians= {0}", BobUtility.AngleToRadian(BobUtility.RadianToAngle(BobVector2.Angle(v1, v2))));
            for (int i = 0; i < 11; i++) {
                double t = (double)i * 0.1;
                Console.WriteLine("v1 lerp v2 {0:0.00} = {1}", t, BobVector2.Lerp(v1, v2, t));
            }
        }
    }
}
