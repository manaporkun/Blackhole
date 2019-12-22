using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Techonology_Market_Management_System.Forms;
using Techonology_Market_Management_System.Classes;

namespace Techonology_Market_Management_System
{
    public partial class PaymentDelivery : Form
    {
        User u = new User();
        static string email;
        CartClass cc = new CartClass();
        private static int numberProduct;
        Product product = new Product();
        Home home = new Home();
        string phonenumber;
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
            try
            {
                string name1 = tName.Text.Trim();
                string card_number = maskedTextBox1.Text.Trim();
                string expire_date = maskedTextBox2.Text.Trim();
                string ccv = maskedTextBox3.Text.Trim();

                if(name1.Length == 0 || card_number.Length != 14 || expire_date.Length != 5 || ccv.Length != 3)
                {
                    label12.Text = "Please enter informations correctly";
                    
                }
                else
                {
                    if (dataGridView1.Rows.Count < 1) return;

                    for (int i = 0; i < dataGridView1.RowCount; i++)
                    {
                        string name = dataGridView1.Rows[i].Cells[0].Value.ToString();
                        string category = dataGridView1.Rows[i].Cells[3].Value.ToString();
                        int number = int.Parse(dataGridView1.Rows[i].Cells[2].Value.ToString());
                        int current_stock = int.Parse(product.GetByName(name, category).Rows[0][3].ToString());

                        product.UpdatePiece(name, current_stock - number, category);

                    }




                    MessageBox.Show("Your order has been received. Thank you");

                    for (int i = 0; i < dataGridView1.RowCount; i++)
                    {
                        string name = dataGridView1.Rows[i].Cells[0].Value.ToString();
                        cc.Delete(phonenumber, name);
                    }

                    //this.Visible = false;
                    printPreviewDialog1.Document = printDocument1;
                    printPreviewDialog1.ShowDialog();
                    //this.Visible = true;

                    PaymentDelivery_Load(sender, e);
                    label12.Text = "";
                }
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            


        }

        private void PaymentDelivery_Load(object sender, EventArgs e)
        {
           
            phonenumber = u.GetCustomerByEmail(email).Rows[0][7].ToString();
            dataGridView1.DataSource = cc.Get(u.GetCustomerByEmail(email).Rows[0][7].ToString());
            label7.Text = cc.Get(u.GetCustomerByEmail(email).Rows[0][7].ToString()).Rows.Count.ToString();
            label4.Text = u.GetCustomerByEmail(email).Rows[0][5].ToString();
            //MessageBox.Show(dataGridView1.Rows[0].Cells[0].Value.ToString());
        }

        public static void TakeNumberPorduct(int number)
        {
            numberProduct = number;
        }

        private void label11_Click(object sender, EventArgs e)
        {
            this.Close();
            home.Show();
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap bm = new Bitmap(this.dataGridView1.Width, this.dataGridView1.Height);
            dataGridView1.DrawToBitmap(bm, new Rectangle(0, 0, this.dataGridView1.Width, this.dataGridView1.Height));
            e.Graphics.DrawImage(bm, 0, 0);
        }
    }
}
