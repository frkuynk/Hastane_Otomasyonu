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
    public partial class DOKTORDETAY : Form
    {
        public DOKTORDETAY()
        {
            InitializeComponent();
        }

        sqlbaglanti bgl = new sqlbaglanti();
        public string TC;
        private void DOKTORDETAY_Load(object sender, EventArgs e)
        {
            lbltc.Text = TC;

            //doktor adsoyad çekme
            SqlCommand komut = new SqlCommand("select doktorad,doktorsoyad from tbl_doktorlar where doktortc=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1" , lbltc.Text);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())  // if sadece girişlerde kullanılır 
            {
                lbladsoyad.Text = oku[0]  + " " + oku[1];
            }
            bgl.baglanti().Close();

            //randevugetir
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from tbl_randevular where randevudoktor = '" + lbladsoyad.Text + "'" , bgl.baglanti());    
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DOKTORBİLGİGÜNCELLEME güncel = new DOKTORBİLGİGÜNCELLEME();
            güncel.TC1 = lbltc.Text;
            güncel.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MESAJLAR msj = new MESAJLAR();
            msj.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            richTextBox1.Text = dataGridView1.Rows[secilen].Cells[7].Value.ToString();
        }
    }
}
