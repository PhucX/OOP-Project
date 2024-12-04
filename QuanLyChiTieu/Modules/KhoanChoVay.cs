using DocumentFormat.OpenXml.Presentation;
using QuanLyChiTieu.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyChiTieu.Modules
{
    public class KhoanChoVay : KhoanVay
    {
        private string nguoiVay;
        private double soTienBiThieu;

        // phương thức khởi tạo
        public KhoanChoVay() { }
        public KhoanChoVay(string idKhoanVay, double soTienVay, double laiSuat, DateTime ngayVay, DateTime ngayDenHan, string trangThai, string nguoiVay) : base(idKhoanVay, soTienVay, laiSuat, ngayVay, ngayDenHan, trangThai)
        {
            this.nguoiVay = nguoiVay;
        }

        // tạo các property cho các thuộc tính
        public string NguoiVay { get => nguoiVay; set => nguoiVay = value; }

        public double SoTienBiThieu { get => soTienBiThieu; set => soTienBiThieu = value; }

        public void ThanhToan(double soTienTra)
        {
            double ketqua = soTienBiThieu - soTienTra;
            if (ketqua < 0)
            {
                MessageBox.Show("Lố số tiền cần trả", "Cảnh báo");
                return;
            }

            if (ketqua == 0)
            {
                DichVuVay.Instance.Xoa(this.IdKhoanVay);
                MessageBox.Show("Đã được hoàn trả đầy đủ", "Thông báo");
                return;
            }

            soTienBiThieu = ketqua;
            DanhSachThanhToan.Add(new Modules.ThanhToan(soTienTra, DateTime.Now));
        }
    }
}
