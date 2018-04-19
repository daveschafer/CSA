using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace SimpleHttpServer {
    abstract class HttpServer {
        #region Fields

        private int myPort;
        TcpListener myListener;
        bool is_active = true;

        #endregion

        public HttpServer(int port) {
            this.myPort = port;
        }

        public void listen() {
           // IPAddress myIPAddress = Dns.GetHostEntry("localhost").AddressList[1];
         //   myListener = new TcpListener(myIPAddress, myPort);
            myListener = new TcpListener(myPort);
            // myListener = new TcpListener(myPort);
            myListener.Start();
            while (is_active) {
                TcpClient myClient = myListener.AcceptTcpClient();
                HttpProcessor myProcessor = new HttpProcessor(myClient, this);
                Thread myThread = new Thread(new ThreadStart(myProcessor.process));
                myThread.Start();
                Thread.Sleep(1);
            }
        }

        // GET Request handler
        public abstract void handleGETRequest(HttpProcessor p);

        // POST Request handler
        public abstract void handlePOSTRequest(HttpProcessor p, StreamReader inputData);
    }
}
