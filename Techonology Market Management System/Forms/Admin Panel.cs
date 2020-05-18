using System;
using System.Windows.Forms;
using Blackhole.Forms;
using Techonology_Market_Management_System.Forms;

namespace Techonology_Market_Management_System
{
    public partial class AdminPanel : DevExpress.XtraEditors.XtraForm
    {
        private EditEmployees _editEmployees;
        private Edit_MusicBook _editMusicBook;
        private Edit_Product _editProduct;
        private Edit_SmartPhones _editSmartPhones;
        private EditUsers _editUsers;
        private TMMS _tMms;

        public AdminPanel()
        {
            InitializeComponent();
        }

        private void Admin_Panel_Load(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (_tMms == null)
            {
                TMMS.ChangeWindowsState(1);
                Close();
            }
            else
            {
                _tMms = null;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            pictureBox1_Click(sender, e);
            Close();
        }

        private void tbUsers_Click(object sender, EventArgs e)
        {
            if (_editUsers == null)
            {
                _editUsers = new EditUsers();
                this.Close();
                _editUsers.Show();
            }
            else
            {
                _editUsers = null;
            }
        }

        private void tbComputers_Click(object sender, EventArgs e)
        {
            if (_editProduct == null)
            {
                _editProduct = new Edit_Product();
                this.Close();
                _editProduct.Show();
            }
            else
            {
                _editProduct = null;
            }
        }

        private void tbAdmins_Click(object sender, EventArgs e)
        {
            if (_editEmployees == null)
            {
                _editEmployees = new EditEmployees();
                this.Close();
                _editEmployees.Show();
            }
            else
            {
                _editEmployees = null;
            }
        }

        private void tbSmartphones_Click(object sender, EventArgs e)
        {
            if (_editSmartPhones == null)
            {
                _editSmartPhones = new Edit_SmartPhones();
                this.Close();
                _editSmartPhones.Show();
            }
            else
            {
                _editSmartPhones = null;
            }
        }

        private void tbMusicBook_Click(object sender, EventArgs e)
        {
            if (_editMusicBook == null)
            {
                _editMusicBook = new Edit_MusicBook();
                this.Close();
                _editMusicBook.Show();
            }
            else
            {
                _editMusicBook = null;
            }
        }
    }
}