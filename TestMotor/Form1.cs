using RobotCtrl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TestMotor
{
    public partial class Form1 : Form
    {
        #region constructor & destructor
        public Form1()
        {
            InitializeComponent();
            driveCtrlView1.DriveCtrl = new DriveCtrl(Constants.IODriveCtrl);
            motorCtrlViewLeft.MotorCtrl = new MotorCtrl(Constants.IOMotorCtrlLeft);
            motorCtrlViewRight.MotorCtrl = new MotorCtrl(Constants.IOMotorCtrlRight);
        }
        #endregion
    }
}
