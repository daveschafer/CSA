using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using RobotCtrl;
using System.IO;

namespace RobotCtrl
{


    public class TrackLogger
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
            WriteHeader();
        }

        private void WriteHeader()
        {
            //ToDo; header setzen "Team 16" + file jedesmal löschen bei jedem start
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
                writer.WriteLine("Team 16");
                writer.Flush();
            }
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
                //String xPos = ReferenceDrive.DriveInfo.Position.X.ToString("F3");
                //String yPos = ReferenceDrive.DriveInfo.Position.Y.ToString("F3");


              //  Console.WriteLine("Aufruf Nr: {0}", Entrycounter);
                //String Logentry = (localDate.ToString("dd/MM/yyy-hh:mm:ss:fff") + ";" + xPos + ";" + yPos);
                String Logentry = (localDate.ToString("dd/MM/yyy-hh:mm:ss:fff") + ";" + ReferenceDrive.DriveInfo.Position.X.ToString("F3") + ";" + ReferenceDrive.DriveInfo.Position.Y.ToString("F3"));
                //  Console.WriteLine("Zeitstempel,x,y,: " + Logentry);

                //Daten in CSV/TXT schreiben:
                using (StreamWriter writer = new StreamWriter(new FileStream(CSVPath, FileMode.Append, FileAccess.Write)))
                {
                    writer.WriteLine(Logentry);
                    writer.Flush();
                }
            }
            else
            {
                //Timer Thread beenden... falls nach 200 millisekunden der drive nicht wieder läuft
                Thread.Sleep(200);
                if (ReferenceDrive.Done)
                {
                    Thread.CurrentThread.Abort();
                }

            }
        }

        public static bool LogYes = true;
        public void runLogger()
        {
            //Hier quasi in einem endlos Loop den Logger laufen lassen biss ein bool gesetzt wird der das ganze stopt
            while (LogYes)
            {
                writeEntry(null);
                Thread.Sleep(150);
            }
            if (!LogYes)
            {
                Console.WriteLine("Logger wird demnaechst beendet...");
                while(!ReferenceDrive.Done) {
                    //Falls der letzte Track noch läuft warten bis dieser beendet wird.
                    writeEntry(null);
                    Thread.Sleep(150);
                }
                Console.WriteLine("Logger wurde deaktiviert...");
            }
        }

        //fakultativ,
        public bool readEntries()
        {
            return false;

        }
    }
}