

using System.IO;


namespace SimpleHttpServer
{
    class ActionLogger
    {
        public static void cleanActionLog()
        {
            string logFile = "../../report/actionList.csv";
            //File.WriteAllText(logFile, string.Empty);
            File.Delete(logFile);
        }

        public static void writeActionLog(string actionLogText)
        {
            string logFile = "../../report/actionList.csv";
            using (StreamWriter writer = new StreamWriter(new FileStream(logFile, FileMode.Append, FileAccess.Write)))
            {
                writer.WriteLine(actionLogText);
            }
        }
    }
}
