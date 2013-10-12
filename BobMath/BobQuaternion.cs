using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BobMath
{
    public class BobQuaternion
    {
        #region static members
        private static BobQuaternion _identity;
        public static BobQuaternion Identity
        {
            get {
                return _identity;
            }
        }

        #endregion

        #region constructor
        static BobQuaternion() {
            _identity = new BobQuaternion(0, 0, 0, 1);
        }

        public BobQuaternion(double x, double y, double z, double w) {
            this._data = new double[4];
            this.Set(x, y, z, w);
        }
        #endregion

        #region operator
        public static BobQuaternion operator +(BobQuaternion q1, BobQuaternion q2){
            return new BobQuaternion(q1.X + q2.X, q1.Y + q2.Y, q1.Z + q2.Z, q1.W + q2.W);
        }
        public static BobQuaternion operator -(BobQuaternion q1, BobQuaternion q2)
        {
            return new BobQuaternion(q1.X - q2.X, q1.Y - q2.Y, q1.Z - q2.Z, q1.W - q2.W);
        }
        public static BobQuaternion operator *(BobQuaternion q1, BobQuaternion q2)
        {
            return new BobQuaternion(
                q1.W * q2.X + q1.X * q2.W + q1.Y * q2.Z - q1.Z * q2.Y,
                q1.W * q2.Y - q1.X * q2.Z + q1.Y * q2.W + q1.Z * q2.X,
                q1.W * q2.Z + q1.X * q2.Y - q1.Y * q2.X + q1.Z * q2.W,
                q1.W * q2.W - q1.X * q2.X - q1.Y * q2.Y - q1.Z * q2.Z
                );
        }
        #endregion

        #region fields
        private double[] _data;
        private bool _isDirty;
        #endregion

        #region properties
        public double X
        {
            get
            {
                return _data[0];
            }
        }
        public double Y
        {
            get
            {
                return _data[1];
            }
        }
        public double Z
        {
            get
            {
                return _data[2];
            }
        }
        public double W
        {
            get
            {
                return _data[3];
            }
        }

        private double _length;
        public double Length
        {
            get
            {
                return this._length;
            }
        }
        private double _sqrLength;
        public double sqrLength
        {
            get
            {
                return this._sqrLength;
            }
        }

        private BobQuaternion _normalized;
        public BobQuaternion Normalized
        {
            get
            {
                CheckDirty();
                return _normalized;
            }
        }


        private BobVector3 _axis;
        public BobVector3 Axis {
            get
            {
                CheckDirty();
                return this._axis;
            }
        }

        private double _angle;
        public double Angle {
            get {
                CheckDirty();
                return this._angle;
            }
        }

        #endregion


        #region static method
        #endregion

        #region overrided methods
        public override string ToString()
        {
            return string.Format("x={0:0.000} y={1:0.000} z={2:0.000} w={3:0.000}", this.X, this.Y, this.Z, this.W);
        }
        #endregion

        #region private methods

        private void CheckDirty()
        {
            if (!this._isDirty) {
                return;
            }

            _normalized = new BobQuaternion(this.X / this.Length, this.Y / this.Length, this.Z / this.Length, this.W / this.Length);

            this._angle = 2 * Math.Acos(this._normalized.W);

            this._axis = new BobVector3(this.X, this.Y, this.Z);
            this._axis.Normalize();
            
            this._isDirty = false;
        }
        #endregion

        #region public methods
        public void Set(double x, double y, double z, double w) {
            this._data[0] = x;
            this._data[1] = y;
            this._data[2] = z;
            this._data[3] = w;

            this._sqrLength = 0;
            for (int i = 0; i < this._data.Length; i++) {
                this._sqrLength += this._data[i] * this._data[i];
            }

            this._length = Math.Sqrt(this._sqrLength);

            this._isDirty = true;
        }
        #endregion
    }
}
