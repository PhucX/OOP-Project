using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyChiTieu.Modules
{
    public class TaiKhoan
    {
        private string tenTaiKhoan;
        private double soDu;
        private string loaiThe;

        // Phương thức khởi tạo
        public TaiKhoan() { }

        public TaiKhoan(string tenTaikhoan, double soDu, string loaiThe)
        {
            this.tenTaiKhoan = tenTaikhoan;
            this.soDu = soDu;
            this.loaiThe = loaiThe;
        }

        // Tạo các property cho các biến

        public string TenTaiKhoan { get => tenTaiKhoan; set => tenTaiKhoan = value; }

        public double SoDu { get => soDu; set => soDu = value; }

        public string LoaiThe { get => loaiThe; set => loaiThe = value; }
    }
}
