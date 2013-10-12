using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BobMath
{
    public class BobVector2
    {
        #region static members
        private static BobVector2 _zero;
        public static BobVector2 zero {
            get {
                return _zero;
            }
        }

        private static BobVector2 _one;
        public static BobVector2 one {
            get
            {
                return _one;
            }
        }

        private static BobVector2 _right;
        public static BobVector2 right
        {
            get
            {
                return _right;
            }
        }

        private static BobVector2 _up;
        public static BobVector2 up
        {
            get
            {
                return _up;
            }
        }
        #endregion

        #region constructor
        static BobVector2() {
            _zero = new BobVector2(0, 0);
            _one = new BobVector2(1, 1);
            _right = new BobVector2(1, 0);
            _up = new BobVector2(0, 1);

        }

        public BobVector2(double x, double y)
        {
            _data = new double[2];
            this.Set(x, y);
        }
        #endregion

        #region operator
        public static BobVector2 operator +(BobVector2 v1, BobVector2 v2)
        {
            return new BobVector2(v1.X + v2.X, v1.Y + v2.Y);
        }

        public static BobVector2 operator -(BobVector2 v1, BobVector2 v2)
        {
            return new BobVector2(v1.X - v2.X, v1.Y - v2.Y);
        }

        public static BobVector2 operator *(double d, BobVector2 v) {
            return new BobVector2(d*v.X, d*v.Y);
        }
        public static BobVector2 operator *(BobVector2 v, double d) {
            return d * v;
        }

        #endregion

        #region fields
        private bool _isDirty;
        private double[] _data;
        #endregion

        #region properties
        public double X
        {
            get{
                return _data[0];
            }
            private set {
                _data[0] = value;
            }
        }
        public double Y
        {
            get {
                return _data[1];
            }
            private set {
                _data[1] = value;
            }
        }

        private double _magtitude;
        public double Magtitude
        {
            get
            {
                return _magtitude;
            }
        }

        private double _sqrMagtitude;
        public double sqrMagtitude
        {
            get
            {
                return _sqrMagtitude;
            }
        }

        private BobVector2 _Normalized;
        public BobVector2 Normalized {
            get {

                if (this.Magtitude == 0)
                {
                    throw new Exception("Zero Vector cannot be normalized");
                }

                if (_isDirty) {
                    _Normalized = new BobVector2(this.X/this.Magtitude, this.Y/this.Magtitude);
                    _isDirty = false;
                }
                return _Normalized;
            }
        }

        #endregion


        #region static method
        public static double Distance(BobVector2 v1, BobVector2 v2) {
            return (v1 - v2).Magtitude;
        }
        public static double Dot(BobVector2 v1, BobVector2 v2) {
            double result = 0;
            for (int i = 0; i < 2; i++) {
                result += v1._data[i] * v2._data[i];
            }
            return result;
        }
        public static double Angle(BobVector2 from, BobVector2 to) {
            return Math.Acos(BobVector2.Dot(from.Normalized, to.Normalized));
        }

        public static BobVector2 Lerp(BobVector2 from, BobVector2 to, double t)
        {
            return new BobVector2(BobUtility.lerp(from.X, to.X, t), BobUtility.lerp(from.Y, to.Y, t));
        }
        #endregion

        #region overrided methods
        public override string ToString()
        {
            return string.Format("x:{0:0.00} y:{1:0.00}", this.X, this.Y);
        }
        #endregion

        #region private methods
        #endregion

        #region public methods
        public void Normalize() {
            if (this.Magtitude == 0)
            {
                throw new Exception("Zero Vector cannot be normalized");
            }
            this.Set(this.X / this.Magtitude, this.Y / this.Magtitude);
        }
        public void Set(double x, double y) {
            this.X = x;
            this.Y = y;

            this._sqrMagtitude = 0;
            for (int i = 0; i < this._data.Length; i++) {
                this._sqrMagtitude += this._data[i] * this._data[i];
            } 

            this._magtitude = Math.Sqrt(this._sqrMagtitude);
            _isDirty = true;
        }
        #endregion
    }
}
