
using Guna.UI2.WinForms;
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
using System.Windows.Forms.VisualStyles;
using DocumentFormat.OpenXml.Spreadsheet;
using ClosedXML.Excel;

namespace QuanLyChiTieu
{
    
    
    public partial class fGiaoDich : Form
    {
        public Guna2DataGridView Guna2DataGridView1;
        private static fGiaoDich instance;
        public fGiaoDich()
        {
            InitializeComponent();
            dgvGiaoDich.MultiSelect = true;
        
        }
        private Queue<int> queueIndex = new Queue<int>();
        
        public static fGiaoDich Instance
        {
            get
            {
                if (instance == null)
                    instance = new fGiaoDich();
                return instance;
            }

            set => instance = value;
        }


        private void dgv_Them(GiaoDich giaodich)
        {
            dgvGiaoDich.Rows.Add(false, giaodich.MaGiaoDich, giaodich.LoaiGiaoDich,giaodich.ViDienTu, giaodich.NgayGiaoDich.ToString(), giaodich.SoTienGiaoDich.ToString(), giaodich.GhiChu);
        
        }
        public void fGiaoDich_Load(object sender, EventArgs e)
        {
            dgvGiaoDich.Rows.Clear();
            foreach (var giaodich in DichVuGiaoDich.Instance.DanhSachGiaoDich)
            {
                if (giaodich.Value != null)
                {
                    if (giaodich.Value.ViDienTu == null)
                        giaodich.Value.ViDienTu = "Nan";
                    dgv_Them(giaodich.Value);
                }                  
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
            if (e.RowIndex < 0 || e.RowIndex >= dgvGiaoDich.Rows.Count)
            {
                return; 
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
                    string magiaodich = dgvGiaoDich.Rows[e.RowIndex].Cells["Idgiaodich"].Value.ToString();
                    DichVuGiaoDich.Instance.Xoa(magiaodich);
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
            fGiaoDich_Load(sender,e);


        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            queueIndex.Clear();
            for (int i = 0; i < dgvGiaoDich.Rows.Count; i++)
            {
                var cellValue = dgvGiaoDich.Rows[i].Cells["Select"].Value;
                if (cellValue != null && cellValue.ToString().ToLower()=="true")
                {
                    queueIndex.Enqueue(i); // Thêm chỉ số vào hàng đợi
                }
            }
            DialogResult result = MessageBox.Show(
                        $"Bạn có chắc chắn muốn xóa {queueIndex.Count} giao dịch này?",
                        "Xác nhận xóa",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning
                    );
            if (result == DialogResult.Yes)
            {
                for (int i = dgvGiaoDich.Rows.Count - 1; i >= 0; i--) // Duyệt ngược từ cuối lên đầu
                {
         
                    if (dgvGiaoDich.Rows[i].Cells["Select"].Value != null && dgvGiaoDich.Rows[i].Cells["Select"].Value.ToString().ToLower() == "true") // Kiểm tra giá trị ô "chon"
                    {
                        string magiaodich = dgvGiaoDich.Rows[i].Cells["Idgiaodich"].Value.ToString();
                        DichVuGiaoDich.Instance.Xoa(magiaodich);
                        dgvGiaoDich.Rows.RemoveAt(i); // Xóa dòng
                    }
                }
            }
            
        }


        private void btnLuu_Click(object sender, EventArgs e)
        {
            SaveData.SaveDataTran();
        }

        private void ptbTimKiem_Click(object sender, EventArgs e)
        {
            string searchText = txbTimKiem.Text.Trim();
            if (string.IsNullOrEmpty(searchText)) // kiểm tra văn bản có rỗng hay không
            {
                fGiaoDich_Load(sender, e);
                return;
            }


            dgvGiaoDich.Rows.Clear(); // xóa bảng hiển thị trước khi tìm kiếm

            List<GiaoDich> giaTriThoaMan = DichVuGiaoDich.Instance.DanhSachGiaoDich.Where(giaodich => giaodich.Key.Contains(searchText) || (giaodich.Value.NgayGiaoDich).ToString().Contains(searchText)).Select(giaodich => (GiaoDich)giaodich.Value).ToList(); ;

            // Thêm kết quả vào DataGridView
            foreach (var giaodich in giaTriThoaMan)
                dgv_Them(giaodich);
        }

       

        
    }
}
