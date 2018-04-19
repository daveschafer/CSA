//------------------------------------------------------------------------------
// C #   I N   A C T I O N   ( C S A )
//------------------------------------------------------------------------------
// Repository:
//    $Id: Led.cs 1024 2016-10-11 12:06:49Z chj-hslu $
//------------------------------------------------------------------------------
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace RobotCtrl
{

    public enum Leds
    {
        Led1 = 0,
        Led2,
        Led3,
        Led4
    }


    /// <summary>
    /// Diese Klasse bildet eine LED des Roboters ab.
    /// </summary>
    public class Led
    {

        #region members
        private Leds led;
        private DigitalOut digitalOut;
        private bool oldState;
        #endregion


        #region eventhandler
        public event EventHandler<LedEventArgs> LedStateChanged;
        #endregion


        #region constructor & destructor
        /// <summary>
        /// Initialisiert die gewünschte LED und verknüpft sie mit einem digitalOut-Objekt.
        /// </summary>
        /// <param name="digitalOut"></param>
        /// <param name="led"></param>
        public Led(DigitalOut digitalOut, Leds led)
        {
            this.digitalOut = digitalOut;
            this.led = led;
            this.oldState = false;
            this.digitalOut.DigitalOutputChanged += new EventHandler(DigitalOutputChanged);
        }
        #endregion


        #region properties
        /// <summary>
        /// Liefert bzw. setzt den Zustand der LED beim digitalOut-Objekt (ein-/ausgeschaltet)
        /// </summary>
        public bool LedEnabled
        {
            get { return this.digitalOut[(int)led]; }
            set { this.digitalOut[(int)led] = value; }
        }
        #endregion


        #region methods
        /// <summary>
        /// Dieser Eventhandler wird aufgerufen, sobald sich ein Ausgang (DigitalOut) ändert und
        /// führt dazu, dass die LED entsprechend ein-/ausgeschaltet wrid.
        /// </summary>
        /// 
        /// <param name="sender">DigitalOut</param>
        /// <param name="e"></param>
        private void DigitalOutputChanged(object sender, EventArgs e)
        {
            bool newState = this.digitalOut[(int)led];
            if (oldState != newState)
            {
                OnLedStateChanged(new LedEventArgs(this.led, newState));
                oldState = newState;
            }
        }


        /// <summary>
        /// Diese Methode informiert alle registrierten Eventhandler über den Zustandswechsel 
        /// (ein-/ausgeschaltet) der LED.
        /// </summary>
        public void OnLedStateChanged(LedEventArgs e)
        {
            if (LedStateChanged != null)
            {
                LedStateChanged(this, e);
            }
        }
        #endregion

    }
}