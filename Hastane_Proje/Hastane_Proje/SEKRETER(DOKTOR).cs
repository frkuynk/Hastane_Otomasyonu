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
    public partial class SEKRETER_DOKTOR_ : Form
    {
        public SEKRETER_DOKTOR_()
        {
            InitializeComponent();
        }

        sqlbaglanti bgl = new sqlbaglanti();
        private void SEKRETER_DOKTOR__Load(object sender, EventArgs e)
        {
            //doktor çekme 
            DataTable dt2 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter("select * from tbl_doktorlar", bgl.baglanti());
            da1.Fill(dt2);
            dataGridView1.DataSource = dt2;

            //BRANŞLARI COMBO ÇEKME 
            SqlCommand çekme = new SqlCommand("select bransad from tbl_branslar", bgl.baglanti());
            SqlDataReader çek = çekme.ExecuteReader();
            while (çek.Read())
            {
                cmbbrans.Items.Add(çek[0]);
            }
            bgl.baglanti().Close();
    }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("insert into Tbl_Doktorlar (doktorad,doktorsoyad,doktorbrans,doktortc,doktorsifre) values (@p1,@p2,@p3,@p4,@p5)" , bgl.baglanti());
            cmd.Parameters.AddWithValue("@p1", txtad.Text);
            cmd.Parameters.AddWithValue("@p2", txtsoyad.Text);
            cmd.Parameters.AddWithValue("@p3", cmbbrans.Text);
            cmd.Parameters.AddWithValue("@p4", msktc.Text);
            cmd.Parameters.AddWithValue("@p5", txtsifre.Text);
            cmd.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("DOKTOR BAŞARILI BİR ŞEKİLDE EKLENMİŞTİR" , "BİLGİ" , MessageBoxButtons.OK , MessageBoxIcon.Asterisk);
            txtad.Text = " ";
            txtsoyad.Text = " ";
            cmbbrans.Text = " ";
            msktc.Text = " ";
            txtsifre.Text = " ";    
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txtad.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtsoyad.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            cmbbrans.Text= dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            msktc.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            txtsifre.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("delete from tbl_doktorlar where doktortc=@p1" , bgl.baglanti());
            komut.Parameters.AddWithValue("@p1" , msktc.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("KAYIT SİLİNDİ" , "BİLGİ" , MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("update  Tbl_Doktorlar set doktorad=@p1 ,doktorsoyad=@p2, doktorbrans=@p3, doktorsifre=@p5 where  doktortc=@p4 ", bgl.baglanti());
            cmd.Parameters.AddWithValue("@p1", txtad.Text);
            cmd.Parameters.AddWithValue("@p2", txtsoyad.Text);
            cmd.Parameters.AddWithValue("@p3", cmbbrans.Text);
            cmd.Parameters.AddWithValue("@p4", msktc.Text);
            cmd.Parameters.AddWithValue("@p5", txtsifre.Text);
            cmd.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("DOKTOR BİLGİLERİ BAŞARILI BİR ŞEKİLDE GÜNCELLENMİŞTİR", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
    }
}
