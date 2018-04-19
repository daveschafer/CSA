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
    /// Diese Klasse visualisiert einen Schalter des Roboters.
    /// </summary>
    public partial class SwitchView : UserControl
    {

        #region members
        private Switch swi;
        private bool state;
        #endregion


        #region constructor & destructor
        /// <summary>
        /// Der Konstruktor initialisiert nur das Control. Erst wenn per Switch-Property ein Schalter
        /// dieser View zugewiesen wird, funktioniert dieser Schalter und kann den aktuellen Zustand anzeigen.
        /// </summary>
        public SwitchView()
        {
            InitializeComponent();

            State = false;
        }
        #endregion


        #region properties
        /// <summary>
        /// Liefert bzw. setzt das Switch-Objekt (Model).
        /// Die SwitchView registriert sich beim Model und wird so über Änderungen per Event informiert.
        /// </summary>
        public Switch Switch
        {
            get { return swi; }
            set
            {
                // Falls bereits ein Eventhandler registriert war => diesen zuerst beim alten Led-Objekt entfernen
                if (swi != null) swi.SwitchStateChanged -= SwitchStateChanged;

                // Handler beim Led-Objekt (Model) registrieren.
                swi = value;
                if (swi != null)
                {
                    this.swi.SwitchStateChanged += SwitchStateChanged;
                    State = swi.SwitchEnabled;
                }
            }
        }


        /// <summary>
        /// Liefert bzw. setzt den Zustand des Schalters (true => ein, false => aus)
        /// </summary>
        public bool State
        {
            get { return state; }
            set
            {
                state = value;
                pictureBox1.Image = (value ? Resource.SwitchOn : Resource.SwitchOff);
            }
        }
        #endregion


        #region methods
        /// <summary>
        /// Diese Methode wir aufgerufen, wenn sich im Model der Zustand des Schalters verändert. Somit
        /// kann die View den aktuellen Zustand darstellen.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SwitchStateChanged(object sender, SwitchEventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new EventHandler<SwitchEventArgs>(SwitchStateChanged), sender, e);
            }
            else
            {
                State = e.SwitchEnabled;
            }
        }
        #endregion
    }
}