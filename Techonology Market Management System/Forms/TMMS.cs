namespace Techonology_Market_Management_System.Forms
{
    public partial class TMMS : Form
    {
        private Login l = null;
        private Register r;

        public TMMS()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void label1_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (r == null)
            {
                r = new Register();
                r.Show();
                // this.Hide();
                WindowState = FormWindowState.Minimized;
            }
            else
            {
                r = null;
            }
        }

        public static void ChangeWindowsState(int state)
        {
            switch (state)
            {
                case 1:
                    ActiveForm.Show();
                    break;

                case 2:
                    ActiveForm.WindowState = FormWindowState.Normal;
                    break;
            }
        }
    }
}