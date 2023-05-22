using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameNim
{
    public partial class FormMoDau : Form
    {
        public FormMoDau()
        {
            InitializeComponent();
        }
        private void nutChoiNgay_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormTroChoi f = new FormTroChoi();
            f.ShowDialog();
            this.Close();
        }
        private void nutChoiTiep_Click(object sender, EventArgs e)
        {
            FormTroChoi f = new FormTroChoi();
            f.choiTiep();
            this.Hide();
            f.ShowDialog();
            this.Close();
        }

        private void pbChoiNgay_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormTroChoi f = new FormTroChoi();
            f.ShowDialog();
            this.Close();
        }

        private void pbChoiTiep_Click(object sender, EventArgs e)
        {
            FormTroChoi f = new FormTroChoi();
            f.choiTiep();
            this.Hide();
            f.ShowDialog();
            this.Close();
        }

        private void pbLuatChoi_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormLuatChoi f = new FormLuatChoi();
            f.ShowDialog();
            this.Close();
        }
    }
}
