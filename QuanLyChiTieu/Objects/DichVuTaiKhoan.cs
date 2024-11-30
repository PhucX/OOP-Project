using QuanLyChiTieu.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyChiTieu.Objects
{
    public class DichVuTaiKhoan : BaseFunc<TaiKhoan>
    {
        private static DichVuTaiKhoan instance;
        private List<TaiKhoan> danhSachTaiKhoan = new List<TaiKhoan>();

        // phương thức khởi tạo
        public static DichVuTaiKhoan Instance
        {
            get
            {
                if (instance == null)
                    instance = new DichVuTaiKhoan();
                return instance;
            }

            set => instance = value;
        }

        public List<TaiKhoan> DanhSachTaiKhoan { get => danhSachTaiKhoan; set => danhSachTaiKhoan = value; }
        public override void Them(string id, TaiKhoan item) { }

        public override TaiKhoan DocDanhSach(string id) { return new TaiKhoan(); }

        public override bool CapNhat(string id, TaiKhoan item) { return false; }
        public override bool Xoa(string id) { return false; }

        public override void HienThi() { }

        public override TaiKhoan TimKiem(string id) { return new TaiKhoan(); }

        public void ChuyenKhoan(string maTaiKhoan, double soTien) { }
    }
}
