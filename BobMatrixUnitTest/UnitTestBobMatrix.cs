using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BobMath;

namespace BobMatrixUnitTest
{
    [TestClass]
    public class UnitTestBobMatrix
    {
        [TestMethod]
        public void TestArrayLength()
        {
            // make a single dimension array
            Array MyArray1 = Array.CreateInstance(typeof(int), 5);

            // make a 3 dimensional array
            Array MyArray2 = Array.CreateInstance(typeof(int), 5, 3, 2);

            // make an array container
            Array BossArray = Array.CreateInstance(typeof(Array), 2);
            BossArray.SetValue(MyArray1, 0);
            BossArray.SetValue(MyArray2, 1);

            int i = 0, j, rank;
            foreach (Array anArray in BossArray)
            {
                rank = anArray.Rank;
                if (rank > 1)
                {
                    Console.WriteLine("Lengths of {0:d} dimension array[{1:d}]", rank, i);
                    // show the lengths of each dimension 
                    for (j = 0; j < rank; j++)
                    {
                        Console.WriteLine("    Length of dimension({0:d}) = {1:d}", j, anArray.GetLength(j));
                    }
                }
                else
                {
                    Console.WriteLine("Lengths of single dimension array[{0:d}]", i);
                }
                // show the total length of the entire array or all dimensions
                Console.WriteLine("    Total length of the array = {0:d}", anArray.Length);
                Console.WriteLine();
                i++;
            }
        }

        [TestMethod]
        public void TestArrayDimension() { 
            int [,,] a = new int[1,2,3];
            int rank = a.Rank;
            for (int i = 0; i < rank; i++)
            {
                Console.WriteLine("{0} dimension length is{1}", i, a.GetLength(i));
            }
            
        }

        [TestMethod]
        public void TestMatrixOperation()
        {
            BobMatrix a = BobMatrix.Identity(3);
            BobMatrix b = BobMatrix.Identity(3);
            a[2, 1] = -2;
            b[0, 1] = 2;
            b[0, 2] = 1;
            b[1, 1] = 2;
            b[1, 2] = -2;
            b[2, 1] = 4;
            b[2, 2] = 1;
            Console.WriteLine(3 * a);
            Console.WriteLine(3 * b);            
        }
        [TestMethod]
        public void TestMatrixRowExchange()
        {
            BobMatrix a = BobMatrix.Identity(5);
            a.ExchangeRow1(1, 2);
            Console.WriteLine(a);
        }
        [TestMethod]
        public void TestMatrixColumnExchange()
        {
            BobMatrix a = BobMatrix.Identity(5);
            a.ExchangeColumn1(1, 2);
            Console.WriteLine(a);
        }
        [TestMethod]
        public void TestMatrixElimination()
        {
            BobMatrix a = new BobMatrix(3, 3);
            a[0, 0] = 1;
            a[0, 1] = 2;
            a[0, 2] = 1;
            a[1, 0] = 3;
            a[1, 1] = 8;
            a[1, 2] = 1;
            a[2, 0] = 0;
            a[2, 1] = 4;
            a[2, 2] = 1;
            Console.WriteLine(a.Eliminate());
        }
        [TestMethod]
        public void TestMatrixTranspose()
        {
            BobMatrix a = new BobMatrix(3, 4);
            a[0, 0] = 1;
            a[0, 1] = 2;
            a[0, 2] = 1;
            a[0, 3] = 2;
            a[1, 0] = 3;
            a[1, 1] = 8;
            a[1, 2] = 1;
            a[1, 3] = 12;
            a[2, 0] = 0;
            a[2, 1] = 4;
            a[2, 2] = 1;
            a[2, 3] = 2;
            Console.WriteLine(a);
            Console.WriteLine(a.Transpose());
        }
        [TestMethod]
        public void TestMatrixConstructor()
        {
            BobMatrix a = new BobMatrix(3, 4, new double[]{1,2,1,2,3,8,1,12,0,4,1,2});
            Console.WriteLine(a);
            Console.WriteLine(a.Transpose());
        }
    }
}
