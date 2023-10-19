namespace Interface
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txbx_poli = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_filndRoots = new System.Windows.Forms.Button();
            this.btn_calc = new System.Windows.Forms.Button();
            this.btn_pow = new System.Windows.Forms.Button();
            this.btn_divC = new System.Windows.Forms.Button();
            this.btn_multC = new System.Windows.Forms.Button();
            this.btn_subC = new System.Windows.Forms.Button();
            this.btn_addC = new System.Windows.Forms.Button();
            this.txbx_c = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_modP = new System.Windows.Forms.Button();
            this.btn_divP = new System.Windows.Forms.Button();
            this.btn_mulP = new System.Windows.Forms.Button();
            this.btn_subP = new System.Windows.Forms.Button();
            this.btn_addP = new System.Windows.Forms.Button();
            this.txbx_otherPoli = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txbx_res = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(367, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(174, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Проект полином";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(12, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(183, 26);
            this.label2.TabIndex = 1;
            this.label2.Text = "Введите полином";
            // 
            // txbx_poli
            // 
            this.txbx_poli.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txbx_poli.Location = new System.Drawing.Point(201, 56);
            this.txbx_poli.Name = "txbx_poli";
            this.txbx_poli.Size = new System.Drawing.Size(829, 34);
            this.txbx_poli.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_filndRoots);
            this.groupBox1.Controls.Add(this.btn_calc);
            this.groupBox1.Controls.Add(this.btn_pow);
            this.groupBox1.Controls.Add(this.btn_divC);
            this.groupBox1.Controls.Add(this.btn_multC);
            this.groupBox1.Controls.Add(this.btn_subC);
            this.groupBox1.Controls.Add(this.btn_addC);
            this.groupBox1.Controls.Add(this.txbx_c);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.Location = new System.Drawing.Point(15, 107);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(518, 345);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Действия, требующие второе число";
            // 
            // btn_filndRoots
            // 
            this.btn_filndRoots.Location = new System.Drawing.Point(4, 296);
            this.btn_filndRoots.Name = "btn_filndRoots";
            this.btn_filndRoots.Size = new System.Drawing.Size(508, 36);
            this.btn_filndRoots.TabIndex = 16;
            this.btn_filndRoots.Text = "Найти корни";
            this.btn_filndRoots.UseVisualStyleBackColor = true;
            this.btn_filndRoots.Visible = false;
            this.btn_filndRoots.Click += new System.EventHandler(this.btn_filndRoots_Click);
            // 
            // btn_calc
            // 
            this.btn_calc.Location = new System.Drawing.Point(6, 254);
            this.btn_calc.Name = "btn_calc";
            this.btn_calc.Size = new System.Drawing.Size(506, 36);
            this.btn_calc.TabIndex = 15;
            this.btn_calc.Text = "Вычислить в точке";
            this.btn_calc.UseVisualStyleBackColor = true;
            this.btn_calc.Click += new System.EventHandler(this.btn_calc_Click);
            // 
            // btn_pow
            // 
            this.btn_pow.Location = new System.Drawing.Point(6, 212);
            this.btn_pow.Name = "btn_pow";
            this.btn_pow.Size = new System.Drawing.Size(506, 36);
            this.btn_pow.TabIndex = 10;
            this.btn_pow.Text = "Возвести в степень";
            this.btn_pow.UseVisualStyleBackColor = true;
            this.btn_pow.Click += new System.EventHandler(this.btn_pow_Click);
            // 
            // btn_divC
            // 
            this.btn_divC.Location = new System.Drawing.Point(309, 170);
            this.btn_divC.Name = "btn_divC";
            this.btn_divC.Size = new System.Drawing.Size(203, 36);
            this.btn_divC.TabIndex = 14;
            this.btn_divC.Text = "Разделить";
            this.btn_divC.UseVisualStyleBackColor = true;
            this.btn_divC.Click += new System.EventHandler(this.btn_divC_Click);
            // 
            // btn_multC
            // 
            this.btn_multC.Location = new System.Drawing.Point(6, 170);
            this.btn_multC.Name = "btn_multC";
            this.btn_multC.Size = new System.Drawing.Size(203, 36);
            this.btn_multC.TabIndex = 13;
            this.btn_multC.Text = "Умножить";
            this.btn_multC.UseVisualStyleBackColor = true;
            this.btn_multC.Click += new System.EventHandler(this.btn_multC_Click);
            // 
            // btn_subC
            // 
            this.btn_subC.Location = new System.Drawing.Point(309, 128);
            this.btn_subC.Name = "btn_subC";
            this.btn_subC.Size = new System.Drawing.Size(203, 36);
            this.btn_subC.TabIndex = 12;
            this.btn_subC.Text = "Вычесть";
            this.btn_subC.UseVisualStyleBackColor = true;
            this.btn_subC.Click += new System.EventHandler(this.btn_subC_Click);
            // 
            // btn_addC
            // 
            this.btn_addC.Location = new System.Drawing.Point(6, 128);
            this.btn_addC.Name = "btn_addC";
            this.btn_addC.Size = new System.Drawing.Size(203, 36);
            this.btn_addC.TabIndex = 11;
            this.btn_addC.Text = "Добавить";
            this.btn_addC.UseVisualStyleBackColor = true;
            this.btn_addC.Click += new System.EventHandler(this.btn_addC_Click);
            // 
            // txbx_c
            // 
            this.txbx_c.Location = new System.Drawing.Point(6, 71);
            this.txbx_c.Name = "txbx_c";
            this.txbx_c.Size = new System.Drawing.Size(428, 34);
            this.txbx_c.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(154, 26);
            this.label5.TabIndex = 9;
            this.label5.Text = "Введите число";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_modP);
            this.groupBox2.Controls.Add(this.btn_divP);
            this.groupBox2.Controls.Add(this.btn_mulP);
            this.groupBox2.Controls.Add(this.btn_subP);
            this.groupBox2.Controls.Add(this.btn_addP);
            this.groupBox2.Controls.Add(this.txbx_otherPoli);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox2.Location = new System.Drawing.Point(539, 107);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(491, 345);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Действия, требующие второй полином";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // btn_modP
            // 
            this.btn_modP.Location = new System.Drawing.Point(6, 212);
            this.btn_modP.Name = "btn_modP";
            this.btn_modP.Size = new System.Drawing.Size(479, 36);
            this.btn_modP.TabIndex = 9;
            this.btn_modP.Text = "Найти остаток от деления";
            this.btn_modP.UseVisualStyleBackColor = true;
            this.btn_modP.Click += new System.EventHandler(this.btn_modP_Click);
            // 
            // btn_divP
            // 
            this.btn_divP.Location = new System.Drawing.Point(282, 170);
            this.btn_divP.Name = "btn_divP";
            this.btn_divP.Size = new System.Drawing.Size(203, 36);
            this.btn_divP.TabIndex = 8;
            this.btn_divP.Text = "Разделить";
            this.btn_divP.UseVisualStyleBackColor = true;
            this.btn_divP.Click += new System.EventHandler(this.btn_divP_Click);
            // 
            // btn_mulP
            // 
            this.btn_mulP.Location = new System.Drawing.Point(6, 170);
            this.btn_mulP.Name = "btn_mulP";
            this.btn_mulP.Size = new System.Drawing.Size(203, 36);
            this.btn_mulP.TabIndex = 7;
            this.btn_mulP.Text = "Умножить";
            this.btn_mulP.UseVisualStyleBackColor = true;
            this.btn_mulP.Click += new System.EventHandler(this.btn_mulP_Click);
            // 
            // btn_subP
            // 
            this.btn_subP.Location = new System.Drawing.Point(282, 128);
            this.btn_subP.Name = "btn_subP";
            this.btn_subP.Size = new System.Drawing.Size(203, 36);
            this.btn_subP.TabIndex = 6;
            this.btn_subP.Text = "Вычесть";
            this.btn_subP.UseVisualStyleBackColor = true;
            this.btn_subP.Click += new System.EventHandler(this.btn_subP_Click);
            // 
            // btn_addP
            // 
            this.btn_addP.Location = new System.Drawing.Point(6, 128);
            this.btn_addP.Name = "btn_addP";
            this.btn_addP.Size = new System.Drawing.Size(203, 36);
            this.btn_addP.TabIndex = 5;
            this.btn_addP.Text = "Добавить";
            this.btn_addP.UseVisualStyleBackColor = true;
            this.btn_addP.Click += new System.EventHandler(this.btn_addP_Click);
            // 
            // txbx_otherPoli
            // 
            this.txbx_otherPoli.Location = new System.Drawing.Point(6, 71);
            this.txbx_otherPoli.Name = "txbx_otherPoli";
            this.txbx_otherPoli.Size = new System.Drawing.Size(479, 34);
            this.txbx_otherPoli.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(183, 26);
            this.label3.TabIndex = 3;
            this.label3.Text = "Введите полином";
            // 
            // txbx_res
            // 
            this.txbx_res.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txbx_res.Location = new System.Drawing.Point(128, 458);
            this.txbx_res.Multiline = true;
            this.txbx_res.Name = "txbx_res";
            this.txbx_res.Size = new System.Drawing.Size(902, 106);
            this.txbx_res.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(12, 455);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 26);
            this.label4.TabIndex = 12;
            this.label4.Text = "Результат";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1042, 583);
            this.Controls.Add(this.txbx_res);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txbx_poli);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txbx_poli;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Button btn_addP;
        private TextBox txbx_otherPoli;
        private Label label3;
        private Button btn_filndRoots;
        private Button btn_calc;
        private Button btn_pow;
        private Button btn_divC;
        private Button btn_multC;
        private Button btn_subC;
        private Button btn_addC;
        private TextBox txbx_c;
        private Label label5;
        private Button btn_modP;
        private Button btn_divP;
        private Button btn_mulP;
        private Button btn_subP;
        private TextBox txbx_res;
        private Label label4;
        private ErrorProvider errorProvider1;
    }
}