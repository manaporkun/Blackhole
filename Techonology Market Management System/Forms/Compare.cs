using Blackhole.Properties;
using Technology_Market_Management_System.Classes;

namespace Techonology_Market_Management_System.Forms
{
    public partial class Compare : Form
    {
        private DataGridViewButtonColumn _col;
        private readonly Computers _comp = new Computers();
        private Home _home;
        private bool _menu;
        private bool _product1Selected;
        private bool _product2Selected;
        private string _selection = "Computers";
        private readonly SmartPhones _sp = new SmartPhones();

        public Compare()
        {
            InitializeComponent();
        }

        private void Compare_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = _comp.GetShort();
            AddButton();
            GetProperties(0, 1);
            groupBox5.Hide();
        }

        private void GetProperties(int row1, int row2)
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

            _col = new DataGridViewButtonColumn
            {
                HeaderText = "",
                Text = "SELECT",
                UseColumnTextForButtonValue = true,
                Width = 120,
                DefaultCellStyle = { ForeColor = Color.WhiteSmoke, BackColor = Color.DarkCyan },
                FlatStyle = FlatStyle.Flat,
                DisplayIndex = dataGridView1.Columns.Count + 1
            };
            dataGridView1.Columns.Add(_col);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex != dataGridView1.Columns.Count - 1 || e.RowIndex < 0) return;
                if (_product1Selected == false)
                {
                    switch (_selection)
                    {
                        case "Computers":
                            GetComp1(e.RowIndex);
                            break;

                        case "SmartPhones":
                            GetPhone1(e.RowIndex);
                            break;
                    }

                    _product1Selected = true;
                }
                else if (_product2Selected == false)
                {
                    switch (_selection)
                    {
                        case "Computers":
                            GetComp2(e.RowIndex);
                            break;

                        case "SmartPhones":
                            GetPhone2(e.RowIndex);
                            break;
                    }

                    _product2Selected = true;
                }
                else
                {
                    _product1Selected = false;
                    _product2Selected = false;
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
                var name = textBox1.Text.Trim();
                dataGridView1.Columns.Clear();

                switch (_selection)
                {
                    case "Computers":
                        dataGridView1.DataSource = _comp.GetShortByName(name);
                        break;

                    case "SmartPhones":
                        dataGridView1.DataSource = _sp.GetShortByName(name);
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
            if (_home == null)
            {
                _home = new Home();
                _home.Show();
                Close();
            }
            else
            {
                _home = null;
            }
        }

        private void label11_Click(object sender, EventArgs e)
        {
            button6_Click(sender, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _selection = "Computers";
            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = _comp.GetShort();
            c1picture.Image = Resources.outline_computer_black_48dp;
            pictureBox4.Image = Resources.outline_computer_black_48dp;
            AddButton();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            _selection = "SmartPhones";
            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = _sp.GetShort();
            c1picture.Image = Resources.baseline_smartphone_black_48dp;
            pictureBox4.Image = Resources.baseline_smartphone_black_48dp;
            AddButton();
        }

        private void menubutton_Click(object sender, EventArgs e)
        {
            if (_menu == false)
            {
                _menu = true;
                groupBox5.Show();
            }
            else
            {
                _menu = false;
                groupBox5.Hide();
            }
        }

        private void menulabel_Click(object sender, EventArgs e)
        {
            menubutton_Click(sender, e);
        }
    }
}