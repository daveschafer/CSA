//------------------------------------------------------------------------------
// C #   I N   A C T I O N   ( C S A )
//------------------------------------------------------------------------------
// Repository:
//    $Id: TrackArcLeft.cs 1039 2016-10-25 11:56:45Z chj-hslu $
//------------------------------------------------------------------------------
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace RobotCtrl
{

    /// <summary>
    /// Track um eine Linkskurve zu fahren. Dazu werden beide Motoren mit
    /// unterschiedlicher Geschwindigkeit angesteuert.
    /// </summary>
    public class TrackArcLeft : Track
    {

        #region constructor & destructor
        /// <summary>
        /// siehe TracArcRight
        /// </summary>
        /// <param name="radius"></param>
        /// <param name="angle"></param>
        /// <param name="speed"></param>
        /// <param name="acceleration"></param>
        public TrackArcLeft(float radius, float angle, float speed, float acceleration)
        {
            reverse = (Math.Sign(angle) ^ Math.Sign(speed)) != 0;
            this.nominalSpeed = Math.Abs(speed);
            this.acceleration = acceleration;
            this.Angle = Math.Abs(angle);
            this.Radius = Math.Abs(radius);
            this.length = Math.Abs((radius + Constants.AxleLength / 2.0f) * 2.0f * (float)Math.PI * angle / 360.0f);
        }
        #endregion


        #region properties
        public float Angle { get; protected set; }
        public float Radius { get; protected set; }
        #endregion


        #region methods
        public override void IncrementalStep(float timeInterval, float newVelocity, out float leftSpeed, out float rightSpeed)
        {
            currentVelocity = newVelocity;
            if (reverse)
                newVelocity = -newVelocity;
            leftSpeed = -newVelocity * (Radius - Constants.AxleLength / 2.0f) / (Radius + Constants.AxleLength / 2.0f);
            rightSpeed = newVelocity;
            DoStep(timeInterval);
        }
        #endregion
    }
}
