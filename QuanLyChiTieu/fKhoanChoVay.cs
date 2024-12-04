using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
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
    public partial class fKhoanChoVay : Form
    {
        public fKhoanChoVay()
        {
            InitializeComponent();
            dgvKhoanChoVay.MultiSelect = true;
        }

        private int index;
        private void dgv_Them(KhoanChoVay _khoanChoVay)
        {
            dgvKhoanChoVay.Rows.Add(false, _khoanChoVay.IdKhoanVay, _khoanChoVay.NguoiVay, _khoanChoVay.NgayDenHan.ToString(), _khoanChoVay.SoTienVay.ToString(), _khoanChoVay.LaiSuat.ToString(), _khoanChoVay.TrangThai);
        }
        private void fKhoanChoVay_Load(object sender, EventArgs e)
        {
            dgvKhoanChoVay.Rows.Clear();

            foreach (var khoanChoVay in DichVuVay.Instance.DanhSachKhoanVay)
            {
                KhoanChoVay _khoanChoVay = khoanChoVay.Value as KhoanChoVay;

                if (_khoanChoVay != null)
                    dgv_Them(_khoanChoVay);
            }
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
                index = e.RowIndex;
                dgvDaThanhToan_Load();

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
            foreach (DataGridViewRow row in dgvKhoanChoVay.Rows)
            {
                // Kiểm tra xem dòng có phải là dòng data (không phải dòng tiêu đề hoặc dòng mới)
                if (!row.IsNewRow)
                {
                    // Lấy giá trị từ cột đầu tiên (chỉ số cột là 0)
                    var cellValue = row.Cells[0].Value;

                    // Kiểm tra trạng thái của checkbox
                    if (bool.Parse(cellValue.ToString()))
                        DichVuVay.Instance.Xoa(row.Cells[1].Value.ToString()); // xóa theo mã vay
                }
            }
        }

        private void CapNhatDuLieu(List<object> rowData)
        {
            try
            {
                DateTime ngayVay = DichVuVay.Instance.DanhSachKhoanVay[rowData[1].ToString()].NgayVay;
                KhoanChoVay khoanNo = new KhoanChoVay(rowData[1].ToString(), double.Parse(rowData[4].ToString()), double.Parse(rowData[5].ToString()), ngayVay, DateTime.Parse(rowData[3].ToString()), rowData[6].ToString(), rowData[2].ToString());

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
                DataGridViewRow row = dgvKhoanChoVay.Rows[e.RowIndex];

                // Duyệt qua tất cả các ô trong hàng và lấy giá trị
                List<object> rowData = new List<object>();

                foreach (DataGridViewCell cell in row.Cells)
                    rowData.Add(cell.Value); // Thêm giá trị của mỗi ô vào danh sách rowData

                CapNhatDuLieu(rowData);
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

            List<KhoanChoVay> giaTriThoaMan = DichVuVay.Instance.DanhSachKhoanVay.Where(khoanChoVay => khoanChoVay.Key.Contains(searchText) || ((KhoanChoVay)khoanChoVay.Value).NguoiVay.Contains(searchText)).Select(khoanChoVay => (KhoanChoVay)khoanChoVay.Value).ToList();

            // Thêm kết quả vào DataGridView
            foreach (var khoanChoVay in giaTriThoaMan)
                dgv_Them(khoanChoVay);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            XoaKhoanChoVay();
            fKhoanChoVay_Load(sender, e);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            SaveData.SaveDataLoan();
        }

        private void dgvDaThanhToan_Load()
        {
            dgvDaThanhToan.Rows.Clear();
            string maVay = dgvKhoanChoVay.Rows[index].Cells["maVay"].Value.ToString();
            KhoanNo khoanNo = (KhoanNo)DichVuVay.Instance.DanhSachKhoanVay[maVay];
            List<ThanhToan> cacKhoanVay = khoanNo.DanhSachThanhToan;

            for (int i = 0; i < cacKhoanVay.Count; i++)
                dgvDaThanhToan.Rows.Add(cacKhoanVay[i].NgayThanhToan.ToString(), cacKhoanVay[i].SoTienThanhToan.ToString(), khoanNo.SoDuNo.ToString());
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            string maVay = dgvKhoanChoVay.Rows[index].Cells["maVay"].Value.ToString();
            KhoanNo khoanNo = DichVuVay.Instance.DanhSachKhoanVay[maVay] as KhoanNo;
            khoanNo.ThanhToan(50000);

            DichVuVay.Instance.DanhSachKhoanVay[maVay] = khoanNo;

            dgvDaThanhToan_Load();
        }
    }
}
