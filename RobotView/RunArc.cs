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
    public partial class RunArc : UserControl
    {
        #region constructor & destructor
        public RunArc()
        {
            InitializeComponent();
        }
        #endregion


        #region properties
        public float Speed { get; set; }
        public float Acceleration { get; set; }
        public Drive Drive { get; set; }
        #endregion


        #region methods
        private void buttonArcNeg_Click(object sender, EventArgs e)
        {
            upDownArcAngle.Value = -upDownArcAngle.Value;
        }


        private void buttonStartArc_Click(object sender, EventArgs e)
        {
            //thread safe invoke
            if (InvokeRequired)
            {
                //selbst aufrufen... das GUI darf sich nur selbst aufrufen
                Invoke(new EventHandler<EventArgs>(buttonStartArc_Click), sender, e);
            }
            //normaler aufruf, vom GUI selbst
            else
            {
                if (Drive != null)
                {
                    if (radioButtonArcRight.Checked)
                    {
                        Drive.RunArcRight((float)upDownArcRadius.Value / 1000,
                            (float)upDownArcAngle.Value, Speed, Acceleration);
                    }
                    else
                    {
                        Drive.RunArcLeft((float)upDownArcRadius.Value / 1000,
                            (float)upDownArcAngle.Value, Speed, Acceleration);
                    }
                }
            }
        }

        public void Start()
        {
            buttonStartArc_Click(null, EventArgs.Empty);
        }

        #endregion

        private void button1_Click(object sender, EventArgs e)
        {

            NumberKeyboard nk = new NumberKeyboard();
        
                

            if (nk.ShowDialog() == DialogResult.OK)
            {
                //max abfrage
                if ((decimal)nk.Number <= this.upDownArcRadius.Maximum)
                {
                    this.upDownArcRadius.Value = (decimal)nk.Number;
                }
                //sonst max value setzen
               else
                {
                    this.upDownArcRadius.Value = this.upDownArcRadius.Maximum;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            NumberKeyboard nk = new NumberKeyboard();

            if(nk.ShowDialog() == DialogResult.OK)
            {
                //MAX Abfrage...
                if ((decimal)nk.Number <= this.upDownArcAngle.Maximum)
                {
                    this.upDownArcAngle.Value = (decimal)nk.Number;
                }
                else
                {
                    this.upDownArcAngle.Value = this.upDownArcAngle.Maximum;
                }
            }
        }
    }
}