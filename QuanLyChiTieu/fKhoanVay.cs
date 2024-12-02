﻿using DocumentFormat.OpenXml.Spreadsheet;
using QuanLyChiTieu.Modules;
using QuanLyChiTieu.Objects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyChiTieu
{
    public partial class fKhoanVay : Form
    {
        public fKhoanVay()
        {
            InitializeComponent();
            dgvKhoanVay.MultiSelect = true;
        }

        private Queue<int> queueIndex = new Queue<int>(); // danh sách chứa các vị trí được chọn trong bảng
        private int phan_trang = 10;
        private int tong_so_trang = 0;
        private int trang_hien_tai = 1;
         
        private void dgv_Them(KhoanNo khoanNo)
        {
            dgvKhoanVay.Rows.Add(false, khoanNo.IdKhoanVay, khoanNo.NguoiChoVay, khoanNo.NgayDenHan.ToString(), khoanNo.SoTienVay.ToString(), khoanNo.LaiSuat.ToString(), khoanNo.TrangThai);
        }

        private void fKhoanVay_Load(object sender, EventArgs e)
        {
            dgvKhoanVay.Rows.Clear();
            int viTriBatDau = (trang_hien_tai - 1) * phan_trang;
            int viTriKetThuc = trang_hien_tai * phan_trang;
            int dem = 0;


            foreach (var khoanVay in DichVuVay.Instance.DanhSachKhoanVay)
            {
                if (dem >= viTriBatDau && dem < viTriKetThuc)
                {
                    KhoanNo khoanNo = khoanVay.Value as KhoanNo;

                    if (khoanNo != null)
                        dgv_Them(khoanNo);
                }
                ++dem;
            }
        }

        private void dgvKhoanVay_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Kiểm tra nếu cột là "xoaColumn" hoặc "suaColumn"
            if (e.ColumnIndex == this.dgvKhoanVay.Columns["xoaColumn"].Index ||
                e.ColumnIndex == this.dgvKhoanVay.Columns["suaColumn"].Index)
            {
                // Kiểm tra nếu giá trị là một hình ảnh
                if (e.Value is Image)
                {
                    // Thay đổi kích thước hình ảnh
                    Image originalImage = (Image)e.Value;
                    int newWidth = 20;  // Đặt chiều rộng của hình ảnh
                    int newHeight = 20; // Đặt chiều cao của hình ảnh

                    // Tạo một bitmap mới với kích thước mong muốn
                    Bitmap resizedImage = new Bitmap(originalImage, new Size(newWidth, newHeight));

                    // Đặt lại hình ảnh đã thay đổi kích thước làm giá trị cho ô
                    e.Value = resizedImage;
                }
            }
        }

        private void XoaKhoanVay()
        {
            while (queueIndex.Count > 0)
            {
                int index = queueIndex.Dequeue();
                string maVay = dgvKhoanVay.Rows[index].Cells["maVay"].Value.ToString();
                DichVuVay.Instance.Xoa(maVay); // xóa theo mã vay
            }
        }

        private void dgbKhoanVay_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Kiểm tra có click vào vùng dữ liệu
            {
                queueIndex.Enqueue(e.RowIndex);

                if (e.ColumnIndex == dgvKhoanVay.Columns["xoaColumn"].Index)
                {
                    // Xác nhận trước khi xóa
                    DialogResult result = MessageBox.Show(
                        "Bạn có chắc chắn muốn xóa giao dịch này?",
                        "Xác nhận xóa",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning
                    );
                    if (result == DialogResult.Yes)
                        XoaKhoanVay();

                    fKhoanVay_Load(sender, e);
                }
                else if (e.ColumnIndex == dgvKhoanVay.Columns["suaColumn"].Index)
                {
                    fSuaKhoanVay fSuaKhoanVay = new fSuaKhoanVay(dgvKhoanVay.Rows[e.RowIndex].Cells["maVay"].Value.ToString());
                    fSuaKhoanVay.ShowDialog();
                    fKhoanVay_Load(sender, e);
                }
                else if(e.ColumnIndex == dgvKhoanVay.Columns["chon"].Index)
                {
                    //MessageBox.Show("abc");
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            fThemKhoanVay fThemKhoanVay = new fThemKhoanVay();
            fThemKhoanVay.ShowDialog();
            fKhoanVay_Load(sender, e);
        }

        private void ptbTimKiem_Click(object sender, EventArgs e)
        {
            string searchText = txbTimKiem.Text.Trim();
            if (string.IsNullOrEmpty(searchText)) // kiểm tra văn bản có rỗng hay không
            {
                fKhoanVay_Load(sender, e);
                return;
            }

            dgvKhoanVay.Rows.Clear(); // xóa bảng hiển thị trước khi tìm kiếm

            List<KhoanNo> giaTriThoaMan = DichVuVay.Instance.DanhSachKhoanVay.Where(khoanVay => khoanVay.Key.Contains(searchText) || ((KhoanNo)khoanVay.Value).NguoiChoVay.Contains(searchText)).Select(khoanVay => (KhoanNo)khoanVay.Value).ToList();

            // Thêm kết quả vào DataGridView
            foreach (var khoanNo in giaTriThoaMan)
                dgv_Them(khoanNo);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            XoaKhoanVay();
            fKhoanVay_Load(sender, e);
        }

        private void CapNhatDuLieu(List<object> rowData)
        {
            try
            {
                KhoanNo khoanNo = new KhoanNo(rowData[1].ToString(), double.Parse(rowData[4].ToString()), double.Parse(rowData[5].ToString()), DateTime.Parse(rowData[3].ToString()), rowData[6].ToString(), rowData[2].ToString());

                DichVuVay.Instance.CapNhat(rowData[1].ToString(), khoanNo);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvKhoanVay_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra nếu là ô cần thiết (ví dụ: ô dữ liệu thay đổi)
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Lấy hàng đã thay đổi
                DataGridViewRow row = dgvKhoanVay.Rows[e.RowIndex];

                // Duyệt qua tất cả các ô trong hàng và lấy giá trị
                List<object> rowData = new List<object>();

                foreach (DataGridViewCell cell in row.Cells)
                    rowData.Add(cell.Value); // Thêm giá trị của mỗi ô vào danh sách rowData

                CapNhatDuLieu(rowData);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string taiKhoan = QuanLyChiTieu.Objects.ConnectionFile.currentAccount;
            string childpath = QuanLyChiTieu.Objects.ConnectionFile.GetFileChildConnection("LoanAndDebt");
            string filepath = QuanLyChiTieu.Objects.ConnectionFile.GetFileConnection(childpath);
            new DataManager(new ExcelExporter()).ExportKhoanVay(taiKhoan, filepath);
        }
    }
}
