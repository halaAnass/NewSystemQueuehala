namespace NewSystemQueue
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnMM1 = new System.Windows.Forms.Button();
            this.btnMMS = new System.Windows.Forms.Button();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnMM1);
            this.flowLayoutPanel1.Controls.Add(this.btnMMS);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(800, 450);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // btnMM1
            // 
            this.btnMM1.Location = new System.Drawing.Point(3, 3);
            this.btnMM1.Margin = new System.Windows.Forms.Padding(3, 3, 10, 3);
            this.btnMM1.Name = "btnMM1";
            this.btnMM1.Size = new System.Drawing.Size(142, 35);
            this.btnMM1.TabIndex = 0;
            this.btnMM1.Text = "show mm1";
            this.btnMM1.UseVisualStyleBackColor = true;
            this.btnMM1.Click += new System.EventHandler(this.btnMM1_Click);
            // 
            // btnMMS
            // 
            this.btnMMS.Location = new System.Drawing.Point(198, 4);
            this.btnMMS.Name = "btnMMS";
            this.btnMMS.Size = new System.Drawing.Size(142, 35);
            this.btnMMS.TabIndex = 1;
            this.btnMMS.Text = "show M/M/S";
            this.btnMMS.UseVisualStyleBackColor = true;
            this.btnMMS.Click += new System.EventHandler(this.btnMMS_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnMM1;
        private System.Windows.Forms.Button btnMMS;
    }
}

