using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculators
{
    public partial class Operate : Form
    {
        public Operate()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
        }

        

        private void Calculate_Click(object sender, EventArgs e)
        {
            String s1 = firstNumber.Text;
            String s2 = secondNumber.Text;
            double ret = 0;
            try
            {
                double a = Convert.ToDouble(s1);
                double b = Convert.ToDouble(s2);
                switch (comboBox1.Text)
                {
                    case "+":ret = a + b;break;
                    case "-":ret = a - b;break;
                    case "*":ret = a * b;break;
                    case "/": if (b == 0)
                        {
                            result.Text="math error";
                            return;
                        }
                        ret = a / b;break;
                    default:result.Text="operator error";return;
                }
                result.Text = Convert.ToString(ret);
            }
            catch (FormatException)
            {
                result.Text="Format error";
                return;
            }
            catch(OverflowException)
            {
                result.Text="Overflow error";
                return;
            }
        }
    }
}
