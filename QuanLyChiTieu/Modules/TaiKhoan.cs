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
        private string loaiTaiKhoan;
        private double soDu;

        // Phương thức khởi tạo
        public TaiKhoan() { }

        public TaiKhoan(string idTaiKhoan, string tenTaikhoan, string loaiTaiKhoan, double soDu)
        {
            this.idTaiKhoan = idTaiKhoan;
            this.tenTaiKhoan = tenTaikhoan;
            this.LoaiTaiKhoan = loaiTaiKhoan;
            this.soDu = soDu;
        }

        // Tạo các property cho các biến
        public string IdTaiKhoan { get => idTaiKhoan; }

        public string TenTaiKhoan { get => tenTaiKhoan; set => tenTaiKhoan = value; }

        public string LoaiTaiKhoan { get => loaiTaiKhoan; set => loaiTaiKhoan = value; }

        public double SoDu { get => soDu; set => soDu = value; }
    }
}
