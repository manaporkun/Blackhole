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
    public partial class Compare : Form
    {
        Computers comp = new Computers();
        SmartPhones sp = new SmartPhones();
        Home home;
        DataGridViewButtonColumn col;
        string selection = "Computers";
        bool product1_selected = false;
        bool product2_selected = false;
        bool menu = false;


        public Compare()
        {
            InitializeComponent();
        }

        private void Compare_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = comp.GetShort();
            AddButton();
            GetProperties(0, 1);
            groupBox5.Hide();

        }

        private void GetProperties(int row1,int row2)
        {
            c1name.Text = dataGridView1.Rows[row1].Cells[0].Value.ToString();
            c1brand.Text = dataGridView1.Rows[row1].Cells[3].Value.ToString();
            c1price.Text = dataGridView1.Rows[row1].Cells[1].Value.ToString();
            label3.Text = dataGridView1.Rows[row1].Cells[4].Value.ToString();
            label4.Text = dataGridView1.Rows[row1].Cells[5].Value.ToString();
            label5.Text = dataGridView1.Rows[row1].Cells[6].Value.ToString();
            label6.Text = dataGridView1.Rows[row1].Cells[7].Value.ToString();
            label7.Text = dataGridView1.Rows[row1].Cells[8].Value.ToString();
            label8.Text = dataGridView1.Rows[row1].Cells[2].Value.ToString();

            label37.Text = dataGridView1.Rows[row2].Cells[0].Value.ToString();
            label38.Text = dataGridView1.Rows[row2].Cells[3].Value.ToString();
            label39.Text = dataGridView1.Rows[row2].Cells[4].Value.ToString();
            label40.Text = dataGridView1.Rows[row2].Cells[5].Value.ToString();
            label41.Text = dataGridView1.Rows[row2].Cells[6].Value.ToString();
            label42.Text = dataGridView1.Rows[row2].Cells[7].Value.ToString();
            label43.Text = dataGridView1.Rows[row2].Cells[8].Value.ToString();
            label44.Text = dataGridView1.Rows[row2].Cells[2].Value.ToString();
            label36.Text = dataGridView1.Rows[row2].Cells[1].Value.ToString();



        }

        private void GetComp1(int row1)
        {
            c1name.Text = dataGridView1.Rows[row1].Cells[0].Value.ToString();
            c1brand.Text = dataGridView1.Rows[row1].Cells[3].Value.ToString();
            c1price.Text = dataGridView1.Rows[row1].Cells[1].Value.ToString();
            label3.Text = dataGridView1.Rows[row1].Cells[4].Value.ToString();
            label4.Text = dataGridView1.Rows[row1].Cells[5].Value.ToString();
            label5.Text = dataGridView1.Rows[row1].Cells[6].Value.ToString();
            label6.Text = dataGridView1.Rows[row1].Cells[7].Value.ToString();
            label7.Text = dataGridView1.Rows[row1].Cells[8].Value.ToString();
            label8.Text = dataGridView1.Rows[row1].Cells[2].Value.ToString();
        }

        private void GetComp2(int row2)
        {
            label37.Text = dataGridView1.Rows[row2].Cells[0].Value.ToString();
            label38.Text = dataGridView1.Rows[row2].Cells[3].Value.ToString();
            label39.Text = dataGridView1.Rows[row2].Cells[4].Value.ToString();
            label40.Text = dataGridView1.Rows[row2].Cells[5].Value.ToString();
            label41.Text = dataGridView1.Rows[row2].Cells[6].Value.ToString();
            label42.Text = dataGridView1.Rows[row2].Cells[7].Value.ToString();
            label43.Text = dataGridView1.Rows[row2].Cells[8].Value.ToString();
            label44.Text = dataGridView1.Rows[row2].Cells[2].Value.ToString();
            label36.Text = dataGridView1.Rows[row2].Cells[1].Value.ToString();
        }

        private void GetPhone1(int row1)
        {
            c1name.Text = dataGridView1.Rows[row1].Cells[0].Value.ToString();
            c1brand.Text = dataGridView1.Rows[row1].Cells[3].Value.ToString();
            c1price.Text = dataGridView1.Rows[row1].Cells[1].Value.ToString();
            label20.Text = "Screen Type";
            label3.Text = dataGridView1.Rows[row1].Cells[7].Value.ToString();
            label4.Text = dataGridView1.Rows[row1].Cells[4].Value.ToString();
            label5.Text = dataGridView1.Rows[row1].Cells[5].Value.ToString();
            label6.Text = dataGridView1.Rows[row1].Cells[6].Value.ToString();
            label7.Text = "";
            label8.Text = dataGridView1.Rows[row1].Cells[2].Value.ToString();
            label13.Text = "";
            
        }

        private void GetPhone2(int row2)
        {
            label37.Text = dataGridView1.Rows[row2].Cells[0].Value.ToString();
            label38.Text = dataGridView1.Rows[row2].Cells[3].Value.ToString();
            label36.Text = dataGridView1.Rows[row2].Cells[1].Value.ToString();
            label42.Text = dataGridView1.Rows[row2].Cells[6].Value.ToString();
            label39.Text = dataGridView1.Rows[row2].Cells[7].Value.ToString();
            label40.Text = dataGridView1.Rows[row2].Cells[4].Value.ToString();
            label41.Text = dataGridView1.Rows[row2].Cells[5].Value.ToString();            
            label43.Text = "";
            label44.Text = dataGridView1.Rows[row2].Cells[2].Value.ToString();
            label26.Text = "Screen Type";
            label10.Text = "";

        }

        private void AddButton()
        {
            //dataGridView1.Columns.Clear();

            col = new DataGridViewButtonColumn();
            col.HeaderText = "";
            col.Text = "SELECT";
            col.UseColumnTextForButtonValue = true;
            col.Width = 120;
            col.DefaultCellStyle.ForeColor = Color.WhiteSmoke;
            col.DefaultCellStyle.BackColor = Color.DarkCyan;
            col.FlatStyle = FlatStyle.Flat;
            col.DisplayIndex = dataGridView1.Columns.Count + 1;
            dataGridView1.Columns.Add(col);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == dataGridView1.Columns.Count - 1 && e.RowIndex >= 0)
                {

                    if (product1_selected == false)
                    {
                        switch (selection)
                        {
                            case "Computers":
                                GetComp1(e.RowIndex);
                                break;
                            case "SmartPhones":
                                GetPhone1(e.RowIndex);
                                break;
                            default:
                                break;
                            
                        }
                        
                        product1_selected = true;
                    }
                    else if(product2_selected == false)
                    {
                        switch (selection)
                        {
                            case "Computers":
                                GetComp2(e.RowIndex);
                                break;
                            case "SmartPhones":
                                GetPhone2(e.RowIndex);
                                break;
                            default:
                                break;

                        }
                        product2_selected = true;
                        
                    }
                    else
                    {
                        product1_selected = false;
                        product2_selected = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                
                string name = textBox1.Text.Trim();
                dataGridView1.Columns.Clear();

                switch (selection)
                {
                    case "Computers":
                        dataGridView1.DataSource = comp.GetShortByName(name);
                        break;
                    case "SmartPhones":
                        dataGridView1.DataSource = sp.GetShortByName(name);
                        break;
                    default:
                        break;
                }

                AddButton();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (home == null)
            {
                home = new Home();
                home.Show();
                this.Close();
            }
            else home = null;
        }

        private void label11_Click(object sender, EventArgs e)
        {
            button6_Click(sender, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            selection = "Computers";
            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = comp.GetShort();
            c1picture.Image = Techonology_Market_Management_System.Properties.Resources.outline_computer_black_48dp;
            pictureBox4.Image = Techonology_Market_Management_System.Properties.Resources.outline_computer_black_48dp;
            AddButton();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            selection = "SmartPhones";
            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = sp.GetShort();
            c1picture.Image = Techonology_Market_Management_System.Properties.Resources.baseline_smartphone_black_48dp;
            pictureBox4.Image = Techonology_Market_Management_System.Properties.Resources.baseline_smartphone_black_48dp;
            AddButton();
        }

        private void menubutton_Click(object sender, EventArgs e)
        {
            if(menu == false)
            {
                menu = true;
                groupBox5.Show();
            }
            else
            {
                menu = false;
                groupBox5.Hide();
            }
        }

        private void menulabel_Click(object sender, EventArgs e)
        {
            menubutton_Click(sender, e);
        }
    }
}
