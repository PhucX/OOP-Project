using QuanLyChiTieu.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyChiTieu.Objects
{
    public class DichVuVay : BaseFunc<KhoanVay>
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
        public override void Them(KhoanVay item) 
        {
            danhSachKhoanVay.Add(item);
        }

        public override KhoanVay DocDanhSach(string id) { return new KhoanVay(); }

        public override bool CapNhat(string id, KhoanVay item) 
        {
            // Tìm vị trí (index) của phần tử có mã "id"
            int index = danhSachKhoanVay.FindIndex(khoan => khoan.IdKhoanVay == id);
            if (index == -1)
                return false;

            danhSachKhoanVay[index] = item;
            return true;
        }

        public override bool Xoa(string id) { return false; }

        public override void HienThi() { }

        public override KhoanVay TimKiem(string id) 
        {
            return danhSachKhoanVay.Where(vay => vay.IdKhoanVay.Equals(id)).FirstOrDefault();
        }


        public List<KhoanVay> PhanLoaiGiaoDich(string id) { return new List<KhoanVay>(); }
    }
}
