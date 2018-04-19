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
    public partial class DriveView : UserControl
    {
        public DriveView()
        {
            InitializeComponent();
        }

        public Drive Drive { get; set; }



        private void timer_Tick(object sender, EventArgs e)
        {
            if (Drive != null)
            {
                DriveInfo info = Drive.DriveInfo;

                textBoxDriveCtrl.Text = "0x" + info.DriveStatus.ToString("X2");

                textBoxMotorCtrlLeft.Text = "0x" + info.MotorStatusL.ToString("X2");
                textBoxMotorCtrlRight.Text = "0x" + info.MotorStatusR.ToString("X2");

                textBoxSpeedLeft.Text = info.SpeedL.ToString("F3");
                textBoxSpeedRight.Text = info.SpeedR.ToString("F3");

                textBoxRelPosLeft.Text = info.DistanceL.ToString("F3");
                textBoxRelPosRight.Text = info.DistanceR.ToString("F3");

                textBoxPosX.Text = info.Position.X.ToString("F3");
                textBoxPosY.Text = info.Position.Y.ToString("F3");

                textBoxAngle.Text = info.Position.Angle.ToString("F3");

                textBoxRuntime.Text = info.Runtime.ToString("F3");
            }
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            if (Drive != null)
            {
                Drive.Position = new PositionInfo(0, 0, 0);
            }
        }
    }
}