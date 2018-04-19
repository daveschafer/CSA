namespace RobotView
{
    partial class DriveCtrlView
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxDriveCtrlStatus = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.checkBoxDriveCtrlRight = new System.Windows.Forms.CheckBox();
            this.buttonResetDriveCtrl = new System.Windows.Forms.Button();
            this.checkBoxDriveCtrlLeft = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer();
            this.timer1 = new System.Windows.Forms.Timer();
            this.SuspendLayout();
            // 
            // textBoxDriveCtrlStatus
            // 
            this.textBoxDriveCtrlStatus.Location = new System.Drawing.Point(197, 29);
            this.textBoxDriveCtrlStatus.Name = "textBoxDriveCtrlStatus";
            this.textBoxDriveCtrlStatus.Size = new System.Drawing.Size(72, 23);
            this.textBoxDriveCtrlStatus.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(3, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 20);
            this.label4.Text = "Reset DriveCtrl";
            // 
            // checkBoxDriveCtrlRight
            // 
            this.checkBoxDriveCtrlRight.Location = new System.Drawing.Point(153, 32);
            this.checkBoxDriveCtrlRight.Name = "checkBoxDriveCtrlRight";
            this.checkBoxDriveCtrlRight.Size = new System.Drawing.Size(38, 20);
            this.checkBoxDriveCtrlRight.TabIndex = 14;
            this.checkBoxDriveCtrlRight.Text = "R";
            this.checkBoxDriveCtrlRight.CheckStateChanged += new System.EventHandler(this.checkBoxDriveCtrlRight_CheckStateChanged);
            // 
            // buttonResetDriveCtrl
            // 
            this.buttonResetDriveCtrl.Location = new System.Drawing.Point(197, 3);
            this.buttonResetDriveCtrl.Name = "buttonResetDriveCtrl";
            this.buttonResetDriveCtrl.Size = new System.Drawing.Size(72, 20);
            this.buttonResetDriveCtrl.TabIndex = 12;
            this.buttonResetDriveCtrl.Text = "Reset";
            this.buttonResetDriveCtrl.Click += new System.EventHandler(this.buttonResetDriveCtrl_Click);
            // 
            // checkBoxDriveCtrlLeft
            // 
            this.checkBoxDriveCtrlLeft.Location = new System.Drawing.Point(109, 34);
            this.checkBoxDriveCtrlLeft.Name = "checkBoxDriveCtrlLeft";
            this.checkBoxDriveCtrlLeft.Size = new System.Drawing.Size(38, 20);
            this.checkBoxDriveCtrlLeft.TabIndex = 13;
            this.checkBoxDriveCtrlLeft.Text = "L";
            this.checkBoxDriveCtrlLeft.CheckStateChanged += new System.EventHandler(this.checkBoxDriveCtrlLeft_CheckStateChanged);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(3, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 20);
            this.label3.Text = "Power left/right";
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // DriveCtrlView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.textBoxDriveCtrlStatus);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.checkBoxDriveCtrlRight);
            this.Controls.Add(this.buttonResetDriveCtrl);
            this.Controls.Add(this.checkBoxDriveCtrlLeft);
            this.Controls.Add(this.label3);
            this.Name = "DriveCtrlView";
            this.Size = new System.Drawing.Size(274, 57);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxDriveCtrlStatus;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkBoxDriveCtrlRight;
        private System.Windows.Forms.Button buttonResetDriveCtrl;
        private System.Windows.Forms.CheckBox checkBoxDriveCtrlLeft;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Timer timer1;
    }
}
