
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

namespace QuanLyChiTieu
{
    public partial class fSuaGiaoDich : Form
    {
        private GiaoDich giaodich;
        public fSuaGiaoDich(string magiaodich)
        {
            InitializeComponent();
            bool laHopLe = DichVuGiaoDich.Instance.TimKiem(magiaodich);
            if (laHopLe)
                giaodich = DichVuGiaoDich.Instance.DanhSachGiaoDich[magiaodich];
            List<string> items = new List<string>{ "Rút tiền", "Chuyển khoản", "Đầu tư", "Nạp tiền" };
            foreach (string item in items)
            {
                guna2ComboBox1.Items.Add(item);
            }
            guna2ComboBox1.Text=giaodich.LoaiGiaoDich;
            txbTSoTien.Text=giaodich.SoTienGiaoDich.ToString();
            guna2TextBox1.Text = giaodich.GhiChu;
            NgayGiaoDich.Text=giaodich.NgayGiaoDich.ToString();

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

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string idgiaodich = giaodich.MaGiaoDich;
            DateTime ngaygiaodich = NgayGiaoDich.Value.Date;
            Double sotien= Double.Parse(txbTSoTien.Text) ;
            string loaigiaodich = guna2ComboBox1.Text;
            string ghichu= guna2TextBox1.Text;

            GiaoDich GIaoDich = new GiaoDich(idgiaodich,ngaygiaodich,sotien,loaigiaodich,ghichu);
            DichVuGiaoDich.Instance.CapNhat(idgiaodich,GIaoDich);

            this.Close();
        }
    }
}
