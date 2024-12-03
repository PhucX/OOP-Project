using QuanLyChiTieu.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyChiTieu.Objects
{
    class DichVuChoVay : BaseFunc<KhoanChoVay>
    {
        private static DichVuChoVay instance;
        private Dictionary<string, KhoanChoVay> danhSachKhoanChoVay = new Dictionary<string, KhoanChoVay>();

        // phương thức khởi tạo
        public static DichVuChoVay Instance
        {
            get
            {
                if (instance == null)
                    instance = new DichVuChoVay();
                return instance;
            }

            set => instance = value;
        }

        public Dictionary<string, KhoanChoVay> DanhSachKhoanChoVay 
        { 
            get => danhSachKhoanChoVay; 
            set => danhSachKhoanChoVay = value; 
        }

        public string GetIdKhoanVay()
        {
            for (int i = 0; i < 1e6; i++)
                if (!danhSachKhoanChoVay.ContainsKey("debt" + i.ToString()))
                    return "debt" + i.ToString();
            return "-1";
        }

        public override void Them(string id, KhoanChoVay item)
        {
            if (id != "-1")
                danhSachKhoanChoVay.Add(id, item);
            else
                MessageBox.Show("Vui lòng xóa lịch sử khoản vay!", "Lỗi");
        }

        public override KhoanChoVay DocDanhSach(string id) { return new KhoanChoVay(); }

        public override bool CapNhat(string id, KhoanChoVay item)
        {
            if (danhSachKhoanChoVay.ContainsKey(id))
            {
                danhSachKhoanChoVay[id] = item;
                return true;
            }
            return false;
        }

        public override bool Xoa(string id)
        {
            if (danhSachKhoanChoVay.ContainsKey(id))
            {
                danhSachKhoanChoVay.Remove(id);
                return true;
            }

            return false;
        }

        public override void HienThi() { }

        public override bool TimKiem(string id)
        {
            if (DanhSachKhoanChoVay.ContainsKey(id))
                return true;
            return false;
        }
        public int SoLuong()
        {
            return DanhSachKhoanChoVay.Count;
        }
        public List<KhoanVay> PhanLoaiGiaoDich(string id) { return new List<KhoanVay>(); }
    }
}
