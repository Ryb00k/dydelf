namespace dydelf
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(GlobalVars.y.ToString());
            Form2 form = new Form2(this);
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 form = new Form3(this);
            form.Show();
        }
    }

    public static class GlobalVars
    {

        public static int x = 3;
        public static int y = 3;
        public static int dydelf = 1;
        public static int krokodyle = 0;
        public static int czas = 30;

    }

}
