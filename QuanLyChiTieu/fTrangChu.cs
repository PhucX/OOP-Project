using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyChiTieu
{
    public partial class fTrangChu : Form
    {
        public fTrangChu()
        {
            InitializeComponent();
        }

        private bool isFirstClick = true;
        private void guna2PictureBox3_Click(object sender, EventArgs e)
        {

            if (isFirstClick)
            {
                lbTongSoDu.Text = 123.ToString();
                lbTongSoDu.Text += " VND";
                isFirstClick = false;
            }
            else
            {
                this.lbTongSoDu.Text = "************";
                isFirstClick = true;
            }
        }

        private void ptbThongBao_Click(object sender, EventArgs e)
        {
            fThongBaoDenHan f = new fThongBaoDenHan();
            f.ShowDialog();
        }
    }
}
