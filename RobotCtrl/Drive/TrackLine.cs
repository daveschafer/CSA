//------------------------------------------------------------------------------
// C #   I N   A C T I O N   ( C S A )
//------------------------------------------------------------------------------
// Repository:
//    $Id: TrackLine.cs 1039 2016-10-25 11:56:45Z chj-hslu $
//------------------------------------------------------------------------------
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace RobotCtrl
{

    /// <summary>
    /// Track um geradeaus zu fahren. Dazu werden beide Motoren gleichzeitig 
    /// und mit der selben Geschwindigkeit angesteuert.
    /// </summary>
    public class TrackLine : Track
    {

        #region constructor & destructor
        /// <summary>
        /// Initialisiert das TrackLine Objekt.
        /// 
        /// Folgende Variablen der Basisklasse müssen gesetzt werden:
        /// - length (nur positiver Wert!!!)
        /// - nominalspeed (nur positiver Wert!!!)
        /// - acceleration
        /// - reverse
        /// 
        /// </summary>
        /// <param name="length">Strecke, die zurückgelegt werden soll [m]</param>
        /// <param name="speed">die gewünschte Geschwindigkeit [m/s]</param>
        /// <param name="acceleration">die gewünschte Beschleunigung [m/s^2]</param>
        public TrackLine(float length, float speed, float acceleration)
        {
            // Reverse: -1^-1=0, -1^1=-2, 1^1=0
            this.reverse = (Math.Sign(length) ^ Math.Sign(speed)) != 0;
            this.length = Math.Abs(length);
            this.nominalSpeed = Math.Abs(speed);
            this.acceleration = acceleration;
        }
        #endregion


        #region methods
        /// <summary>
        /// Berechnet die Geschwindigkeit für die beiden Räder (rechts/links).
        /// 
        /// Geradeausfahren heisst, beide Räder gleich schnell laufen lassen.
        /// Es muss nur berücksichtigt werden, dass ein Motor um 180° gedreht
        /// montiert ist => einer muss in die umgekehrte Richtung drehen.
        /// </summary>
        /// <param name="timeInterval">die Zeit seit dem letzten Aufruf [s]</param>
        /// <param name="newVelocity">die neue Fahrgeschwindigkeit [m/s]</param>
        /// <param name="leftSpeed">die entsprechende Geschwindigkeit für das linke Rad [m/s]</param>
        /// <param name="rightSpeed">die entsprechende Geschwindigkeit für das rechte Rad [m/s]</param>
        public override void IncrementalStep(float timeInterval, float newVelocity, out float leftSpeed, out float rightSpeed)
        {
            currentVelocity = newVelocity;

            if (reverse) newVelocity = -newVelocity;

            leftSpeed = -newVelocity; // Motor ist um 180° gedreht montiert!!!
            rightSpeed = newVelocity;
            DoStep(timeInterval);
        }
        #endregion
    }
}
