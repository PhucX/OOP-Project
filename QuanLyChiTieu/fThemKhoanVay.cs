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
    public partial class fThemKhoanVay : Form
    {
        public fThemKhoanVay()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            try
            {
                string idVay = DichVuVay.Instance.GetIdKhoanVay();
                string nguoiChoVay = txbNguoiChoVay.Text;
                double soTienVay = double.Parse(txbSoTienVay.Text);
                double laiSuat = double.Parse(txbLaiSuat.Text);
                string trangThai = guna2ComboBox1.SelectedItem.ToString();
                DateTime ngayDenHan = NgayDenHan.Value.Date;

                DichVuVay.Instance.Them(idVay, new Modules.KhoanNo(idVay, soTienVay, laiSuat, ngayDenHan, trangThai, nguoiChoVay));

                this.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
