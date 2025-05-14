using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using Timer = System.Windows.Forms.Timer;
namespace dydelf
{
    public partial class Form2 : Form
    {
        enum Pole { Puste, Dydelf, Krokodyl }
        Pole[,] plansza;

        private int ZnalezioneDydelfy = 0;
        private Stopwatch stoper;
        private Timer gameTimer;

        private Timer krokodylTimer;
        private Button ostatniKliknietyKrokodyl = null;

        private void Ticker(object sender, EventArgs e)
        {

            LabelCzas.Text = $"Czas: {GlobalVars.czas - (int)stoper.Elapsed.TotalSeconds}s";
            
            if (stoper.Elapsed.TotalSeconds >= GlobalVars.czas)
            {

                gameTimer.Stop();
                stoper.Stop();
                MessageBox.Show("Koniec czasu!");
                this.Close();

            }

        }

        private void KrokodylTimeout(object sender, EventArgs e)
        {
            krokodylTimer.Stop();
            krokodylTimer.Dispose();

            MessageBox.Show("Koniec gry! Trafiłeś na krokodyla.");
            this.Close();
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            string[] parts = clickedButton.Name.Split('_');
            int col = int.Parse(parts[1]);
            int row = int.Parse(parts[2]);

            if (krokodylTimer != null && krokodylTimer.Enabled)
            {
                
                if (clickedButton == ostatniKliknietyKrokodyl)
                {
                    
                    krokodylTimer.Stop();
                    krokodylTimer.Dispose();
                    krokodylTimer = null;
                    ostatniKliknietyKrokodyl = null;

                    clickedButton.BackColor = SystemColors.Control;
                    stoper.Start();
                    gameTimer.Start();
                    return;
                }
                else
                {
                    
                    return;
                }
            }

            switch (plansza[col, row])
            {
                case Pole.Puste:
                    clickedButton.BackColor = Color.LightGray;
                    clickedButton.Enabled = false;
                    break;

                case Pole.Dydelf:
                    clickedButton.BackColor = Color.LightGreen;
                    ZnalezioneDydelfy++;
                    clickedButton.Enabled = false;
                    break;

                case Pole.Krokodyl:
                    clickedButton.BackColor = Color.Red;

                    ostatniKliknietyKrokodyl = clickedButton;

                    stoper.Stop();
                    gameTimer.Stop();

                    krokodylTimer = new Timer();
                    krokodylTimer.Interval = 2000;
                    krokodylTimer.Tick += KrokodylTimeout;
                    krokodylTimer.Start();

                    LabelCzas.Text = $"Trafiłeś na krokodyla! Masz 2 sekundy na odkliknięcie";
                    break;
            }

            if (ZnalezioneDydelfy == GlobalVars.dydelf)
            {
                MessageBox.Show("Udało ci się znalezc wszystkie Dydelfy!");
                this.Close();
            }
        }

        public void board(int x, int y)
        {
            int left = 50;
            int top = 50;
            int button_namer = 0;
            List<Button> buttons = new List<Button>();

            plansza = new Pole[x, y];

            Random rand = new Random();

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
                    button.Name = $"btn_{i}_{j}";
                    button.Left = left;
                    button.Top = top;
                    button.Width = 50;
                    button.Height = 50;
                    button.Click += Button_Click;
                    this.Controls.Add(button);


                }
                top += 50;
            }
        }
        public void randCrocDydPosition()
        {
            Random rnd = new Random();
            int placed_dydelfs = 0;
            while (placed_dydelfs < GlobalVars.dydelf)
            {

                int x = rnd.Next(GlobalVars.x);
                int y = rnd.Next(GlobalVars.y);

                if (plansza[x, y] == Pole.Puste)
                {

                    plansza[x, y] = Pole.Dydelf;
                    placed_dydelfs++;

                }

            }

            int placed_crocs = 0;
            while (placed_crocs < GlobalVars.krokodyle)
            {

                int x = rnd.Next(GlobalVars.x);
                int y = rnd.Next(GlobalVars.y);

                if (plansza[x, y] == Pole.Puste)
                {
                    plansza[x, y] = Pole.Krokodyl;
                    placed_crocs++;
                }
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
            board(GlobalVars.x, GlobalVars.y);
            randCrocDydPosition();

            LabelCzas.Text = $"Czas: {GlobalVars.czas}s";

            stoper = new Stopwatch();
            gameTimer = new Timer();
            gameTimer.Interval = 1000;
            gameTimer.Tick += Ticker;

            stoper.Start();
            gameTimer.Start();

        }

        private void LabelCzas_Click(object sender, EventArgs e)
        {
            
        }
    }
}
