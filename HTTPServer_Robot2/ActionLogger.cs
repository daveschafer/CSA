using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace SimpleHttpServer {
    class ActionLogger {
        public static void cleanActionLog() {
            string logFile = @"Temp\actionList.txt";
            //File.WriteAllText(logFile, string.Empty);
            try
            {
                if (File.Exists(logFile))
                {
                    File.Delete(logFile);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public static void writeActionLog(string actionLogText) {
            string logFile = @"Temp\actionList.txt";
            using (StreamWriter writer = new StreamWriter(new FileStream(logFile, FileMode.Append, FileAccess.Write))) {
                writer.WriteLine(actionLogText);
            }
        }
    }
}
