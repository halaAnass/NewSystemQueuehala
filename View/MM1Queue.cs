using ExteanstionExceaption;
using NewSystemQueue.Helper;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace NewSystemQueue.View
{
    public partial class MM1Queue : Form
    {
        private double rho;
        private double p0;

        public MM1Queue()
        {
            InitializeComponent();
            SetDefulatPropForMM1();
            ApplayAcceptOnlyNumberInTextBox();
            SetDefulatValue();
        }
        /// <summary>
        /// to reset value to defualt value 
        /// </summary>
        private void SetDefulatValue()
        {
            rho = -1;
            p0 = -1;
        }
        private void SetDefulatPropForMM1()
        {
            txtLs.ReadOnly = true;
            txtLq.ReadOnly = true;
            txtWs.ReadOnly = true;
            txtWq.ReadOnly = true;
            txtRho.ReadOnly = true;
            txtP0.ReadOnly = true;
        }
        /// <summary>
        /// applay event into all text box inside control
        /// </summary>
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
        private void btnCalcRho_Click(object sender, EventArgs e)
        {
            try
            {
                double lambda = double.Parse(txtLambda.Text);
                double mu = double.Parse(txtMho.Text);
                if (mu == 0)
                {

                    throw new DivideByZeroException("لا يمكن ان تكون ميو صفر");
                }
                if (mu <= lambda)
                {
                    throw new SystemUnstableException("لا يمكن ان تكون متساوية القيم");
                }
                rho = lambda / mu;
                txtRho.Text =( rho * 100).ToString("F0") + "%";


            }
            catch (Exception ex)
            {
                if (ex is FormatException)
                    MessageBox.Show("تأكد من إدخال قيم صحيحة للمدخلات.");
                else if (ex is DivideByZeroException)
                {
                    txtMho.BackColor = Color.Red;
                    MessageBox.Show(ex.Message);
                }
                else
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void CalcPerformance_Click(object sender, EventArgs e)
        {
            try
            {
                double lambda = double.Parse(txtLambda.Text);
                double mu = double.Parse(txtMho.Text);

                if (lambda >= mu)
                {
                    MessageBox.Show("النظام غير مستقر. تأكد من أن معدل الوصول أقل من معدل الخدمة.");

                    return;
                }

                double rho = lambda / mu;

                double L = rho / (1 - rho);
                double Lq = Math.Pow(rho, 2) / (1 - rho);
                double W = 1 / (mu - lambda);
                double Wq = rho / (mu - lambda);

                txtLs.Text = (L * 100).ToString("F0") + "%"; 
                txtLq.Text = (Lq * 100).ToString("F0") + "%";
                txtWs.Text = (W * 100).ToString("F0") + "%";
                txtWq.Text = (Wq * 100).ToString("F0") + "%";

            }
            catch (FormatException)
            {
                MessageBox.Show("تأكد من إدخال قيم صحيحة للمدخلات.");
            }
        }

        private void calcMM1P0_Click(object sender, EventArgs e)
        {
            try
            {
                if (rho == -1)
                {
                    //Replace Exception with Error like down 👇🏻
                    throw new Exception("the rho is Negtive");
                }
                p0 = (1 - rho);
                txtP0.Text = (p0 * 100) + "%".ToString();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);

            }
        }

        private void btnCalcPn_Click(object sender, EventArgs e)
        {
            try
            {
                if (rho == -1)
                {
                    MessageBox.Show("Please Clac Rho before clac Pn");
                    btnCalcRho.Focus();
                    return;
                }
                if (p0 == -1)
                {
                    MessageBox.Show("Please Clac P0 before clac Pn");
                    btnCalcP0.Focus();
                    txtP0.Focus();
                    return;
                }
                //check if n is integer number and value > 0
                if (string.IsNullOrEmpty(txtN.Text) || !int.TryParse(txtN.Text, out int n) || n <= 0)
                {
                    MessageBox.Show("Please enter a valid integer value for n greater than zero");
                    txtN.Focus();
                    return;
                }
                double pn = Math.Pow(rho, n) * p0;
                txtPn.Text = (pn * 100) + "%".ToString();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);

            }
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            //This is hepler
            ClearTextBoxText.ClearText(this);
            SetDefulatValue();
        }

    }
}
