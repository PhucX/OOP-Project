using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyChiTieu.Modules
{
    public class NguoiDung
    {
        private static string taiKhoanNguoiDung;
        private static string tenNguoiDung;
        private static string soDienThoai = "";
        private static string diaChi = "";
        private static string matKhau = "";

        public NguoiDung(string taiKhoan, string mk, string ten = "",string sdt = "", string diaChi1 = "") 
        {
            taiKhoanNguoiDung = taiKhoan;
            matKhau = mk;
            tenNguoiDung = ten;
            soDienThoai = sdt;
            diaChi = diaChi1;
        }

        public static void CapNhatNguoiDung(string ten, string sdt, string diaChi1)
        {
            tenNguoiDung = ten;
            soDienThoai = sdt;
            diaChi = diaChi1;
        }

        public static string TaiKhoanNguoiDung { get => taiKhoanNguoiDung; }

        public static string MatKhau { get => matKhau; set => matKhau = value; }

        public static string TenNguoiDung { get => tenNguoiDung; set => tenNguoiDung = value; }

        public static string SoDienThoai { get => soDienThoai; set => soDienThoai = value; }

        public static string DiaChi { get => diaChi; set => diaChi = value; }
    }
}
