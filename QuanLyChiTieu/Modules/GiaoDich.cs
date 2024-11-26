using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyChiTieu.Modules
{
    public class GiaoDich
    {
        private string maGiaoDich;
        private double soTienGiaoDich;
        private DateTime ngayGiaoDich;
        private string ghiChu;
        private string loaiGiaoDich;

        // phương thức khởi tạo
        public GiaoDich() { }
        public GiaoDich(string maGiaoDich, double soTienGiaoDich, DateTime ngayGiaoDich, string ghiChu, string loaiGiaoDich)
        { 
            this.maGiaoDich = maGiaoDich;
            this.soTienGiaoDich = soTienGiaoDich;
            this.ngayGiaoDich = ngayGiaoDich;
            this.ghiChu = ghiChu;
            this.loaiGiaoDich = loaiGiaoDich;
        }

        // tạo các property cho các thuộc tính
        public string MaGiaoDich { get => maGiaoDich; set => maGiaoDich = value; }

        public double SoTienGiaoDich{ get => soTienGiaoDich; set => soTienGiaoDich = value; }

        public string GhiChu      { get => ghiChu; set => ghiChu = value; }

        public string LoaiGiaoDich { get => loaiGiaoDich; set => loaiGiaoDich = value; }
    }
}
