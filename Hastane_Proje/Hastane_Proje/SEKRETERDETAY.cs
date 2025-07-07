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
    public partial class SEKRETERDETAY : Form
    {
        public SEKRETERDETAY()
        {
            InitializeComponent();
        }
        public string TCno;
        sqlbaglanti bgl = new sqlbaglanti();
        private void SEKRETERDETAY_Load(object sender, EventArgs e)
        {
            lbltc.Text = TCno;

            //adsoyad

            SqlCommand komut8 = new SqlCommand("select sekreteradsoyad from tbl_sekreter where sekretertc=@p1" , bgl.baglanti());
            komut8.Parameters.AddWithValue("@p1" , lbltc.Text);
            SqlDataReader oku = komut8.ExecuteReader();
            while (oku.Read())
            {
                lbladsoyad.Text = oku[0].ToString();
            }
            bgl.baglanti().Close();


            //branş çekme 
            DataTable dt1 = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from tbl_branslar", bgl.baglanti());
            da.Fill(dt1);
            dataGridView1.DataSource = dt1;

            //doktor çekme 
            DataTable dt2= new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter("select (doktorad + ' ' + doktorsoyad) as 'Doktorlar' ,DoktorBrans from tbl_doktorlar", bgl.baglanti());
            // üst satırda as kullanmamın nedeni sütüna isim atamam 
            da1.Fill(dt2);
            dataGridView2.DataSource = dt2;

            //BRANŞLARI COMBO ÇEKME 
            SqlCommand çekme = new SqlCommand("select bransad from tbl_branslar", bgl.baglanti());
            SqlDataReader çek = çekme.ExecuteReader();
            while (çek.Read())
            {
                cmbbranş.Items.Add(çek[0]);
            }
            bgl.baglanti().Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand kaydet = new SqlCommand("insert into Tbl_Randevular (RandevuTarih,RandevuSaat,RandevuBrans,RandevuDoktor) values (@p1,@p2,@p3,@p4)", bgl.baglanti());
            kaydet.Parameters.AddWithValue("@p1" , msktarih.Text);
            kaydet.Parameters.AddWithValue("@p2", msksaat.Text);
            kaydet.Parameters.AddWithValue("@p3", cmbbranş.Text);
            kaydet.Parameters.AddWithValue("@p4", cmbdoktor.Text);
            kaydet.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("RANDEVU OLUŞTURULDU" , "BİLGİ" , MessageBoxButtons.OK , MessageBoxIcon.Asterisk);
        }

        private void cmbbranş_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbdoktor.Items.Clear();

            SqlCommand çekme1 = new SqlCommand("select doktorad,doktorsoyad from tbl_doktorlar where doktorbrans=@p1" , bgl.baglanti());
            çekme1.Parameters.AddWithValue("@p1" , cmbbranş.Text);
            SqlDataReader oku = çekme1.ExecuteReader();
            while (oku.Read())
            {
                cmbdoktor.Items.Add( oku[0]+ " " + oku[1] );
            }
            bgl.baglanti().Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into tbl_duyurular (duyuru) values (@p1)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1" , richTextBox1.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("DUYURU OLUŞTURULDU", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            richTextBox1.Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SEKRETER_DOKTOR_ dr = new SEKRETER_DOKTOR_();
            dr.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SEKRETER_BRANŞ_ brans = new SEKRETER_BRANŞ_();
            brans.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SEKRETER_RANDEVU_ randevu = new SEKRETER_RANDEVU_();
            randevu.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MESAJLAR msj = new MESAJLAR();
            msj.Show();
        }
    }
}
