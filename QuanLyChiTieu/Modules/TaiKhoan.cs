using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyChiTieu.Modules
{
    public class TaiKhoan
    {
        private string idTaiKhoan;
        private string tenTaiKhoan;
        private double soDu;

        // Phương thức khởi tạo
        public TaiKhoan() { }

        public TaiKhoan(string tenTaikhoan, double soDu)
        {
            this.tenTaiKhoan = tenTaikhoan;
            this.soDu = soDu;
        }

        // Tạo các property cho các biến

        public string TenTaiKhoan { get => tenTaiKhoan; set => tenTaiKhoan = value; }

        public double SoDu { get => soDu; set => soDu = value; }
    }
}
