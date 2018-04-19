using SimpleHttpServer.Action;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using RobotCtrl;

namespace SimpleHttpServer
{
    class Actions
    {

        // Queue
        private Queue<IActions> actions = new Queue<IActions>();
        private Robot robot;
        private static bool singleton = false;

        public void Action()
        {

        }

        public void addAction(Object obj)
        {
            actions.Enqueue((IActions)obj);
        }

        public bool executeActions()
        {
            //http Post start -> eceXutActions
            if (!singleton)
            {
                this.robot = new Robot();
                singleton = true;
            }

            try
            {
                while (actions.Count > 0)
                {
                    while (robot.Drive.Done)
                    {
                        Console.WriteLine("Befehl Nr: " + actions.Count);
                        actions.Dequeue().Execute(robot);
                    }
                }
                Thread.Sleep(100);
                //Logger stoppen
                Console.WriteLine("***Fahrbefehle abgearbeitet***");
                TrackLogger.LogYes = false;
                //robot.AbortLogger();

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Fehler bei der Abarbeitung des Befehls!");
                return false;
            }
        }


        public void listActions()
        {
            while (actions.Count > 0)
            {
                Console.WriteLine(actions.Dequeue().ToString());
            }
        }
    }
}
