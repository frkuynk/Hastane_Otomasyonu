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
    public partial class FrmHastaGiriş : Form
    {
        public FrmHastaGiriş()
        {
            InitializeComponent();
        }
        private void FrmHastaGiriş_Load(object sender, EventArgs e)
        {

        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                txtsifre.UseSystemPasswordChar = false;
            }
            else
            {
                txtsifre.UseSystemPasswordChar = true;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Close();
        }

        sqlbaglanti hstbgl = new sqlbaglanti();
        private void lnküye_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            HASTAÜYEKAYIT üye = new HASTAÜYEKAYIT();
            üye.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut1 = new SqlCommand("select * from tbl_hastalar  where hastatc=@p1 and hastasifre=@p2" , hstbgl.baglanti());
            komut1.Parameters.AddWithValue("@p1", msktc.Text);
            komut1.Parameters.AddWithValue("@p2", txtsifre.Text);
            SqlDataReader oku = komut1.ExecuteReader();
            if (oku.Read())
            {
                HASTADETAY detay = new HASTADETAY();
                detay.tc = msktc.Text;
                detay.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("TC NO VEYA ŞİFRE YANLIŞ TEKRAR" , "BİLGİ" , MessageBoxButtons.OK, MessageBoxIcon.Error );
            }
            hstbgl.baglanti().Close();
        }
    }
}
