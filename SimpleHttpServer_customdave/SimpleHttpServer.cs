using System;
using System.Collections;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading;


namespace ch.hslu.httpserver
{

    public class SimpleHTTPServer
    {
        TcpListener listener;
        bool is_active = true;
        protected int port;

        public SimpleHTTPServer(int port)
        {
            this.port = port;
        }

        public void returnPNG(String sourcePNG, TcpClient tcpclient)
        {
            /*HTML Response format:
            HTTP/1.1 200 OK
            Server: ExperimentalWebServer 1.0
            Content-type: image/png
            Content-length: 153
            Leere Zeile
            binäre Daten
            */
            StreamWriter outputStream = new StreamWriter(new BufferedStream(tcpclient.GetStream()));
            //StreamReader sr_PNG = new StreamReader(new FileStream(sourcePNG, FileMode.Open,FileAccess.Read));

            byte[] imageBytes = GetFileByteArray(sourcePNG);
            //Zuerst Default HTTP 200 Response:
            {
                outputStream.WriteLine("HTTP/1.1 200 OK");
                outputStream.WriteLine("Server: Daves Webserver");
                outputStream.WriteLine("Content-type: image/png");
                outputStream.WriteLine("content-length: " + imageBytes.Length);
                outputStream.WriteLine("");
            }

            //SEND PNG as BaseStream
            outputStream.BaseStream.Write(GetFileByteArray(sourcePNG), 0, imageBytes.Length);
            outputStream.Flush();

            // sr_PNG.Close();
            outputStream.Close();
        }

        /// <summary>
        /// 
        /// Hilfsmethode um ein Bild in ein Byte Array zu konvertieren.
        /// </summary>
        /// /// <param name="filename">Der Speicherort der Bilddatei (z.B. C:\Temp\bild.png).</param>
        /// <returns>Gibt ein Array zurück vom Typ: byte[].</returns>
        private byte[] GetFileByteArray(string filename)
        {
            FileStream oFileStream = new FileStream(filename, FileMode.Open, FileAccess.Read);
            // Create a byte array of file size.
            byte[] FileByteArrayData = new byte[oFileStream.Length];
            //Read file in bytes from stream into the byte array
            oFileStream.Read(FileByteArrayData, 0, System.Convert.ToInt32(oFileStream.Length));
            //Close the File Stream
            oFileStream.Close();
            //return Array 
            return FileByteArrayData; //return the byte data
        }

        public void returnHTML(String sourceHTML, TcpClient tcpclient)
        {
            /*HTML Response format:
            HTTP/1.1 200 OK
            Server: ExperimentalWebServer 1.0
            Content-type: text/html
            Content-length: 143
            Leere Zeile
            HTML Stuff
            */
            StreamWriter outputStream = new StreamWriter(new BufferedStream(tcpclient.GetStream()));
            StreamReader sr_html = new StreamReader(new FileStream(sourceHTML, FileMode.Open));
            //Zuerst Default HTTP 200 Response:
            {
                outputStream.WriteLine("HTTP/1.1 200 OK");
                outputStream.WriteLine("Server: Daves Webserver");
                outputStream.WriteLine("Content-type: text/html");
                outputStream.WriteLine("content-length: 999");
                outputStream.WriteLine("");
            }
            while (sr_html.EndOfStream == false)
            {
                //Console.WriteLine(sr_html.ReadLine());
                outputStream.WriteLine(sr_html.ReadLine());
            }
            outputStream.Flush();
            outputStream.Close();
            sr_html.Close();
        }
        public void handleGETRequest(String request, TcpClient tcpclient)
        {
            Console.WriteLine("GET Request Handler entered.");

            //splittetstring erstellen
            String[] splittedRequest = request.Split(' ');
            //Split 0 = was (get/post) | split 1 = was (html,png...) | Split 2 = Version (http1.1.)
            Console.WriteLine("Get Anfrage nach: {0}", splittedRequest[1]);
            //Ausgabe String Array (Debug Zweck)
            for (int i = 0; i < splittedRequest.Length; i++)
            {
                Console.WriteLine("Splitt[{0}] : " + splittedRequest[i], i);
                // Console.WriteLine("Split: " + splittedRequest[i]);
            }

            //prüfe ob angefordertes element vorhanden, bez. ob / (/ = default, also wird nur der index.html zurückgegeben)

            if (splittedRequest[1].Equals("/"))
            {
                //Return Default
                Console.WriteLine("GET: Default angefordert (index).");
                //html files parsen zeile für zeile:
                returnHTML("index.html", tcpclient);

            }
            else if (splittedRequest[1].Equals("/test.html"))
            {
                Console.WriteLine("Get: test.html angefordert");
                returnHTML("test.html", tcpclient);


            }
            else if (splittedRequest[1].Equals("/test.png"))
            {
                Console.WriteLine("Get: Test.png angefordert");
                returnPNG("test.png", tcpclient);
            }
            else
            {
                Console.WriteLine("Get: Unbekannte Anforderung...");
                //Return notfound.html
                returnHTML("notfound.html", tcpclient);
            }
        }

        public void handlePOSTRequest(Stream inputStream, TcpClient tcpclient)
        {
            //Variablen für das Auslesen der Post Message
            int content_len = 0;
            int BUF_SIZE = 4096;

            Console.WriteLine("POST Request Handler entered.");


            #region find Content Length Region
            //splittetstring erstellen
            String[] splittedRequest;
            int linecounter = 0;


            //Kurz, jede Zeile lesen und dann nach leerzeichen splitten und wiedergeben bis content-length gefunden, danach weiter bis leerzeile gefunden, ab da übernimmt der MemoryStream
            while (streamReadLine(inputStream) != "")
            {
                Console.WriteLine("Line: {0}", linecounter);

                splittedRequest = streamReadLine(inputStream).Split(' ');
                for (int i = 0; i < splittedRequest.Length; i++)
                {
                    if (splittedRequest[i] == "Content-Length:")
                    {
                        content_len = Int32.Parse(splittedRequest[i + 1]);
                        Console.WriteLine("Content Lenght: {0}", content_len);
                        break;
                    }
                    Console.WriteLine("Line [{0}], Splitt[{1}] : " + splittedRequest[i], linecounter, i);
                }
                linecounter++;
            }
            #endregion

            #region Verarbeite Post Request
            {
                MemoryStream ms = new MemoryStream();
                byte[] buf = new byte[BUF_SIZE];
                int to_read = content_len;
                while (to_read > 0)
                {
                    Console.WriteLine("starting Read, to_read={0}", to_read);
                    int numread = inputStream.Read(buf, 0, Math.Min(BUF_SIZE, to_read));
                    Console.WriteLine("read finished, numread={0}", numread);
                    if (numread == 0)
                    {
                        if (to_read == 0)
                        {
                            break;
                        }
                        else
                        {
                            throw new Exception("client disconnected during post");
                        }
                    }
                    to_read -= numread;
                    ms.Write(buf, 0, numread);
                }
                ms.Seek(0, SeekOrigin.Begin);
                StreamReader inputData = new StreamReader(ms);
                string data = inputData.ReadToEnd();
                //Hier müssen noch Aktionen eingebaut werden (if data == x dann y)
                Console.WriteLine("Post Body: {0}", data);
                //ToDo
            }
            #endregion

            #region sende succes Meldung auf POST Request
            StreamWriter outputStream = new StreamWriter(new BufferedStream(tcpclient.GetStream()));
            //Zuerst Default HTTP 200 Response:
            {
                outputStream.WriteLine("HTTP/1.1 200 OK");
                outputStream.WriteLine("Server: Daves Webserver");
                outputStream.WriteLine("Content-type: text/html");
                outputStream.WriteLine("content-length: 999");
                outputStream.WriteLine("");
                outputStream.Flush();
                outputStream.Close();
                Console.WriteLine("POST success gesendet");
            }
            #endregion

            Console.WriteLine("POST Request finished");
        }

        public void parseRequest(TcpClient tcpclient)
        {
            Stream inputStream = new BufferedStream(tcpclient.GetStream());
            String request = streamReadLine(inputStream);

            Console.WriteLine("Request erhalten: +" + request);
            //HTTP Request kommen im Format "Methode Wohin Version" wobei Methode z.B. Get oder Post ist (in diesem Beispeil, es gibt noch 6 andere...)
            //Splittet den Request durch Leerzeichen
            String[] splittedRequest = request.Split(' ');
            Console.WriteLine("Splitsize: " + splittedRequest.Length);

            #region GET oder POST oder Illegal
            for (int i = 0; i < splittedRequest.Length; i++)
            {
                Console.WriteLine("Splitt[{0}] : " + splittedRequest[i], i);
                // Console.WriteLine("Split: " + splittedRequest[i]);
            }
            //Unterscheidung nach GET, POST oder Illegal
            if (splittedRequest[0].Equals("GET") || splittedRequest[0].Equals("get") || splittedRequest[0].Equals("Get"))
            {
                Console.WriteLine("GET Request erhalten");
                handleGETRequest(request, tcpclient);
            }
            else if (splittedRequest[0].Equals("POST") || splittedRequest[0].Equals("post") || splittedRequest[0].Equals("Post"))
            {
                Console.WriteLine("POST Request erhalten");
                handlePOSTRequest(inputStream, tcpclient);
            }
            else
            {
                Console.WriteLine("Illegal HTTP-Request: {0}", splittedRequest[0]);
                Console.WriteLine("Session wird beendet...");
                tcpclient.Close();
            }
            #endregion
            Console.WriteLine("Streams werden geschlossen...");
           // Stream abschliessen
            inputStream.Close();
        }

        /**
         * Hilfsmethode welche einen Stream mit mehreren Zeilen (Lines) in einen einfachen Stream konvertiert
         * **/
        private string streamReadLine(Stream inputStream)
        {
            int next_char;
            string data = "";
            while (true)
            {
                next_char = inputStream.ReadByte();
                if (next_char == '\n') { break; }
                if (next_char == '\r') { continue; }
                if (next_char == -1) { Thread.Sleep(1); continue; };
                data += Convert.ToChar(next_char);
            }
            return data;
        }

        /**
         * Startet einen Listener
        **/
        public void listen()
        {
            listener = new TcpListener(port);
            listener.Start();
            while (is_active)
            {
                TcpClient s = listener.AcceptTcpClient();
                //Sobald eine Antwort eine Verbindung aktiviert wurde -> Delegieren an eine parse Methode welche schaut ob es get oder post ist
                parseRequest(s);
            }
        }

    }

}



