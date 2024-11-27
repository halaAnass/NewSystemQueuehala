using NewSystemQueue.Helper;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace NewSystemQueue.View
{

    public partial class MMSQueue : Form
    {

        double mhoMMS;
        double lambdaMMS;
        double rhoMMS;
        double p0MMS;
        double pnMMS;
        public MMSQueue()
        {
            InitializeComponent();
            ApplayAcceptOnlyNumberInTextBox();
            SetDefualtValue();
        }

        private void SetDefualtValue()
        {
            mhoMMS = -1;
            lambdaMMS = -1;
            rhoMMS = -1;
            p0MMS = -1;
        }
        private void ApplayAcceptOnlyNumberInTextBox()
        {
            foreach (Control control in this.Controls)
            {
                if (control is TextBox textBox)
                {
                    textBox.KeyPress += InputHelper.HandleNumericInput;
                }
            }
        }
        private void btnCalcP0_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsFillData(txtServicesCount, txtMho, txtLambda))
                {
                    ///for student write complete  exception
                    lblMMSReultP0.Text = string.Empty;
                    mhoMMS = Convert.ToDouble(txtMho.Text);
                    lambdaMMS = Convert.ToDouble(txtLambda.Text);
                    //عدد المخدمات
                    int servicesCount = Convert.ToInt32(txtServicesCount.Text);
                    double rateOfServices = mhoMMS * servicesCount;
                    rhoMMS = lambdaMMS / rateOfServices;
                    p0MMS = CalcP0(servicesCount, rhoMMS);
                    p0MMS = p0MMS * 100;


                    txtP0.Text = p0MMS.ToString("F2") + "%";
                }
            }
            catch (Exception ex)
            {
                
                    MessageBox.Show(ex.Message);
                 
            }
        }

        private bool IsFillData(params TextBox[] texts)
        {
            foreach (TextBox textBox in texts)
            {

                if (textBox.Text.Trim()=="")
                {
                    textBox.BackColor = Color.Red;
                    textBox.ForeColor = Color.White;
                    textBox.Focus();
                    MessageBox.Show("قم بتعبئة جميع القيم");
                    return false;
                }

            }
            return true;
        }

        private double CalcP0(int servicesCount, double rhoMMS)
        {
            double firstSecation = 0;
            for (int x = 0; x <= servicesCount - 1; x++)
            {
                firstSecation = firstSecation
                        + (Math.Pow(servicesCount * rhoMMS, x) / Fact(x));
            }
            double secoundSecation = (Math.Pow(servicesCount * rhoMMS, servicesCount)
                            / (Fact(servicesCount) * (1 - rhoMMS)));
            double result = firstSecation + secoundSecation;

            return 1 / result;
        }
        private static long Fact(int number)
        {
            long factResult = 1;
            for (int i = number; i > 1; i--)
            {
                factResult = factResult * i;
            }
            return factResult;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            namespace QueueSystemGUI

    }{
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }

            // زر حساب Pn
            private void btnPn_Click(object sender, EventArgs e)
            {
                try
                {
                    // قراءة المدخلات
                    double lambda = double.Parse(txtLambda.Text); // معدل الوصول
                    double mu = double.Parse(txtMu.Text);        // معدل الخدمة
                    int s = int.Parse(txtS.Text);                // عدد القنوات
                    int n = int.Parse(txtn.Text);                // عدد العملاء
                    int pn = int.Parse(txtpn.Text);

                    // التحقق من القيم
                    if (lambda <= 0 || mu <= 0 || s <= 0 || n < 0)
                    {
                        MessageBox.Show("تأكد من إدخال قيم صحيحة موجبة.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // حساب rho
                    double rho = lambda / (s * mu);

                    // التحقق من استقرار النظام
                    if (rho >= 1)
                    {
                        MessageBox.Show("النظام غير مستقر، تأكد من أن معدل الوصول أقل من معدل الخدمة.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // حساب P0
                    double P0 = CalculateP0(lambda, mu, s, rho);

                    // حساب Pn
                    double Pn = CalculatePn(lambda, mu, s, n, P0);

                    // عرض الناتج في مربع النص
                    txtPn.Text = Pn.ToString("F4");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"حدث خطأ: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            // حساب P0
            private double CalculateP0(double lambda, double mu, int s, double rho)
            {
                double sum = 0;

                // الجزء الأول: n = 0 إلى s-1
                for (int n = 0; n < s; n++)
                {
                    sum += Math.Pow(lambda / mu, n) / Factorial(n);
                }

                // الجزء الثاني: n = s
                sum += (Math.Pow(lambda / mu, s) / Factorial(s)) / (1 - rho);

                // إرجاع معكوس المجموع
                return 1 / sum;
            }

            // حساب Pn
            private double CalculatePn(double lambda, double mu, int s, int n, double P0)
            {
                if (n < s)
                {
                    // إذا كان n < s
                    return (Math.Pow(lambda / mu, n) / Factorial(n)) * P0;
                }
                else
                {
                    // إذا كان n >= s
                    return (Math.Pow(lambda / mu, n) / (Factorial(s) * Math.Pow(s, n - s))) * P0;
                }
            }

            // دالة حساب المضروب
            private double Factorial(int n)
            {
                if (n == 0 || n == 1) return 1;

                double fact = 1;
                for (int i = 2; i <= n; i++)
                {
                    fact *= i;
                }
                return fact;
            }
        }
    }
}
