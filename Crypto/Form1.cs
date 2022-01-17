using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Crypto
{
    public partial class Form1 : Form
    {
        CryptageNet cryptnet;
        public Form1()
        {
            InitializeComponent();
        }

        private void TexteACrypterPerso(object sender, EventArgs e)
        {
            string Texte = textBox1.Text;
            string Cle = textBox2.Text;
            if (Texte.Length > 0 && Cle.Length>0)
            {
                var cryptperso = new CryptagePerso(Texte, Cle);
                textBox3.Text = cryptperso.executer(false);
            }
        }

        private void TexteACrypterNet(object sender, EventArgs e)
        {
            string Texte = textBox1.Text;
            if(Texte.Length>0)
            {
                this.cryptnet = new CryptageNet(Texte);
                string crypter = cryptnet.CrypterNet();
                textBox3.Text = crypter;
            }
        }

        private void TexteADecrypterNet(object sender, EventArgs e)
        {
            textBox4.Text = cryptnet.decode(textBox3.Text);
        }

        private void TexteADecrypterPerso(object sender, EventArgs e)
        {
            string Texte = textBox3.Text;
            string Cle = textBox2.Text;
            if (Texte.Length > 0 && Cle.Length > 0)
            {
                var cryptperso = new CryptagePerso(Texte, Cle);
                textBox4.Text = cryptperso.executer(true);
            }
        }
    }
}