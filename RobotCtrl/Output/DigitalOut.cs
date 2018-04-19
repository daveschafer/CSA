//------------------------------------------------------------------------------
// C #   I N   A C T I O N   ( C S A )
//------------------------------------------------------------------------------
// Repository:
//    $Id: DigitalOut.cs 1024 2016-10-11 12:06:49Z chj-hslu $
//------------------------------------------------------------------------------
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace RobotCtrl
{

    /// <summary>
    /// Mit Hilfe diese Klasse kann auf die 4 Ausgänge (Led's) des Roboters zugegeriffen werden.
    /// </summary>
    public class DigitalOut
    {

        #region members
        private int data;
        public event EventHandler DigitalOutputChanged;
        #endregion


        #region constructor & destructor
        /// <summary>
        /// Initialisiert die Ausgänge auf 0 und schreibt diese Information auch zum Roboter
        /// </summary>
        /// 
        /// <param name="port">der IO-Port für den Zugriff auf die Ausgänge</param>
        public DigitalOut(int port)
        {
            Port = port;
            IOPort.Write(Port, 0);
            data = 0;
        }
        #endregion


        #region properties
        /// <summary>
        /// Liefert bzw. setzt den IO-Port für den Zugriff auf die Ausgänge des Roboters.
        /// </summary>
        public int Port { get; set; }


        /// <summary>
        /// Schreibt die übergebenen Daten auf den Port des Roboters falls sie sich
        /// geändert haben und informiert die registrierten Handler über das Event
        /// DigitalOutputChanged.
        /// </summary>
        public int Data
        {
            get { return data; }
            set
            {
                if (data != value)
                {
                    data = value;
                    IOPort.Write(Port, data);
                    OnDigitalOutputChanged(EventArgs.Empty);
                }
            }
        }
        #endregion


        #region methods
        /// <summary>
        /// Mit Hilfe dieser Methode wird das Event DigitalOutputChanged generiert.
        /// </summary>
        /// <param name="e"></param>
        protected void OnDigitalOutputChanged(EventArgs e)
        {
            if (DigitalOutputChanged != null)
            {
                DigitalOutputChanged(this, e);
            }
        }


        /// <summary>
        /// Indexierter Zugriff auf die einzelnen Bits des Properties Data.
        /// </summary>
        /// 
        /// <param name="bit">das gewünschte Bit [0..3]</param>
        /// <returns>den aktuellen Zustand des Bits</returns>
        public virtual bool this[int bit]
        {
            get { return (Data & (1 << bit)) != 0; }
            set
            {
                if (value)
                {
                    // bit setzen
                    // OR = Bit setzen = |
                    Data = Data | (1 << bit);
                }
                else
                {
                    // bit löschen
                    // AND = Bit löschen und prüfen = &
                    Data = Data & ~(1 << bit);
                }
                //Data = value ? Data | (1 << bit) : Data & ~(1 << bit); }
            }
        }
        #endregion
    }
}