namespace RobotView
{
    partial class RunLine
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
            this.buttonLineStart = new System.Windows.Forms.Button();
            this.buttonLineNeg = new System.Windows.Forms.Button();
            this.upDownLineLength = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonLineStart
            // 
            this.buttonLineStart.Location = new System.Drawing.Point(290, 15);
            this.buttonLineStart.Name = "buttonLineStart";
            this.buttonLineStart.Size = new System.Drawing.Size(51, 24);
            this.buttonLineStart.TabIndex = 18;
            this.buttonLineStart.Text = "Start";
            this.buttonLineStart.Click += new System.EventHandler(this.buttonLineStart_Click);
            // 
            // buttonLineNeg
            // 
            this.buttonLineNeg.Location = new System.Drawing.Point(117, 15);
            this.buttonLineNeg.Name = "buttonLineNeg";
            this.buttonLineNeg.Size = new System.Drawing.Size(35, 24);
            this.buttonLineNeg.TabIndex = 19;
            this.buttonLineNeg.Text = "+/ -";
            this.buttonLineNeg.Click += new System.EventHandler(this.buttonLineNeg_Click);
            // 
            // upDownLineLength
            // 
            this.upDownLineLength.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.upDownLineLength.Location = new System.Drawing.Point(158, 15);
            this.upDownLineLength.Maximum = new decimal(new int[] {
            50000,
            0,
            0,
            0});
            this.upDownLineLength.Minimum = new decimal(new int[] {
            50000,
            0,
            0,
            -2147483648});
            this.upDownLineLength.Name = "upDownLineLength";
            this.upDownLineLength.Size = new System.Drawing.Size(75, 24);
            this.upDownLineLength.TabIndex = 20;
            this.upDownLineLength.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label9.Location = new System.Drawing.Point(0, -1);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(182, 20);
            this.label9.Text = "RunLine";
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular);
            this.label8.Location = new System.Drawing.Point(3, 19);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(114, 20);
            this.label8.Text = "Length (+/- mm)";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(239, 15);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(45, 24);
            this.button1.TabIndex = 23;
            this.button1.Text = "...";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // RunLine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonLineStart);
            this.Controls.Add(this.buttonLineNeg);
            this.Controls.Add(this.upDownLineLength);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Name = "RunLine";
            this.Size = new System.Drawing.Size(351, 46);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonLineStart;
        private System.Windows.Forms.Button buttonLineNeg;
        private System.Windows.Forms.NumericUpDown upDownLineLength;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button1;
    }
}
