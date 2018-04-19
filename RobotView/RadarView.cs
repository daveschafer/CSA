using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using RobotCtrl;

namespace RobotView
{
    public partial class RadarView : UserControl
    {


        #region properties
        /// <summary>
        /// Liefert bzw. setzt das Radar-Objekt
        /// </summary>
        public Radar Radar { get; set; }
        #endregion

        
        public event EventHandler TooClose;
        #region constructor & destructor
        public RadarView()
        {
            InitializeComponent();
        }
        #endregion




        #region methods
        private void timer_Tick(object sender, EventArgs e)
        {
            if (Radar != null)
            {
                //Distanz angeben, Achtung Distanz  ist in millimetern ( vom Sensor
                this.label1.Text = "Distanz: " + Radar.Distance.ToString("0.00") + " m";
                //Radard Distanz, konvertiert in centi
                int value = (int)(Radar.Distance * 100);
                //obergrenze Radar
                if (value > 255) value = 255;
                //untergrenze
                if (value < 0) value = 0;

                //Falls Radar Distanz unter 20cm -> Block und event triggern, sprich alle abonnierten invoken
                if (value < 20)
                    TooClose?.Invoke(null, null);
                //progressbar aktualisieren
                this.progressBar1.Value = value;
            }
        }
        #endregion
    }
}