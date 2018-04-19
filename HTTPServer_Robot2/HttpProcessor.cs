using System;
using System.Collections;
using System.IO;
using System.Net.Sockets;
using System.Threading;

namespace SimpleHttpServer {
    class HttpProcessor {
        #region Attribute
        public TcpClient mySocket;
        public HttpServer myServer;

        private Stream myInputSteam;
        public StreamWriter myOutputStream;

        public String http_method;
        public String http_url;
        public String http_protocol_versionstring;
        public String[] http_url_split;

        public Hashtable httpHeaders = new Hashtable();

        // Max Size POST 10 MB
        private static int MAX_POST_SIZE = 10 * 1024 * 1024;
        #endregion

        // Konstruktor
        public HttpProcessor(TcpClient s, HttpServer srv) {
            this.mySocket = s;
            this.myServer = srv;
        }

        // Liest den InputStream komplett durch
        private string streamReadLine(Stream inputStream) {
            int next_char;
            string data = "";
            while (true) {
                next_char = inputStream.ReadByte();
                if (next_char == '\n') { break; }
                if (next_char == '\r') { continue; }
                if (next_char == -1) { Thread.Sleep(1); continue; };
                data += Convert.ToChar(next_char);
            }
            return data;
        }

        //
        public void process() {
            //myInputSteam = new BufferedStream(mySocket.GetStream());

            myInputSteam = mySocket.GetStream();

            myOutputStream = new StreamWriter(mySocket.GetStream());

            try {
                parseRequest();
                readHeaders();
                if (http_method.Equals("GET")) {
                    handleGETRequest();
                }
                else if (http_method.Equals("POST")) {
                    handlePOSTRequest();
                }
            }
            catch (Exception e) {
                Console.WriteLine("ERROR: Exception: " + e.ToString());
                writeFailure();
            }

            myOutputStream.Flush();
            myInputSteam = null;
            myOutputStream = null;
            mySocket.Close();
        }

        // Request parsen
        public void parseRequest() {
            //hier passiert ein fehler...
            Console.WriteLine("ParseReqeust gestartet...");
            String request = streamReadLine(myInputSteam);
            string[] tokens = request.Split(' ');

            Console.WriteLine("INFO: Start reading request: " + request);

            // Request darf nur aus drei Teilen bestehen
            if (tokens.Length != 3) {
                throw new Exception("ERROR: Invalid http request = only 3 tokens are allowd!");
            }

            // Request in die Attributte befüllen
            http_method = tokens[0].ToUpper();
            http_url = tokens[1];
            http_protocol_versionstring = tokens[2];

            // http_url_split in das uri befüllen
            Char delimiter = '/';
            http_url_split = http_url.Split(delimiter);
            
            Console.WriteLine("DEBUG: http_method = " + this.http_method);
            Console.WriteLine("DEBUG: http_url = " + this.http_url);
            Console.WriteLine("DEBUG: http_protocol = " + this.http_protocol_versionstring);
        }

        public void readHeaders() {
            Console.WriteLine("INFO: Start reading header...");
            String myLine;

            while ((myLine = streamReadLine(myInputSteam)) != null) {
                if (myLine.Equals("")) {
                    Console.WriteLine("INFO: got headers!");
                    return;
                }

                int seperator = myLine.IndexOf(":");
                if (seperator == -1) {
                    throw new Exception("invalid http header line: " + myLine);
                }
                String name = myLine.Substring(0, seperator);
                int pos = seperator + 1;
                while ((pos < myLine.Length) && (myLine[pos] == ' ')) {
                    pos++; // strip any spaces
                }

                string value = myLine.Substring(pos, myLine.Length - pos);
                Console.WriteLine("DEBUG: Header accept: {0}:{1}", name, value);
                httpHeaders[name] = value;
            }
        }

        public void handleGETRequest() {
            myServer.handleGETRequest(this);
        }

        private const int BUF_SIZE = 4096;
        public void handlePOSTRequest() {
            Console.WriteLine("DEBUG: get post data start...");
            int content_lenght = 0;
            MemoryStream ms = new MemoryStream();
            if (this.httpHeaders.ContainsKey("content-length")) {
                content_lenght = Convert.ToInt32(this.httpHeaders["content-length"]);

                // Check content lenght
                if (content_lenght > MAX_POST_SIZE) {
                    throw new Exception(
                         String.Format("POST Content-Length({0}) too big for this simple server",
                           content_lenght));
                }

                byte[] buffer = new byte[BUF_SIZE];
                int to_read = content_lenght;
                while (to_read > 0) {
                    Console.WriteLine("DEBUG: starting Read, to_read={0}", to_read);
                    int numread = this.myInputSteam.Read(buffer, 0, Math.Min(BUF_SIZE, to_read));
                    Console.WriteLine("DEBUG: read finished, numread={0}", numread);

                    if(numread == 0) {
                        if(to_read == 0) {
                            break;
                        } else {
                            throw new Exception("ERROR: Exception - client disconnected during post");
                        }
                    }
                    to_read -= numread;
                    ms.Write(buffer, 0, numread);

                }
                ms.Seek(0, SeekOrigin.Begin);




                // Content-Type = application/json
                if (this.httpHeaders.ContainsKey("Content-Type")) {
                    if (this.httpHeaders["Content-Type"].Equals("application/json")) {
                        
                    }
                    

                }

            }

            Console.WriteLine("INFO: get post data end");
            myServer.handlePOSTRequest(this, new StreamReader (ms));
        }

        public void writeSuccess(string content_type = "text/html") {
            // this is the successful HTTP response line
            myOutputStream.WriteLine("HTTP/1.0 200 OK");
            // these are the HTTP headers...          
            myOutputStream.WriteLine("Content-Type: " + content_type);
            myOutputStream.WriteLine("Connection: close");
            // ..add your own headers here if you like

            myOutputStream.WriteLine(""); // this terminates the HTTP headers.. everything after this is HTTP body..
        }

        public void writeFailure() {
            // this is an http 404 failure response
            myOutputStream.WriteLine("HTTP/1.0 404 Error");
            // these are the HTTP headers
            myOutputStream.WriteLine("Connection: close");
            // ..add your own headers here

            myOutputStream.WriteLine(""); // this terminates the HTTP headers.
        }

    }
}
