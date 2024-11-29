using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyChiTieu.Modules
{
    public class KhoanVay
    {
        private string maKhoanVay;
        private double soTienVay;
        private double laiSuat;
        private DateTime ngayDenHan;
        private string trangThai;
        private List<ThanhToan> danhSachThanhToan = new List<ThanhToan>();

        // phương thức khởi tạo
        public KhoanVay() { }
        public KhoanVay(string idKhoanVay, double soTienVay, double laiSuat, DateTime ngayDenHan, string trangThai) 
        { 
            this.maKhoanVay = idKhoanVay;
            this.soTienVay = soTienVay;
            this.laiSuat = laiSuat;
            this.ngayDenHan = ngayDenHan;
            this.trangThai = trangThai;
        }

        // tạo các property cho các thuộc tính
        public List<ThanhToan> DanhSachThanhToan { get => danhSachThanhToan; set => danhSachThanhToan = value; }

        public string IdKhoanVay { get => maKhoanVay; }

        public double SoTienVay { get => soTienVay; set => soTienVay = value; }

        public double LaiSuat { get => laiSuat; set => laiSuat = value; }

        public DateTime NgayDenHan { get => ngayDenHan; set => ngayDenHan = value; }

        public string TrangThai { get => trangThai; set => trangThai = value; }
    }
}
