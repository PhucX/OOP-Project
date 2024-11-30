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
    public partial class fKhoanVay : Form
    {
        public fKhoanVay()
        {
            InitializeComponent();
            dgvKhoanVay.MultiSelect = true;
        }

        private void fKhoanVay_Load(object sender, EventArgs e)
        {
            dgvKhoanVay.Rows.Clear();

            foreach (var khoanVay in DichVuVay.Instance.DanhSachKhoanVay)
            {
                KhoanNo khoanNo = khoanVay.Value as KhoanNo;

                if (khoanNo != null)
                {
                    dgvKhoanVay.Rows.Add(false, khoanNo.IdKhoanVay, khoanNo.NguoiChoVay, khoanNo.NgayDenHan.ToString(), khoanNo.SoTienVay.ToString(), khoanNo.LaiSuat.ToString(), khoanNo.TrangThai);
                }

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

        private Queue<int> queueIndex = new Queue<int>();
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
                    {
                        while(queueIndex.Count > 0)
                        {
                            int index = queueIndex.Dequeue();
                            string maVay = dgvKhoanVay.Rows[index].Cells["maVay"].Value.ToString();
                            DichVuVay.Instance.Xoa(maVay); // xoas  
                        }

                    }
                    fKhoanVay_Load(sender, e);
                }
                else if (e.ColumnIndex == dgvKhoanVay.Columns["suaColumn"].Index)
                {
                    fSuaKhoanVay fSuaKhoanVay = new fSuaKhoanVay(dgvKhoanVay.Rows[e.RowIndex].Cells["maVay"].Value.ToString());
                    fSuaKhoanVay.ShowDialog();
                    fKhoanVay_Load(sender, e);
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            fThemKhoanVay fThemKhoanVay = new fThemKhoanVay();
            fThemKhoanVay.ShowDialog();
            fKhoanVay_Load(sender, e);
        }

    }
}
