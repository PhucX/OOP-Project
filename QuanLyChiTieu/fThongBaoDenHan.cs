using QuanLyChiTieu.Modules;
using QuanLyChiTieu.Objects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyChiTieu
{
    public partial class fThongBaoDenHan : Form
    {
        private static int stt=0;
        public fThongBaoDenHan()
        {
            InitializeComponent();
            dgvThongBao.Rows.Clear();
            int khoangcach;

            foreach (var khoanVay in DichVuVay.Instance.DanhSachKhoanVay)
            {
                if ((khoanVay.Value.NgayDenHan.Day-DateTime.Now.Day) <= 7 && khoanVay.Value.TrangThai!="Đã thanh toán")
                {
                    khoangcach = khoanVay.Value.NgayDenHan.Day - DateTime.Now.Day;
                    if (khoanVay.Value.IdKhoanVay.Contains("debt"))
                    {
                        dgvThongBao.Rows.Add((stt++).ToString(), "Nợ", $"Cách ngày đến hạn còn {khoangcach} ngày");
                    }
                    else
                    {
                        dgvThongBao.Rows.Add((stt++).ToString(), "Cho vay", $"Cách ngày đến hạn còn {khoangcach} ngày");
                    }
                }

            }
        }
    }
}
