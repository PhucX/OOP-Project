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
    public partial class fNguoiDung : Form
    {
        public fNguoiDung()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            // cập nhật các tài khoản
            SaveData.SaveDataAccount();

            // cập nhật các khoản vay
            SaveData.SaveDataLoan();

            // cập nhật các khoản giao dịch
            SaveData.SaveDataTran();
        }

        private void fNguoiDung_Load(object sender, EventArgs e)
        {
            dgvViDienTu.Rows.Clear();

            foreach (TaiKhoan taiKhoan in DichVuTaiKhoan.Instance.DanhSachTaiKhoan.Values.Where(the => the.LoaiThe == "Tiền mặt"))
                dgvViDienTu.Rows.Add(taiKhoan.TenTaiKhoan, taiKhoan.SoDu.ToString());

            guna2HtmlLabel12.Text = NguoiDung.TenNguoiDung;
            lbTenDangNhap.Text = NguoiDung.TaiKhoanNguoiDung;
            lbSoDienThoai.Text = NguoiDung.SoDienThoai;
            lbDiaChi.Text = NguoiDung.DiaChi;
        }

        private void btnCapNhatThongTin_Click(object sender, EventArgs e)
        {
            NguoiDung nguoiDung = new NguoiDung(NguoiDung.TaiKhoanNguoiDung, NguoiDung.MatKhau);
            NguoiDung.CapNhatNguoiDung(txbTenNguoiDung.Text, txbSoDienThoai.Text, txbDiaChi.Text);

            SaveData.SaveDataUser();

            fNguoiDung_Load(sender, e);
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            new fDoiMatKhau().ShowDialog();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            this.Close();
            new fDangNhap().ShowDialog();
        }
    }
}
