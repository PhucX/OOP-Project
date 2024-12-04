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
            string taiKhoan = QuanLyChiTieu.Objects.ConnectionFile.currentAccount;

            // cập nhật các khoản vay
            string childpath = QuanLyChiTieu.Objects.ConnectionFile.GetFileChildConnection("LoanAndDebt");
            string filepath = QuanLyChiTieu.Objects.ConnectionFile.GetFileConnection(childpath);
            new DataManager(new ExcelExporter()).ExportKhoanVay(taiKhoan, filepath);

            // cập nhật các khoản giao dịch
            childpath = QuanLyChiTieu.Objects.ConnectionFile.GetFileChildConnection("LoanAndDebt");
            childpath = QuanLyChiTieu.Objects.ConnectionFile.GetFileConnection(childpath);
            new DataManager(new ExcelExporter()).ExportKhoanVay(taiKhoan, filepath);
        }

        private void fNguoiDung_Load(object sender, EventArgs e)
        {
            foreach(TaiKhoan taiKhoan in DichVuTaiKhoan.Instance.DanhSachTaiKhoan.Values)
                dgvViDienTu.Rows.Add(taiKhoan.TenTaiKhoan, taiKhoan.SoDu.ToString());   
        }
    }
}
