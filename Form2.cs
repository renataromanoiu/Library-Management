using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Biblioteca
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Autor autor = new Autor();
            autor.Show();
            this.Hide(); // sau this.Close(); dacă vrei să închizi Form1
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Carte carte = new Carte();
            carte.Show();
            this.Hide(); // sau this.Close(); dacă vrei să închizi Form1
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CarteAutor carteautor = new CarteAutor();
            carteautor.Show();
            this.Hide(); // sau this.Close(); dacă vrei să închizi Form1
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Client client = new Client();
            client.Show();
            this.Hide(); // sau this.Close(); dacă vrei să închizi Form1
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Editura editura = new Editura();
            editura.Show();
            this.Hide(); // sau this.Close(); dacă vrei să închizi Form1
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Furnizor furnizor = new Furnizor();
            furnizor.Show();
            this.Hide(); // sau this.Close(); dacă vrei să închizi Form1
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Imprumut imprumut = new Imprumut();
            imprumut.Show();
            this.Hide(); // sau this.Close(); dacă vrei să închizi Form1
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Interogări_simple interogări_Simple = new Interogări_simple();
            interogări_Simple.Show();
            this.Hide(); // sau this.Close(); dacă vrei să închizi Form1
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Interogari_complexe interogări_complexe = new Interogari_complexe();
            interogări_complexe.Show();
            this.Hide(); // sau this.Close(); dacă vrei să închizi Form1
        }
    }
}
