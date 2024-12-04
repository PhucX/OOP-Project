
using Guna.UI2.WinForms;
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
    public partial class fSuaGiaoDich : Form
    {
        private GiaoDich giaodich;
        public fSuaGiaoDich(string magiaodich)
        {
            InitializeComponent();
            bool laHopLe = DichVuGiaoDich.Instance.TimKiem(magiaodich);
            if (laHopLe)
                giaodich = DichVuGiaoDich.Instance.DanhSachGiaoDich[magiaodich];
            List<string> items = new List<string>{ "Thu nhập", "Chi tiêu" };
            foreach (string item in items)
            {
                cbxLoaiGiaoDich.Items.Add(item);
            }

            foreach (var taikhoan in DichVuTaiKhoan.Instance.DanhSachTaiKhoan)
            {
                cbxViDienTu.Items.Add(taikhoan.Value.TenTaiKhoan);
            }
            cbxLoaiGiaoDich.Text=giaodich.LoaiGiaoDich;
            txbTSoTien.Text=giaodich.SoTienGiaoDich.ToString();
            txbGhiChu.Text = giaodich.GhiChu;
            NgayGiaoDich.Text=giaodich.NgayGiaoDich.ToString();
            cbxViDienTu.Text = giaodich.ViDienTu.ToString();

        }
        private void fSuaGiaoDich_Load_1(object sender, EventArgs e)
        {
            //dgvGiaoDich.Rows.Clear();
            //foreach (var giaodich in DichVuGiaoDich.Instance.DanhSachGiaoDich)
            //{
            //    if (giaodich.Value != null)
            //        dgv_Them(giaodich.Value);
            //}
        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = cbxLoaiGiaoDich.SelectedItem.ToString();

            // Hiển thị loại giao dịch được chọn (ví dụ)
            MessageBox.Show("Bạn đã chọn: " + selectedValue);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string magiaodich = giaodich.MaGiaoDich;
            Double SoTien = Double.Parse(txbTSoTien.Text);
            string GhiChu = txbGhiChu.Text;
            DateTime ngaygiaodich = NgayGiaoDich.Value.Date;
            string loaigiaodich = cbxLoaiGiaoDich.SelectedItem.ToString();
            string viDienTu = cbxViDienTu.SelectedItem.ToString();
            if (viDienTu == null)
            {
                MessageBox.Show("Please select an item from the Vi Dien Tu ComboBox.");
                return;
            }

            DichVuGiaoDich.Instance.CapNhat(magiaodich, new Modules.GiaoDich(magiaodich, ngaygiaodich, SoTien, loaigiaodich, GhiChu, viDienTu));

            this.Close();
        }

        private void guna2ComboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
    }
}
