using System.Windows.Forms;

namespace Techonology_Market_Management_System.Forms
{
    public partial class TMMS : Form
    {
        Login l = null;
        Register r = null;
        public TMMS()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, System.EventArgs e)
        {

        }



        private void label1_Click_1(object sender, System.EventArgs e)
        {
            this.Close();
            
        }

        private void button1_Click_1(object sender, System.EventArgs e)
        {
            if (r == null)
            {
                r = new Register();
                r.Show();
                // this.Hide();
                this.WindowState = FormWindowState.Minimized;
            }
            else
            {
                r = null;
            }
        }

        public static void ChangeWindowsState(int state)
        {
            switch (state){
                case 1:
                    TMMS.ActiveForm.Show();
                    break;
                case 2:
                    TMMS.ActiveForm.WindowState = FormWindowState.Normal;
                    break;
                default:
                    break;

            }
        }
    }
}