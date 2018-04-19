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
    public partial class MotorCtrlView : UserControl
    {
        #region constructor & destructor
        public MotorCtrlView()
        {
            InitializeComponent();
        }
        #endregion


        #region properties
        public bool Running { get; private set; }

        public MotorCtrl MotorCtrl { get; set; }
        #endregion


        #region methods
        private void buttonResetTicks_Click(object sender, EventArgs e)
        {
            if (MotorCtrl != null)
            {
                MotorCtrl.ResetTicks();
            }
        }

        private void buttonMotorCtrlStart_Click(object sender, EventArgs e)
        {
            if (MotorCtrl != null)
            {
                Running = true;
                MotorCtrl.Go();
            }
        }

        private void buttonMotorCtrlStop_Click(object sender, EventArgs e)
        {
            if (MotorCtrl != null)
            {
                Running = false;
                MotorCtrl.Stop();
            }
        }

        private void buttonResetMotorCtrl_Click(object sender, EventArgs e)
        {
            if (MotorCtrl != null)
            {
                MotorCtrl.Reset();
                Running = false;
            }
        }


        private void timer_Tick(object sender, EventArgs e)
        {
            if (MotorCtrl != null)
            {
                labelMotorStatus.Text = MotorCtrl.Stopped ? "stopped" : "running";
                textBoxDriveCtrlMotorStatus.Text = "0x" + MotorCtrl.Status.ToString("X2");

                textBoxDistance.Text = MotorCtrl.Distance.ToString("F3");
                textBoxTicks.Text = MotorCtrl.Ticks.ToString();

                float acceleration = trackBarAcceleration.Value / 1000f;
                textBoxAcceleration.Text = acceleration.ToString("F3");

                float speed = this.trackBarMotorSpeed.Value / 1000f;
                textBoxMotorSpeed.Text = speed.ToString("F3");

                this.labelCurrentSpeed.Text = MotorCtrl.CurrentSpeed.ToString("F3") + " m/s";

                if (Running)
                {
                    MotorCtrl.Speed = speed;
                    MotorCtrl.Go();
                }
                else
                {
                    MotorCtrl.Acceleration = acceleration;
                    // MotorCtrl.SetPID(100, 20, 1000, 1000, 1);
                }

                // Smartgui
                buttonMotorCtrlStart.Enabled = !Running;
                buttonMotorCtrlStop.Enabled = Running;
                trackBarAcceleration.Enabled = !Running;
            }
        }
        #endregion
    }
}