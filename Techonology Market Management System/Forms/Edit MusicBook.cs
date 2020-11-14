using Blackhole.Classes;
using Technology_Market_Management_System.Classes;

namespace Techonology_Market_Management_System.Forms
{
    public partial class Edit_MusicBook : Form
    {
        private readonly MusicBook _musicBook = new MusicBook();
        private AdminPanel _adminPanel;
        private string imgLoc = "";
        byte[] img = null;

        public Edit_MusicBook()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (_adminPanel == null)
            {
                _adminPanel = new AdminPanel();
                _adminPanel.Show();
                Close();
            }
            else
            {
                _adminPanel = null;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            pictureBox2_Click(sender, e);
        }

        private void Edit_MusicBook_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = _musicBook.Get("MusicBook");
            Error.Text = "";
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Edit_MusicBook_Load(sender, e);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                //var id = int.Parse(tID.Text);
                var name = tName.Text;
                var price = int.Parse(tPrice.Text);
                var piece = int.Parse(tPiece.Text);
                var date = tDate.Text;
                var producer = tProducer.Text;
                var author = tAuthor.Text;
                var result = _musicBook.GetByName(name, "Computers");
                var fs = new FileStream(imgLoc, FileMode.Open, FileAccess.Read);
                var br = new BinaryReader(fs);
                img = br.ReadBytes((int)fs.Length);

                if (result.Rows.Count > 0)
                {
                    lberror.ForeColor = Color.Red;
                    searchError.Text = CommonFunctions.ReturnString("exist");
                }

                else
                {
                    _musicBook.Add(name, "MusicBook", price, piece, date, producer, author);
                    _musicBook.AddImage(int.Parse(_musicBook.GetByName(name, "MusicBook").Rows[0][0].ToString()), img, "MusicBook");
                    lberror.ForeColor = Color.Green;
                    lberror.Text = CommonFunctions.ReturnString("success");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var id = int.Parse(tID.Text);
            var name = tName.Text;
            var price = int.Parse(tPrice.Text);
            var piece = int.Parse(tPiece.Text);
            var date = tDate.Text;
            var producer = tProducer.Text;
            var author = tAuthor.Text;
            var fs = new FileStream(imgLoc, FileMode.Open, FileAccess.Read);
            var br = new BinaryReader(fs);
            img = br.ReadBytes((int)fs.Length);
            _musicBook.Update(id, name, "MusicBook", price, piece, date, producer, author);
            _musicBook.AddImage(id, img, "MusicBook");
        }

        private void search_Click_1(object sender, EventArgs e)
        {
            try
            {
                Error.Text = "";
                if (searchID.Text.Length == 0 && searchName.Text.Length == 0)
                {
                    searchError.Text = CommonFunctions.ReturnString("empty");
                }
                else
                {
                    if (searchID.Text.Length != 0 && searchName.Text.Length == 0)
                    {

                        var id = int.Parse(searchID.Text.Trim());
                        byte[] img;
                        if (_musicBook.GetById(id, "MusicBook").Rows[0][8].ToString() != "NULL")
                        {

                            img = (byte[])(_musicBook.GetById(id, "MusicBook").Rows[0][8]);
                            if (img == null)
                            {
                                productPicture.Image = null;
                            }
                            else
                            {
                                var ms = new MemoryStream(img);
                                productPicture.Image = Image.FromStream(ms);

                            }
                        }
                        CommonFunctions.GetMusicBookById(dataGridView1, id, tID, tName, tPrice, tPiece, tDate, tAuthor, tProducer);
                    }

                    else if (searchID.Text.Length == 0 && searchName.Text.Length != 0)
                    {
                        var name = searchName.Text.Trim();
                        CommonFunctions.GetMusicBookByName(dataGridView1, name, tID, tName, tPrice, tPiece, tDate, tAuthor, tProducer);
                    }

                    else
                    {
                        searchError.Text = CommonFunctions.ReturnString("one");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void browse_Click(object sender, EventArgs e)
        {
            try
            {
                var dlg = new OpenFileDialog();
                dlg.Filter = "JPEG Files (*.jpg)|*.jpg|All Files(*.*)|*.*";
                dlg.Title = "Select Computer Picture";
                if (dlg.ShowDialog() != DialogResult.OK) return;
                imgLoc = dlg.FileName;
                productPicture.ImageLocation = imgLoc;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}