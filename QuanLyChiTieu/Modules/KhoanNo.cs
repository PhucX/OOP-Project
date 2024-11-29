using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyChiTieu.Modules
{
    public class KhoanNo : KhoanVay
    {
        private string nguoiChoVay;
        private double soDuNo;

        // phương thức khởi tạo
        public KhoanNo(string idKhoanVay, double soTienVay, double laiSuat, DateTime ngayDenHan, string trangThai, string nguoiChoVay, double soDuNo) : base(idKhoanVay, soTienVay, laiSuat, ngayDenHan, trangThai)
        {
            this.nguoiChoVay = nguoiChoVay;
            this.soDuNo = soDuNo;
        }

        // tạo các property cho các thuộc tính
        public string NguoiChoVay { get => nguoiChoVay; set => nguoiChoVay = value; }

        public double SoDuNo { get => soDuNo; set => soDuNo = value; }
    }
}
