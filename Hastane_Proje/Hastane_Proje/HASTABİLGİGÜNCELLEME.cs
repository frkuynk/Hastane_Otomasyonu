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
    public partial class HASTABİLGİGÜNCELLEME : Form
    {
        public HASTABİLGİGÜNCELLEME()
        {
            InitializeComponent();
        }

        public string tcno;
        sqlbaglanti bgl = new sqlbaglanti();
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void HASTABİLGİGÜNCELLEME_Load(object sender, EventArgs e)
        {
            msktc.Text = tcno;
            SqlCommand komut5 = new SqlCommand("select * from tbl_hastalar where hastatc=@p1", bgl.baglanti());
            komut5.Parameters.AddWithValue("@p1" , msktc.Text);
            SqlDataReader oku = komut5.ExecuteReader(); 
            while (oku.Read())
            {
                txtad.Text = oku[1].ToString(); // oku[0]  id var onu çekmiyorum
                txtsoyad.Text = oku[2].ToString();
              //  msktc.Text = oku[3].ToString();  tc var zaten
                msktel.Text = oku[4].ToString();
                txtsifre.Text = oku[5].ToString();
                cmbcinsiyet.Text = oku[6].ToString();
            }
            bgl.baglanti().Close();
        }

        private void btngüncel_Click(object sender, EventArgs e)
        {
          SqlCommand komut6 = new SqlCommand("update tbl_hastalar set HastaAd=@p1, HastaSoyad=@p2, HastaTelefon=@p3, HastaSifre=@p4, HastaCinsiyet=@p5 where hastatc=@p6" , bgl.baglanti());
            komut6.Parameters.AddWithValue("@p1" , txtad.Text);
            komut6.Parameters.AddWithValue("@p2", txtsoyad.Text);
            komut6.Parameters.AddWithValue("@p3", msktel.Text);
            komut6.Parameters.AddWithValue("@p4", txtsifre.Text);
            komut6.Parameters.AddWithValue("@p5", cmbcinsiyet.Text);
            komut6.Parameters.AddWithValue("@p6", msktc.Text);
            komut6.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("BİLGİLERİNİZ GÜNCELLENDİ" , "BİLGİ" , MessageBoxButtons.OK , MessageBoxIcon.Warning);
        }
    }
}
