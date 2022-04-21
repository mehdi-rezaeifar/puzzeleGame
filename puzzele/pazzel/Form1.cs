using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pazzel
{
    public partial class Form1 : Form
    {
        Button[,] cells;
        int empty_x, empty_y;

        public Form1()
        {
            InitializeComponent();
            cells = new Button[4, 4] { { button1, button2, button3, button4 },{ button5,button6 ,button7,button8 },
                                       { button9,button10,button11,button12 },{ button13,button14,button15,button16 } };

            Random r = new Random();
            int[] a = new int[16];

            for (int i = 0; i < 16; i++)
            {
                while (true)
                {
                    int x = r.Next(1, 17);

                    if (!a.Contains(x))
                    {
                        a[i] = x;

                        break;
                    }
                }
            }

            int k = 0;

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (a[k] == 16)
                    {
                        cells[i, j].Hide();

                        empty_x = i;
                        empty_y = j;
                    }
                    cells[i, j].Text = Convert.ToString(a[k]);
                    cells[i, j].Font = new Font("Arial", 19);

                    k++;
                }
            }
            
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Button this_button = sender as Button;
            int x = 0, y = 0;
            this_button.BackColor = Color.LightSlateGray;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (cells[i, j] == this_button)
                    {
                        x = i;
                        y = j;
                    }
                }
            }
            if (
                (x == empty_x && (y == empty_y - 1 || y == empty_y + 1)) ||
               (y == empty_y && (x == empty_x - 1 || x == empty_x + 1))
               )
            {
                cells[empty_x, empty_y].Text = this_button.Text;
                this_button.Text = "16";

                cells[empty_x, empty_y].Show();
                this_button.Hide();
                empty_x = x;
                empty_y = y;
                check_game();
            }
            
        }

        private void check_game()
        {
            if (cells[0, 0].Text == "button1" && cells[0, 1].Text == "button2" && cells[0, 2].Text == "button3" && cells[0, 3].Text == "button4" &&
                cells[1, 0].Text == "button5" && cells[1, 1].Text == "button6" && cells[1, 2].Text == "button7" && cells[1, 3].Text == "button8" &&
                cells[2, 0].Text == "button9" && cells[2, 1].Text == "button10" && cells[2, 2].Text == "button11" && cells[2, 3].Text == "button12" &&
                cells[3, 0].Text == "button13" && cells[3, 1].Text == "button14" && cells[3, 2].Text == "button15" && cells[3, 3].Text == "button16")
                {
                    MessageBox.Show("you win");
                }
            
        }
    }
}

