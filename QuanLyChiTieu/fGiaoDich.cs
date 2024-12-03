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
using DocumentFormat.OpenXml.Spreadsheet;
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
            dgvGiaoDich.Rows.Clear();
            foreach (var giaodich in DichVuGiaoDich.Instance.DanhSachGiaoDich)
            { 
                if (giaodich.Value != null)
                    dgv_Them(giaodich.Value);
            }
        }
        private void dgvGiaoDich_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
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

        private void dgvGiaoDich_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                object cellValue = dgvGiaoDich.Rows[e.RowIndex].Cells["Select"].Value;

                if (cellValue != DBNull.Value)
                {
                    // Kiểm tra nếu giá trị là kiểu CheckState
                    if (cellValue is CheckState)
                    {
                        CheckState checkState = (CheckState)cellValue;

                        // Kiểm tra trạng thái của checkbox
                        if (checkState == CheckState.Checked)
                        {
                            // Nếu checkbox được chọn, thêm index vào queue
                            if (!queueIndex.Contains(e.RowIndex))
                            {
                                queueIndex.Enqueue(e.RowIndex); // Thêm vào hàng đợi
                            }
                        }
                    }
                }
            }
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

        private void XoaGiaoDich(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                        $"Bạn có chắc chắn muốn xóa {queueIndex.Count} cuộc giao dịch này?",
                        "Xác nhận xóa",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning
             );
            if (result == DialogResult.Yes)
            {
                while (queueIndex.Count > 0)
                {
                    int index = queueIndex.Dequeue();
                    string MaGiaoDich = dgvGiaoDich.Rows[index].Cells["Idgiaodich"].Value.ToString();
                    DichVuGiaoDich.Instance.Xoa(MaGiaoDich);
                }
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
            XoaGiaoDich(sender,e);
            fGiaoDich_Load(sender, e);
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
