using SimpleHttpServer.Action;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RobotCtrl;

namespace SimpleHttpServer {
    class Actions  {

        // Queue
        private Queue<IActions> actions = new Queue<IActions>();
        private Robot robot;
        private static bool singleton = false;

        public void Action() {
            
        }

        public void addAction(Object obj) {
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
                    actions.Dequeue().Execute(robot);
                }
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }

        public void listActions() {
            while(actions.Count > 0) {
                Console.WriteLine(actions.Dequeue().ToString());
            }
        }
    }
}
