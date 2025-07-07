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
    public partial class DOKTORGİRİŞ : Form
    {
        public DOKTORGİRİŞ()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Close();
        }

        sqlbaglanti bgl = new sqlbaglanti();
        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select * from tbl_doktorlar where doktortc=@p1 and doktorsifre=@p2" , bgl.baglanti());
            komut.Parameters.AddWithValue("@p1" , msktc.Text);
            komut.Parameters.AddWithValue("@p2" ,txtsifre.Text);
            SqlDataReader oku = komut.ExecuteReader();
            if (oku.Read())
            {
                DOKTORDETAY dr = new DOKTORDETAY();
                dr.TC = msktc.Text; // doktor detaya tc taşıdım 
                dr.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("KULLANICI ADI VEYA ŞİFRE YANLIŞ" , "BİLGİ" , MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            bgl.baglanti().Close();
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
    }
}
