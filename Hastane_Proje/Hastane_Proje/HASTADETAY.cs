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
    public partial class HASTADETAY : Form
    {
        public HASTADETAY()
        {
            InitializeComponent();
        }
        public string tc;

        sqlbaglanti detay = new sqlbaglanti();
        private void HASTADETAY_Load(object sender, EventArgs e)
        {
            lbltc.Text = tc;
            //adsoyadçekme
            SqlCommand komut2 = new SqlCommand("select hastaad,hastasoyad from tbl_hastalar where hastatc=@p1" , detay.baglanti());
            komut2.Parameters.AddWithValue("@p1" , lbltc.Text);
            SqlDataReader oku = komut2.ExecuteReader(); 
            while (oku.Read())
            {
                lbladsoyad.Text = oku[0] + " " + oku[1];
            }
            detay.baglanti().Close();
            
            //randevuçekme
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from tbl_randevular where hastatc=" + tc, detay.baglanti());
            da.Fill(dt); // tablonun çini doldur 
            dataGridView1.DataSource = dt;

            //branşçekme
            SqlCommand komut3 = new SqlCommand("select bransad from tbl_branslar" , detay.baglanti());
            SqlDataReader oku1 = komut3.ExecuteReader();
            while (oku1.Read())
            {
                cmbbranş.Items.Add(oku1[0]);
            }
            detay.baglanti().Close();
        }

        private void cmbbranş_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbdoktor.Items.Clear(); // içini temizlesin sonra işlemleri yapsın 

            SqlCommand komut3 = new SqlCommand("Select doktorad,doktorsoyad from tbl_doktorlar where doktorbrans=@p1", detay.baglanti());
            komut3.Parameters.AddWithValue("@p1", cmbbranş.Text);
            SqlDataReader oku2 = komut3.ExecuteReader();
            while (oku2.Read())
            {
                cmbdoktor.Items.Add(oku2[0] + " " + oku2[1]);
            }
            detay.baglanti().Close();
        }

        private void cmbdoktor_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from tbl_randevular where randevubrans='" + cmbbranş.Text + "'" + " and randevudoktor='" + cmbdoktor.Text + "' and randevudurum=0" , detay.baglanti());
            da.Fill(dt);
            dataGridView2.DataSource = dt;
        }

        private void lnkbilgidüzen_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            HASTABİLGİGÜNCELLEME güncel = new HASTABİLGİGÜNCELLEME();
            güncel.tcno = lbltc.Text;
            güncel.Show();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView2.SelectedCells[0].RowIndex;
            textBox1.Text = dataGridView2.Rows[secilen].Cells[0].Value.ToString();
        }

        private void btnrandevu_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update tbl_randevular set randevudurum=1,hastatc=@p1,hastasikayet=@p2 where randevuid=@p3", detay.baglanti());
            komut.Parameters.AddWithValue("@p1", lbltc.Text);
            komut.Parameters.AddWithValue("@p2", rchsikayet.Text);
            komut.Parameters.AddWithValue("@p3", textBox1.Text);
            komut.ExecuteNonQuery();
            detay.baglanti().Close();
            MessageBox.Show("RANDEVU ALINDI" , "BİLGİ" , MessageBoxButtons.OK , MessageBoxIcon.Warning);
        }
    }
}

