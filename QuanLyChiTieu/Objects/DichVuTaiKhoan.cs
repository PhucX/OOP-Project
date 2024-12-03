using QuanLyChiTieu.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyChiTieu.Objects
{
    public class DichVuTaiKhoan : BaseFunc<TaiKhoan>
    {
        private static DichVuTaiKhoan instance;
        private Dictionary<string, TaiKhoan> danhSachTaiKhoan = new Dictionary<string, TaiKhoan>();

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

        public Dictionary<string, TaiKhoan> DanhSachTaiKhoan { get => danhSachTaiKhoan; set => danhSachTaiKhoan = value; }

        public override void Them(string id, TaiKhoan item) 
        {
            if (!danhSachTaiKhoan.ContainsKey(id))
                danhSachTaiKhoan.Add(id, item);
            else
                MessageBox.Show("Đã tồn tài tài khoản!", "Lỗi");
        }

        public override TaiKhoan DocDanhSach(string id) { return new TaiKhoan(); }

        public override bool CapNhat(string id, TaiKhoan item) { return false; }
        public override bool Xoa(string id) { return false; }

        public override void HienThi() { }

        public override bool TimKiem(string id) { return false; }

        public void ChuyenKhoan(string maTaiKhoan, double soTien) { }
    }
}
