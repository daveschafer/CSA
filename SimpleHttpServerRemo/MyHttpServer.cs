using System;
using System.IO;
//Howto Get this library: powershell öffnen --> "Install-Package Newtonsoft.Json" --> clean & build -> freude haben
using SimpleHttpServer.Action;

namespace SimpleHttpServer {
    class MyHttpServer : HttpServer {

        //static list
        private static Actions Fahrbefehle = new Actions();

        public MyHttpServer(int port) : base(port) {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p"></param>
        public override void handleGETRequest(HttpProcessor p) {
            Console.WriteLine("DEBUG: {0} : {1}", p.http_method, p.http_url);

            // a beautiful photo
            if (p.http_url_split[1].Equals("Robot")) {
                Stream fs = File.Open("../../img/robot.png", FileMode.Open);

                p.writeSuccess("image/png");
                p.myOutputStream.Flush();
                fs.CopyTo(p.myOutputStream.BaseStream);
                fs.Close();
            }
            // Report File
            else if (p.http_url_split[1].Equals("Log")) {
                Stream fs = File.Open("../../report/protocol.csv", FileMode.Open);

                p.writeSuccess("text/csv");
                p.myOutputStream.Flush();
                fs.CopyTo(p.myOutputStream.BaseStream);
                fs.Close();
            }
            // Error
            else {
                p.writeFailure();
            }
            #region HTML Site
            //p.myOutputStream.WriteLine("<!DOCTYPE html>");
            //p.myOutputStream.WriteLine("<html lang=\"de\">");
            //p.myOutputStream.WriteLine("   <head>");
            //p.myOutputStream.WriteLine("      <meta charset=\"UTF-8\" />");
            //p.myOutputStream.WriteLine("      <meta name=\"viewport\" content=\"width=device-width, initial-scale=1\">");
            //p.myOutputStream.WriteLine("      <title>CSA - C# in Action HS2017</title>");
            //p.myOutputStream.WriteLine("      <link rel=\"stylesheet\" href=\"https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css\" integrity=\"sha384-BVYiiSIFeK1dGmJRAkycuHAHRg32OmUcww7on3RYdg4Va+PmSTsz/K68vbdEjh4u\" crossorigin=\"anonymous\">");
            //p.myOutputStream.WriteLine("   </head>");
            //p.myOutputStream.WriteLine("   <body>");
            //p.myOutputStream.WriteLine("      <div class=\"container\">");
            //p.myOutputStream.WriteLine("         <div class=\"page-header\">");
            //p.myOutputStream.WriteLine("            <h1>C# in Action HS2017</h1>");
            //p.myOutputStream.WriteLine("         </div>");
            //p.myOutputStream.WriteLine("         <div class=\"panel panel-info\">");
            //p.myOutputStream.WriteLine("            <div class=\"panel-heading\">");
            //p.myOutputStream.WriteLine("               <div class=\"panel-title\">Roboter Image</div>");
            //p.myOutputStream.WriteLine("            </div>");
            //p.myOutputStream.WriteLine("            <div class=\"panel-body\">");
            //p.myOutputStream.WriteLine("               Mit dem nachfolgen Button, kann ");
            //p.myOutputStream.WriteLine("               <strong>ein Foto</strong> vom Roboter angezeigt werden.");
            //p.myOutputStream.WriteLine("               <br/>");
            //p.myOutputStream.WriteLine("               Gruppe 16 Testatübung Teil 2 – Roboterprojekt");
            //p.myOutputStream.WriteLine("               <br/>");
            //p.myOutputStream.WriteLine("               Schafer | Felber | Schwarzentruber");
            //p.myOutputStream.WriteLine("               <br/>");
            //p.myOutputStream.WriteLine("               <br/>");
            //p.myOutputStream.WriteLine("               Aktuelle Zeit: " + DateTime.Now.ToString());
            //p.myOutputStream.WriteLine("               <br/>url : {0}", p.http_url);
            //p.myOutputStream.WriteLine("               <br/>");
            //p.myOutputStream.WriteLine("               <br/>");
            //p.myOutputStream.WriteLine("               <a href=\"/Robot\" class=\"btn btn-info\" role=\"button\">Gib mir ein Foto!</a>");
            //p.myOutputStream.WriteLine("            </div>");
            //p.myOutputStream.WriteLine("         </div>");
            //p.myOutputStream.WriteLine("      </div>");
            //p.myOutputStream.WriteLine("   </body>");
            //p.myOutputStream.WriteLine("</html>");
            #endregion
        }

        public override void handlePOSTRequest(HttpProcessor p, StreamReader inputData) {

            Console.WriteLine("DEBUG: {0} : {1}", p.http_method, p.http_url);
            //string jsonData = inputData.ReadToEnd();
            string data = inputData.ReadToEnd();

            string[] param = data.Split(';');

            // Recording Route
            if (p.http_url_split[1].Equals("Route")) {

                // TrackLine
                if(p.http_url_split[2].Equals("TrackLine")) {
                    TrackLine trackLine = new TrackLine(float.Parse(param[1]));
                    Console.WriteLine("DEBUG: TrackLine: ValueL - " + trackLine.ValueL.ToString());
                    p.writeSuccess();
                    ActionLogger.writeActionLog(trackLine.ToString());
                    
                    MyHttpServer.Fahrbefehle.addAction(trackLine);
                    Console.WriteLine("Fahrbefehl hinzugefügt");
                }

                // TrackTurnLeft
                else if (p.http_url_split[2].Equals("TrackTurnLeft")) {
                    TrackTurnLeft trackTurnLeft = new TrackTurnLeft(float.Parse(param[1]));
                    Console.WriteLine("DEBUG: TrackTurnLeft: ValueA - " + trackTurnLeft.ValueA.ToString());
                    p.writeSuccess();
                    ActionLogger.writeActionLog(trackTurnLeft.ToString());

                }

                // TrackTurnRight
                else if (p.http_url_split[2].Equals("TrackTurnRight")) {
                    TrackTurnRight trackTurnRight = new TrackTurnRight(float.Parse(param[1]));
                    Console.WriteLine("DEBUG: TrackTurnRight: ValueA - " + trackTurnRight.ValueA.ToString());
                    p.writeSuccess();
                    ActionLogger.writeActionLog(trackTurnRight.ToString());
                  
                }

                // TrackArcLeft
                else if (p.http_url_split[2].Equals("TrackArcLeft")) {
                    TrackArcLeft trackArcLeft = new TrackArcLeft(float.Parse(param[1]), float.Parse(param[3]));
                    Console.WriteLine("DEBUG: TrackArcLeft: ValueA - " + trackArcLeft.ValueA.ToString());
                    Console.WriteLine("DEBUG: TrackArcLeft: ValueL - " + trackArcLeft.ValueL.ToString());
                    p.writeSuccess();
                    ActionLogger.writeActionLog(trackArcLeft.ToString());
                }

                // TrackArcRight
                else if (p.http_url_split[2].Equals("TrackArcRight")) {
                    TrackArcRight trackArcRight = new TrackArcRight(float.Parse(param[1]), float.Parse(param[3]));
                    Console.WriteLine("DEBUG: TrackArcRight: ValueA - " + trackArcRight.ValueA.ToString());
                    Console.WriteLine("DEBUG: TrackArcRight: ValueL - " + trackArcRight.ValueL.ToString());
                    p.writeSuccess();
                    ActionLogger.writeActionLog(trackArcRight.ToString());
                }

                // Error
                else {
                    p.writeFailure();
                }


            }
            // Start
            else if (p.http_url_split[1].Equals("Start")) {
                Console.WriteLine("DEBUG: Tuck Tuck");
                p.writeSuccess();

                //Alle Befehle abarbeiten
                bool BefehleErfolgreich = Fahrbefehle.executeActions();
                if (BefehleErfolgreich)
                {
                    Console.WriteLine("Alle Befehle abgearbeitet");
                }
                else
                {
                    Console.WriteLine("Fehler bei der Verarbeitung");
                }
            }
            else {
                p.writeFailure();
            }
        }
    }
}
