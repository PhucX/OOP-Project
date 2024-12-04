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
            foreach (TaiKhoan taiKhoan in DichVuTaiKhoan.Instance.DanhSachTaiKhoan.Values)
            {
                if(taiKhoan.TenTaiKhoan != ConnectionFile.currentAccount && taiKhoan.LoaiThe != "Tiền mặt")
                    guna2ComboBox2.Items.Add(taiKhoan.TenTaiKhoan);
            }
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
                string idgiaodich = DichVuGiaoDich.Instance.GetIdGiaoDich();
                DateTime ngaygiaodich = DateTime.Now;
                Double sotien = tienChuyen;
                string loaigiaodich = "Chuyển khoản";
                string ghichu = "None";
                string viDienTu = taiKhoan;
                GiaoDich GIaoDich = new GiaoDich(idgiaodich, ngaygiaodich, sotien, loaigiaodich, ghichu, viDienTu);
                DichVuGiaoDich.Instance.Them(idgiaodich, GIaoDich);
                fGiaoDich.Instance.fGiaoDich_Load(sender,e);

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
