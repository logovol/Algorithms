using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace RPN
{
    public partial class Form1 : Form
    {
        List<string> functions = new List<string>();

        public Form1()
        {
            InitializeComponent();
            functions.Add("sin");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBoxFormula.Text = "-2,09*x+sin(0,5*x)";
            textBoxA.Text = "1";
            textBoxB.Text = "5";
            textBoxH.Text = "1";
        }

        private void buttonExecuteRPN_Click(object sender, EventArgs e)
        {
            double a;
            double b;
            double h;
            bool err = false;
            if (!double.TryParse(textBoxA.Text, out a))
            { err = true; }
            if (!double.TryParse(textBoxB.Text, out b))
            { err = true; }
            if (!double.TryParse(textBoxH.Text, out h))
            { err = true; }
            if (b < a || h == 0)
            { err = true; }

            if (!err)
            {
                RPN RPN = new RPN();
                string result = RPN.BuildListOfSymbols(textBoxFormula.Text, functions);
                if (result == "")
                {
                    textBoxPostfix.Text = RPN.BuildRPN();
                    textBoxResult.Text = RPN.Calculate(a, b, h);
                }
                else 
                {
                    textBoxResult.Text = result;
                }
            }
            else
            {
                textBoxResult.Text = "Put correct parameters";
            }
        }         
    }
}
