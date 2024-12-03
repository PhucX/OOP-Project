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
    public partial class fThemGiaoDich : Form
    {
        public fThemGiaoDich()
        {
            InitializeComponent();
            List<string> items = new List<string> { "Rút tiền", "Chuyển khoản", "Đầu tư", "Nạp tiền" };
            foreach (string item in items)
            {
                guna2ComboBox1.Items.Add(item);
            }
            guna2ComboBox1.SelectedIndex = 0;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            try
            {
                string idgiaodich = DichVuGiaoDich.Instance.GetIdGiaoDich();
                DateTime ngaygiaodich = NgayGiaoDich.Value.Date;
                Double sotien = Double.Parse(txbTSoTien.Text);
                string loaigiaodich = guna2ComboBox1.Text;
                string ghichu = txbGhiChu.Text;

                GiaoDich GIaoDich = new GiaoDich(idgiaodich, ngaygiaodich, sotien, loaigiaodich, ghichu);
                DichVuGiaoDich.Instance.Them(idgiaodich, GIaoDich);

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
