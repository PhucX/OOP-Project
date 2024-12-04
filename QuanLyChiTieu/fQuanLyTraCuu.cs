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
                // thêm và load lại bảng hiển thị
                DichVuTaiKhoan.Instance.Them(taiKhoan, new Modules.TaiKhoan(taiKhoan, soDu));
                fTranCuuQuanLy_Load(sender, e);
                SaveData.SaveDataAccount();

                // lấy đường dẫn file
                string filepath = QuanLyChiTieu.Objects.ConnectionFile.GetFileConnection("LoanAndDebt");
                new QuanLyChiTieu.Excel.DataCreator(new TaoFileKhoanVay()).ThemSheet(filepath, taiKhoan);

                filepath = QuanLyChiTieu.Objects.ConnectionFile.GetFileConnection("Transaction");
                new QuanLyChiTieu.Excel.DataCreator(new TaoFileGiaoDich()).ThemSheet(filepath, taiKhoan);
            }
            else
                MessageBox.Show("Tài khoản đã tồn tại");

        }

        private void btnSuaVi_Click(object sender, EventArgs e)
        {
            if (index >= 0)
            {
                QuanLyChiTieu.Objects.ConnectionFile.currentAccount = dgvViDienTu.Rows[index].Cells[0].Value.ToString();

                UsedData.UsedDataLoan(); // lấy dữ liệu khoản vay
                UsedData.UsedDataTran(); // lấy dữ liệu giao dịch
            }
        }

        private void dgvViDienTu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                index = e.RowIndex;
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            new fChuyenKhoan().ShowDialog();
        }

        private void btnXoaTaiKhoan_Click(object sender, EventArgs e)
        {
            DichVuTaiKhoan.Instance.Xoa(QuanLyChiTieu.Objects.ConnectionFile.currentAccount);
        }
    }
}
