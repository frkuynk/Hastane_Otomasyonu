using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Hastane_Proje
{
    internal class sqlbaglanti //sınıfımın adı 
    {
        public SqlConnection baglanti() // metodumun adı
        {
        SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-CQLN272\\SQLEXPRESS;Initial Catalog=Hastane_Otomasyon;Integrated Security=True;Encrypt=False");
        // baglan SqlConnection türettiğim ve adresimi tutan nesnemin adı 
        baglan.Open();  //open metod 
        return baglan;  // geriye dönen değeri tutan kısım

        }
    }
}
