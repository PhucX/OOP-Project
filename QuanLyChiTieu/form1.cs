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
    public partial class fDangNhap : Form
    {
        public fDangNhap()
        {
            InitializeComponent();
        }

       

        private void label3_Click(object sender, EventArgs e)
        {
            guna2ShadowPanel1.Visible = true;

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            guna2ShadowPanel1.Visible = false;

        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (txbTaiKhoan.Text == "" || txbMatKhau.Text == "")
            {
                MessageBox.Show("Tài khoản hay mật khẩu không hợp lệ" +
                " !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                fBangDieuKhien   form2 = new fBangDieuKhien();
                this.Hide();
                form2.ShowDialog(); 
                this.Close();
            }
        }
    }
}
