using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using RobotCtrl;

namespace SimpleHttpServer.Action {
    public class TrackTurnLeft : IActions {
        // Robot Objekt
        private Robot robot;

        // Add value
        public float ValueA { get; private set; }

        public TrackTurnLeft(float paramValueA) {
            this.ValueA = paramValueA;
        }

        public void Execute(Robot ReferenceRobot) {
            Console.WriteLine("Call Drive Class TrackTurnLeft...");
            robot = ReferenceRobot;
            robot.Drive.Power = true;


            float angle = ValueA;
            float speed = 0.5f;
            float acceleration = 0.3f;

            // Parameter für die Drive Klasse
            robot.Drive.RunTurn(angle, speed, acceleration);
        }

        public override string ToString() {
            return "TrackTurnLeft;ValueA=" + this.ValueA.ToString();
        }
    }
}
