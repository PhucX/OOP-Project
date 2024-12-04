using Guna.UI2.WinForms;
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
    public partial class fChuyenKhoan : Form
    {
        public fChuyenKhoan()
        {
            InitializeComponent();
        }

        private string taiKhoanHienTai;

        private void fChuyenKhoan_Load(object sender, EventArgs e)
        {
            guna2HtmlLabel8.Text = QuanLyChiTieu.Objects.ConnectionFile.currentAccount;
            taiKhoanHienTai = guna2HtmlLabel8.Text;

            // Truyền danh sách vào ComboBox
            guna2ComboBox2.DataSource = DichVuTaiKhoan.Instance.DanhSachTaiKhoan.ToList();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string taiKhoan = guna2ComboBox2.Text;

            try
            {
                double tienA = DichVuTaiKhoan.Instance.DanhSachTaiKhoan[taiKhoanHienTai].SoDu;
                double tienB = DichVuTaiKhoan.Instance.DanhSachTaiKhoan[taiKhoan].SoDu;
                double tienChuyen = double.Parse(guna2TextBox1.Text);

                if (tienA - tienChuyen < 0)
                {
                    MessageBox.Show("Số dư không đủ để thực hiện", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DichVuTaiKhoan.Instance.DanhSachTaiKhoan[taiKhoan].SoDu += tienChuyen;
                DichVuTaiKhoan.Instance.DanhSachTaiKhoan[taiKhoanHienTai].SoDu -= tienChuyen;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
