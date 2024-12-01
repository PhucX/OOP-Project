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
        private Dictionary<string, GiaoDich> danhSachGiaoDich = new Dictionary<string,GiaoDich>();

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
        public override void Them(string id, GiaoDich item) {
            if (id != "-1")
                danhSachGiaoDich.Add(id, item);
            else
                MessageBox.Show("Thêm giao dịch lỗi, vui lòng thêm lại!", "Lỗi");
        }

        public string GetIdGiaoDich()
        {
            for (int i = 0; i < 1e6; i++)
                if (!danhSachGiaoDich.ContainsKey("debt" + i.ToString()))
                    return "debt" + i.ToString();
            return "-1";
        }

        public override GiaoDich DocDanhSach(string id) { return new GiaoDich(); }

        public override bool CapNhat(string id, GiaoDich item) {
            if (danhSachGiaoDich.ContainsKey(id))
            {
                danhSachGiaoDich[id] = item;
                return true;
            }
            return false;
        }

        public override bool Xoa(string id) {
            if (danhSachGiaoDich.ContainsKey(id))
            {
                danhSachGiaoDich.Remove(id);
                return true;
            }
            return false;
        }

        public override void HienThi() { }
        //public override GiaoDich TimKiem(string id) { }
        public override bool TimKiem(string id) {
            if (danhSachGiaoDich.ContainsKey(id))
                return true;
            return false;
        }


        public List<GiaoDich> PhanLoaiGiaoDich(string id) { return new List<GiaoDich>(); }
    }
}
