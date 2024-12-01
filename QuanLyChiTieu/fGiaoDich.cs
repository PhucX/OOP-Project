using QuanLyChiTieu.Modules;
using QuanLyChiTieu.Objects;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
//using DocumentFormat.OpenXml.Drawing.Charts;
namespace QuanLyChiTieu
{
    
    
    public partial class fGiaoDich : Form
    {
       public Guna2DataGridView Guna2DataGridView1;
        public fGiaoDich()
        {
            InitializeComponent();
            dgvGiaoDich.MultiSelect = true;
        
        }
        private Queue<int> queueIndex = new Queue<int>();
        
        private void dgv_Them(GiaoDich giaodich)
        {
            dgvGiaoDich.Rows.Add(false, giaodich.MaGiaoDich, giaodich.LoaiGiaoDich, giaodich.NgayGiaoDich.ToString(), giaodich.SoTienGiaoDich.ToString(), giaodich.GhiChu);
        
        }
        private void fGiaoDich_Load(object sender, EventArgs e)
        {

            // Điều chỉnh độ rộng của các cột
            dgvGiaoDich.Columns["xoaColumn"].Width = 50;  // Độ rộng cho cột xóa (biểu tượng khóa)
            dgvGiaoDich.Columns["suaColumn"].Width = 50;  // Độ rộng cho cột sửa (biểu tượng bút chì)
            dgvGiaoDich.Columns["loaiGiaoDich"].Width = 150;  // Độ rộng cho cột mã giao dịch
            dgvGiaoDich.Columns["ngayGiaoDich"].Width = 150; // Độ rộng cho cột ngày giao dịch
            dgvGiaoDich.Columns["soTien"].Width = 100; // Độ rộng cho cột số tiền
            dgvGiaoDich.Columns["ghiChu"].Width = 200; // Độ rộng cho cột ghi chú

            // Đặt căn giữa cho các cột chứa biểu tượng
            dgvGiaoDich.Columns["xoaColumn"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvGiaoDich.Columns["suaColumn"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Căn giữa tiêu đề các cột
            dgvGiaoDich.Columns["xoaColumn"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvGiaoDich.Columns["suaColumn"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvGiaoDich.Columns["loaiGiaoDich"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvGiaoDich.Rows.Clear();
            foreach (var giaodich in DichVuGiaoDich.Instance.DanhSachGiaoDich)
            { 
                if (giaodich.Value != null)
                    dgv_Them(giaodich.Value);
            }
        }
        private void guna2DataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Kiểm tra nếu cột là "xoaColumn" hoặc "suaColumn"
            if (e.ColumnIndex == this.dgvGiaoDich.Columns["xoaColumn"].Index ||
                e.ColumnIndex == this.dgvGiaoDich.Columns["suaColumn"].Index)
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

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Kiểm tra có click vào vùng dữ liệu
            {
                if (e.ColumnIndex == dgvGiaoDich.Columns["xoaColumn"].Index)
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
                        dgvGiaoDich.Rows.RemoveAt(e.RowIndex); // Xóa dòng
                    }
                }
                else if (e.ColumnIndex == dgvGiaoDich.Columns["suaColumn"].Index)
                {
                    // Mở form sửa
                    fSuaGiaoDich fSuaGiaoDich = new fSuaGiaoDich(dgvGiaoDich.Rows[e.RowIndex].Cells["Idgiaodich"].Value.ToString());
                    fSuaGiaoDich.ShowDialog();
                }
            }
        }

        private void XoaGiaoDich()
        {
            while (queueIndex.Count > 0)
            {
                int index=queueIndex.Dequeue();
                string MaGiaoDich = dgvGiaoDich.Rows[index].Cells["Idgiaodich"].Value.ToString();
                DichVuGiaoDich.Instance.Xoa(MaGiaoDich);
            }
        }




        private void ptbSua_Click(object sender, EventArgs e)
        {
            string idGiaoDich = dgvGiaoDich.CurrentRow.Cells["Idgiaodich"].Value.ToString();
            fSuaGiaoDich fSuaGiaoDich = new fSuaGiaoDich(idGiaoDich);
            fSuaGiaoDich.ShowDialog();
            fGiaoDich_Load(sender, e);
        }


        private void btnThem_Click(object sender, EventArgs e)
        {
            fThemGiaoDich fThemGiaoDich = new fThemGiaoDich();
            fThemGiaoDich.ShowDialog();
            fGiaoDich_Load(sender, e);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            XoaGiaoDich();
        }


        private void btnLuu_Click(object sender, EventArgs e)
        {

        }
        private void ptbTimKiem_Click(object sender, EventArgs e)
        {
            string searchText = txbTimKiem.Text;
            if (string.IsNullOrEmpty(searchText)) // kiểm tra văn bản có rỗng hay không
            {
                fGiaoDich_Load(sender, e);
                return;
            }
            else
                dgvGiaoDich.Rows.Clear(); // xóa bảng hiển thị trước khi tìm kiếm
        
            if (!DichVuGiaoDich.Instance.TimKiem(searchText))
            {
                foreach (var giaodich in DichVuGiaoDich.Instance.DanhSachGiaoDich)
                {
                    bool laMaGiaoDich = giaodich.Key.Contains(searchText);
                    if (laMaGiaoDich)
                        dgv_Them(giaodich.Value);
                }
            }
            else
            {
                GiaoDich giaodich = DichVuGiaoDich.Instance.DanhSachGiaoDich[searchText];
                dgv_Them(giaodich);
            }
        }
    }
}
