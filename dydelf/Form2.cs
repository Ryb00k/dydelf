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
    public partial class Form2 : Form
    {
        public void board(int x, int y)
        {
            int left = 50;
            int top = 50;
            int button_namer = 0;
            List<Button> buttons = new List<Button>();
            for (int i = 0; i < x; i++)
            {
                left = 50;
                for (int j = 0; j < y; j++)
                {
                    left += 50;
                    button_namer += 1;
                    Button button = new Button();
                    buttons.Add(button);
                    button.Text = (button_namer).ToString();
                    button.Name = (button_namer).ToString();
                    button.Left = left;
                    button.Top = top;
                    button.Width = 50;
                    button.Height = 50;
                    this.Controls.Add(button);

                }
                top += 50;
            }
        }

        Form1 parent;
        public Form2()
        {
            InitializeComponent();
        }

        public Form2(Form1 sth)
        {
            parent = sth;
            InitializeComponent();
            board(GlobalVars.x,GlobalVars.y);
        }

       
    }
}
