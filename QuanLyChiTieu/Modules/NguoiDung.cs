using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        // Kiểm tra xem tài khoản có hợp lệ không
        public static bool IsValidAccount(string account)
        {
            // Kiểm tra độ dài tài khoản (ví dụ, từ 5 đến 20 ký tự)
            if (account.Length < 5 || account.Length > 20)
            {
                MessageBox.Show("Tài khoản phải có độ dài từ 5 đến 20 ký tự.");
                return false;
            }

            // Kiểm tra ký tự hợp lệ (chỉ cho phép chữ cái, chữ số và dấu gạch dưới)
            string pattern = @"^[a-zA-Z0-9_]+$";
            if (!Regex.IsMatch(account, pattern))
            {
                MessageBox.Show("Tài khoản chỉ được phép chứa chữ cái, chữ số và dấu gạch dưới.");
                return false;
            }

            return true;
        }

        public static bool IsValidPassword(string password)
        {
            // Kiểm tra độ dài (ít nhất 8 ký tự)
            if (password.Length < 8)
            {
                MessageBox.Show("Mật khẩu phải có ít nhất 8 ký tự.");
                return false;
            }

            // Kiểm tra có chữ hoa
            if (!Regex.IsMatch(password, @"[A-Z]"))
            {
                MessageBox.Show("Mật khẩu phải chứa ít nhất một chữ cái hoa.");
                return false;
            }

            // Kiểm tra có chữ thường
            if (!Regex.IsMatch(password, @"[a-z]"))
            {
                MessageBox.Show("Mật khẩu phải chứa ít nhất một chữ cái thường.");
                return false;
            }

            // Kiểm tra có số
            if (!Regex.IsMatch(password, @"[0-9]"))
            {
                MessageBox.Show("Mật khẩu phải chứa ít nhất một số.");
                return false;
            }

            // Kiểm tra có ký tự đặc biệt
            if (!Regex.IsMatch(password, @"[\W_]"))
            {
                MessageBox.Show("Mật khẩu phải chứa ít nhất một ký tự đặc biệt.");
                return false;
            }

            // Nếu tất cả các điều kiện đều thỏa mãn
            return true;
        }
    }
}
