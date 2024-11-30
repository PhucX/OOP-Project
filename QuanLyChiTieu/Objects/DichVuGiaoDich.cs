﻿using QuanLyChiTieu.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyChiTieu.Objects
{
    public class DichVuGiaoDich : BaseFunc<GiaoDich>
    {
        private static DichVuGiaoDich instance;
        private List<GiaoDich> danhSachGiaoDich = new List<GiaoDich>();

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

        public List<GiaoDich> DanhSachGiaoDich { get => danhSachGiaoDich; set => danhSachGiaoDich = value; }
        public override void Them(string id, GiaoDich item) { }

        public override GiaoDich DocDanhSach(string id) { return new GiaoDich(); }

        public override bool CapNhat(string id, GiaoDich item) { return false; }

        public override bool Xoa(string id) { return false; }

        public override void HienThi() { }
        //public override GiaoDich TimKiem(string id) { }
        public override GiaoDich TimKiem(string id) { return new GiaoDich(); }


        public List<GiaoDich> PhanLoaiGiaoDich(string id) { return new List<GiaoDich>(); }
    }
}
