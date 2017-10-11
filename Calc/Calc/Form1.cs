using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace Calc
{
    public partial class Form1 : Form
    {
        Calculator calculator;
        bool displayingResult = true;
        bool previousValueIsOperator = false;

        public Form1()
        {
            InitializeComponent();
            Opacity = 0.98;
            button0.Focus();
            calculator = new Calculator();
            numberText.Text = "0";
            numberText.SelectionAlignment = HorizontalAlignment.Right;
            historyText.SelectionAlignment = HorizontalAlignment.Right;

            this.button0.Click += (sender, EventArgs) => { DigitButton_Click(sender, EventArgs, '0'); };
            this.button1.Click += (sender, EventArgs) => { DigitButton_Click(sender, EventArgs, '1'); };
            this.button2.Click += (sender, EventArgs) => { DigitButton_Click(sender, EventArgs, '2'); };
            this.button3.Click += (sender, EventArgs) => { DigitButton_Click(sender, EventArgs, '3'); };
            this.button4.Click += (sender, EventArgs) => { DigitButton_Click(sender, EventArgs, '4'); };
            this.button5.Click += (sender, EventArgs) => { DigitButton_Click(sender, EventArgs, '5'); };
            this.button6.Click += (sender, EventArgs) => { DigitButton_Click(sender, EventArgs, '6'); };
            this.button7.Click += (sender, EventArgs) => { DigitButton_Click(sender, EventArgs, '7'); };
            this.button8.Click += (sender, EventArgs) => { DigitButton_Click(sender, EventArgs, '8'); };
            this.button9.Click += (sender, EventArgs) => { DigitButton_Click(sender, EventArgs, '9'); };
            this.buttonPoint.Click += (sender, EventArgs) => { DigitButton_Click(sender, EventArgs, '.'); };

            this.buttonAdd.Click += (sender, EventArgs) => { OperatorButton_Click(sender, EventArgs, '+'); };
            this.buttonSub.Click += (sender, EventArgs) => { OperatorButton_Click(sender, EventArgs, '-'); };
            this.buttonMul.Click += (sender, EventArgs) => { OperatorButton_Click(sender, EventArgs, '*'); };
            this.buttonDiv.Click += (sender, EventArgs) => { OperatorButton_Click(sender, EventArgs, '/'); };
        }



        private void richTextBox1_Enter(object sender, EventArgs e)
        {
            button0.Focus();
        }

        private void DigitButton_Click(object sender, EventArgs e, char digit)
        {
            if (displayingResult)
            {
                numberText.Text = "" + digit;
                displayingResult = false;
            }
            else
                numberText.Text += digit;

            previousValueIsOperator = false;
            numberText.SelectionAlignment = HorizontalAlignment.Right;
        }

        private void OperatorButton_Click(object sender, EventArgs e, char op)
        {
            if (!previousValueIsOperator)
            {
                calculator.OnNumber(Convert.ToDouble(numberText.Text));
                historyText.Text += numberText.Text + op;
            }
            else
            {
                if (historyText.Text.Length != 0)
                    historyText.Text = historyText.Text.Remove(historyText.Text.Length - 1);
                historyText.Text += op;
            }

            calculator.OnOperator(op);

            numberText.Text = ""+calculator.GetResult();

            previousValueIsOperator = true;
            displayingResult = true;
            numberText.SelectionAlignment = HorizontalAlignment.Right;
        }

        private void buttonEqu_Click(object sender, EventArgs e)
        {
            if (previousValueIsOperator)
            {
                historyText.Text = historyText.Text.Remove(historyText.Text.Length - 1);
                historyText.Text += calculator.GetOp();
            }
            historyText.Text += numberText.Text + "=";
            calculator.OnNumber(Convert.ToDouble(numberText.Text));
            numberText.Text = "" + calculator.GetResult();
            previousValueIsOperator = true;
            displayingResult = true;
            numberText.SelectionAlignment = HorizontalAlignment.Right;
        }

        private void buttonC_Click(object sender, EventArgs e)
        {
            calculator.OnCancel();
            numberText.Text = "0";
            historyText.Text = "";
            previousValueIsOperator = true;
            displayingResult = true;
            numberText.SelectionAlignment = HorizontalAlignment.Right;
        }

        private void historyText_Enter(object sender, EventArgs e)
        {
            button0.Focus();
        }

        private void numberText_Enter(object sender, EventArgs e)
        {
            button0.Focus();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            if (numberText.Text.Length <= 1)
                numberText.Text = "0";
            else
                numberText.Text = numberText.Text.Remove(numberText.Text.Length - 1);
            numberText.SelectionAlignment = HorizontalAlignment.Right;
        }


        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch(keyData)
            {
                case Keys.D0: case Keys.NumPad0: button0.PerformClick(); break;
                case Keys.D1: case Keys.NumPad1: button1.PerformClick(); break;
                case Keys.D2: case Keys.NumPad2: button2.PerformClick(); break;
                case Keys.D3: case Keys.NumPad3: button3.PerformClick(); break;
                case Keys.D4: case Keys.NumPad4: button4.PerformClick(); break;
                case Keys.D5: case Keys.NumPad5: button5.PerformClick(); break;
                case Keys.D6: case Keys.NumPad6: button6.PerformClick(); break;
                case Keys.D7: case Keys.NumPad7: button7.PerformClick(); break;
                case Keys.D8: case Keys.NumPad8: button8.PerformClick(); break;
                case Keys.D9: case Keys.NumPad9: button9.PerformClick(); break;

                case Keys.Add: buttonAdd.PerformClick(); break;
                case Keys.Subtract: buttonSub.PerformClick(); break;
                case Keys.Divide: buttonDiv.PerformClick(); break;
                case Keys.Multiply: buttonMul.PerformClick(); break;

                case Keys.Back: buttonBack.PerformClick(); break;
                case Keys.C: buttonC.PerformClick(); break;
                case Keys.Enter: buttonEqu.PerformClick(); break;
                case Keys.Decimal: buttonPoint.PerformClick(); break;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
