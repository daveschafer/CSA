using System;
using System.Threading;

namespace SimpleHttpServer {
    class TestMain {
        // Default Port
        private static int DEFAULT_PORT = 1337;

        public static int Main(String[] args) {
            //Action Log löschen
            ActionLogger.cleanActionLog();

            // Server definieren
            HttpServer httpServer;

            //in den Args kann der Port fürs listening mitgegeben werden
            if (args.GetLength(0) > 0) {
                httpServer = new MyHttpServer(Convert.ToInt16(args[0]));
            }
            //Standard Port: gemäss DEFAULT_PORT
            else {
                httpServer = new MyHttpServer(DEFAULT_PORT);
            }

            // Thread starten und listen!
            Thread thread = new Thread(new ThreadStart(httpServer.listen));
            thread.Start();
            return 0;
        }
    }
}
