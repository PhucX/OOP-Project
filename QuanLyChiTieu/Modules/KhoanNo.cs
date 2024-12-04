using QuanLyChiTieu.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyChiTieu.Modules
{
    public class KhoanNo : KhoanVay
    {
        private string nguoiChoVay;
        private double soDuNo;

        // phương thức khởi tạo
        public KhoanNo() { }
        public KhoanNo(string idKhoanVay, double soTienVay, double laiSuat,DateTime ngayVay, DateTime ngayDenHan, string trangThai, string nguoiChoVay) : base(idKhoanVay, soTienVay, laiSuat, ngayVay, ngayDenHan, trangThai)
        {
            this.nguoiChoVay = nguoiChoVay;
            soDuNo = soTienVay;
        }

        // tạo các property cho các thuộc tính
        public string NguoiChoVay { get => nguoiChoVay; set => nguoiChoVay = value; }

        public double SoDuNo { get => soDuNo; }

        public double ThanhToan(double soTienTra)
        {
            //// Kiểm tra nếu ngày hiện tại trước ngày vay, thì không tính lãi
            //if (DateTime.Now < NgayVay)
            //{
            //    return SoDuNo;
            //}

            //// Tính số ngày đã trôi qua từ ngày vay đến ngày hiện tại
            //int soNgay = (DateTime.Now - NgayVay).Days;

            //// Tính số ngày giữa ngày vay và ngày hạn trả
            //int soNgayHanTra = (NgayDenHan - NgayVay).Days;

            //// Nếu ngày hiện tại đã qua ngày hạn trả, tính lãi theo toàn bộ thời gian cho đến hạn trả
            //if (DateTime.Now >= NgayDenHan)
            //{
            //    soNgay = soNgayHanTra;  // Chỉ tính đến ngày hạn trả
            //}

            //// Tính tổng số dư nợ với lãi suất hàng ngày
            //double soDu = soDuNo * (1 + LaiSuat * soNgay);
            soDuNo -= soTienTra;

            return soDuNo - soTienTra;
        }
    }
}
