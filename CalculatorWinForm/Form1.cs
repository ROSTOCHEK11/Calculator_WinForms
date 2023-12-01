using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculatorWinForm
{
    public partial class Form1 : Form
    { 

        double result = 0;
        string operation = string.Empty;
        string fstNum, secNum;
        bool enterValue = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnNum_Click(object sender, EventArgs e)
        {

            if (tbResult.Text == "0" || enterValue)
            {
                tbResult.Text = string.Empty;
            }

            enterValue = false;

            Button button = (Button)sender;

            if(button.Text == ",")
            {

                if(!tbResult.Text.Contains(","))
                {
                    tbResult.Text += button.Text;
                }

            }
            else
            {
                tbResult.Text += button.Text;
            }

        }

        private void BtnEqual_Click(object sender, EventArgs e)
        {

            secNum = tbResult.Text;
            tbHistory.Text = $"{tbHistory.Text}{tbResult.Text}=";

            if(tbResult.Text != string.Empty)
            {

                if(tbResult.Text == "0")
                {
                    tbHistory.Text = string.Empty;
                }

                switch (operation)
                {
                    case "+":
                        tbResult.Text = (result + Double.Parse(tbResult.Text)).ToString();
                        break;

                    case "-":
                        tbResult.Text = (result - Double.Parse(tbResult.Text)).ToString();
                        break;

                    case "×":
                        tbResult.Text = (result * Double.Parse(tbResult.Text)).ToString();
                        break;

                    case "÷":
                        tbResult.Text = (result / Double.Parse(tbResult.Text)).ToString();
                        break;

                    default:
                        tbHistory.Text = $"{tbResult.Text}=";
                        break;
                }

                result = Double.Parse(tbResult.Text);
                operation = string.Empty;

            }


        }

        private void BtnBackSpace_Click(object sender, EventArgs e)
        {

            if(tbResult.Text.Length > 0)
            {
                tbResult.Text = tbResult.Text.Remove(tbResult.Text.Length - 1, 1);
            }
            if(tbResult.Text == string.Empty)
            {
                tbResult.Text = "0";
            }

        }

        private void BtnC_Click(object sender, EventArgs e)
        {

            tbResult.Text = "0";
            tbHistory.Text = string.Empty;
            result = 0;


        }

        private void BtnCE_Click(object sender, EventArgs e)
        {

            tbResult.Text = "0";

        }

        private void BtnOperations_Click(object sender, EventArgs e)
        {

            Button button = (Button)sender;
            operation = button.Text;

            switch (operation)
            {
                case "√x":
                    tbHistory.Text = $"√({tbResult.Text})";
                    tbResult.Text = Convert.ToString( Math.Sqrt(Double.Parse(tbResult.Text)) );
                    break;

                case "x^2":
                    tbHistory.Text = $"({tbResult.Text})^2";
                    tbResult.Text = Convert.ToString(Math.Pow(Double.Parse(tbResult.Text), 2));
                    break;

                case "1/x":
                    tbHistory.Text = $"1/({tbResult.Text})";
                    tbResult.Text = Convert.ToString( 1.0 / (Double.Parse(tbResult.Text)));
                    break;

                case "%":
                    tbHistory.Text = $"%({tbResult.Text})";
                    tbResult.Text = Convert.ToString( (Double.Parse(tbResult.Text)) / 100 );
                    break;

                case "+/-":
                    tbResult.Text = Convert.ToString(-1 * (Double.Parse(tbResult.Text)));
                    break;

              
            }


        }

        private void BtnMathOperation_Click(object sender, EventArgs e)
        {

            if(result != 0)
            {
                btnEqual.PerformClick();
            }
            else
            {
                result = Double.Parse(tbResult.Text);
            }

            Button button = (Button)sender;
            operation = button.Text;
            enterValue = true;

            if(tbResult.Text != "0")
            {
                tbHistory.Text = fstNum = $"{result}{operation}";
                tbResult.Text = string.Empty;
            }


        }

    }
}
