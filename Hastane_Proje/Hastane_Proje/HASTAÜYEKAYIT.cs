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
    public partial class HASTAÜYEKAYIT : Form
    {
        public HASTAÜYEKAYIT()
        {
            InitializeComponent();
        }
        sqlbaglanti üyebgl = new sqlbaglanti();        
        private void btnkayıt_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into Tbl_Hastalar (HastaAd,HastaSoyad,HastaTC,HastaTelefon,HastaSifre,HastaCinsiyet) values (@p1,@p2,@p3,@p4,@p5,@p6)" , üyebgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtad.Text);
            komut.Parameters.AddWithValue("@p2", txtsoyad.Text);
            komut.Parameters.AddWithValue("@p3", msktc.Text);
            komut.Parameters.AddWithValue("@p4", msktel.Text);
            komut.Parameters.AddWithValue("@p5", txtsifre.Text);
            komut.Parameters.AddWithValue("@p6", cmbcinsiyet.Text);
            komut.ExecuteNonQuery();
            üyebgl.baglanti().Close();
            MessageBox.Show("KAYDINIZ GERÇEKLEŞMİŞTİR ŞİFRENİZ:" + txtsifre.Text , "BİLGİ" ,MessageBoxButtons.OK,MessageBoxIcon.Information);

            txtad.Text = " ";
            txtsoyad.Text= " ";
            msktc.Clear();
            msktel.Clear();
            txtsifre.Text = " ";
            cmbcinsiyet.Text = " ";
            txtad.Focus();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
