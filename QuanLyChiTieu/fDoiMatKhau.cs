using DocumentFormat.OpenXml.Spreadsheet;
using QuanLyChiTieu.Modules;
using QuanLyChiTieu.Objects;
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
    public partial class fDoiMatKhau : Form
    {
        public fDoiMatKhau()
        {
            InitializeComponent();
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            string matKhauCu = txbMatKhauCu.Text;
            string matKhauMoi = txbMatKhauMoi.Text;
            string matKhauDangNhap = NguoiDung.MatKhau;

            if (matKhauCu == matKhauDangNhap)
            {
                if (NguoiDung.IsValidPassword(matKhauMoi) && matKhauMoi == txbXacNhanMatKhau.Text)
                {
                    NguoiDung.MatKhau = matKhauMoi;
                    SaveData.SaveDataUser();
                    this.Close();
                }
            }
            else
                MessageBox.Show("Mật khẩu không chính xác", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
