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
    public partial class fThanhToan : Form
    {
        private string maVay;
        public fThanhToan(string maVay)
        {
            InitializeComponent();
            this.maVay = maVay;

            foreach (var taiKhoan in DichVuTaiKhoan.Instance.DanhSachTaiKhoan.Values)
                cbxViDienTu.Items.Add(taiKhoan.TenTaiKhoan);

            guna2HtmlLabel3.Text = maVay;
        }

        private void TraNoTienVay()
        {
            KhoanNo khoanNo = DichVuVay.Instance.DanhSachKhoanVay[maVay] as KhoanNo;

            if (khoanNo != null)
            {
                try
                {
                    double soTienTra = double.Parse(guna2TextBox1.Text);
                    string viDienTu = cbxViDienTu.Text;

                    if (soTienTra <= 0)
                    {
                        MessageBox.Show("Vui lòng nhập lại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (DichVuTaiKhoan.Instance.DanhSachTaiKhoan[viDienTu].SoDu < soTienTra)
                    {
                        MessageBox.Show("Số dư không đủ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (soTienTra > khoanNo.SoDuNo)
                    {
                        MessageBox.Show("Vượt mức cho phép", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    double soTien = khoanNo.ThanhToan(soTienTra);
                    
                    DichVuTaiKhoan.Instance.DanhSachTaiKhoan[viDienTu].SoDu -= soTienTra; // trừ số tiền vào tài khoản

                    // cập nhật lại khoản vay
                    if (khoanNo.SoDuNo == 0)
                        khoanNo.TrangThai = "Đã thanh toán";

                    DichVuVay.Instance.DanhSachKhoanVay[maVay] = khoanNo;
                    DichVuVay.Instance.DanhSachKhoanVay[maVay].DanhSachThanhToan.Add(new ThanhToan(soTienTra, DateTime.Now, viDienTu));

                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi xảy raã: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void HoanTraTienVay()
        {
            KhoanChoVay khoanChoVay = DichVuVay.Instance.DanhSachKhoanVay[maVay] as KhoanChoVay;

            if (khoanChoVay != null)
            {
                try
                {
                    double soTienHoanTra = double.Parse(guna2TextBox1.Text);
                    string viDienTu = cbxViDienTu.Text;

                    if (soTienHoanTra <= 0)
                    {
                        MessageBox.Show("Vui lòng nhập lại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (soTienHoanTra > khoanChoVay.SoTienBiThieu)
                    {
                        MessageBox.Show("Vượt mức cho phép", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    double soTien = khoanChoVay.ThanhToan(soTienHoanTra);

                    // cộng số tiền vào tài khoản
                    DichVuTaiKhoan.Instance.DanhSachTaiKhoan[viDienTu].SoDu += soTienHoanTra; 

                    // cập nhật lại khoản vay
                    if (khoanChoVay.SoTienBiThieu == 0)
                        khoanChoVay.TrangThai = "Đã thanh toán";

                    DichVuVay.Instance.DanhSachKhoanVay[maVay] = khoanChoVay;
                    DichVuVay.Instance.DanhSachKhoanVay[maVay].DanhSachThanhToan.Add(new ThanhToan(soTienHoanTra, DateTime.Now, viDienTu));

                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi xảy raã: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (maVay.Contains("debt"))
                TraNoTienVay();
            else
                HoanTraTienVay();
        }
    }
}
