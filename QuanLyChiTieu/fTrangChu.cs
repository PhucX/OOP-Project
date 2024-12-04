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
    public partial class fTrangChu : Form
    {
        public fTrangChu()
        {
            InitializeComponent();
           
            label2.Text = (QuanLyChiTieu.Objects.DichVuGiaoDich.Instance.TongchitieuAll() + QuanLyChiTieu.Objects.DichVuVay.Instance.TongchitieuAll()).ToString();

            btnSoTinThongBao.Text = DichVuVay.Instance.DanhSachKhoanVay.Count(khoanVay => (-khoanVay.Value.NgayVay.Day + DateTime.Now.Day) <= 7).ToString();
            guna2DataGridView1.Rows.Clear();
            foreach (var giaodich in DichVuGiaoDich.Instance.DanhSachGiaoDich)
            {
                if (giaodich.Value != null)
                {
                    if (giaodich.Value.LoaiGiaoDich == "Chi tiêu")
                    {
                        guna2DataGridView1.Rows.Add(giaodich.Value.NgayGiaoDich.ToString(), giaodich.Value.SoTienGiaoDich.ToString(), giaodich.Value.ViDienTu, giaodich.Value.GhiChu);
                    }
                }
            }
        }

        private bool isFirstClick = true;
        private void guna2PictureBox3_Click(object sender, EventArgs e)
        {
            string taiKhoan = QuanLyChiTieu.Objects.ConnectionFile.currentAccount;
            
            if (isFirstClick)
            {
                lbTongSoDu.Text = QuanLyChiTieu.Objects.DichVuTaiKhoan.Instance.DanhSachTaiKhoan[taiKhoan].SoDu.ToString();
                lbTongSoDu.Text += " VND";
                isFirstClick = false;
            }
            else
            {
                this.lbTongSoDu.Text = "************";
                isFirstClick = true;
            }
        }

        private void ptbThongBao_Click(object sender, EventArgs e)
        {
            fThongBaoDenHan f = new fThongBaoDenHan();
            f.ShowDialog();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            
        }

        private void btnSoTinThongBao_Click(object sender, EventArgs e)
        {

        }

        private void fTrangChu_Load(object sender, EventArgs e)
        {

        }
    }
}
