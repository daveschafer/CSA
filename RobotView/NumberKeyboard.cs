using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RobotView
{
    public partial class NumberKeyboard : Form
    {

        private float number;

        public NumberKeyboard()
        {
            InitializeComponent();
        }

        public float Number
        {
            get { return float.Parse(TextValue); }
            set { TextValue = value.ToString(); }
        }

        private string TextValue
        {
            get { return textBox1.Text; }
            set { textBox1.Text = value; }
        }


        #region numbers
        private void Add(string ch)
        {
            string s = TextValue.TrimStart('0');
            if (s.Length == 0) s = "0";
            try
            {
                s += ch;
                Number = float.Parse(s);
                TextValue = s;
            }
            catch (Exception) { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Add("1");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Add("2");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Add("3");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Add("4");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Add("5");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Add("6");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Add("7");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Add("8");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Add("9");
        }

        private void button0_Click(object sender, EventArgs e)
        {
            Add("0");
        }





        #endregion

        private void buttonClear_Click(object sender, EventArgs e)
        {
            TextValue = "0";
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            string n = TextValue;
            if (n.Length > 1)
            {
                n = n.Substring(0, n.Length - 1);
                try
                {
                    TextValue = n;
                }
                catch (Exception) { }
            }
            else
            {
                TextValue = "0";
            }
        }

        private void buttonDot_Click(object sender, EventArgs e)
        {
            if (!TextValue.Contains(".")) Add(".");
        }

        private void buttonPlusMinus_Click(object sender, EventArgs e)
        {
            if (TextValue.StartsWith("-")) TextValue = TextValue.Substring(1);
            else TextValue = '-' + TextValue;
        }
    }
}