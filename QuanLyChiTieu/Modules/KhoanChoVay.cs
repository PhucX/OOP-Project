using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyChiTieu.Modules
{
    public class KhoanChoVay : KhoanVay
    {
        private string nguoiVay;
        private double soTienBiThieu;

        // phương thức khởi tạo
        public KhoanChoVay(string idKhoanVay, double soTienVay, double laiSuat, DateTime ngayDenHan, string trangThai, string nguoiVay, double soTienBiThieu) : base(idKhoanVay, soTienVay, laiSuat, ngayDenHan, trangThai)
        {
            this.nguoiVay = nguoiVay;
            this.soTienBiThieu = soTienBiThieu;
        }

        // tạo các property cho các thuộc tính
        public string NguoiChoVay { get => nguoiVay; set => nguoiVay = value; }

        public double SoTienBiThieu { get => soTienBiThieu; set => soTienBiThieu = value; }
    }
}
