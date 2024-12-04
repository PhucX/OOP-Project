using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyChiTieu.Modules
{
    public class ThanhToan
    {
        private double soTienThanhToan;
        private DateTime ngayThanhToan;
        private string taiKhoanDaThanhToan;
        // phương thức khởi tạo
        public ThanhToan(double soTienThanhToan, DateTime ngayThanhToan, string taiKhoanDaThanhToan)
        {
            this.ngayThanhToan = ngayThanhToan;
            this.soTienThanhToan = soTienThanhToan;
            this.taiKhoanDaThanhToan = taiKhoanDaThanhToan;
        }

        // tạo các property cho các thuộc tính
        
        public double SoTienThanhToan { get => soTienThanhToan; }

        public DateTime NgayThanhToan { get => ngayThanhToan; }

        public string TaiKhoanDaThanhToan { get => taiKhoanDaThanhToan; }
    }
}
