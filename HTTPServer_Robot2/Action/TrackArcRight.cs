using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using RobotCtrl;

namespace SimpleHttpServer.Action {
    public class TrackArcRight : IActions {


        // Robot Objekt
        private Robot robot;

        // Add value
        public float ValueA { get; private set; }
        public float ValueL { get; private set; }

        // Konstruktor
        public TrackArcRight(float paramValueA, float paramValueL) {
            this.ValueA = paramValueA;
            this.ValueL = paramValueL;
        }

        public void Execute(Robot ReferenceRobot) {
            Console.WriteLine("Call Drive Class...");
            //Robot tuck tuck
            robot = ReferenceRobot;
            robot.Drive.Power = true;

            // Parameter für die Drive Klasse
            float radius = ValueL;
            float angle = ValueA;
            float speed = 0.5f;
            float acceleration = 0.3f;
            robot.Drive.RunArcRight(radius, angle, speed, acceleration);
        }

        public override string ToString() {
            return "TrackArcLeft;ValueA=" + this.ValueA.ToString() + ";ValueL=" + this.ValueL.ToString();
        }
    }
}
