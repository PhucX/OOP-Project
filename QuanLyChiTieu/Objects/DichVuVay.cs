using QuanLyChiTieu.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyChiTieu.Objects
{
    public class DichVuVay : BaseCRUD<KhoanVay>
    {
        private static DichVuVay instance;
        private List<KhoanVay> danhSachKhoanVay = new List<KhoanVay>();
        // phương thức khởi tạo
        public static DichVuVay Instance
        {
            get
            {
                if (instance == null)
                    instance = new DichVuVay();
                return instance;
            }

            set => instance = value;
        }

        public List<KhoanVay> DanhSachKhoanVay { get => danhSachKhoanVay; set => danhSachKhoanVay = value; }
        public override void Them(KhoanVay item) { }

        public override KhoanVay DocDanhSach(string id) { return new KhoanVay(); }

        public override bool CapNhat(string id, KhoanVay item) { return false; }

        public override bool Xoa(string id) { return false; }

        public override void HienThi() { }

        public List<KhoanVay> PhanLoaiGiaoDich(string id) { return new List<KhoanVay>(); }
    }
}
