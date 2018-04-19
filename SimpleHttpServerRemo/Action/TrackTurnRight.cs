using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RobotCtrl;

namespace SimpleHttpServer.Action {
    public class TrackTurnRight : IActions {
        public float ValueA { get; private set; }

        public TrackTurnRight(float paramValueA) {
            this.ValueA = paramValueA;
        }

        public void Execute(Robot ReferenceRobot) {
            Console.WriteLine("Call Drive Class...");
        }

        public override string ToString() {
            return "TrackTurnRight;ValueA=" + this.ValueA.ToString();
        }
    }
}
