//------------------------------------------------------------------------------
// C #   I N   A C T I O N   ( C S A )
//------------------------------------------------------------------------------
// Repository:
//    $Id: Robot.cs 1039 2016-10-25 11:56:45Z chj-hslu $
//------------------------------------------------------------------------------
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace RobotCtrl
{
    public class Robot: IDisposable
    {

        #region members
        private RobotConsole robotConsole;
        private Radar radar;
        private Drive drive;
        #endregion

        //Vars für den Logger
        private System.Threading.Timer timer;

        public void AbortLogger()
        {
            Console.WriteLine("Logger wird beendet");
            timer.Dispose();
        }

        #region constructor & destructor
        public Robot()
        {
            this.robotConsole = new RobotConsole();
            this.radar = new Radar(Constants.IORadarSensor);
            this.drive = new Drive();
            //ToDo hier den Logger implementieren
            bool Logerinit = InitLogger(this.drive);
            if (!Logerinit)
            {
                Console.WriteLine("Fehler, Logger läuft bereits!");
            }
        }

     
        //singleton, es darf nur ein Logger aufs mal laufen
        private static bool singleton = false;
        public bool InitLogger(Drive ReferenceDrive)
        {
            //Falls schon ein Logger lauft -> false
            if (singleton)
            {
                return false;
            }
            //hier der else Teil
            Console.WriteLine("Starte TimerInit");
            // InitTrackLogger example = new InitTrackLogger();
            TrackLogger TrackLog1 = new TrackLogger(ReferenceDrive);
            //timer = new System.Threading.Timer(TrackLog1.writeEntry, null, 150, 85);


            //***Alternative Logger***
            //Logger akitiveren
            TrackLogger.LogYes = true;
            Thread SimpleTrackLog = new Thread(new ThreadStart(TrackLog1.runLogger));
            SimpleTrackLog.Start();
            //******

            return true;
        }

        /// <summary>
        /// Disposed das Drive-Objekt sowie die robotConsole.
        /// Damit werden die Worker-Threads in diesen Objekten beendet
        /// </summary>
        public void Dispose()
        {
            this.drive.Dispose();
            this.robotConsole.Dispose();
        }
        #endregion


        #region properties
        /// <summary>
        /// Liefert die Konsole des Roboters
        /// </summary>
        public RobotConsole RobotConsole
        {
            get { return this.robotConsole; }
        }


        /// <summary>
        /// Liefert den Radar des Roboters
        /// </summary>
        public Radar Radar
        {
            get { return this.radar; }
        }


        /// <summary>
        /// Liefert den Antrieb des Roboters
        /// </summary>
        public Drive Drive
        {
            get { return this.drive; }
        }


        /// <summary>
        /// Liefert bzw. setzt die aktuelle Postion des Roboters.
        /// </summary>
        public PositionInfo Position { get { return drive.Position; } set { drive.Position = value; } }
        #endregion
    }
}
