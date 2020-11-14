using Blackhole.Classes;
using Technology_Market_Management_System.Classes;

namespace Techonology_Market_Management_System.Forms
{
    public partial class Payment : Form
    {
        private static string mail;
        private readonly CartClass cc = new CartClass();
        private DataGridViewButtonColumn col = new DataGridViewButtonColumn();
        private readonly Home home = new Home();
        private Login l;
        private PaymentDelivery pd;
        private int totalPrice = 0;
        private readonly User u = new User();
        private Order order = new Order();

        public Payment()
        {
            InitializeComponent();
            try
            {
                var result = cc.Get(u.GetCustomerByEmail(mail).Rows[0][6].ToString());
                if (result.Rows.Count > 0)
                {
                    var productNumber = cc.Get(u.GetCustomerByEmail(mail).Rows[0][6].ToString()).Rows.Count;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AddButton()
        {
            col = new DataGridViewButtonColumn();
            col.HeaderText = "";
            col.Text = "DELETE";
            col.UseColumnTextForButtonValue = true;
            col.Width = 90;
            col.DefaultCellStyle.ForeColor = Color.WhiteSmoke;
            col.DefaultCellStyle.BackColor = Color.DarkCyan;
            col.FlatStyle = FlatStyle.Flat;
            col.DisplayIndex = dataGridView1.Columns.Count + 1;
            dataGridView1.Columns.Add(col);
        }

        public static void TakeEmail(string userMail)
        {
            mail = userMail;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            home.Show();
            //this.Hide();
            Close();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (l == null)
            {
                l = new Login();
                l.Show();
                Close();
            }
            else
            {
                l = null;
            }
        }

        private void cart_Click(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                if (pd != null)
                {
                    pd = null;
                }
                else
                {
                    pd = new PaymentDelivery();
                    pd.Show();
                    Close();
                }
            }
            else
            {
                label5.Text = "You need to add product to continue.";
            }
        }

        private void Payment_Load(object sender, EventArgs e)
        {
            try
            {
                //label2.Text = mail;
                dataGridView1.Columns.Clear();
                dataGridView1.DataSource = cc.Get(u.GetCustomerByEmail(mail).Rows[0][6].ToString());
                AddButton();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show(u.GetCustomerByEmail(mail).Rows[0][6].ToString());
            }
        }

        private void total_Click(object sender, EventArgs e)
        {
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == dataGridView1.Columns.Count - 1 && e.RowIndex >= 0)
                {
                    var name = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                    var phonenumber = u.GetCustomerByEmail(mail).Rows[0][6].ToString();
                    var userId = int.Parse(u.GetCustomerByEmail(mail).Rows[0][0].ToString());

                    if (cc.GetByName(phonenumber, name).Rows.Count > 0)
                    {
                        var piece = int.Parse(cc.GetByName(phonenumber, name).Rows[0][2].ToString());
                        if (piece > 1)
                        {
                            cc.UpdatePiece(piece - 1, name, phonenumber);
                            order.UpdatePiece(piece - 1, name, userId);
                        }
                        else
                        {
                            cc.Delete(phonenumber, name);
                            order.Delete(userId, name);
                        }

                    }

                    Payment_Load(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}