using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BobMath;
using System.Windows.Media.Media3D;

namespace BobMatrixUnitTest
{
    [TestClass]
    public class UnitTestBobQuaternion
    {
        BobQuaternion q1 = new BobQuaternion(0.1, 0.2, 0.3, 0.4);
        BobQuaternion q2 = new BobQuaternion(0.1, 0.2, 0.3, 0.5);
        Quaternion q3 = new Quaternion(0.1, 0.2, 0.3, 0.4);
        Quaternion q4 = new Quaternion(0.1, 0.2, 0.3, 0.5);
        [TestMethod]
        public void TestBobQuaternion()
        {
            Console.WriteLine("q1 = {0}", q1);
            Console.WriteLine("q2 = {0}", q2);
            Console.WriteLine("q3 = {0}", q3);
            Console.WriteLine("{0} {1} {2} {3}", q3.X, q3.Y, q3.Z, q3.W);
            Console.WriteLine("q4 = {0}", q4);
            Console.WriteLine("q1*q2 = {0}", q1 * q2);
            Console.WriteLine("q2*q1 = {0}", q2 * q1);
            Console.WriteLine("q3*q4 = {0}", Quaternion.Multiply(q3, q4));
            Console.WriteLine("q4*q3 = {0}", Quaternion.Multiply(q4, q3));
            Console.WriteLine("q1.angle = {0}, q1.axis = {1}, q1.length = {2}", q1.Angle, q1.Axis, q1.Length);
            Console.WriteLine("q3.angle = {0}, q3.axis = {1}", q3.Angle, q3.Axis);
        }
    }
}
