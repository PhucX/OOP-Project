using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyChiTieu.Objects
{
    public abstract class BaseFunc<T>
    {
        protected Dictionary<string, T> items = new Dictionary<string, T>();

        public abstract void Them(string id, T item);
        public abstract T DocDanhSach(string id);
        public abstract bool CapNhat(string id, T item);

        public abstract bool Xoa(string id);
        public abstract void HienThi();

        public abstract T TimKiem(string id);
    }
}
