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
    public partial class frmsınavnotlar : Form
    {
        public frmsınavnotlar()
        {
            InitializeComponent();
        }
        DataSet1TableAdapters.TBLNOTLARTableAdapter ds = new DataSet1TableAdapters.TBLNOTLARTableAdapter();
        SqlConnection baglantı = new SqlConnection(@"Data Source=DESKTOP-CMEGFEH\SQLEXPRESS;Initial Catalog=okul;Integrated Security=True");

        private void frmsınavnotlar_Load(object sender, EventArgs e)
        {
            baglantı.Open();
            SqlCommand komut = new SqlCommand("select * from TBLDERSLER", baglantı);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox1.DisplayMember = "DERSAD";
            comboBox1.ValueMember = "DERSID";
            comboBox1.DataSource = dt;
            baglantı.Close();
        }

        int notid;

        private void btnARA_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.NOTLİSTESİ(int.Parse(txtıd.Text));

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            notid=int.Parse( dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            txtıd.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txts1.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txts2.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txts3.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtproje.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
         txtort.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            txtdurum.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
        }
        int sinav1, sinav2, sinav3, proje;
        double ortalama;
        private void btnhesapla_Click(object sender, EventArgs e)
        {
            
           // string durum;
            sinav1 = Convert.ToInt32(txts1.Text);
            sinav2 = Convert.ToInt32(txts2.Text);
            sinav3 = Convert.ToInt32(txts3.Text);
            proje = Convert.ToInt32(txtproje.Text);
            ortalama = (sinav1 + sinav2 + sinav3 + proje) / 4;
            txtort.Text = ortalama.ToString();
            if (ortalama>=50)
            {
                txtdurum.Text = "true";
            }
            else
            {
                txtdurum.Text = "false";
            }
           
        }

        private void btngüncelle_Click(object sender, EventArgs e)
        {
            ds.notgüncelle(byte.Parse(comboBox1.SelectedValue.ToString()), int.Parse(txtıd.Text),byte.Parse(txts1.Text),byte.Parse(txts2.Text),byte.Parse(txts3.Text),byte.Parse(txtproje.Text),decimal.Parse(txtort.Text),bool.Parse(txtdurum.Text), notid);

        }
    }
}
