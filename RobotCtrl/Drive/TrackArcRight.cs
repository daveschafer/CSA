//------------------------------------------------------------------------------
// C #   I N   A C T I O N   ( C S A )
//------------------------------------------------------------------------------
// Repository:
//    $Id: TrackArcRight.cs 1039 2016-10-25 11:56:45Z chj-hslu $
//------------------------------------------------------------------------------
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace RobotCtrl
{
    /// <summary>
    /// Track um eine Rechtskurve zu fahren. Dazu werden beide Motoren mit
    /// unterschiedlicher Geschwindigkeit angesteuert.
    /// </summary>
    public class TrackArcRight : Track
    {

        #region constructor & destructor
        /// <summary>
        /// Initialisiert den Track. Dabei muss u.a. die Länge angegeben werden,
        /// die zurückgelegt wird. Per Definition wird die Distanz als Länge
        /// ausgewählt, die das äussere Rad bei diesem Track zurücklegt.
        /// </summary>
        /// <param name="radius"></param>
        /// <param name="angle"></param>
        /// <param name="speed"></param>
        /// <param name="acceleration"></param>
        public TrackArcRight(float radius, float angle, float speed, float acceleration)
        {
            // Falls Winkel oder Geschwindigkeit negativ sind => rückwärts fahren
            reverse = (Math.Sign(angle) ^ Math.Sign(speed)) != 0;
            this.nominalSpeed = Math.Abs(speed);
            this.acceleration = acceleration;
            this.Angle = Math.Abs(angle);
            this.Radius = Math.Abs(radius);
            // Als Länge wird die Strecke festgelegt, die das äussere Rad zurücklegt!
            // Berechnung: Umfang / 360° * (der gewünschten Winkel in Grad)
            //                     angle             AxleLength          angle
            // length = 2r * PI * ------- = 2 * (r + ----------) * PI * -------
            //                      360°                 2                360°
            this.length = Math.Abs(2.0f * (radius + Constants.AxleLength / 2.0f) 
                * (float)Math.PI * angle / 360.0f);
        }
        #endregion


        #region properties
        /// <summary>
        /// Liefert bzw. setzt den Winkel [°]
        /// </summary>
        public float Angle { get; protected set; }

        /// <summary>
        /// Liefert bzw. setzt den Radius [m]
        /// </summary>
        public float Radius { get; protected set; }
        #endregion

















        #region methods
        /// <summary>
        /// Berechnet die Geschwindigkeit der beiden Räder, damit der 
        /// Kreisbogen richtig gefahren wird. Das äussere Rad legt per Definition
        /// die berechnete Strecke zurück. Somit muss auch das äussere Rad mit der
        /// eingestellten Geschwindigkeit drehen und das innere Rad entsprechend
        /// langsamer, damit die Strecke in der richtigen Zeit abgefahren wird.
        /// 
        ///                                 AxleLength
        ///                            r - ------------
        ///                                     2
        /// Geschw. inneres Rad = v * ------------------
        ///                                 AxleLength
        ///                            r + ------------
        ///                                     2
        /// </summary>
        /// <param name="timeInterval">Zeit seit dem letzten Aufruf der Methode [s]</param>
        /// <param name="newVelocity">die Soll-Geschwindigkeit</param>
        /// <param name="leftSpeed">die neue Geschw. des linken Rades [m/s]</param>
        /// <param name="rightSpeed">die neue Geschw. des rechten Rades [m/s]</param>
        public override void IncrementalStep(float timeInterval, float newVelocity,
            out float leftSpeed, out float rightSpeed)
        {
            currentVelocity = newVelocity;
            if (reverse) newVelocity = -newVelocity;

            leftSpeed = -newVelocity;
            rightSpeed = newVelocity * (Radius - Constants.AxleLength / 2.0f) / 
                (Radius + Constants.AxleLength / 2.0f); ;

            // Berechnungen (Distanz & Zeit) in der Basisklasse nachführen
            DoStep(timeInterval);
        }
        #endregion
    }
}
