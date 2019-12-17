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

namespace Techonology_Market_Management_System
{
    public partial class Search : Form
    {
        Computers comp = new Computers();
        SmartPhones SmartPhones = new SmartPhones();
        MusicBook MusicBook = new MusicBook();
        public Search()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Search_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cb.SelectedIndex == 0)
            {
                if (searchID.Text.Trim() == "" && searchName.Text.Trim() == "")
                    searchError.Text = "Parameters can not be empty.";
                else
                {
                    if (searchID.Text.Trim() != "" && searchName.Text.Trim() == "")
                        dataGridView1.DataSource = comp.GetByID(int.Parse(searchID.Text.Trim()),"Computers");
                    else if (searchID.Text.Trim() == "" && searchName.Text.Trim() != "")
                        dataGridView1.DataSource = comp.GetByName(searchName.Text.Trim(), "Computers");
                    else
                        searchError.Text = "You can only search with only one parameter";
                }
            }
            else if (cb.SelectedIndex == 1)
            {
                if (searchID.Text.Trim() == "" && searchName.Text.Trim() == "")
                    searchError.Text = "Parameters can not be empty.";
                else
                {
                    if (searchID.Text.Trim() != "" && searchName.Text.Trim() == "")
                        dataGridView1.DataSource = SmartPhones.GetByID(int.Parse(searchID.Text.Trim()), "SmartPhones");
                    else if (searchID.Text.Trim() == "" && searchName.Text.Trim() != "")
                        dataGridView1.DataSource = SmartPhones.GetByName(searchName.Text.Trim(), "SmartPhones");
                    else
                        searchError.Text = "You can only search with only one parameter";
                }

            }
            else if (cb.SelectedIndex == 2)
            {
                if (searchID.Text.Trim() == "" && searchName.Text.Trim() == "")
                    searchError.Text = "Parameters can not be empty.";
                else
                {
                    if (searchID.Text.Trim() != "" && searchName.Text.Trim() == "")
                        dataGridView1.DataSource = MusicBook.GetByID(int.Parse(searchID.Text.Trim()), "MusicBook");
                    else if (searchID.Text.Trim() == "" && searchName.Text.Trim() != "")
                        dataGridView1.DataSource = MusicBook.GetByName(searchName.Text.Trim(), "MusicBook");
                    else
                        searchError.Text = "You can only search with only one parameter";
                }

            }
            else
                searchError.Text = "Please select a category.";
        }
    }
    }

