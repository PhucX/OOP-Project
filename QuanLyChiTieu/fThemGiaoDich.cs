
﻿using Guna.UI2.WinForms;
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
    public partial class fThemGiaoDich : Form
    {
        public fThemGiaoDich()
        {
            InitializeComponent();
            List<string> items = new List<string> { "Thu nhập", "Chi tiêu" };
            foreach (string item in items)
            {
                cbxLoaiGiaoDich.Items.Add(item);
            }
            cbxLoaiGiaoDich.SelectedIndex = 0;

            foreach (var taikhoan in DichVuTaiKhoan.Instance.DanhSachTaiKhoan)
            {
                cbxViDienTu.Items.Add(taikhoan.Value.TenTaiKhoan);
            }
            
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                string idgiaodich = DichVuGiaoDich.Instance.GetIdGiaoDich();
                DateTime ngaygiaodich = NgayGiaoDich.Value.Date;
                Double sotien = Double.Parse(txbTSoTien.Text);
                string loaigiaodich = cbxLoaiGiaoDich.Text;
                string ghichu = txbGhiChu.Text;
                string viDienTu = cbxViDienTu.Text;
                GiaoDich GIaoDich = new GiaoDich(idgiaodich, ngaygiaodich, sotien, loaigiaodich, ghichu, viDienTu);
                DichVuGiaoDich.Instance.Them(idgiaodich, GIaoDich);

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void fThemGiaoDich_Load(object sender, EventArgs e)
        {
            
            
        }
    }
}
