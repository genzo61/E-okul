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

namespace okulproje
{
    public partial class frmkulup : Form
    {
        public frmkulup()
        {
            InitializeComponent();
        }
        SqlConnection baglantı = new SqlConnection(@"Data Source=DESKTOP-CMEGFEH\SQLEXPRESS;Initial Catalog=okul;Integrated Security=True");
       public void liste()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from TBLKULUP", baglantı);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        
        private void button3_Click(object sender, EventArgs e)
        {
            baglantı.Open();
            SqlCommand komut = new SqlCommand("insert into TBLKULUP (KULUPAD) values (@p1)", baglantı);
            komut.Parameters.AddWithValue("@p1", txtkulupadı.Text);
            komut.ExecuteNonQuery();
            baglantı.Close();
            MessageBox.Show("kulup listeye eklendi", "bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            liste();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            liste();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglantı.Open();
            SqlCommand komut = new SqlCommand("update TBLKULUP set KULUPAD=@P1 where KULUPID=@P2", baglantı);
            komut.Parameters.AddWithValue("@p1", txtkulupadı.Text);
            komut.Parameters.AddWithValue("@p2", txtkulupid.Text);
            komut.ExecuteNonQuery();
            baglantı.Close();
            liste();
            MessageBox.Show("kulüp güncellendi", "bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
             
        }

        private void frmkulup_Load(object sender, EventArgs e)
        {
            liste();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtkulupid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtkulupadı.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();

        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            baglantı.Open();
            SqlCommand komut = new SqlCommand("delete from TBLKULUP WHERE KULUPID=@P1", baglantı);
            komut.Parameters.AddWithValue("@p1", txtkulupid.Text);
            komut.ExecuteNonQuery();
            baglantı.Close();
            liste();
            MessageBox.Show("kulüp silindi", "bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
