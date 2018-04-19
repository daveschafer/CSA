using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using RobotCtrl;
using System.IO;

namespace RobotCtrl
{
    /// <summary>
    /// Diese Klasse loggt den Standort des Roboters alls 200ms in einem separatem Timer Thread und schreibt die Ergebnisse in ein CSV
    /// </summary>
    /// http://www.c-sharpcorner.com/UploadFile/1d42da/timer-class-in-threading-C-Sharp/
    class InitTrackLogger
    {
        //Das hier ist nur ein Beispiel wie ein Logger initialisier wird (aber ein gutes ;)
        private System.Threading.Timer timer;
        public static int Main(String[] args)
        {
            Console.WriteLine("Starte TimerInit");
            InitTrackLogger example = new InitTrackLogger();
            //TrackLogger TrackLog1 = new TrackLogger(this);
            // example.StartTimer(TrackLog1);
            return 0;
        }

        public void StartTimer(TrackLogger TrackReference)
        {
            Console.WriteLine("Timer wird erstellt");

            timer = new System.Threading.Timer(TrackReference.writeEntry, null, 100, 250);
            Thread.Sleep(8000);
        }

    }

}



class TrackLogger
{
    String CSVPath;
    int Entrycounter;
    //singleton, if timer already running return false
    bool singleton = false;
    //Ansatz, das Drive Objekt muss als Referenz dem Logger übergeben werden
    private Drive ReferenceDrive;
    public TrackLogger(Drive ReferenceDrive)
    {
        this.ReferenceDrive = ReferenceDrive;
        Entrycounter = 0;
        CSVPath = @"Temp\log.txt";
        singleton = true;
    }

    //Format des Eintrages:
    //Aufbau einer Positionszeile: Zeitstempel mit dem Format "dd/MM/yyyy-hh:mm:ss.fff" Semikolon(;) x-Position
    //Semikolon(;) y-Position
    //Beispiel:
    //06.12.2017-08:55:09.334;2.999658;0.01311078

    public void writeEntry(object state)
    {
        if (!ReferenceDrive.Done)
        {
            Entrycounter++;
            DateTime localDate = DateTime.Now;
            //  RobotCtrl.Drive.DriveInfo.get(Position)
            //Ansatz, das Drive Objekt muss als Referenz dem Logger übergeben werden
            String xPos = ReferenceDrive.DriveInfo.Position.X.ToString();
            String yPos = ReferenceDrive.DriveInfo.Position.Y.ToString();
            //String xPos = "1.337";
            //String yPos = "0.69";

            Console.WriteLine("Aufruf Nr: {0}", Entrycounter);
            String Logentry = (localDate.ToString("dd/MM/yyy-hh:mm:ss:fff") + ";" + xPos + ";" + yPos);
            Console.WriteLine("Zeitstempel,x,y,: " + Logentry);

            //ToDo; header setzen "Team 10" + file jedesmal löschen bei jedem start
            if (File.Exists(CSVPath))
            {
                try
                {
                    File.Delete(CSVPath);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Löschen fehlgeschlagen... " + e.ToString());
                }
            }
            //Schreibt header der Log Datei
            using (StreamWriter writer = new StreamWriter(new FileStream(CSVPath, FileMode.Append, FileAccess.Write)))
            {
                writer.WriteLine("Team 10");
            }
            //Daten in CSV schreiben:


            using (StreamWriter writer = new StreamWriter(new FileStream(CSVPath, FileMode.Append, FileAccess.Write)))
            {
                writer.WriteLine(Logentry);
            }
        }
        else
        {
            //Timer Thread beenden...
            Thread.CurrentThread.Abort();

        }
    }

    //fakultativ,
    public bool readEntries()
    {
        return false;

    }
}
