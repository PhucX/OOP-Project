using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyChiTieu.Modules;

namespace QuanLyChiTieu.Objects
{
    internal class ConnectionFile
    {
        public static string currentAccount;
        private static string stringConnection = $"{Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).FullName).FullName.ToString()}";
        
        public static string StringConnection { get => stringConnection; }

        public static string GetFileConnection(string currentPath)
        {
            return stringConnection + $"\\Data\\{NguoiDung.TaiKhoanNguoiDung}\\{currentPath}.xlsx";
        }

        public static string GetFileConnectionAccount()
        {
            return $"{stringConnection}\\Data\\Account.xlsx";
        }
    }
}
