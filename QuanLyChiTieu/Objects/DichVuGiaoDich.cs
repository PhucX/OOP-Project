using QuanLyChiTieu.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyChiTieu.Objects
{
    public class DichVuGiaoDich : BaseFunc<GiaoDich>
    {
        private static DichVuGiaoDich instance;
        private Dictionary<string, GiaoDich> danhSachGiaoDich = new Dictionary<string, GiaoDich>();

        // phương thức khởi tạo
        public static DichVuGiaoDich Instance
        {
            get
            {
                if (instance == null)
                    instance = new DichVuGiaoDich();
                return instance;
            }

            set => instance = value;
        }

        public Dictionary<string, GiaoDich> DanhSachGiaoDich { get => danhSachGiaoDich; set => danhSachGiaoDich = value; }
        public override void Them(string id, GiaoDich item) 
        {
            if (id != "-1")
                danhSachGiaoDich.Add(id, item);
            else
                MessageBox.Show("Đã đủ số lượng tài khoản cho phép!", "Lỗi");
        }

        public override GiaoDich DocDanhSach(string id) { return new GiaoDich(); }

        public override bool CapNhat(string id, GiaoDich item) { return false; }

        public override bool Xoa(string id) { return false; }

        public override void HienThi() { }
        //public override GiaoDich TimKiem(string id) { }
        public override bool TimKiem(string id) { return false; }

        public int SoLuong()
        {
            return danhSachGiaoDich.Count;
        }

        public List<GiaoDich> PhanLoaiGiaoDich(string id) { return new List<GiaoDich>(); }
    }
}
