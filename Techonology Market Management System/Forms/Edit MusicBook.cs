using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Techonology_Market_Management_System.Classes;

namespace Techonology_Market_Management_System.Forms
{
    public partial class Edit_MusicBook : Form
    {
        Admin_Panel Admin_Panel;
        MusicBook MusicBook = new MusicBook();

        public Edit_MusicBook()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (Admin_Panel == null)
            {
                Admin_Panel = new Admin_Panel();
                Admin_Panel.Show();
                this.Close();
            }
            else Admin_Panel = null;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            pictureBox2_Click(sender, e);
        }

        private void Edit_MusicBook_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = MusicBook.Get("MusicBook");
        }

        private void search_Click(object sender, EventArgs e)
        {
            try
            {
                if (searchID.Text.Trim() == "" && searchName.Text.Trim() == "")
                    searchError.Text = "Parameters can not be empty.";
                else
                {
                    if (searchID.Text.Trim() != "" && searchName.Text.Trim() == "")
                    {
                        dataGridView1.DataSource = MusicBook.GetByID(int.Parse(searchID.Text.Trim()), "MusicBook");
                        tID.Text = MusicBook.GetByID(int.Parse(searchID.Text.Trim()), "MusicBook").Rows[0][0].ToString();
                        tName.Text = MusicBook.GetByID(int.Parse(searchID.Text.Trim()), "MusicBook").Rows[0][1].ToString();
                        tPrice.Text = MusicBook.GetByID(int.Parse(searchID.Text.Trim()), "MusicBook").Rows[0][3].ToString();
                        tPiece.Text = MusicBook.GetByID(int.Parse(searchID.Text.Trim()), "MusicBook").Rows[0][4].ToString();
                        tDate.Text = MusicBook.GetByID(int.Parse(searchID.Text.Trim()), "MusicBook").Rows[0][5].ToString();
                        tAuthor.Text = MusicBook.GetByID(int.Parse(searchID.Text.Trim()), "MusicBook").Rows[0][7].ToString();
                        
                        tProducer.Text = MusicBook.GetByID(int.Parse(searchID.Text.Trim()), "MusicBook").Rows[0][6].ToString();
                        

                    }

                    else if (searchID.Text.Trim() == "" && searchName.Text.Trim() != "")
                    {
                        dataGridView1.DataSource = MusicBook.GetByName(searchName.Text.Trim(), "MusicBook");
                        tID.Text = MusicBook.GetByName(searchName.Text.Trim(), "MusicBook").Rows[0][0].ToString();
                        tName.Text = MusicBook.GetByName(searchName.Text.Trim(), "MusicBook").Rows[0][1].ToString();
                        tPrice.Text = MusicBook.GetByName(searchName.Text.Trim(), "MusicBook").Rows[0][3].ToString();
                        tPiece.Text = MusicBook.GetByName(searchName.Text.Trim(), "MusicBook").Rows[0][4].ToString();
                        tDate.Text = MusicBook.GetByName(searchName.Text.Trim(), "MusicBook").Rows[0][5].ToString();
                        
                        tProducer.Text = MusicBook.GetByName(searchName.Text.Trim(), "MusicBook").Rows[0][6].ToString();
                        
                        tAuthor.Text = MusicBook.GetByName(searchName.Text.Trim(), "MusicBook").Rows[0][7].ToString();
                        
                    }

                    else
                        searchError.Text = "You can only search with only one parameter";

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            int id = int.Parse(tID.Text);
            string name = tName.Text;
            int price = int.Parse(tPrice.Text);
            int piece = int.Parse(tPiece.Text);
            string date = tDate.Text;
            string producer = tProducer.Text;
            string author = tAuthor.Text;
            MusicBook.Update(id,name,"MusicBook",price,piece,date,producer,author);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int id = int.Parse(tID.Text);
            string name = tName.Text;
            int price = int.Parse(tPrice.Text);
            int piece = int.Parse(tPiece.Text);
            string date = tDate.Text;
            string producer = tProducer.Text;
            string author = tAuthor.Text;
            MusicBook.Add(name,"MusicBook",price,piece,date,producer,author);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Edit_MusicBook_Load(sender, e);
        }
    }
}
