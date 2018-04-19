//------------------------------------------------------------------------------
// C #   I N   A C T I O N   ( C S A )
//------------------------------------------------------------------------------
// Repository:
//    $Id: ConsoleView.cs 1027 2016-10-11 12:15:12Z chj-hslu $
//------------------------------------------------------------------------------
using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using RobotCtrl;

namespace RobotView
{
    /// <summary>
    /// Diese Klasse bildet die Konsole des Roboters (4 Led's und 4 Schalter) ab.
    /// </summary>
    public partial class ConsoleView : UserControl
    {

        #region members
        private RobotConsole robotConsole;
        #endregion


        #region constructor & destructor
        public ConsoleView()
        {
            InitializeComponent();
        }
        #endregion


        #region properties
        /// <summary>
        /// Liefert bzw. setzt das Konsolenobjekt.
        /// Sobald ein Konsolenobjekt gesetzt wird, werden die Led's und Schalter damit verknüpft.
        /// </summary>
        public RobotConsole RobotConsole
        {
            get { return robotConsole; }
            set
            {
                robotConsole = value;

                if (robotConsole != null)
                {
                    // jeder LedView die entsprechende Led zuweisen
                    ledView1.Led = robotConsole[Leds.Led1];
                    ledView2.Led = robotConsole[Leds.Led2];
                    ledView3.Led = robotConsole[Leds.Led3];
                    ledView4.Led = robotConsole[Leds.Led4];

                    // jeder SwitchView den entsprechenden Schalter zuweisen
                    switchView1.Switch = robotConsole[Switches.Switch1];
                    switchView2.Switch = robotConsole[Switches.Switch2];
                    switchView3.Switch = robotConsole[Switches.Switch3];
                    switchView4.Switch = robotConsole[Switches.Switch4];
                }
            }
        }
        #endregion
    }
}
