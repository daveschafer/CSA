using RobotCtrl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleHttpServer.Action
{
    public class TrackLine : IActions
    {
        // Robot Objekte
        private Robot robot;

        // 
        public float ValueL { get; private set; }

        // Konstruktor 
        public TrackLine(float paramValueL) {
            this.ValueL = paramValueL;
        }

        public void Execute(Robot ReferenceRobot)
        {
            Console.WriteLine("Call Drive Class...");
            //Call Drive klass
            //Tipp:
            robot = ReferenceRobot;      // neuen Roboter erstellen
            robot.Drive.Power = true;   // Stromversorgung der Motoren (im DriveCtrl) einschalten

            //views mappen
            float lenght = ValueL;
            float speed = 0.5f;
            float acceleration = 0.3f;
            robot.Drive.RunLine(lenght, speed, acceleration);
        }

        public override string ToString()
        {
            return "TrackLine;ValueL=" + this.ValueL.ToString();
        }
    }
}
