using BobMath;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bobCG
{
    public class CGCamera : CGObject
    {
        #region static variables

        #endregion

        #region constructors
        public CGCamera() { 

        }
        #endregion

        #region fields
        private double _near;
        private double _far;
        private double _fieldOfView;
        private BobVector3 _position;

        private BobQuaternion _rotation;


        #endregion

        #region properties
        public double Near
        {
            get
            {
                return this._near;
            }
            set
            {
                this._near = value;
            }
        }
        public double Far
        {
            get
            {
                return this._far;
            }
            set
            {
                this._far = value;
            }
        }
        public double FieldOfView
        {
            get
            {
                return this._fieldOfView;
            }
            set
            {
                this._fieldOfView = value;
            }
        }

        public BobVector3 Position
        {
            get { return this._position; }
            set { this._position = value; }
        }
        public BobQuaternion Rotation
        {
            get { return this._rotation; }
            set { this._rotation = value; }
        }

        #endregion
        #region
        #endregion
        #region
        #endregion
        #region
        #endregion
        #region
        #endregion
        #region
        #endregion
        #region
        #endregion

    }
}
