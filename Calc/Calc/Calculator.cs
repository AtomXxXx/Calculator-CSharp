using System.Collections.Generic;
using System.Windows.Forms;

namespace Calc
{
    class Calculator
    {
        double operand;
        double result;
        int numbersCount;
        char op;

        public Calculator()
        {
            result = 0;
            operand = 0;
            numbersCount = 0;
            op = '+';
        }

        public double CalculateResult()
        {
            if (numbersCount <= 1)
            {
                result = operand;
                return result;
            }
            switch (op)
            {
                case '+':
                    result = result + operand;
                    break;
                case '-':
                    result = result - operand;
                    break;
                case '*':
                    result = result * operand;
                    break;
                case '/':
                    {
                        if (operand == 0)
                        {
                            MessageBox.Show("Divide by zero error!", "Error");
                        }
                        result = result / operand;
                        break;
                    }
                default:
                    MessageBox.Show("The only operators are + - / *", "Error");
                    break;
            }
            return result;
        }

        public double GetResult()
        {
            return result;
        }

        public void OnNumber(double number)
        {
            numbersCount++;
            this.operand = number;
            CalculateResult();
        }
        public void OnOperator(char op)
        {
            this.op = op;
        }
        public char GetOp()
        {
            return op;
        }
        public void OnCancel()
        {
            result = 0;
            numbersCount = 0;
            operand = 0;
            op = '+';
        }
    }
}
