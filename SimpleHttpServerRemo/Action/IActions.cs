using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RobotCtrl;

namespace SimpleHttpServer.Action {
    interface IActions {
        void Execute(Robot ReferenceRobot);
    }
}
