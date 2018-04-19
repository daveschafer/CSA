using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RobotCtrl;

namespace SimpleHttpServer.Action {
    public class TrackTurnLeft : IActions {
        public float ValueA { get; set; }

        public TrackTurnLeft(float paramValueA) {
            this.ValueA = paramValueA;
        }

        public void Execute(Robot ReferenceRobot) {
            Console.WriteLine("Call Drive Class...");
        }

        public override string ToString() {
            return "TrackTurnLeft;ValueA=" + this.ValueA.ToString();
        }
    }
}
