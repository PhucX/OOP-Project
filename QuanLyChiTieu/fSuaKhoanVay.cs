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
    public partial class fSuaKhoanVay : Form
    {
        private KhoanVay khoanVay;
        public fSuaKhoanVay(string maVay)
        {
            InitializeComponent();
            bool laHopLe = DichVuVay.Instance.TimKiem(maVay);
            if (laHopLe)
                khoanVay = DichVuVay.Instance.DanhSachKhoanVay[maVay];
            KhoanNo khoanNo = khoanVay as KhoanNo;

            txbNguoiChoVay.Text = khoanNo.NguoiChoVay;
            txbSoTienVay.Text = khoanNo.SoTienVay.ToString();
            txbLaiSuat.Text = khoanNo.LaiSuat.ToString();
            guna2ComboBox1.Text = khoanNo.TrangThai;
            NgayDenHan.Text = khoanNo.NgayDenHan.ToString();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string idVay = khoanVay.IdKhoanVay;
            string nguoiChoVay = txbNguoiChoVay.Text;
            double soTienVay = double.Parse(txbSoTienVay.Text);
            double laiSuat = double.Parse(txbLaiSuat.Text);
            string trangThai = guna2ComboBox1.SelectedItem.ToString();
            DateTime ngayDenHan = NgayDenHan.Value.Date;

            KhoanNo khoanNo = new KhoanNo(idVay, soTienVay, laiSuat, ngayDenHan, trangThai, nguoiChoVay);
            DichVuVay.Instance.CapNhat(khoanVay.IdKhoanVay, khoanNo);

            this.Close();
        }

        private void fSuaKhoanVay_Load(object sender, EventArgs e)
        {

        }
    }
}
