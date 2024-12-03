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
using TheArtOfDevHtmlRenderer.Adapters;

namespace QuanLyChiTieu
{
    public partial class fSuaKhoanChoVay : Form
    {
        private KhoanVay khoanChoVay;
        public fSuaKhoanChoVay(string maVay)
        {
            InitializeComponent();
            bool laHopLe = DichVuVay.Instance.TimKiem(maVay);
            if (laHopLe)
                khoanChoVay = DichVuVay.Instance.DanhSachKhoanVay[maVay];
            
            KhoanChoVay _khoanChoVay = khoanChoVay as KhoanChoVay;

            txbNguoiVay.Text = _khoanChoVay.NguoiVay;
            txbSoTienVay.Text = _khoanChoVay.SoTienVay.ToString();
            txbLaiSuat.Text = _khoanChoVay.LaiSuat.ToString();
            cbxTrangThai.Text = _khoanChoVay.TrangThai;
            NgayDenHan.Text = _khoanChoVay.NgayDenHan.ToString();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string idVay = khoanChoVay.IdKhoanVay;
            string nguoiChoVay = txbNguoiVay.Text;
            double soTienVay = double.Parse(txbSoTienVay.Text);
            double laiSuat = double.Parse(txbLaiSuat.Text);
            string trangThai = cbxTrangThai.SelectedItem.ToString();
            DateTime ngayDenHan = NgayDenHan.Value.Date;

            KhoanChoVay _khoanChoVay = new KhoanChoVay(idVay, soTienVay, laiSuat, ngayDenHan, trangThai, nguoiChoVay);
            DichVuVay.Instance.CapNhat(_khoanChoVay.IdKhoanVay, _khoanChoVay);

            this.Close();
        }

    }
}
