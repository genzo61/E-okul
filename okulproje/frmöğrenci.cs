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
    public partial class frmöğrenci : Form
    {
        public frmöğrenci()
        {
            InitializeComponent();
        }
        SqlConnection baglantı = new SqlConnection(@"Data Source=DESKTOP-CMEGFEH\SQLEXPRESS;Initial Catalog=okul;Integrated Security=True");
        DataSet1TableAdapters.TBLOGRENCITableAdapter ds = new DataSet1TableAdapters.TBLOGRENCITableAdapter();

        private void frmöğrenci_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.öğrencilistesi();
            baglantı.Open();
            SqlCommand komut = new SqlCommand("select * from TBLKULUP", baglantı);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cmbkulup.DisplayMember = "KULUPAD";
            cmbkulup.ValueMember = "KULUPID";
            cmbkulup.DataSource = dt;
            baglantı.Close();

        }
        string c = "";
        private void btnekle_Click(object sender, EventArgs e)
        {
            ds.öğrenciekle(txtad.Text, textsoyad.Text, byte.Parse(cmbkulup.SelectedValue.ToString()), c);
            MessageBox.Show("öğrenci ekleme yapıldı");
        }

        private void btnlistele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.öğrencilistesi();
        }

        private void cmbkulup_SelectedIndexChanged(object sender, EventArgs e)
        {
          //txtid.Text = cmbkulup.SelectedValue.ToString();
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            ds.ÖĞRENCİSİL(int.Parse(txtid.Text));
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtad.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textsoyad.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            //
            //
        }

        private void btngüncelle_Click(object sender, EventArgs e)
        {
            ds.ÖĞRENCİGÜNCELLE(txtad.Text, textsoyad.Text, byte.Parse(cmbkulup.SelectedValue.ToString()), c, int.Parse(txtid.Text));
        
             
        }

        private void rderkek_CheckedChanged(object sender, EventArgs e)
        {
            if (rderkek.Checked == true)
            {
                c = "KIZ";
            }
            if (rdkız.Checked == true)
            {
                c = "ERKEK";
            }
        }

        private void rdkız_CheckedChanged(object sender, EventArgs e)
        {
            if (rderkek.Checked == true)
            {
                c = "KIZ";
            }
            if (rdkız.Checked == true)
            {
                c = "ERKEK";
            }
        }

        private void btnbul_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.ÖĞRENCİGETİR(txtara.Text);
        }
    }
}
