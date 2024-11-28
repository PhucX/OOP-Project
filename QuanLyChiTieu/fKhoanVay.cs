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
        }

        private void fKhoanVay_Load(object sender, EventArgs e)
        {
            dgvKhoanVay.Rows.Add(false, "Nguyễn Văn A", "01/12/2024", "5,000,000", "5%", "Chưa thanh toán");
            dgvKhoanVay.Rows.Add(false, "Lê Thị B", "15/12/2024", "10,000,000", "10%", "Đã thanh toán");
            dgvKhoanVay.Rows.Add(false, "Trần Văn C", "20/12/2024", "3,000,000", "3%", "Quá hạn");
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
        private void dgbKhoanVay_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Kiểm tra có click vào vùng dữ liệu
            {
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
                        dgvKhoanVay.Rows.RemoveAt(e.RowIndex); // Xóa dòng
                    }
                }
                else if (e.ColumnIndex == dgvKhoanVay.Columns["suaColumn"].Index)
                {
                    fSuaKhoanVay fSuaKhoanVay = new fSuaKhoanVay();
                    fSuaKhoanVay.ShowDialog();
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            fThemKhoanVay fThemKhoanVay = new fThemKhoanVay();
            fThemKhoanVay.ShowDialog();
        }

    }
}
