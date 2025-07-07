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
    public partial class DOKTORBİLGİGÜNCELLEME : Form
    {
        public DOKTORBİLGİGÜNCELLEME()
        {
            InitializeComponent();
        }
        
        sqlbaglanti bgl = new sqlbaglanti();
        public string TC1;
        private void DOKTORBİLGİGÜNCELLEME_Load(object sender, EventArgs e)
        {
            msktc.Text = TC1;

            SqlCommand komut = new SqlCommand("select * from tbl_doktorlar where doktortc=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", msktc.Text);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                txtad.Text = oku[1].ToString(); // oku[0]  id var onu çekmiyorum
                txtsoyad.Text = oku[2].ToString();
                //  msktc.Text = oku[4].ToString();  tc var zaten
                cmbbrans.Text = oku[3].ToString();
                txtsifre.Text = oku[5].ToString();
            }
            bgl.baglanti().Close();
        }

        private void btnkayıt_Click(object sender, EventArgs e)
        {
            SqlCommand komut6 = new SqlCommand("update tbl_doktorlar set doktorAd=@p1, doktorSoyad=@p2, doktorbrans=@p3, doktorSifre=@p4  where doktortc=@p5", bgl.baglanti());
            komut6.Parameters.AddWithValue("@p1", txtad.Text);
            komut6.Parameters.AddWithValue("@p2", txtsoyad.Text);
            komut6.Parameters.AddWithValue("@p3", cmbbrans.Text);
            komut6.Parameters.AddWithValue("@p4", txtsifre.Text);
            komut6.Parameters.AddWithValue("@p5", msktc.Text);
            komut6.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("BİLGİLERİNİZ GÜNCELLENDİ", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
