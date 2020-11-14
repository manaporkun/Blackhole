using Blackhole.Classes;
using Technology_Market_Management_System.Classes;
using Techonology_Market_Management_System.Forms;

namespace Techonology_Market_Management_System
{
    public partial class PaymentDelivery : Form
    {
        private static string email;
        private static int numberProduct;
        private readonly CartClass cc = new CartClass();
        private readonly Home home = new Home();
        private string phonenumber;
        private readonly Product product = new Product();
        private readonly User u = new User();
        private readonly Order order = new Order();

        public PaymentDelivery()
        {
            InitializeComponent();
            label12.Text = "";
        }

        public static void TakeEmail(string mail)
        {
            email = mail;
        }

        private void bRegister_Click(object sender, EventArgs e)
        {

            var name1 = tName.Text.Trim();
            var card_number = maskedTextBox1.Text.Trim();
            var expire_date = maskedTextBox2.Text.Trim();
            var ccv = maskedTextBox3.Text.Trim();

            if (name1.Length == 0 || card_number.Length != 14 || expire_date.Length != 5 || ccv.Length != 3)
            {
                label12.Text = "Please enter informations correctly";
            }
            else
            {
                if (dataGridView1.Rows.Count < 1) return;

                for (var i = 0; i < dataGridView1.RowCount; i++)
                {
                    var name = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    var category = dataGridView1.Rows[i].Cells[3].Value.ToString();
                    var number = int.Parse(dataGridView1.Rows[i].Cells[2].Value.ToString());
                    var current_stock = int.Parse(product.GetByName(name, category).Rows[0][3].ToString());

                    product.UpdatePiece(name, current_stock - number, category);
                }

                MessageBox.Show("Your order has been received. Thank you");

                var user_id = int.Parse(u.GetCustomerByEmail(email).Rows[0][0].ToString());

                for (var i = 0; i < dataGridView1.RowCount; i++)
                {
                    var name = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    order.UpdateStatus(name, user_id);
                    order.UpdateAddress(u.GetCustomerByEmail(email).Rows[0][5].ToString(), user_id);
                    cc.Delete(phonenumber, name);
                }

                //this.Visible = false;
                printPreviewDialog1.Document = printDocument1;
                printPreviewDialog1.ShowDialog();
                //this.Visible = true;

                PaymentDelivery_Load(sender, e);
                label12.Text = "";
            }

            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void PaymentDelivery_Load(object sender, EventArgs e)
        {
            phonenumber = u.GetCustomerByEmail(email).Rows[0][6].ToString();
            dataGridView1.DataSource = cc.Get(u.GetCustomerByEmail(email).Rows[0][6].ToString());
            label7.Text = cc.Get(u.GetCustomerByEmail(email).Rows[0][6].ToString()).Rows.Count.ToString();
            label4.Text = u.GetCustomerByEmail(email).Rows[0][5].ToString();
            //MessageBox.Show(dataGridView1.Rows[0].Cells[0].Value.ToString());
        }

        public static void TakeNumberProduct(int number)
        {
            numberProduct = number;
        }

        private void label11_Click(object sender, EventArgs e)
        {
            Close();
            home.Show();
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            var bm = new Bitmap(dataGridView1.Width, dataGridView1.Height);
            dataGridView1.DrawToBitmap(bm, new Rectangle(0, 0, dataGridView1.Width, dataGridView1.Height));
            e.Graphics.DrawImage(bm, 0, 0);
        }
    }
}