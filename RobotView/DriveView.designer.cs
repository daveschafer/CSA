namespace RobotView
{
    partial class DriveView
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
            this.label11 = new System.Windows.Forms.Label();
            this.buttonReset = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxRuntime = new System.Windows.Forms.TextBox();
            this.textBoxAngle = new System.Windows.Forms.TextBox();
            this.textBoxPosY = new System.Windows.Forms.TextBox();
            this.textBoxPosX = new System.Windows.Forms.TextBox();
            this.textBoxRelPosRight = new System.Windows.Forms.TextBox();
            this.textBoxRelPosLeft = new System.Windows.Forms.TextBox();
            this.textBoxSpeedRight = new System.Windows.Forms.TextBox();
            this.textBoxSpeedLeft = new System.Windows.Forms.TextBox();
            this.textBoxMotorCtrlRight = new System.Windows.Forms.TextBox();
            this.textBoxMotorCtrlLeft = new System.Windows.Forms.TextBox();
            this.textBoxDriveCtrl = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer();
            this.SuspendLayout();
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label11.Location = new System.Drawing.Point(6, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(110, 20);
            this.label11.Text = "DriveInfo";
            // 
            // buttonReset
            // 
            this.buttonReset.Location = new System.Drawing.Point(129, 257);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(156, 27);
            this.buttonReset.TabIndex = 52;
            this.buttonReset.Text = "Reset Position";
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(210, 2);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(75, 20);
            this.label10.Text = "Right";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(129, 2);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(75, 20);
            this.label9.Text = "Left";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(6, 229);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(110, 20);
            this.label8.Text = "Runtime (s)";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(6, 200);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(110, 20);
            this.label7.Text = "Angle (degree)";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(6, 171);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(110, 20);
            this.label6.Text = "Y (m)";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(6, 142);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 20);
            this.label5.Text = "X (m)";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(6, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 20);
            this.label4.Text = "Rel. Position (m)";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(6, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 20);
            this.label3.Text = "Speed (m/s)";
            // 
            // textBoxRuntime
            // 
            this.textBoxRuntime.Location = new System.Drawing.Point(169, 228);
            this.textBoxRuntime.Name = "textBoxRuntime";
            this.textBoxRuntime.Size = new System.Drawing.Size(75, 23);
            this.textBoxRuntime.TabIndex = 51;
            // 
            // textBoxAngle
            // 
            this.textBoxAngle.Location = new System.Drawing.Point(169, 199);
            this.textBoxAngle.Name = "textBoxAngle";
            this.textBoxAngle.Size = new System.Drawing.Size(75, 23);
            this.textBoxAngle.TabIndex = 50;
            // 
            // textBoxPosY
            // 
            this.textBoxPosY.Location = new System.Drawing.Point(169, 170);
            this.textBoxPosY.Name = "textBoxPosY";
            this.textBoxPosY.Size = new System.Drawing.Size(75, 23);
            this.textBoxPosY.TabIndex = 49;
            // 
            // textBoxPosX
            // 
            this.textBoxPosX.Location = new System.Drawing.Point(169, 141);
            this.textBoxPosX.Name = "textBoxPosX";
            this.textBoxPosX.Size = new System.Drawing.Size(75, 23);
            this.textBoxPosX.TabIndex = 48;
            // 
            // textBoxRelPosRight
            // 
            this.textBoxRelPosRight.Location = new System.Drawing.Point(210, 112);
            this.textBoxRelPosRight.Name = "textBoxRelPosRight";
            this.textBoxRelPosRight.Size = new System.Drawing.Size(75, 23);
            this.textBoxRelPosRight.TabIndex = 47;
            // 
            // textBoxRelPosLeft
            // 
            this.textBoxRelPosLeft.Location = new System.Drawing.Point(129, 112);
            this.textBoxRelPosLeft.Name = "textBoxRelPosLeft";
            this.textBoxRelPosLeft.Size = new System.Drawing.Size(75, 23);
            this.textBoxRelPosLeft.TabIndex = 46;
            // 
            // textBoxSpeedRight
            // 
            this.textBoxSpeedRight.Location = new System.Drawing.Point(210, 83);
            this.textBoxSpeedRight.Name = "textBoxSpeedRight";
            this.textBoxSpeedRight.Size = new System.Drawing.Size(75, 23);
            this.textBoxSpeedRight.TabIndex = 45;
            // 
            // textBoxSpeedLeft
            // 
            this.textBoxSpeedLeft.Location = new System.Drawing.Point(129, 83);
            this.textBoxSpeedLeft.Name = "textBoxSpeedLeft";
            this.textBoxSpeedLeft.Size = new System.Drawing.Size(75, 23);
            this.textBoxSpeedLeft.TabIndex = 44;
            // 
            // textBoxMotorCtrlRight
            // 
            this.textBoxMotorCtrlRight.Location = new System.Drawing.Point(210, 54);
            this.textBoxMotorCtrlRight.Name = "textBoxMotorCtrlRight";
            this.textBoxMotorCtrlRight.Size = new System.Drawing.Size(75, 23);
            this.textBoxMotorCtrlRight.TabIndex = 43;
            // 
            // textBoxMotorCtrlLeft
            // 
            this.textBoxMotorCtrlLeft.Location = new System.Drawing.Point(129, 54);
            this.textBoxMotorCtrlLeft.Name = "textBoxMotorCtrlLeft";
            this.textBoxMotorCtrlLeft.Size = new System.Drawing.Size(75, 23);
            this.textBoxMotorCtrlLeft.TabIndex = 42;
            // 
            // textBoxDriveCtrl
            // 
            this.textBoxDriveCtrl.Location = new System.Drawing.Point(169, 25);
            this.textBoxDriveCtrl.Name = "textBoxDriveCtrl";
            this.textBoxDriveCtrl.Size = new System.Drawing.Size(75, 23);
            this.textBoxDriveCtrl.TabIndex = 41;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(6, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 20);
            this.label2.Text = "MotorCtrl-Status";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 20);
            this.label1.Text = "DriveCtrl-Status";
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // DriveView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.label11);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxRuntime);
            this.Controls.Add(this.textBoxAngle);
            this.Controls.Add(this.textBoxPosY);
            this.Controls.Add(this.textBoxPosX);
            this.Controls.Add(this.textBoxRelPosRight);
            this.Controls.Add(this.textBoxRelPosLeft);
            this.Controls.Add(this.textBoxSpeedRight);
            this.Controls.Add(this.textBoxSpeedLeft);
            this.Controls.Add(this.textBoxMotorCtrlRight);
            this.Controls.Add(this.textBoxMotorCtrlLeft);
            this.Controls.Add(this.textBoxDriveCtrl);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "DriveView";
            this.Size = new System.Drawing.Size(292, 289);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxRuntime;
        private System.Windows.Forms.TextBox textBoxAngle;
        private System.Windows.Forms.TextBox textBoxPosY;
        private System.Windows.Forms.TextBox textBoxPosX;
        private System.Windows.Forms.TextBox textBoxRelPosRight;
        private System.Windows.Forms.TextBox textBoxRelPosLeft;
        private System.Windows.Forms.TextBox textBoxSpeedRight;
        private System.Windows.Forms.TextBox textBoxSpeedLeft;
        private System.Windows.Forms.TextBox textBoxMotorCtrlRight;
        private System.Windows.Forms.TextBox textBoxMotorCtrlLeft;
        private System.Windows.Forms.TextBox textBoxDriveCtrl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer;
    }
}
