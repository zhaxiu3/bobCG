using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BobMath
{
    public class BobMatrix
    {

        #region static members
        public static BobMatrix Identity(int size)
        {
            BobMatrix identity = new BobMatrix(size, size);
            for (int i = 0; i < size; i++)
            {
                identity[i, i] = 1;
            }
            return identity;
        }
        public static BobMatrix Zeros(int size)
        {
            BobMatrix identity = new BobMatrix(size, size);
            for (int i = 0; i < size; i++)
            {
                identity[i, i] = 0;
            }
            return identity;
        }
        #endregion

        #region operators
        public static BobMatrix operator +(BobMatrix m1, BobMatrix m2)
        {
            if (m1.Row != m2.Row)
            {
                throw new ArgumentException("the matrices operating + has different rows!");
            }
            if (m1.Column != m2.Column)
            {
                throw new ArgumentException("the matrices operating + has different columns!");
            }
            BobMatrix _result = new BobMatrix(m1.Row, m1.Column);
            for (int i = 0; i < m1.Row; i++) {
                for (int j = 0; j < m1.Column; j++) {
                    _result[i, j] = m1[i, j] + m2[i, j];
                }
            }
            return _result;
        }
        public static BobMatrix operator -(BobMatrix m1, BobMatrix m2)
        {
            if (m1.Row != m2.Row)
            {
                throw new ArgumentException("the matrices operating + has different rows!");
            }
            if (m1.Column != m2.Column)
            {
                throw new ArgumentException("the matrices operating + has different columns!");
            }
            BobMatrix _result = new BobMatrix(m1.Row, m1.Column);
            for (int i = 0; i < m1.Row; i++)
            {
                for (int j = 0; j < m1.Column; j++)
                {
                    _result[i, j] = m1[i, j] - m2[i, j];
                }
            }
            return _result;
        }
        public static BobMatrix operator *(BobMatrix m1, BobMatrix m2) {
            if (m1.Column != m2.Row) {
                throw new ArgumentException("m1 column not equal to m2 row!!");
            }
            BobMatrix _result = new BobMatrix(m1.Row, m2.Column);
            for (int i = 0; i < _result.Row; i++) {
                for (int j = 0; j < _result.Column; j++) {
                    for (int k = 0; k < m1.Column; k++) {
                        _result[i, j] += m1[i, k] * m2[k, j];
                    }
                }
            }
            return _result;
        }
        public static BobMatrix operator *(BobMatrix m, double n) {
            BobMatrix _result = new BobMatrix(m);
            for (int i = 0; i < m.Row; i++) {
                for (int j = 0; j < m.Column; j++) {
                    _result[i, j] *= n;
                }
            }
            return _result;
        }
        public static BobMatrix operator *(double n, BobMatrix m)
        {
            return m * n;
        }
        public double this[int row, int column]
        {
            get
            {
                checkIndexBoundary(row, column);
                return this.mdataBuffer[row, column];
            }
            set
            {
                checkIndexBoundary(row, column);
                this.mdataBuffer[row, column] = value;
            }
        }
        #endregion

        #region overrided methods
        public override string ToString()
        {
            string mString = string.Format("row:{0} col{1}: \n", this.Row, this.Column);
            for (int i = 0; i < this.Row; i++) {
                for (int j = 0; j < this.Column; j++) {
                    mString += " " + this[i, j]+",";
                }
                mString += "\n";
            }
            return mString;
        }
        #endregion

        #region Fields
        private double[,] mdataBuffer;
        #endregion
        #region Properties
        public int Row
        {
            get;
            private set;
        }
        public int Column
        {
            get;
            private set;
        }
        #endregion

        #region Constructor
        public BobMatrix(int row, int col)
        {
            initRowAndColumn(row, col);
        }
        public BobMatrix(int row, int col, double[] datasource) {
            if (datasource.Length < row * col)
            {
                throw new ArgumentOutOfRangeException("data has not enough entries!");
            }
            initRowAndColumn(row, col);
            for (int i = 0; i < row; i++) {
                for (int j = 0; j < col; j++) {
                    this[i, j] = datasource[i * col + j];
                }
            }
        }
        public BobMatrix(BobMatrix m)
        {
            initRowAndColumn(m.Row, m.Column);
            for (int i = 0; i < m.Row; i++) {
                for (int j = 0; j < m.Column; j++) {
                    this[i, j] = m[i, j];
                }
            }
        }
        #endregion
        #region public method
        public BobMatrix getRow(int rowNum) {
            if (rowNum >= this.Row) {
                throw new ArgumentOutOfRangeException("row num is out of range!");
            }
            BobMatrix rowVector = new BobMatrix(1, this.Column);
            for (int i = 0; i < rowVector.Column; i++) {
                rowVector[0, i] = this[rowNum, i];
            }
            return rowVector;
        }
        public BobMatrix getColumn(int colNum)
        {
            if (colNum >= this.Column)
            {
                throw new ArgumentOutOfRangeException("column num is out of range!");
            }
            BobMatrix colVector = new BobMatrix(this.Row,1);
            for (int i = 0; i < colVector.Row; i++)
            {
                colVector[i,0] = this[i, colNum];
            }
            return colVector;
        }
        public BobMatrix Eliminate() {
            BobMatrix elimination = new BobMatrix(this);
            for (int i = 0; i < elimination.Row - 1; i++)
            {
                for (int j = i + 1; j < elimination.Row; j++)
                {
                    if (elimination[i, i] == 0)
                    {
                        for (int p = i + 1; p < elimination.Row; p++)
                        {
                            if (elimination[p, i] != 0)
                            {
                                elimination.ExchangeRow1(i, p);
                                break;
                            }
                        }
                        if (elimination[i, i] == 0)
                            throw new Exception("this matrix is not invertable!");
                    }
                    double factor = elimination[j, i] / elimination[i, i] * -1.0;
                    if (elimination[j, i] == 0)
                        continue;
                    for (int k = i; k < elimination.Column; k++) {
                        elimination[j, k] += factor * elimination[i, k];
                    }
                    if (elimination.getRow(j).isAllZero())
                    {
                        throw new Exception("this matrix is not invertable!");
                    }
                }
            }
            return elimination;
        }
        public void ExchangeRow1(int row1, int row2)
        {
            if (this.rowOutOfRange(row1))
            {
                throw new ArgumentOutOfRangeException("row1 is out of Range!");
            }
            if (this.rowOutOfRange(row2))
            {
                throw new ArgumentOutOfRangeException("row2 is out of Range!");
            }
            BobMatrix tempRow = this.getRow(row1);
            for (int i = 0; i < this.Column; i++)
            {
                this[row1, i] = this[row2, i];
                this[row2, i] = tempRow[0, i];
            }
        }
        public void ExchangeColumn1(int column1, int column2)
        {
            if (this.columnOutOfRange(column1))
            {
                throw new ArgumentOutOfRangeException("column1 is out of Range!");
            }
            if (this.columnOutOfRange(column2))
            {
                throw new ArgumentOutOfRangeException("column2 is out of Range!");
            }
            BobMatrix tempColumn = this.getColumn(column1);
            for (int i = 0; i < this.Row; i++)
            {
                this[i,column1] = this[i,column2];
                this[i,column2] = tempColumn[i,0];
            }
        }
        public BobMatrix Transpose() {
            BobMatrix transpose = new BobMatrix(this.Column, this.Row);
            for (int i = 0; i < transpose.Row; i++) {
                for (int j = 0; j < transpose.Column; j++) {
                    transpose[i, j] = this[j, i];
                }
            }
            return transpose;
        }
        #endregion
        #region private method
        private void initRowAndColumn(int row, int col)
        {

            this.mdataBuffer = new double[row, col];
            this.Row = row;
            this.Column = col;
        }
        private void checkIndexBoundary(int row, int column)
        {
            if (null == this.mdataBuffer)
                throw new NullReferenceException("please initialize the Matrix first!");
            if (row >= this.mdataBuffer.GetLength(0))
                throw new IndexOutOfRangeException("row index is out of Matrix!");
            if (column >= this.mdataBuffer.GetLength(1))
                throw new IndexOutOfRangeException("column index is out of Matrix!");
        }
        private bool rowOutOfRange(int row)
        {
            return row >= this.Row || row < 0;
        }
        private bool columnOutOfRange(int column)
        {
            return column >= this.Column || column < 0;
        }
        private bool isAllZero() {
            for (int i = 0; i < this.Row; i++) {
                for (int j = 0; j < this.Column; j++) {
                    if (this[i, j] != 0)
                        return false;
                }
            }
            return true;
        }
        #endregion

    }
}
