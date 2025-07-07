using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hastane_Proje
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            FrmHastaGiriş hasta = new FrmHastaGiriş();
            hasta.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            DOKTORGİRİŞ doktor = new DOKTORGİRİŞ();
            doktor.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            SEKRETERGİRİŞ sekreter = new SEKRETERGİRİŞ();
            sekreter.Show();
            this.Hide();
        }
    }
}
