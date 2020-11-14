namespace Blackhole.Forms
{
    public partial class Alert : Form
    {
        public Alert()
        {
            InitializeComponent();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Alert_Load(object sender, EventArgs e)
        {
            FadeOut(Alert.ActiveForm);
            //var MyTimer = new Timer();
            //MyTimer.Interval = (6 * 6 * 1000);
            //MyTimer.Tick += new EventHandler(MyTimer_Tick);
            //MyTimer.Start();
        }


        private async void FadeOut(Form o, int interval = 150)
        {
            //Object is fully visible. Fade it out
            while (o.Opacity > 0.0)
            {
                await Task.Delay(interval);
                o.Opacity -= 0.05;
            }
            o.Opacity = 0;
            this.Close();//make fully invisible       

        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
