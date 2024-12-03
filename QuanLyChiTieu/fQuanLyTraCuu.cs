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
    public partial class fTranCuuQuanLy : Form
    {
        public fTranCuuQuanLy()
        {
            InitializeComponent();
        }

        private int index = -1;

        private void dgv_Them(TaiKhoan taiKhoan)
        {
            dgvViDienTu.Rows.Add(taiKhoan.TenTaiKhoan, taiKhoan.SoDu.ToString());
        }

        private void CapNhatHienThi()
        {
            guna2HtmlLabel2.Text = DichVuTaiKhoan.Instance.DanhSachTaiKhoan.Count.ToString();
        }

        private void fTranCuuQuanLy_Load(object sender, EventArgs e)
        {
            CapNhatHienThi();
            dgvViDienTu.Rows.Clear();

            foreach (var taiKhoan in DichVuTaiKhoan.Instance.DanhSachTaiKhoan)
                dgv_Them(taiKhoan.Value);
        }

        private void btnThemTaiKhoan_Click(object sender, EventArgs e)
        {
            string taiKhoan = txbTenVi.Text;
            double soDu = double.Parse(txbSoDu.Text);


            if (!DichVuTaiKhoan.Instance.DanhSachTaiKhoan.ContainsKey(taiKhoan))
            {
                // lấy đường dẫn file
                string childpath = QuanLyChiTieu.Objects.ConnectionFile.GetFileChildConnection("Accounts");
                string filepath = QuanLyChiTieu.Objects.ConnectionFile.GetFileConnection(childpath);

                // thêm và load lại bảng hiển thị
                DichVuTaiKhoan.Instance.Them(taiKhoan, new Modules.TaiKhoan(taiKhoan, soDu));
                fTranCuuQuanLy_Load(sender, e);
                new DataManager(new ExcelExporter()).ExportTaiKhoan(filepath);

                childpath = QuanLyChiTieu.Objects.ConnectionFile.GetFileChildConnection("LoanAndDebt");
                filepath = QuanLyChiTieu.Objects.ConnectionFile.GetFileConnection(childpath);
                new QuanLyChiTieu.Excel.DataCreator(new TaoFileKhoanVay()).ThemSheet(filepath, taiKhoan);

                childpath = QuanLyChiTieu.Objects.ConnectionFile.GetFileChildConnection("Transaction");
                filepath = QuanLyChiTieu.Objects.ConnectionFile.GetFileConnection(childpath);
                new QuanLyChiTieu.Excel.DataCreator(new TaoFileGiaoDich()).ThemSheet(filepath, taiKhoan);
            }
            else
                MessageBox.Show("Tài khoản đã tồn tại");

        }

        private void btnSuaVi_Click(object sender, EventArgs e)
        {
            if (index >= 0)
            {
                string currentAccount = dgvViDienTu.Rows[index].Cells[0].Value.ToString();
                QuanLyChiTieu.Objects.ConnectionFile.currentAccount = currentAccount;

                string childPathLoan = QuanLyChiTieu.Objects.ConnectionFile.GetFileChildConnection("LoanAndDebt");
                string childPathTran = QuanLyChiTieu.Objects.ConnectionFile.GetFileChildConnection("Transaction");

                string filepathTran = QuanLyChiTieu.Objects.ConnectionFile.GetFileConnection(childPathTran);
                string filepathLoan = QuanLyChiTieu.Objects.ConnectionFile.GetFileConnection(childPathLoan);

                DichVuGiaoDich.Instance.DanhSachGiaoDich.Clear();
                DichVuVay.Instance.DanhSachKhoanVay.Clear();

                new DataManager(new ExcelImporter()).ImportGiaoDich(filepathTran, currentAccount);
                new DataManager(new ExcelImporter()).ImportKhoanVay(filepathLoan, currentAccount);
            }
        }

        private void dgvViDienTu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                index = e.RowIndex;
        }
    }
}
