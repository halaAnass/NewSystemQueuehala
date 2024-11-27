using NewSystemQueue.View;
using System;
using System.Windows.Forms;

namespace NewSystemQueue
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnMM1_Click(object sender, EventArgs e)
        {
            MM1Queue mM1Queue = new MM1Queue();
              mM1Queue.ShowDialog();
        }

        private void btnMMS_Click(object sender, EventArgs e)
        {
            MMSQueue mMSQueue = new MMSQueue();
            mMSQueue.ShowDialog();
        }
    }
}
