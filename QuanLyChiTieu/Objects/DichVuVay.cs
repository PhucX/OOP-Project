using QuanLyChiTieu.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyChiTieu.Objects
{
    public class DichVuVay : BaseFunc<KhoanVay>
    {
        private static DichVuVay instance;
        private Dictionary<string, KhoanVay> danhSachKhoanVay = new Dictionary<string, KhoanVay>();

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

        public Dictionary<string, KhoanVay> DanhSachKhoanVay { get => danhSachKhoanVay; set => danhSachKhoanVay = value; }

        public string GetIdKhoanVay()
        {
            for (int i = 0; i < 1e6; i++)
                if (!danhSachKhoanVay.ContainsKey("debt" + i.ToString()))
                    return "debt" + i.ToString();
            return "-1";
        }

        public override void Them(string id, KhoanVay item) 
        {
            if (id != "-1")
                danhSachKhoanVay.Add(id, item);
            else
                MessageBox.Show("Vui lòng xóa lịch sử khoản vay!", "Lỗi");
        }

        public override KhoanVay DocDanhSach(string id) { return new KhoanVay(); }

        public override bool CapNhat(string id, KhoanVay item) 
        {
            if (danhSachKhoanVay.ContainsKey(id))
            {
                danhSachKhoanVay[id] = item;
                return true;
            }
            return false;
        }

        public override bool Xoa(string id) 
        {
            if (danhSachKhoanVay.ContainsKey(id))
            {
                danhSachKhoanVay.Remove(id);
                return true;
            }

            return false;
        }

        public override void HienThi() { }

        public override bool TimKiem(string id) 
        {
            if(danhSachKhoanVay.ContainsKey(id))
                return true;
            return false;
        }


        public List<KhoanVay> PhanLoaiGiaoDich(string id) { return new List<KhoanVay>(); }
    }
}
