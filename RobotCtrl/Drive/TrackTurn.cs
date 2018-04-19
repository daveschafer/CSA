//------------------------------------------------------------------------------
// C #   I N   A C T I O N   ( C S A )
//------------------------------------------------------------------------------
// Repository:
//    $Id: TrackTurn.cs 1039 2016-10-25 11:56:45Z chj-hslu $
//------------------------------------------------------------------------------
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace RobotCtrl
{

    /// <summary>
    /// Track um an Ort und Stelle zu drehen..
    /// </summary>
    public class TrackTurn : Track
    {

        #region constructor & destructor
        /// <summary>
        /// 
        /// </summary>
        /// <param name="angle">der gewünschte Winkel [°]</param>
        /// <param name="speed">die Drehgeschwindigkeit [m/s]</param>
        /// <param name="acceleration">die Beschleunigung [m/s^2]</param>
        public TrackTurn(float angle, float speed, float acceleration)
        {
            this.reverse = (Math.Sign(angle) ^ Math.Sign(speed)) != 0;
            this.nominalSpeed = Math.Abs(speed);
            this.acceleration = acceleration;
            this.Angle = Math.Abs(angle);
            this.length = Math.Abs(Constants.AxleLength / 2.0f * 2.0f * (float)Math.PI * angle / 360.0f);
        }
        #endregion


        #region properties
        /// <summary>
        /// Liefert bzw. setzt den Drehwinkel [°]
        /// </summary>
        public float Angle { get; protected set; }
        #endregion


        #region methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="timeInterval"></param>
        /// <param name="newVelocity"></param>
        /// <param name="leftSpeed"></param>
        /// <param name="rightSpeed"></param>
        public override void IncrementalStep(float timeInterval, float newVelocity, out float leftSpeed, out float rightSpeed)
        {
            currentVelocity = newVelocity;
            if (reverse) newVelocity = -newVelocity;

            rightSpeed = newVelocity;
            leftSpeed = newVelocity;
            DoStep(timeInterval);
        }
        #endregion
    }
}