﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using RobotCtrl;

namespace SimpleHttpServer.Action {
    public class TrackArcLeft :IActions {
        public float ValueA { get; private set; }
        public float ValueL { get; private set; }

        public TrackArcLeft(float paramValueA, float paramValueL) {
            this.ValueA = paramValueA;
            this.ValueL = paramValueL;
        }

        public void Execute(Robot ReferenceRobot) {
            Console.WriteLine("Call Drive Class...");
        }

        public override string ToString() {
            return "TrackArcLeft;ValueA=" + this.ValueA.ToString() + ";ValueL=" + this.ValueL.ToString();
        }
    }
}
