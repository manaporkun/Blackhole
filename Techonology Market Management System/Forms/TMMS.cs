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
                this.Hide();
            }
            else
            {
                r = null;
            }
        }
    }
}