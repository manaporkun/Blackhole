using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SQLite;

namespace Techonology_Market_Management_System
{
    public partial class Home : Form
    {
        Login l = null;
        Register r = null;
        Search s = null;
        PaymentDelivery p = null;
        public Home()
        {
            InitializeComponent();
            SQLiteConnection con = new SQLiteConnection(@"Data Source=D:\Dev\C# Projects\Technology Market Management System\Database.db;");
            string query = "SELECT * from Computer";
            SQLiteCommand cmd = new SQLiteCommand(query, con);

            DataTable dt = new DataTable();
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);
            adapter.Fill(dt);

            dataGridView1.DataSource = dt;

        }

        private void InitializeComponent()
        {
            throw new NotImplementedException();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void bLogin_Click(object sender, EventArgs e)
        {
            if (l == null)
                l = new Login();
            
            l.Show();
                   

        }

        private void bRegister_Click(object sender, EventArgs e)
        {
            if (r == null)
                r = new Register();

            r.Show();
        }

        private void imgSearch_Click(object sender, EventArgs e)
        {
            
            if (s == null)
                s = new Search();
            s.Show();
          
        }

        private void bCart_Click(object sender, EventArgs e)
        {
            if (p == null)
                p = new PaymentDelivery();
            p.Show();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}
