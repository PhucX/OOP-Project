using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyChiTieu.Modules
{
    public class ThanhToan
    {
        private string maThanhToan;
        private double soTienThanhToan;
        private DateTime ngayThanhToan;
        private string maKhoanVay;
        // phương thức khởi tạo
        public ThanhToan(string maThanhToan, double soTienThanhToan, DateTime ngayThanhToan, string maKhoanVay)
        {
            this.maThanhToan = maThanhToan;
            this.ngayThanhToan = ngayThanhToan;
            this.soTienThanhToan = soTienThanhToan;
            this.maKhoanVay = maKhoanVay;
        }

        // tạo các property cho các thuộc tính
        public string MaThanhToan { get => maThanhToan; }
        
        public double SoTienThanhToan { get => soTienThanhToan; }

        public DateTime NgayThanhToan { get => ngayThanhToan; }

        public string MaKhoanVay { get => maKhoanVay;}
    }
}
