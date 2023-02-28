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

namespace KelimeOgrenme
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        sqlbaglantı bgl = new sqlbaglantı();
        int kayitSayisi=1;
        Random rnd = new Random();



        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            

            






            SqlCommand komut = new SqlCommand("select count(*) from Kelime", bgl.baglanti());    
            kayitSayisi = Convert.ToInt32(komut.ExecuteScalar());

            List<int> numbers = new List<int>();

            while (numbers.Count < 4)
            {
                int newNumber = rnd.Next(1, kayitSayisi);
                if (!numbers.Contains(newNumber))
                {
                    numbers.Add(newNumber);
                }
            }

            komut.ExecuteNonQuery();

            
            SqlCommand komut1 = new SqlCommand("SELECT * FROM Kelime where kelimeid=@p1", bgl.baglanti());
            komut1.Parameters.AddWithValue("@p1", numbers[0]);

            SqlDataReader reader1 = komut1.ExecuteReader();
            if (reader1.Read())
            {
                label1.Text = reader1["ingilizceKelime"].ToString();
                label2.Text = reader1["turkceKelime"].ToString();
            }
           

            SqlCommand komut2 = new SqlCommand("SELECT * FROM Kelime where kelimeid=@p1", bgl.baglanti());
            komut2.Parameters.AddWithValue("@p1", numbers[1]);

            SqlDataReader reader2 = komut2.ExecuteReader();
            if (reader2.Read())
            {
                
                label3.Text = reader2["turkceKelime"].ToString();
            }
            
            SqlCommand komut3 = new SqlCommand("SELECT * FROM Kelime where kelimeid=@p1", bgl.baglanti());
            komut3.Parameters.AddWithValue("@p1", numbers[2]);

            SqlDataReader reader3 = komut3.ExecuteReader();
            if (reader3.Read())
            {

                label4.Text = reader3["turkceKelime"].ToString();
            }

            SqlCommand komut4 = new SqlCommand("SELECT * FROM Kelime where kelimeid=@p1", bgl.baglanti());
            komut4.Parameters.AddWithValue("@p1", numbers[3]);

            SqlDataReader reader4 = komut4.ExecuteReader();
            if (reader4.Read())
            {

                label5.Text = reader4["turkceKelime"].ToString();
            }
            bgl.baglanti().Close();

            if (numbers[0] < numbers[1])
            {

            }




        }
    }
}
