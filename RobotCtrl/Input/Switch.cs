//------------------------------------------------------------------------------
// C #   I N   A C T I O N   ( C S A )
//------------------------------------------------------------------------------
// Repository:
//    $Id: Switch.cs 1024 2016-10-11 12:06:49Z chj-hslu $
//------------------------------------------------------------------------------
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace RobotCtrl
{

    public enum Switches
    {
        Switch1 = 0,
        Switch2,
        Switch3,
        Switch4
    }


    /// <summary>
    /// Diese Klasse bildet einen Schalter des Roboters ab
    /// </summary>
    public class Switch
    {

        #region members
        private Switches swi;
        private DigitalIn digitalIn;
        private bool oldState;
        #endregion


        #region eventhandler
        public event EventHandler<SwitchEventArgs> SwitchStateChanged;
        #endregion


        #region constructor & destructor
        /// <summary>
        /// Initialisiert den Schalter.
        /// </summary>
        /// <param name="digitalIn">das zu verwendende DigitalIn-Objekt</param>
        /// <param name="swi">der abzubildende Schalter</param>
        public Switch(DigitalIn digitalIn, Switches swi)
        {
            this.digitalIn = digitalIn;
            this.swi = swi;
            this.oldState = false;
            this.digitalIn.DigitalInChanged += new EventHandler(DigitalInChanged);
        }
        #endregion


        #region properties
        /// <summary>
        /// Liefert bzw. setzt den Zustand des Schalters beim digitalIn-Objekt (ein-/ausgeschaltet)
        /// </summary>
        public bool SwitchEnabled
        {
            get { return this.digitalIn[(int)swi]; }
        }
        #endregion


        #region methods
        /// <summary>
        /// Dieser Eventhandler wird aufgerufen, sobald sich ein oder mehrere Bits des DigitalIn-Objekts ändern.
        /// Falls sich der Zustand des Schalters geändert hat, so werden alle registrierten Eventhandler darüber
        /// informiert.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DigitalInChanged(object sender, EventArgs e)
        {
            bool newState = SwitchEnabled;
            if (oldState != newState)
            {
                OnSwitchStateChanged(new SwitchEventArgs(this.swi, newState));
                oldState = newState;
            }
        }


        /// <summary>
        /// Diese Methode informiert alle registrierten Eventhandler über den Zustandswechsel 
        /// (ein-/ausgeschaltet) des Schalters.
        /// </summary>
        public void OnSwitchStateChanged(SwitchEventArgs e)
        {
            if (SwitchStateChanged != null)
            {
                SwitchStateChanged(this, e);
            }
        }
        #endregion

    }
}