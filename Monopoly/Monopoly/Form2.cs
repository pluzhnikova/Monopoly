using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;


namespace Monopoly
{
    public partial class Form2 : Form
    {

        Player p1 = new Player();
        Player p2 = new Player();
        Piece piece1 = new Piece();
        Piece piece2 = new Piece();
        public Form2()
        {
            InitializeComponent();

            Bitmap buf = new Bitmap("monopoly.jpg");     

            piece1.X = 525; piece1.Y = 500;
            piece2.X = 525; piece2.Y = 550;
            Graphics g = Graphics.FromImage(buf);
            pictureBox1.Image = buf;
            imageList1.Draw(g, new Point(piece1.X, piece1.Y), 0);
            imageList1.Draw(g, new Point(piece2.X, piece2.Y), 1);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Bitmap buff = new Bitmap("monopoly.jpg");
            Graphics a = Graphics.FromImage(buff);
            pictureBox1.Image = buff;
            p1.TakeTurn(piece1);
            p2.board.owned = p1.board.owned;
            p2.Money += p1.GivenMoney;
            p1.GivenMoney = 0;
            imageList1.Draw(a, new Point(piece1.X, piece1.Y), 0);
            
            foreach (Square p in p1.PlayersStreets)
            {
                textBox1.AppendText(p.name + "    "); 
            }
            foreach (Square p in p2.PlayersStreets)
            {
                textBox2.AppendText(p.name + "    ");
            }
            p1.added = null;
            if (p1.Money < 0 && p1.PlayersStreets.Count != 0)
            {
                //начать продавать
                while (p1.Money <= 0 || p1.PlayersStreets.Count != 0) 
                {
                    p1.board.owned.Remove(p1.PlayersStreets.Peek().sell);
                    if (p2.AbleToSpend(p1.PlayersStreets.Peek().Cost / 2))
                    {
                        p2.own.Add(p1.PlayersStreets.Peek().sell);
                        p2.PlayersStreets.Enqueue(p1.PlayersStreets.Peek());
                        p2.Spend(p1.PlayersStreets.Peek().Cost / 2);
                        p2.board.owned.Add(p1.PlayersStreets.Peek().sell);
                    }
                    p1.Gain(p1.PlayersStreets.Peek().Cost / 2);
                    p1.own.Remove(p1.PlayersStreets.Peek().sell);
                    textBox3.Text = p1.PlayersStreets.Dequeue().name;
                }
            }
            if (p1.Money < 0 && p1.PlayersStreets == null)
            {
                Hide();
                Form3 form3 = new Form3();
                form3.ShowDialog();
                Close();
            }
            p2.TakeTurn(piece2);
            p1.Money += p2.GivenMoney;
            p2.GivenMoney = 0;
            p1.board.owned = p2.board.owned;
            imageList1.Draw(a, new Point(piece2.X, piece2.Y), 1);
            label6.Text = "Переход на " + p1.diceValue.ToString() + "  Остаток: " + p1.Money.ToString() + " $";

            label7.Text = "Переход на " + p2.diceValue.ToString() + "  Остаток: " + p2.Money.ToString() + " $";
            p2.added = null;
            if (p2.Money < 0 && p2.PlayersStreets.Count!= 0)
            {
                while (p2.Money<=0 || p2.PlayersStreets.Count != 0)
                { 
                    p2.board.owned.Remove(p1.PlayersStreets.Peek().sell);
                    if (p1.AbleToSpend(p2.PlayersStreets.Peek().Cost / 2))
                    {
                        p2.own.Add(p1.PlayersStreets.Peek().sell);
                        p2.PlayersStreets.Enqueue(p1.PlayersStreets.Peek());
                        p1.Spend(p1.PlayersStreets.Peek().Cost / 2);
                    }
                    p2.Gain(p1.PlayersStreets.Peek().Cost / 2);
                    p1.own.Remove(p1.PlayersStreets.Peek().sell);
                    textBox3.Text = p2.PlayersStreets.Dequeue().name;
                    
                }
            }
            if (p2.Money < 0 && p2.PlayersStreets == null)
            {
                Hide();
                Form4 form4 = new Form4();
                form4.ShowDialog();
                Close();     // Открытие новой формы
            }
            textBox1.Clear();
            textBox2.Clear();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
