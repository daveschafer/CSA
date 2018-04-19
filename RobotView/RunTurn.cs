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
    public partial class RunTurn : UserControl
    {
        #region constructor & destructor
        public RunTurn()
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
        private void buttonTurnStart_Click(object sender, EventArgs e)
        {
            //thread safe invoke
            if (InvokeRequired)
            {
                Invoke(new EventHandler<EventArgs>(buttonTurnStart_Click), sender, e);
            }
            //normaler invoke
            else
            {
                if (Drive != null) Drive.RunTurn(
                    (float)upDownTurnAngle.Value, Speed, Acceleration);
            }
        }

        private void buttonTurnNeg_Click(object sender, EventArgs e)
        {
            upDownTurnAngle.Value = -upDownTurnAngle.Value;
        }

        public void Start()
        {
            buttonTurnStart_Click(null, EventArgs.Empty);
        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            NumberKeyboard nk = new NumberKeyboard();

            if (nk.ShowDialog() == DialogResult.OK)
            {
                if ((decimal)nk.Number <= this.upDownTurnAngle.Maximum)
                {
                    this.upDownTurnAngle.Value = (decimal)nk.Number;
                }
                else
                {
                    this.upDownTurnAngle.Value = this.upDownTurnAngle.Maximum;
                }
            }

        }
    }
}