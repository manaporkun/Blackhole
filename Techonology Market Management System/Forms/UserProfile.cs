using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Blackhole.Classes;
using Technology_Market_Management_System.Classes;
using Techonology_Market_Management_System.Forms;

namespace Blackhole.Forms
{
    public partial class UserProfile : Form
    {

        private string _email;
        private Home h;

        public UserProfile()
        {
            InitializeComponent();
        }

        private void UserProfile_Load(object sender, EventArgs e)
        {
            lbError.Text = string.Empty;
            CommonFunctions.SetUserDetails(_email,tName,tSurname,tEmail,tPassword,tAdress,maskedTextBox1,dateTimePicker1,rbMale,rbFemale);
        }

        public void TakeEmail(string e)
        {
            _email = e;
        }


        private void lbClose_Click(object sender, EventArgs e)
        {
            if (h == null)
            {
                h = new Home();
                h.Show();
                this.Close();

                //UserInformations.TakeEmail(email);
            }
            else
            {
                h = null;
            }
        }
    }
}
