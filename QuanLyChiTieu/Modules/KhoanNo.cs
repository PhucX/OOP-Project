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

        public void ThanhToan(double soTienTra)
        {
            double ketqua = soDuNo - soTienTra;
            if(ketqua < 0)
            {
                MessageBox.Show("Lố số tiền cần trả", "Cảnh báo");
                return;
            }

            soDuNo = ketqua;
            DanhSachThanhToan.Add(new Modules.ThanhToan(soTienTra, DateTime.Now));
        }
    }
}
