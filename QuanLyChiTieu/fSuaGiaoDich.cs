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
    public partial class fSuaGiaoDich : Form
    {
        private GiaoDich giaodich;
        public fSuaGiaoDich(string magiaodich)
        {
            InitializeComponent();
            List<string> loaiGiaoDich = new List<string>
            {
                "Nạp tiền",
                "Chuyển tiền",
                "Rút tiền",
                "Đầu tư",
                "Thanh toán"
            };

            // Gán danh sách vào ComboBox
            guna2ComboBox1.DataSource = loaiGiaoDich;

            giaodich = DichVuGiaoDich.Instance.DanhSachGiaoDich[magiaodich];

            txbTSoTien.Text = giaodich.SoTienGiaoDich.ToString();
            guna2TextBox1.Text = giaodich.GhiChu;
            guna2ComboBox1.Text = giaodich.LoaiGiaoDich;
            NgayGiaoDich.Text = giaodich.NgayGiaoDich.ToString();
            
        }
        private void fSuaGiaoDich_Load_1(object sender, EventArgs e)
        {
            //dgvGiaoDich.Rows.Clear();
            //foreach (var giaodich in DichVuGiaoDich.Instance.DanhSachGiaoDich)
            //{
            //    if (giaodich.Value != null)
            //        dgv_Them(giaodich.Value);
            //}
        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = guna2ComboBox1.SelectedItem.ToString();

            // Hiển thị loại giao dịch được chọn (ví dụ)
            MessageBox.Show("Bạn đã chọn: " + selectedValue);
        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            string magiaodich = DichVuGiaoDich.Instance.GetIdGiaoDich();
            Double SoTien = Double.Parse(txbTSoTien.Text);
            string GhiChu = guna2TextBox1.Text;
            DateTime ngaygiaodich = NgayGiaoDich.Value.Date;
            string loaigiaodich = guna2ComboBox1.SelectedItem.ToString();

            DichVuGiaoDich.Instance.CapNhat(magiaodich, new Modules.GiaoDich(magiaodich, ngaygiaodich, SoTien, loaigiaodich, GhiChu));

            this.Close();
        }
    }
}
