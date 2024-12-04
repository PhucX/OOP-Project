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
            if (Double.Parse(txbSoTienVay.Text) < 0)
            {
                MessageBox.Show("Không được nhập số âm", "Lỗi");
                return;
            }
            string idVay = DichVuVay.Instance.GetIdKhoanChoVay();
            string nguoiVay = txbNguoiChoVay.Text;
            double soTienVay = double.Parse(txbSoTienVay.Text);
            double laiSuat = double.Parse(txbLaiSuat.Text);
            string trangThai = cbxTrangThai.SelectedItem.ToString();
            DateTime ngayDenHan = NgayDenHan.Value.Date;

            if (new Excel.ExcelSearcher().SearchUser(Objects.ConnectionFile.GetFileConnectionAccount(), nguoiVay))
            {
                DichVuVay.Instance.Them(idVay, new Modules.KhoanChoVay(idVay, soTienVay, laiSuat, DateTime.Now, ngayDenHan, trangThai, nguoiVay));
                KhoanChoVay khoanChoVay = new KhoanChoVay(idVay, soTienVay, laiSuat, DateTime.Now, ngayDenHan, trangThai, nguoiVay);
                DichVuVay.Instance.Them(idVay, khoanChoVay);

                new DataCreator(new TaoFileKhoanVay()).ThemKhoanChoVay(Objects.ConnectionFile.StringConnection + $"\\Data\\{nguoiVay}\\LoanAndDebt.xlsx", nguoiVay, khoanChoVay);

                this.Close();
            }
            else
                MessageBox.Show("Người dùng không tồn tại.", "Thông báo");
        }
    }
}
