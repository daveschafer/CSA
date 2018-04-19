namespace RobotView
{
    partial class RunTurn
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
            this.buttonTurnStart = new System.Windows.Forms.Button();
            this.buttonTurnNeg = new System.Windows.Forms.Button();
            this.upDownTurnAngle = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonTurnStart
            // 
            this.buttonTurnStart.Location = new System.Drawing.Point(296, 14);
            this.buttonTurnStart.Name = "buttonTurnStart";
            this.buttonTurnStart.Size = new System.Drawing.Size(51, 24);
            this.buttonTurnStart.TabIndex = 21;
            this.buttonTurnStart.Text = "Start";
            this.buttonTurnStart.Click += new System.EventHandler(this.buttonTurnStart_Click);
            // 
            // buttonTurnNeg
            // 
            this.buttonTurnNeg.Location = new System.Drawing.Point(129, 14);
            this.buttonTurnNeg.Name = "buttonTurnNeg";
            this.buttonTurnNeg.Size = new System.Drawing.Size(35, 24);
            this.buttonTurnNeg.TabIndex = 22;
            this.buttonTurnNeg.Text = "+/ -";
            this.buttonTurnNeg.Click += new System.EventHandler(this.buttonTurnNeg_Click);
            // 
            // upDownTurnAngle
            // 
            this.upDownTurnAngle.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.upDownTurnAngle.Location = new System.Drawing.Point(170, 14);
            this.upDownTurnAngle.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.upDownTurnAngle.Minimum = new decimal(new int[] {
            360,
            0,
            0,
            -2147483648});
            this.upDownTurnAngle.Name = "upDownTurnAngle";
            this.upDownTurnAngle.Size = new System.Drawing.Size(75, 24);
            this.upDownTurnAngle.TabIndex = 23;
            this.upDownTurnAngle.Value = new decimal(new int[] {
            90,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(0, -2);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(182, 20);
            this.label6.Text = "RunTurn";
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular);
            this.label12.Location = new System.Drawing.Point(3, 18);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(123, 20);
            this.label12.Text = "Angle (+/- degrees)";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(252, 14);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(38, 24);
            this.button1.TabIndex = 26;
            this.button1.Text = "...";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // RunTurn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonTurnStart);
            this.Controls.Add(this.buttonTurnNeg);
            this.Controls.Add(this.upDownTurnAngle);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label12);
            this.Name = "RunTurn";
            this.Size = new System.Drawing.Size(353, 45);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonTurnStart;
        private System.Windows.Forms.Button buttonTurnNeg;
        private System.Windows.Forms.NumericUpDown upDownTurnAngle;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button button1;
    }
}
