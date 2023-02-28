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
    public partial class klmKayıt : Form
    {
        public klmKayıt()
        {
            InitializeComponent();
        }
        sqlbaglantı bgl = new sqlbaglantı();
       

        private void BtnKayıt_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into Kelime (ingilizceKelime,turkceKelime) values (@p1,@p2) ", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", Txtingilizce.Text);
            komut.Parameters.AddWithValue("@p2", TxtTurkce.Text);
            komut. ExecuteNonQuery();
            bgl.baglanti().Close();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update Kelime set ingilizceKelime=@p2 ,turkceKelime=@p3 where kelimeid=@p1", bgl.baglanti());
            
            komut.Parameters.AddWithValue("@p2", Txtingilizce.Text);
            komut.Parameters.AddWithValue("@p3", TxtTurkce.Text);
            komut.Parameters.AddWithValue("@p1", Txtid.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From Kelime", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            MessageBox.Show("Branş Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);


            
        }

        private void klmKayıt_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From Kelime", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            Txtid.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            Txtingilizce.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            TxtTurkce.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("delete From Kelime where kelimeid=@b1", bgl.baglanti());
            komut.Parameters.AddWithValue("@b1", Txtid.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From Kelime", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            MessageBox.Show("Branş Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
