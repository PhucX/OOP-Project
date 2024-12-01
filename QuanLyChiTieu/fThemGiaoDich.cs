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
    public partial class fThemGiaoDich : Form
    {
        public fThemGiaoDich()
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
            guna2ComboBox1.Text= loaiGiaoDich[1];
        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            string magiaodich = DichVuGiaoDich.Instance.GetIdGiaoDich();
            Double SoTien = Double.Parse(txbTSoTien.Text);
            string GhiChu = txbGhiChu.Text;
            DateTime ngaygiaodich = NgayGiaoDich.Value.Date;
            string loaigiaodich = guna2ComboBox1.SelectedItem.ToString();

            DichVuGiaoDich.Instance.Them(magiaodich, new Modules.GiaoDich(magiaodich, ngaygiaodich, SoTien, loaigiaodich, GhiChu));

            this.Close();
        }
    }
}
