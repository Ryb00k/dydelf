using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace dydelf
{
    public partial class Form3 : Form
    {
        Form1 parent;
        public Form3()
        {
            InitializeComponent();
        }

        public Form3(Form1 sth)
        {

            parent = sth;
            InitializeComponent();

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            GlobalVars.y = Int32.Parse(textBox2.Text);

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            GlobalVars.x = Int32.Parse(textBox1.Text);
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            GlobalVars.dydelf = Int32.Parse(textBox4.Text);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            GlobalVars.krokodyle = Int32.Parse(textBox3.Text);
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            GlobalVars.czas = Int32.Parse(textBox5.Text);
        }
    }
}
