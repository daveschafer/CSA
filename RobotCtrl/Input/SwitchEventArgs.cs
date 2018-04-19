//------------------------------------------------------------------------------
// C #   I N   A C T I O N   ( C S A )
//------------------------------------------------------------------------------
// Repository:
//    $Id: SwitchEventArgs.cs 1024 2016-10-11 12:06:49Z chj-hslu $
//------------------------------------------------------------------------------
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace RobotCtrl
{

    /// <summary>
    /// EventArgs-Klasse um über Änderungen der Schalter zu informieren.
    /// </summary>
    public class SwitchEventArgs : EventArgs
    {

        #region constructor & destructor
        /// <summary>
        /// Initialisiert die SwitchEventArgs-Klasse
        /// </summary>
        /// <param name="swi">der betroffene Schalter</param>
        /// <param name="switchEnabled">der aktuelle Zustand des Schalters</param>
        public SwitchEventArgs(Switches swi, bool switchEnabled)
        {
            Swi = swi;
            SwitchEnabled = switchEnabled;
        }
        #endregion


        #region properties
        /// <summary>
        /// Liefert bzw. setzt die Eigenschaft, ob der Schalter aktiviert ist oder nicht
        /// </summary>
        public bool SwitchEnabled { get; set; }


        /// <summary>
        /// Liefert bzw. setzt den betroffenen Schalter
        /// </summary>
        public Switches Swi { get; set; }
        #endregion
    }
}