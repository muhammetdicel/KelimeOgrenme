using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace KelimeOgrenme
{
    class sqlbaglantı
    {
        public SqlConnection baglanti()
        {
            SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-TCEOMIL\\SQLEXPRESS;Initial Catalog=Kelimeler;Integrated Security=True");
            baglan.Open();
            return baglan;
        }

    }
}
