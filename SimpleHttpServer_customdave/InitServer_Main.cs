using ch.hslu.httpserver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ch.hslu.httpserver
{
    class InitServer_Main
    {
        public static int Main(String[] args)
        {
            Console.WriteLine("HTTP Server startet");
            SimpleHTTPServer httpServer;
            //in den Args kann der Port fürs listening mitgegeben werden
            if (args.GetLength(0) > 0)
            {
                httpServer = new SimpleHTTPServer(Convert.ToInt16(args[0]));
            }
            //Standard Port: 8080
            else
            {
                httpServer = new SimpleHTTPServer(8080);
            }
            Thread thread = new Thread(new ThreadStart(httpServer.listen));
            thread.Start();
            return 0;
        }
    }
}
