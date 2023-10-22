using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace okulproje
{
    public partial class frmdersler : Form
    {
        public frmdersler()
        {
            InitializeComponent();
        }
        DataSet1TableAdapters.TBLDERSLERTableAdapter ds = new DataSet1TableAdapters.TBLDERSLERTableAdapter();

        private void frmdersler_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.Derslistesi();
        }

        private void btnekle_Click(object sender, EventArgs e)
        {
            ds.Dersekle(txtkulupadı.Text);
            MessageBox.Show("ders ekleme işlemi yapıldı");
        }

        private void btnlistele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.Derslistesi();
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            ds.Derssil(byte.Parse(txtkulupid.Text));
            MessageBox.Show("ders silindi");
        }

        private void btngüncelle_Click(object sender, EventArgs e)
        {
            ds.Dersgüncelle(txtkulupadı.Text,byte.Parse(txtkulupid.Text));
            MessageBox.Show("dersler güncellendi");

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtkulupid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
           txtkulupadı.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }
    }
}
