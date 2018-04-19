#define VARIANTE2

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace RobotView
{
    public partial class CommonRunParameters : UserControl
    {
#if VARIANTE1

        #region events
        public event EventHandler<EventArgs> SpeedChanged;
        public event EventHandler<EventArgs> AccelerationChanged;
        #endregion


        #region constructor & destructor
        public CommonRunParameters()
        {
            InitializeComponent();
            upDownAcceleration.ValueChanged += new EventHandler(upDownAcceleration_ValueChanged);
            upDownSpeed.ValueChanged += new EventHandler(upDownSpeed_ValueChanged);
        }
        #endregion


        #region properties
        public float Speed
        {
            get { return (float)upDownSpeed.Value / 1000; }
            set { upDownSpeed.Value = (decimal)value * 1000; }
        }

        public float Acceleration
        {
            get { return (float)upDownAcceleration.Value / 1000; }
            set { upDownAcceleration.Value = (decimal)value * 1000; }
        }
        #endregion


        #region methods
        void upDownSpeed_ValueChanged(object sender, EventArgs e)
        {
            if (SpeedChanged != null)
            {
                SpeedChanged(this, e);
            }
        }

        void upDownAcceleration_ValueChanged(object sender, EventArgs e)
        {
            if (AccelerationChanged != null)
            {
                AccelerationChanged(this, e);
            }
        }
        #endregion

#else

        #region constructor & destructor
        public CommonRunParameters()
        {
            InitializeComponent();
        }
        #endregion


        #region properties
        public float Speed
        {
            get { return (float)upDownSpeed.Value / 1000; }
            set { upDownSpeed.Value = (decimal)value * 1000; }
        }

        public float Acceleration
        {
            get { return (float)upDownAcceleration.Value / 1000; }
            set { upDownAcceleration.Value = (decimal)value * 1000; }
        }
        #endregion


        #region events
        public event EventHandler SpeedChanged
        {
            add { upDownSpeed.ValueChanged += value; }
            remove { upDownSpeed.ValueChanged -= value; }
        }

        public event EventHandler AccelerationChanged
        {
            add { upDownAcceleration.ValueChanged += value; }
            remove { upDownAcceleration.ValueChanged -= value; }
        }
        #endregion

#endif
    }
}