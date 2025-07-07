using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Hastane_Proje
{
    public partial class SEKRETERGİRİŞ : Form
    {
        public SEKRETERGİRİŞ()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 gris = new Form1();
            gris.Show();
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txtsifre.UseSystemPasswordChar = false;
            }
            else
            {
                txtsifre.UseSystemPasswordChar= true;
            }
        }
        sqlbaglanti sekbgl = new sqlbaglanti();
        private void btngiris_Click(object sender, EventArgs e)
        {
            SqlCommand komut7 = new SqlCommand("select * from Tbl_Sekreter where SekreterTC=@p1 and SekreterSifre=@p2", sekbgl.baglanti());
            komut7.Parameters.AddWithValue("@p1", msktc.Text);
            komut7.Parameters.AddWithValue("@p2", txtsifre.Text);
            SqlDataReader oku = komut7.ExecuteReader();
            if (oku.Read())
            {
                SEKRETERDETAY sekdetay = new SEKRETERDETAY();
                sekdetay.TCno = msktc.Text;
                sekdetay.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("ŞİFRE VEYA TC YANLIŞ" , "BİLGİ" , MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
