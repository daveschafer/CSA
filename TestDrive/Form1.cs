using RobotCtrl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;


namespace TestDrive
{
    public partial class Form1 : Form
    {
        #region members
        private Robot robot;
        #endregion

        #region constructor & destructor
        public Form1()
        {
            InitializeComponent();

            robot = new Robot();        // neuen Roboter erstellen
            robot.Drive.Power = true;   // Stromversorgung der Motoren (im DriveCtrl) einschalten

            //views mappen
            runLine1.Drive = robot.Drive;
            runTurn1.Drive = robot.Drive;
            runArc1.Drive = robot.Drive;

            // DriveView benötigt Drive-Objekt zur Visualisierung
            driveView1.Drive = robot.Drive;
            //Standardwerte initialisieren
            Init();
            //Radarview initialisieren
            radarView1.Radar = robot.Radar;
            //Radar Event TooClose abonnieren -> Eventhandler mappen
            radarView1.TooClose += RadarView1_TooClose;
         
            consoleView1.RobotConsole = robot.RobotConsole;

            //An den Events anmelden
            commonRunParameters1.AccelerationChanged += AccelerationChanged;
            commonRunParameters1.SpeedChanged += SpeedChanged;

            //Switch Event anmelden -> S1
            consoleView1.RobotConsole[Switches.Switch1].SwitchStateChanged += switch_handler1;
            //Switch Event anmelden -> S2
            consoleView1.RobotConsole[Switches.Switch2].SwitchStateChanged += switch_handler2;
            //Switch Event anmelden -> S3
            consoleView1.RobotConsole[Switches.Switch3].SwitchStateChanged += switch_handler3;
            //Switch Event anmelden -> S4
            consoleView1.RobotConsole[Switches.Switch4].SwitchStateChanged += switch_handler4;

            //Eventhandler aufrufen und Default Werte setzen
            SpeedChanged(null, EventArgs.Empty); 
            AccelerationChanged(null, EventArgs.Empty); 
        }

        #endregion
        private void RadarView1_TooClose(object sender, EventArgs e)
        {
            //Falls das Radardview Event "Too Close" zieht, muss der roboter gestoppt werden
            //und die LEDs müssen blinken
            robot.Drive.Stop();
            //LEDs blinken lassen
            //LEDThread.Start();
            LEDsblinken();
        }

        private void LEDsblinken()
        {
            //Alle LEDs blinken 8 mal
            for (int i = 0; i < 8; i++)
            {
                //alle LEDs einschalten
                for (int j = 0; j < 4; j++)
                {
                    // whichLED = "Led" + j;
                    Leds whichLED = (Leds)j;
                    consoleView1.RobotConsole[whichLED].LedEnabled = true;
                }
                //pause
           

                //alle LEDs abschalten
                for (int j = 0; j < 4; j++)
                {
                    // whichLED = "Led" + j;
                    Leds whichLED = (Leds)j;
                    consoleView1.RobotConsole[whichLED].LedEnabled = false;
                }
              
            }

            //Funny knightrider LED stuff
            /*
            for (int j = 0; j < 2; j++)
            {
                consoleView1.RobotConsole[Leds.Led1].LedEnabled = true;
                consoleView1.RobotConsole[Leds.Led1].LedEnabled = false;
                consoleView1.RobotConsole[Leds.Led2].LedEnabled = true;
                consoleView1.RobotConsole[Leds.Led2].LedEnabled = false;
                consoleView1.RobotConsole[Leds.Led3].LedEnabled = true;
                consoleView1.RobotConsole[Leds.Led3].LedEnabled = false;
                consoleView1.RobotConsole[Leds.Led4].LedEnabled = true;
                consoleView1.RobotConsole[Leds.Led4].LedEnabled = false;
            }
            */
        }

        #region methods
        private void SpeedChanged(object sender, EventArgs e)
        {
            runLine1.Speed = commonRunParameters1.Speed;
            runTurn1.Speed = commonRunParameters1.Speed;
            runArc1.Speed = commonRunParameters1.Speed;
        }
        private void AccelerationChanged(object sender, EventArgs e)
        {
            runLine1.Acceleration = commonRunParameters1.Acceleration;
            runTurn1.Acceleration = commonRunParameters1.Acceleration;
            runArc1.Acceleration = commonRunParameters1.Acceleration;
        }

        //Initialisiere Standardwerte gemäss Aufgabe
        private void Init()
        {
            runLine1.Speed = commonRunParameters1.Speed;
            runLine1.Acceleration = commonRunParameters1.Acceleration;
            runTurn1.Speed = commonRunParameters1.Speed;
            runTurn1.Acceleration = commonRunParameters1.Acceleration;
            runArc1.Speed = commonRunParameters1.Speed;
            runArc1.Acceleration = commonRunParameters1.Acceleration;
        }


        private void buttonStop_Click(object sender, EventArgs e)
        {
            robot.Drive.Stop();
        }

        private void buttonHalt_Click(object sender, EventArgs e)
        {
            robot.Drive.Halt();
        }
        #endregion

        //Switchhandler 1 = runLine
        private void switch_handler1(object sender, EventArgs e)
        {
            runLine1.Start();
        }
        //Switchhandler 2 = runTurn
        private void switch_handler2(object sender, EventArgs e)
        {
            runTurn1.Start();
        }
        //Switchhandler 3 = turn
        private void switch_handler3(object sender, EventArgs e)
        {
            runArc1.Start();
        }
        //Switchhandler 4 = funny leds
        private void switch_handler4(object sender, EventArgs e)
        {
            LEDsblinken();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void commonRunParameters1_Click(object sender, EventArgs e)
        {

        }
    }
}
