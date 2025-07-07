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
    public partial class SEKRETER_RANDEVU_ : Form
    {
        public SEKRETER_RANDEVU_()
        {
            InitializeComponent();
        }

        sqlbaglanti bgl = new sqlbaglanti();
        private void SEKRETER_RANDEVU__Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable( );
            SqlDataAdapter da = new SqlDataAdapter("select * from tbl_randevular", bgl.baglanti());
            da.Fill( dt );
            dataGridView1.DataSource = dt;
        }
    }
}
