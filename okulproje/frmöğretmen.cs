﻿using System;
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
    public partial class frmöğretmen : Form
    {
        public frmöğretmen()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmkulup fr = new frmkulup();
            fr.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmdersler fr = new frmdersler();
            fr.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            frmöğrenci fr = new frmöğrenci();
            fr.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmsınavnotlar fr = new frmsınavnotlar();
            fr.Show();
            this.Hide();
        }
    }
}
