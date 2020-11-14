using Technology_Market_Management_System.Classes;

namespace Techonology_Market_Management_System.Forms
{
    public partial class ForgotPassword : Form
    {
        private Login login = new Login();
        private string mail;
        private bool newAccount;
        private readonly User u = new User();

        public ForgotPassword()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            login = new Login();
            login.Show();
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var question_index = comboBox1.SelectedIndex;
            var answer = textBox1.Text;

            if (newAccount)
            {
                var result = u.UpdateQuestion(question_index, answer, mail);

                if (result > 0)
                {
                    label4.Text = "Succesful";
                    label4.ForeColor = Color.Green;
                }
                else
                {
                    label4.Text = "Error";
                    label4.ForeColor = Color.Red;
                }
            }
            else
            {
                var result = u.GetCustomerByEmail(mail);

                if (result.Rows.Count < 1)
                {
                    label4.Text = "Please enter mail correctly on the main screen.";
                }
                else
                {
                    var index = int.Parse(u.GetCustomerByEmail(mail).Rows[0][7].ToString());
                    var answ = u.GetCustomerByEmail(mail).Rows[0][8].ToString();

                    if (question_index == index && answer == answ)
                        label4.Text = u.GetCustomerByEmail(mail).Rows[0][4].ToString();
                    else
                        label4.Text = "Please try again.";
                }
            }
        }

        public void isNew(string email)
        {
            newAccount = true;
            mail = email;
        }

        public void notNew(string email)
        {
            newAccount = false;
            mail = email;
        }

        private void ForgotPassword_Load(object sender, EventArgs e)
        {
            label4.Text = "";
        }
    }
}