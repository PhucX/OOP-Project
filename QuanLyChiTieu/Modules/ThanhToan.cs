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
        // phương thức khởi tạo
        public ThanhToan(double soTienThanhToan, DateTime ngayThanhToan)
        {
            this.ngayThanhToan = ngayThanhToan;
            this.soTienThanhToan = soTienThanhToan;
        }

        // tạo các property cho các thuộc tính
        
        public double SoTienThanhToan { get => soTienThanhToan; }

        public DateTime NgayThanhToan { get => ngayThanhToan; }
    }
}
