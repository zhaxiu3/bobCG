using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BobMath
{
    public class BobVector3
    {
        #region static members
        private static BobVector3 _zero;
        public static BobVector3 zero
        {
            get
            {
                return _zero;
            }
        }

        private static BobVector3 _one;
        public static BobVector3 one
        {
            get
            {
                return _one;
            }
        }

        private static BobVector3 _right;
        public static BobVector3 right
        {
            get
            {
                return _right;
            }
        }

        private static BobVector3 _up;
        public static BobVector3 up
        {
            get
            {
                return _up;
            }
        }

        private static BobVector3 _forward;
        public static BobVector3 forward
        {
            get
            {
                return _forward;
            }
        }
        #endregion

        #region constructor
        static BobVector3()
        {
            _zero = new BobVector3(0, 0, 0);
            _one = new BobVector3(1, 1, 1);
            _right = new BobVector3(1, 0, 0);
            _up = new BobVector3(0, 1, 0);
            _forward = new BobVector3(0, 0, 1);
        }
        public BobVector3(double x, double y, double z)
        {
            _data = new double[3];
            this.Set(x, y, z);
        }
        #endregion

        #region operator
        public static BobVector3 operator +(BobVector3 v1, BobVector3 v2)
        {
            return new BobVector3(v1.X + v2.X, v1.Y + v2.Y, v1.Z + v2.Z);
        }

        public static BobVector3 operator -(BobVector3 v1, BobVector3 v2)
        {
            return new BobVector3(v1.X - v2.X, v1.Y - v2.Y, v1.Z - v2.Z);
        }

        public static BobVector3 operator *(double d, BobVector3 v)
        {
            return new BobVector3(d * v.X, d * v.Y, d * v.Z);
        }
        public static BobVector3 operator *(BobVector3 v, double d)
        {
            return d * v;
        }

        #endregion

        #region fields
        private bool _isDirty;
        private double[] _data;
        #endregion

        #region properties
        //在set里可以添加函数修改与X，Y相关的参数如magtitude等等
        public double X
        {
            get
            {
                return _data[0];
            }
            private set
            {
                _data[0] = value;
            }
        }
        public double Y
        {
            get
            {
                return _data[1];
            }
            private set
            {
                _data[1] = value;
            }
        }
        public double Z
        {
            get
            {
                return _data[2];
            }
            private set
            {
                _data[2] = value;
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

        private BobVector3 _Normalized;
        public BobVector3 Normalized
        {
            get
            {
                if (this.Magtitude == 0) {
                    throw new Exception("Zero Vector cannot be normalized");
                }

                if (_isDirty)
                {
                    _Normalized = new BobVector3(this.X / this.Magtitude, this.Y / this.Magtitude, this.Z / this.Magtitude);
                    _isDirty = false;
                }
                return _Normalized;
            }
        }

        #endregion


        #region static method
        public static double Distance(BobVector3 v1, BobVector3 v2)
        {
            return (v1 - v2).Magtitude;
        }
        public static double Dot(BobVector3 v1, BobVector3 v2)
        {
            double result = 0;
            for (int i = 0; i < 3; i++)
            {
                result += v1._data[i] * v2._data[i];
            }
            return result;
        }
        public static double Angle(BobVector3 from, BobVector3 to)
        {
            return Math.Acos(BobVector3.Dot(from.Normalized, to.Normalized));
        }

        public static BobVector3 Lerp(BobVector3 from, BobVector3 to, double t)
        {
            return new BobVector3(BobUtility.lerp(from.X, to.X, t), BobUtility.lerp(from.Y, to.Y, t), BobUtility.lerp(from.Z, to.Z, t));
        }
        #endregion

        #region overrided methods
        public override string ToString()
        {
            return string.Format("x:{0:0.00} y:{1:0.00} z:{2:0.00}", this.X, this.Y, this.Z);
        }
        #endregion

        #region private methods
        #endregion

        #region public methods
        public void Normalize()
        {
            if (this.Magtitude == 0)
            {
                throw new Exception("Zero Vector cannot be normalized");
            }
            this.Set(this.X / this.Magtitude, this.Y / this.Magtitude, this.Z / this.Magtitude);
        }
        public void Set(double x, double y, double z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;

            this._sqrMagtitude = 0;
            for (int i = 0; i < this._data.Length; i++)
            {
                this._sqrMagtitude += this._data[i] * this._data[i];
            } 
            this._magtitude = Math.Sqrt(this._sqrMagtitude);
            _isDirty = true;
        }
        #endregion
    }
}
