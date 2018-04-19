//------------------------------------------------------------------------------
// C #   I N   A C T I O N   ( C S A )
//------------------------------------------------------------------------------
// Repository:
//    $Id: Drive.cs 1039 2016-10-25 11:56:45Z chj-hslu $
//------------------------------------------------------------------------------
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace RobotCtrl
{
    /// <summary>
    /// Mit Hilfe dieser Klasse können Fahrbefehle (z.B. linkskurve, gerade aus fahren etc.) ausgeführt 
    /// werden. Dazu verwendet sie intern die DriveCtrl sowie MotorCtrl Klassen um die einzelnen Motoren 
    /// anzusteuern.
    /// </summary>
    public class Drive : IDisposable
    {

        #region members
        private DriveCtrl driveCtrl;
        private MotorCtrl motorCtrlLeft;
        private MotorCtrl motorCtrlRight;
        private Thread thread;

        private Track track;
        
        private Object infoLock = new object();
        private Object drivesLock = new object();

        private DriveInfo oldInfo;
        private DriveInfo info;

        private bool stop;
        private bool halt;

        private bool disposed;
        private bool run;
        #endregion


        #region constructor & destructor
        /// <summary>
        /// Initialisiert den Antrieb des Roboters
        /// </summary>
        /// 
        /// <param name="runMode">der gewünschte Run-Mode (Real/Virtual)</param>
        public Drive()
        {
            this.disposed = false;

            // Antrieb initialisieren
            this.driveCtrl = new DriveCtrl(Constants.IODriveCtrl);
            this.motorCtrlLeft = new MotorCtrl(Constants.IOMotorCtrlLeft);
            this.motorCtrlRight = new MotorCtrl(Constants.IOMotorCtrlRight);

            // Beschleunigung festlegen
            this.motorCtrlLeft.Acceleration = 10f;
            this.motorCtrlRight.Acceleration = 10f;

            // Prozess-Thread erzeugen und starten
            this.thread = new Thread(RunTracks);
            this.thread.IsBackground = true;
            this.thread.Priority = ThreadPriority.Highest;
            this.thread.Start();
        }

        /// <summary>
        /// Process-Loop beenden und die Motorencontroller zurücksetzen => Motoren halten an
        /// </summary>
        public void Dispose()
        {
            if (!disposed)
            {
                run = false;                // Drive-Thread beenden
                thread.Join();

                motorCtrlLeft.Dispose();    // linkes Motorenobjekt disposen
                motorCtrlRight.Dispose();   // rechtes Motorenobjekt disposen

                driveCtrl.Dispose();        // DriveCtrl disposen => HW-Motorencontroller werden zurückgesetzt und Motoren laufen aus
                disposed = true;
            }
        }
        #endregion


        #region properties
        /// <summary>
        /// Bietet Zugriff auf das DriveCtrl-Objekt um beispielsweise die Motoren ein-/auszuschalten
        /// </summary>
        public DriveCtrl DriveCtrl { get { return driveCtrl; } }


        /// <summary>
        /// Bietet Zugriff auf den linken Motor
        /// </summary>
        public MotorCtrl MotorCtrlLeft { get { return motorCtrlLeft; } }


        /// <summary>
        /// Bietet Zugriff auf den rechten Motor
        /// </summary>
        public MotorCtrl MotorCtrlRight { get { return motorCtrlRight; } }


        /// <summary>
        /// Schaltet die Stromversorgung der Motoren ein-/aus
        /// </summary>
        public bool Power { set { driveCtrl.Power = value; } }


        /// <summary>
        /// Liefert Informationen zum Drive (Position, Geschwindigkeit etc.)
        /// </summary>
        public DriveInfo DriveInfo { get { lock (this.infoLock) { return this.info; } } }



        /// <summary>
        /// Liefert bzw. setzt die aktuelle Position des Roboters
        /// </summary>
        public PositionInfo Position
        {
            get { lock (this.infoLock) { return this.info.Position; } }
            set { lock (this.infoLock) { this.info.Position = value; } }
        }


        public bool Done { get { return track == null; } }
        #endregion


        #region run-methods
        /// <summary>
        /// Fährt eine Strecke gerade aus.
        /// </summary>
        /// 
        /// <remarks> 
        /// Der Fahrbefehl wird nur ausgeführt, falls gerade kein anderer Fahrbefehl abgearbeitet wird!
        /// </remarks>
        /// 
        /// <param name="length">Strecke, die zurückgelegt werden soll [m]</param>
        /// <param name="speed">die gewünschte Geschwindigkeit [m/s]</param>
        /// <param name="acceleration">die gewünschte Beschleunigung [m/s]</param>
        public void RunLine(float length, float speed, float acceleration)
        {
            if (disposed) throw new ObjectDisposedException("Drive");
            if (track == null) track = new TrackLine(length, speed, acceleration);
        }


        /// <summary>
        /// Dreht an Ort und Stelle
        /// </summary>
        /// 
        /// <remarks> 
        /// Der Fahrbefehl wird nur ausgeführt, falls gerade kein anderer Fahrbefehl abgearbeitet wird!
        /// </remarks>
        /// 
        /// <param name="angle">der gewünschte Winkel [°]</param>
        /// <param name="speed">die gewünschte Geschwindigkeit [m/s]</param>
        /// <param name="acceleration">die gewünschte Beschleunigung [m/s]</param>
        public void RunTurn(float angle, float speed, float acceleration)
        {
            Console.WriteLine("TrackTurn wird ausgeführt angle{0} speed{1} accel{2}",angle,speed,acceleration);
            if (disposed) throw new ObjectDisposedException("Drive");
            if (track == null) track = new TrackTurn(angle, speed, acceleration);
        }


        /// <summary>
        /// Fährt eine Linkskurve
        /// </summary>
        /// 
        /// <remarks> 
        /// Der Fahrbefehl wird nur ausgeführt, falls gerade kein anderer Fahrbefehl abgearbeitet wird!
        /// </remarks>
        /// 
        /// <param name="radius">der gewünschte Radius</param>
        /// <param name="angle">der gewünschte Winkel [°]</param>
        /// <param name="speed">die gewünschte Geschwindigkeit [m/s]</param>
        /// <param name="acceleration">die gewünschte Beschleunigung [m/s]</param>
        public void RunArcLeft(float radius, float angle, float speed, float acceleration)
        {
            if (disposed) throw new ObjectDisposedException("Drive");
            if (track == null) track = new TrackArcLeft(radius, angle, speed, acceleration);
        }


        /// <summary>
        /// Fährt eine Rechtskurve
        /// </summary>
        /// 
        /// <remarks> 
        /// Der Fahrbefehl wird nur ausgeführt, falls gerade kein anderer Fahrbefehl abgearbeitet wird!
        /// </remarks>
        /// 
        /// <param name="radius">der gewünschte Radius</param>
        /// <param name="angle">der gewünschte Winkel [°]</param>
        /// <param name="speed">die gewünschte Geschwindigkeit [m/s]</param>
        /// <param name="acceleration">die gewünschte Beschleunigung [m/s]</param>
        public void RunArcRight(float radius, float angle, float speed, float acceleration)
        {
            if (disposed) throw new ObjectDisposedException("Drive");
            if (track == null) track = new TrackArcRight(radius, angle, speed, acceleration);
        }
        #endregion


        #region other methods
        /// <summary>
        /// Hält den Roboter sofort (abrupt) an.
        /// </summary>
        public void Stop()
        {
            stop = true;
        }

        /// <summary>
        /// Bremst den Roboter ab und hält ihn an.
        /// </summary>
        public void Halt()
        {
            halt = true;
        }
        #endregion


        #region process loop
        /// <summary>
        /// Diese Thread-Methode ist dafür zuständig, die Fahrbefehle abzuarbeiten.
        /// Dazu werden folgende Schritte ausgeführt:
        /// - evtl. neuen Track initialisieren
        /// - Aktuelle Prozessdaten (Zeit) erfassen
        /// - Neue Parameter berechnen
        /// - Neue Parameter setzen
        /// - Informationen aktualisieren
        /// </summary>
        private void RunTracks()
        {
            float velocity = 0;
            float deltaTime;

            stop = false;
            halt = false;
            run = true;

            Track oldTrack = null;

            int ticks = Environment.TickCount;

            while (run)
            {
                Thread.Sleep(1);    // Möglichst schneller Process Control Loop

                if (stop)
                {
                    this.track = null;
                    stop = false;
                    velocity = 0; // Joc 10.04.2010
                }

                // Falls ein neuer Track gesetzt wurde, diesen initialisieren und starten 
                if (track != null && track != oldTrack)
                {
                    lock (infoLock)
                    {
                        lock (drivesLock)
                        {
                            // Aktuelle, gefahrene Distanz des linken un rechten Rades speichern
                            oldInfo.DistanceL = -motorCtrlLeft.Distance;
                            oldInfo.DistanceR = motorCtrlRight.Distance;
                        }
                        info.Runtime = 0;
                    }
                    oldTrack = track;
                    halt = false;
                }
                


                // Aktuelle Prozessdaten erfassen
                // ------------------------------
                int deltaTicks = Environment.TickCount - ticks; // Zeit [ms]
                ticks += deltaTicks;
                deltaTime = deltaTicks / 1000.0f; // Zeit [s]

                if (track != null)
                {
                    if ((track.Done) || ((halt && (velocity == 0))))
                    {
                        track = null;
                        halt = false;
                    }
                    else if (track.ResidualLength > 0)
                    {
                        // Neue Prozessparameter berechnen
                        // -------------------------------
                        if (halt)
                        {
                            // Roboter mit der eingestellten Beschleunigung bremsen und anhalten
                            velocity = Math.Max(0, velocity - deltaTime * track.Acceleration);
                        }
                        else
                        {
                            // Beschleunigung (od. Verzögerung bei Reduktion der nominalSpeed(=Sollgeschwindigkeit)) 
                            if (track.NominalSpeed > velocity)
                            {
                                velocity = Math.Min(track.NominalSpeed, velocity + deltaTime * track.Acceleration);
                            }
                            else if (track.NominalSpeed < velocity)
                            {
                                velocity = Math.Max(track.NominalSpeed, velocity - deltaTime * track.Acceleration);
                            }

                            // Verzögerung auf Zielposition
                            // Geschwindigkeit auf max. zulässige Bremsgeschwindigkeit limitieren
                            float ve;
                            float s = track.ResidualLength;
                            if (s >= 0)
                            {
                                ve = (float)Math.Sqrt(2.0 * track.Acceleration * s);
                            }
                            else
                            {
                                ve = 0;
                            }

                            if (float.IsNaN(ve)) ve = 0;
                            velocity = Math.Min(ve, velocity);
                            //System.Console.WriteLine(velocity);
                        }

                        // Neue Prozessparameter aktivieren
                        // --------------------------------
                        float leftSpeed, rightSpeed;
                        track.IncrementalStep(deltaTime, velocity, out leftSpeed, out rightSpeed);
                        motorCtrlLeft.Speed = leftSpeed;
                        motorCtrlRight.Speed = rightSpeed;

                        // Motorenparameter sind gesetzt 
                        // => möglichst gleichzeitig aktivieren (durch .Go())
                        motorCtrlLeft.Go();
                        motorCtrlRight.Go();
                    }
                    else
                    {
                        track = null;
                    }
                }
                else
                {
                    // Idle-Zustand setzen
                    // -------------------
                    lock (drivesLock)
                    {
                        motorCtrlLeft.Speed = 0;
                        motorCtrlRight.Speed = 0;
                        motorCtrlRight.Go();
                        motorCtrlLeft.Go();
                    }
                }
                // Aktuellen Status speichern
                updateInfo(deltaTime);
            }
        }


        /// <summary>
        /// Diese Methode aktualisiert die Positionsinformationen indem die
        /// alten und neuen Daten sowie die gefahrende Distanz (Motorenticks)
        /// seit dem letzten Aufruf der Methode verrechnet werden.
        /// (siehe auch Übung 7)
        /// </summary>
        /// 
        /// <param name="timeInterval">Zeit seit dem letzten Aufruf der Methode</param>
        private void updateInfo(double timeInterval)
		{
			// Motor-Status aktualisieren
            info.DriveStatus = driveCtrl.DriveState;

			lock (infoLock)
			{
				lock (drivesLock)
				{
					info.MotorStatusL = motorCtrlLeft.Status;
					info.MotorStatusR = motorCtrlRight.Status;

					info.SpeedL = -motorCtrlLeft.Speed;
					info.SpeedR = motorCtrlRight.Speed;

					info.DistanceL = -motorCtrlLeft.Distance;
					info.DistanceR = motorCtrlRight.Distance;
				}
				if (track != null) info.Runtime = track.ElapsedTime;
			}


			// Position und Richtung im Weltkoordinatensystem bestimmen 
			// --------------------------------------------------------
            float dL = info.DistanceL - oldInfo.DistanceL;
            float dR = info.DistanceR - oldInfo.DistanceR;

            float d;
            float x1, y1, phi1;
			float x2, y2, phi2;

			d = (dL + dR) / 2.0f;
			x1 = info.Position.X;
			y1 = info.Position.Y;
			phi1 = info.Position.Angle/180.0f * (float)Math.PI;

			if (dL == dR) // Spezialfall geradeaus fahren
			{
				x2 = x1 + d * (float)Math.Cos(phi1);
				y2 = y1 + d * (float)Math.Sin(phi1);
				phi2 = phi1;
			}
			else if (dL == -dR) // Spezialfall an Ort drehen
			{
				x2 = x1;
				y2 = y1;
				phi2 = phi1 + dR / (Constants.AxleLength / 2.0f);
			}
			else // allgemeiner Fall
			{
				float radius = Constants.AxleLength * d / (dR - dL);
                float x0 = x1 + radius * (float)Math.Cos(phi1 + (float)Math.PI / 2.0);
                float y0 = y1 + radius * (float)Math.Sin(phi1 + (float)Math.PI / 2.0);
                float dphi = d / radius;

                x2 = x0 + (x1 - x0) * (float)Math.Cos(dphi) - (y1 - y0) * (float)Math.Sin(dphi);
                y2 = y0 + (x1 - x0) * (float)Math.Sin(dphi) + (y1 - y0) * (float)Math.Cos(dphi);
				phi2 = phi1 + dphi;
			}

			phi2 = phi2 % (2 * (float)Math.PI);

            // Neue Position speichern
			lock (infoLock)
			{
				info.Position.X = x2;
				info.Position.Y = y2;
                info.Position.Angle = phi2 / (float)Math.PI * 180;
				oldInfo = info;
			}
		}
        #endregion
    }
}
