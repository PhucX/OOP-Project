using Guna.UI2.WinForms;
using QuanLyChiTieu.Excel;
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
    public partial class fThemKhoanChoVay : Form
    {
        public fThemKhoanChoVay()
        {
            InitializeComponent();
        }

        private void btnLuu_click(object sender, EventArgs e)
        {
            string idVay = DichVuVay.Instance.GetIdKhoanChoVay();
            string nguoiVay = txbNguoiChoVay.Text;
            double soTienVay = double.Parse(txbSoTienVay.Text);
            double laiSuat = double.Parse(txbLaiSuat.Text);
            string trangThai = "Chưa thanh toán";
            if (cbxTrangThai.SelectedItem.ToString() != "")
                trangThai = cbxTrangThai.SelectedItem.ToString();
            DateTime ngayDenHan = NgayDenHan.Value.Date;

            KhoanChoVay khoanChoVay = new KhoanChoVay(idVay, soTienVay, laiSuat, DateTime.Now, ngayDenHan, trangThai, nguoiVay);
            DichVuVay.Instance.Them(idVay, khoanChoVay);

            this.Close();
        }
    }
}
