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
    public partial class SEKRETER_BRANŞ_ : Form
    {
        public SEKRETER_BRANŞ_()
        {
            InitializeComponent();
        }

        sqlbaglanti bgl = new sqlbaglanti();
        private void SEKRETER_BRANŞ__Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from tbl_branslar", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into tbl_branslar (BransAd) values (@p1)" , bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", textBox2.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("DOKTOR BAŞARILI BİR ŞEKİLDE EKLENMİŞTİR", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            textBox2.Text = " ";
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            textBox1.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("delete from tbl_branslar where bransid=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", textBox1.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("KAYIT SİLİNDİ", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("update  Tbl_Branslar set bransad=@p1 where bransid=@p2", bgl.baglanti());
            cmd.Parameters.AddWithValue("@p1", textBox2.Text);
            cmd.Parameters.AddWithValue("@p2", textBox1.Text);
            cmd.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("BRANS BİLGİLERİ BAŞARILI BİR ŞEKİLDE GÜNCELLENMİŞTİR", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            textBox1.Text = " ";
            textBox2.Text = " ";
        }
    }
}
