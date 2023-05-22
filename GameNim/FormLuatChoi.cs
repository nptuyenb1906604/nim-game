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
    public partial class FormLuatChoi : Form
    {
        public FormLuatChoi()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormMoDau f = new FormMoDau();
            f.ShowDialog();
            this.Close();
        }
    }
}
