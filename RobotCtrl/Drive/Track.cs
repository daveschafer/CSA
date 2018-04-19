//------------------------------------------------------------------------------
// C #   I N   A C T I O N   ( C S A )
//------------------------------------------------------------------------------
// Repository:
//    $Id: Track.cs 1039 2016-10-25 11:56:45Z chj-hslu $
//------------------------------------------------------------------------------
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace RobotCtrl
{

    /// <summary>
    /// Basisklasse für Fahrbefehle
    /// </summary>
    public abstract class Track
    {

        #region members
        protected float nominalSpeed;
        protected float acceleration;
        protected float coveredLength;
        protected float elapsedTime;

        protected bool reverse;
        protected float currentVelocity;
        protected float length;
        #endregion


        #region constructor & destructor
        /// <summary>
        /// Initialisiert alle Parameter auf 0!
        /// Folgenden Variablen muss in der abgeleiteten Klasse 
        /// zwingend ein Wert zugewiesen werden!
        /// - length (nur positiver Wert!!!)
        /// - nominalspeed (nur positiver Wert!!!)
        /// - acceleration
        /// - reverse
        /// </summary>
        public Track()
        {
            length = 0;         
            nominalSpeed = 0; 
            acceleration = 0;
            reverse = false;

            coveredLength = 0;
            elapsedTime = 0;
            currentVelocity = 0;
        }
        #endregion


        #region properties
        /// <summary>
        /// Liefert die Restlänge, d.h. die Länge [m] die vom Track 
        /// noch gefahren wird.
        /// </summary>
        public virtual float ResidualLength
        {
            get { return length - this.coveredLength; }
        }

        /// <summary>
        /// Liefert die Länge [m], die der Track bereits gefahren ist.
        /// </summary>
        public float CoveredLength { get { return coveredLength; } }


        /// <summary>
        /// Liefert true, falls der Track fertig abgearbeitet wurde.
        /// </summary>
        public virtual bool Done
        {
            //get { return (elapsedTime > pauseTime) && (coveredLength > length); }
            get { return (coveredLength > length); }
        }


        /// <summary>
        /// Liefert die Zeit [s], die der Track bis zum aktuellen Zeitpunkt
        /// insgesammt aktiv war (=Fahrzeit).
        /// </summary>
        public float ElapsedTime { get { return elapsedTime; } }


        /// <summary>
        /// Liefert die eingestellt Beschleunigung [m/s^2]
        /// </summary>
        public float Acceleration { get { return acceleration; } }


        /// <summary>
        /// Liefert die Geschwindigkeit [m/s], mit der gefahren werden soll.
        /// </summary>
        public float NominalSpeed { get { return nominalSpeed; } }
        #endregion


        #region methods
        /// <summary>
        /// Diese Methode wird regelmässig aufgerufen und muss von jedem Track
        /// implementiert werden.
        /// Innerhalb der Methode müssen die Geschwindigkeiten für die beiden
        /// Räder berechnet und zurückgeliefert werden. Dazu stehen die Zeit seit
        /// dem letzten Aufruf der Methode sowie die erwartete Geschwindigkeit 
        /// des Roboters zur Verfügung.
        /// 
        /// Weiter muss die Variable currentVelocity aktualisiert werden!
        /// 
        /// Anschliessend muss diese Methode noch die Methode <see cref="DoStep"/>
        /// aufrufen, um die aufgelaufenen Zeiten/Längen nachzuführen.
        /// </summary>
        /// 
        /// <param name="timeInterval">Zeit seit dem letzten Aufruf diese Methode [s]</param>
        /// <param name="newVelocity">die gewünschte Geschwindigkeit [m/s]</param>
        /// <param name="leftSpeed">berechneter Wert für Geschw. des linken Rades [m/s]</param>
        /// <param name="rightSpeed">berechneter Wert für Geschw. des rechten Rades [m/s]</param>
        public abstract void IncrementalStep(float timeInterval, float newVelocity, out float leftSpeed, out float rightSpeed);


        /// <summary>
        /// Diese Methode führt die aufgelaufene Zeit sowie Distanz nach und muss
        /// zwingend von der Methode <see cref="IncrementalStep"/> aufgerufen
        /// werden!
        /// </summary>
        /// <param name="timeInterval">Zeit seit dem letzten Aufruf der Methode</param>
        protected void DoStep(float timeInterval)
        {
            elapsedTime += timeInterval;
            coveredLength += timeInterval * currentVelocity;
        }
        #endregion
    }
}
