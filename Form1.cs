using System;
using System.Windows.Forms;

namespace RPM1204
{
    public partial class Form1 : Form
    {
        const int ASCENDING_SORT = 0;

        public Form1()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = ASCENDING_SORT;
            button1.Click += Button1_Click;
        }

        private delegate bool CompareNumbers(double num1, double num2);

        private static bool IsGreater(double num1, double num2)
        {
            return num1 > num2;
        }

        private static bool IsLess(double num1, double num2)
        {
            return num1 < num2;
        }

        private void SortNumberArray(double[] array, CompareNumbers compare)
        {
            for (int i = 1; i < array.Length; i++)
            {
                double key = array[i];
                int j = i - 1;
                while (j >= 0 && compare(array[j], key))
                {
                    array[j + 1] = array[j];
                    j -= 1;
                }
                array[j + 1] = key;
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string[] tmp = textBox1.Text.Split('\n');
            double[] array = new double[tmp.Length];
            for (int i = 0; i < tmp.Length; i++)
                double.TryParse(tmp[i], out array[i]);

            CompareNumbers compare;
            if (comboBox1.SelectedIndex == ASCENDING_SORT)
                compare = new CompareNumbers(IsGreater);
            else
                compare = new CompareNumbers(IsLess);

            SortNumberArray(array, compare);

            textBox2.Text = "";
            foreach (double number in array)
                textBox2.Text += $"{number}\r\n";
        }
    }
}
