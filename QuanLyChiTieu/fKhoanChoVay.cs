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
    public partial class fKhoanChoVay : Form
    {
        public fKhoanChoVay()
        {
            InitializeComponent();
        }
        private Queue<int> queueIndex = new Queue<int>(); // danh sách chứa các vị trí được chọn trong bảng
        private void dgv_Them(KhoanChoVay _khoanChoVay)
        {
            dgvKhoanChoVay.Rows.Add(false, _khoanChoVay.IdKhoanVay, _khoanChoVay.NguoiVay, _khoanChoVay.NgayDenHan.ToString(), _khoanChoVay.SoTienVay.ToString(), _khoanChoVay.LaiSuat.ToString(), _khoanChoVay.TrangThai);
        }

        private void fKhoanChoVay_Load(object sender, EventArgs e)
        {
            dgvKhoanChoVay.Rows.Clear();

            foreach (var khoanChoVay in DichVuChoVay.Instance.DanhSachKhoanChoVay)
            {
                KhoanChoVay _khoanChoVay = khoanChoVay.Value as KhoanChoVay;

                if (_khoanChoVay != null)
                    dgv_Them(_khoanChoVay);
            }

            new DataManager(new ExcelExporter()).ExportKhoanVay("nha123vo", ConnectionFile.GetFileConnection("\\Data\\nha123vo\\LoanAndDebt.xlsx"));
        }
        private void dgvKhoanChoVay_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Kiểm tra nếu cột là "xoaColumn" hoặc "suaColumn"
            if (e.ColumnIndex == this.dgvKhoanChoVay.Columns["xoaColumn"].Index ||
                e.ColumnIndex == this.dgvKhoanChoVay.Columns["suaColumn"].Index)
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
        private void dgvKhoanChoVay_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Kiểm tra có click vào vùng dữ liệu
            {
                queueIndex.Enqueue(e.RowIndex);

                if (e.ColumnIndex == dgvKhoanChoVay.Columns["xoaColumn"].Index)
                {
                    // Xác nhận trước khi xóa
                    DialogResult result = MessageBox.Show(
                        "Bạn có chắc chắn muốn xóa giao dịch này?",
                        "Xác nhận xóa",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning
                    );
                    if (result == DialogResult.Yes)
                        XoaKhoanChoVay();

                    fKhoanChoVay_Load(sender, e);
                }
                else if (e.ColumnIndex == dgvKhoanChoVay.Columns["suaColumn"].Index)
                {
                    fSuaKhoanChoVay fSuaKhoanChoVay = new fSuaKhoanChoVay(dgvKhoanChoVay.Rows[e.RowIndex].Cells["maVay"].Value.ToString());
                    fSuaKhoanChoVay.ShowDialog();
                    fKhoanChoVay_Load(sender, e);
                }
            }
        }
        private void XoaKhoanChoVay()
        {
            while (queueIndex.Count > 0)
            {
                int index = queueIndex.Dequeue();
                string maVay = dgvKhoanChoVay.Rows[index].Cells["maVay"].Value.ToString();
                DichVuChoVay.Instance.Xoa(maVay); // xóa theo mã vay
            }
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            fThemKhoanChoVay fThemKhoanChoVay = new fThemKhoanChoVay();
            fThemKhoanChoVay.ShowDialog();
            fKhoanChoVay_Load(sender, e);
        }
        private void ptbTimKiem_Click(object sender, EventArgs e)
        {
            string searchText = txbTimKiem.Text.Trim();
            if (string.IsNullOrEmpty(searchText)) // kiểm tra văn bản có rỗng hay không
            {
                fKhoanChoVay_Load(sender, e);
                return;
            }

            dgvKhoanChoVay.Rows.Clear(); // xóa bảng hiển thị trước khi tìm kiếm

            List<KhoanChoVay> giaTriThoaMan = DichVuChoVay.Instance.DanhSachKhoanChoVay.Where(khoanChoVay => khoanChoVay.Key.Contains(searchText) || ((KhoanChoVay)khoanChoVay.Value).NguoiVay.Contains(searchText)).Select(khoanChoVay => (KhoanChoVay)khoanChoVay.Value).ToList();

            // Thêm kết quả vào DataGridView
            foreach (var khoanChoVay in giaTriThoaMan)
                dgv_Them(khoanChoVay);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            XoaKhoanChoVay();
            fKhoanChoVay_Load(sender, e);
        }
    }
}
