using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Калькулятор
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            C = new Calc();

            
            textBox1.Text = "0";
        }

        int k;

        Calc C;

        public interface InterfaceCalc
        {
            //а - первый аргумент, b - второй
            void Put_A(double a); //сохранить а

            void Clear_A();

            double Multiplication(double b);

            double Division(double b);

            double Sum(double b);

            double Subtraction(double b); //вычитание            

            double Sqrt();

            double Square();
            
        }

        public class Calc : InterfaceCalc
        {
            private double a = 0;
            private double memory = 0;

            public void Put_A(double a)
            {
                this.a = a;
            }

            public void Clear_A()
            {
                a = 0;
            }

            public double Multiplication(double b)
            {
                return a * b;
            }

            public double Division(double b)
            {
                return a / b;
            }

            public double Sum(double b)
            {
                return a + b;
            }

            public double Subtraction(double b) 
            {
                return a - b;
            }            

            public double Sqrt()
            {
                return Math.Sqrt(a);
            }

            public double Square()
            {
                return Math.Pow(a, 2.0);
            }            

            //стереть содержимое регистра мамяти
            public void Memory_Clear()
            {
                memory = 0.0;
            }            

        }

        private void CorrectNumber()
        {
            //ситуация: слева ноль, а после него НЕ запятая, тогда ноль можно удалить
            if (textBox1.Text[0] == '0' && (textBox1.Text.IndexOf(",") != 1))
                textBox1.Text = textBox1.Text.Remove(0, 1);

            //аналогично предыдущему, только для отрицательного числа
            if (textBox1.Text[0] == '-')
                if (textBox1.Text[1] == '0' && (textBox1.Text.IndexOf(",") != 2))
                    textBox1.Text = textBox1.Text.Remove(1, 1);
        }

        private bool CanPress()
        {
            if (!buttonMult.Enabled)
                return false;

            if (!buttonDiv.Enabled)
                return false;

            if (!buttonPlus.Enabled)
                return false;

            if (!buttonMinus.Enabled)
                return false;
                       
            return true;
        }

        private void FreeButtons()
        {
            buttonMult.Enabled = true;
            buttonDiv.Enabled = true;
            buttonPlus.Enabled = true;
            buttonMinus.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 1;
            CorrectNumber();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 2;
            CorrectNumber();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 3;
            CorrectNumber();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 4;
            CorrectNumber();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 5;
            CorrectNumber();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 6;
            CorrectNumber();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 7;
            CorrectNumber();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 8;
            CorrectNumber();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 9;
            CorrectNumber();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 0;
            CorrectNumber();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.IndexOf(',') == -1)
            {
                textBox1.Text += ",";
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            textBox1.Text = "" + 0;

            C.Clear_A();
            FreeButtons();

            k = 0;
        }

        private void button19_Click(object sender, EventArgs e)
        {
            int lenght = textBox1.Text.Length - 1;
            string text = textBox1.Text;
            textBox1.Text = "";
            for (int i = 0; i < lenght; i++)
            {
                textBox1.Text = textBox1.Text + text[i];
            }

            if (textBox1.Text == "") 
            {
                textBox1.Text = textBox1.Text + 0;
            }

        }

        private void button21_Click(object sender, EventArgs e)
        {
            if (textBox1.Text[0] == '-')
                textBox1.Text = textBox1.Text.Remove(0, 1);
            else
                textBox1.Text = "-" + textBox1.Text;
        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (!buttonMult.Enabled)
                textBox1.Text = C.Multiplication(Convert.ToDouble(textBox1.Text)).ToString();

            if (!buttonDiv.Enabled)
                textBox1.Text = C.Division(Convert.ToDouble(textBox1.Text)).ToString();

            if (!buttonPlus.Enabled)
                textBox1.Text = C.Sum(Convert.ToDouble(textBox1.Text)).ToString();

            if (!buttonMinus.Enabled)
                textBox1.Text = C.Subtraction(Convert.ToDouble(textBox1.Text)).ToString();

            System.Media.SoundPlayer sp = new System.Media.SoundPlayer("Sound.wav");
            //sp.PlayLooping();
            sp.Play();


            C.Clear_A();
            FreeButtons();

            k = 0;
        }

        private void buttonMult_Click(object sender, EventArgs e)
        {
            if (CanPress())
            {
                C.Put_A(Convert.ToDouble(textBox1.Text));

                buttonMult.Enabled = false;

                textBox1.Text = "0";
            }
        }

        private void buttonDiv_Click(object sender, EventArgs e)
        {
            if (CanPress())
            {
                C.Put_A(Convert.ToDouble(textBox1.Text));

                buttonDiv.Enabled = false;

                textBox1.Text = "0";
            }
        }

        private void buttonPlus_Click(object sender, EventArgs e)
        {
            if (CanPress())
            {
                C.Put_A(Convert.ToDouble(textBox1.Text));

                buttonPlus.Enabled = false;

                textBox1.Text = "0";
            }
        }

        private void buttonMinus_Click(object sender, EventArgs e)
        {
            if (CanPress())
            {
                C.Put_A(Convert.ToDouble(textBox1.Text));

                buttonMinus.Enabled = false;

                textBox1.Text = "0";
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (CanPress())
            {
                C.Put_A(Convert.ToDouble(textBox1.Text));

                textBox1.Text = C.Sqrt().ToString();

                C.Clear_A();
                FreeButtons();
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (CanPress())
            {
                C.Put_A(Convert.ToDouble(textBox1.Text));

                textBox1.Text = C.Square().ToString();

                C.Clear_A();
                FreeButtons();
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != ','))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') > -1))
            {
                e.Handled = true;
            }

        }
                
    }
}
