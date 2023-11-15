using Polinom;
namespace Interface
{
    public partial class Form1 : Form
    {
        RootedPolinomyal cur, other;
        double constant;
        string res;
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_addP_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            try
            {
                cur = RootedPolinomyal.Parse(txbx_poli.Text);
                other = RootedPolinomyal.Parse(txbx_otherPoli.Text);
                txbx_res.Text = (cur + other).ToString();
            }
            catch
            {
                errorProvider1.SetError(btn_addP, "Парсинг невозможен");
            }
        }

        private void btn_subP_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            try
            {
                cur = RootedPolinomyal.Parse(txbx_poli.Text);
                other = RootedPolinomyal.Parse(txbx_otherPoli.Text);

                txbx_res.Text = (cur - other).ToString();
            }
            catch
            {
                errorProvider1.SetError(btn_subP, "Парсинг невозможен");
            }
        }

        private void btn_mulP_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            try
            {
                cur = RootedPolinomyal.Parse(txbx_poli.Text);
                other = RootedPolinomyal.Parse(txbx_otherPoli.Text);

                txbx_res.Text = (cur * other).ToString();
            }
            catch
            {
                errorProvider1.SetError(btn_mulP, "Парсинг невозможен");
            }
        }

        private void btn_divP_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            try
            {
                cur = RootedPolinomyal.Parse(txbx_poli.Text);
                other = RootedPolinomyal.Parse(txbx_otherPoli.Text);

                txbx_res.Text = (cur / other).ToString();
            }
            catch
            {
                errorProvider1.SetError(btn_divP, "Парсинг невозможен");
            }
        }

        private void btn_modP_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            try
            {
                cur = RootedPolinomyal.Parse(txbx_poli.Text);
                other = RootedPolinomyal.Parse(txbx_otherPoli.Text);

                Polinomyal res = cur % other;
                if (!res.IsZero())
                {
                    txbx_res.Text = "[" + (cur % other).ToString()
                        + "] / [" + other + "]";
                } else
                {
                    txbx_res.Text = "0";
                }
            }
            catch
            {
                errorProvider1.SetError(btn_modP, "Парсинг невозможен");
            }
        }

        private void btn_addC_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            try
            {
                cur = RootedPolinomyal.Parse(txbx_poli.Text);
                constant = double.Parse(txbx_c.Text);

                txbx_res.Text = (cur + constant).ToString();
            }
            catch
            {
                errorProvider1.SetError(btn_addC, "Парсинг невозможен");
            }
        }

        private void btn_subC_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            try
            {
                cur = RootedPolinomyal.Parse(txbx_poli.Text);
                constant = double.Parse(txbx_c.Text);

                txbx_res.Text = (cur - constant).ToString();
            }
            catch
            {
                errorProvider1.SetError(btn_subC, "Парсинг невозможен");
            }
        }

        private void btn_multC_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            try
            {
                cur = RootedPolinomyal.Parse(txbx_poli.Text);
                constant = double.Parse(txbx_c.Text);

                txbx_res.Text = (cur * constant).ToString();
            }
            catch
            {
                errorProvider1.SetError(btn_multC, "Парсинг невозможен");
            }
        }

        private void btn_divC_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            try
            {
                cur = RootedPolinomyal.Parse(txbx_poli.Text);
                constant = double.Parse(txbx_c.Text);

                txbx_res.Text = (cur / constant).ToString();
            }
            catch
            {
                errorProvider1.SetError(btn_divC, "Парсинг невозможен");
            }
        }

        private void btn_pow_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            try
            {
                cur = RootedPolinomyal.Parse(txbx_poli.Text);
                constant = int.Parse(txbx_c.Text);

                txbx_res.Text = (cur.Pow((int)constant)).ToString();
            }
            catch
            {
                errorProvider1.SetError(btn_pow, "Парсинг невозможен");
            }
        }

        private void btn_calc_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            try
            {
                cur = RootedPolinomyal.Parse(txbx_poli.Text);
                constant = double.Parse(txbx_c.Text);

                double res = cur.CalculateAt(constant);
                txbx_res.Text = res.ToString();
            }
            catch
            {
                errorProvider1.SetError(btn_calc, "Парсинг невозможен");
            }
        }

        private void btn_filndRoots_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            txbx_res.Text = "";
            try
            {
                cur = RootedPolinomyal.Parse(txbx_poli.Text);

                double[] roots = cur.GetRoots();
                for (int i = 0; i < roots.Length; i++)
                    txbx_res.Text += (roots[i] + " ");
            }
            catch
            {
                errorProvider1.SetError(btn_filndRoots, "Парсинг невозможен");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            txbx_res.Text = "";
            try
            {
                cur = RootedPolinomyal.Parse(txbx_poli.Text);

                double[] roots = cur.FindExtremePoint();
                for (int i = 0; i < roots.Length; i++)
                    txbx_res.Text += (roots[i] + " ");
            }
            catch
            {
                errorProvider1.SetError(btn_filndRoots, "Парсинг невозможен");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            txbx_res.Text = "";
            try
            {
                string[] roots = textBox1.Text.Split(' ');
                double[] factRoots = new double[roots.Length];
                for(int i = 0; i < roots.Length; i++)
                    factRoots[i] = Convert.ToDouble(roots[i]);

                txbx_res.Text = RootedPolinomyal.ConstructFromRoots(factRoots).ToString();
            }
            catch
            {
                errorProvider1.SetError(btn_filndRoots, "Парсинг невозможен");
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}