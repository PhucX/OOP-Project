using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyChiTieu.Objects
{
    internal class ConnectionFile
    {
        public static string currentUser;
        public static string currentAccount;
        private static string stringConnection = $"{Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).FullName).FullName.ToString()}";

        public static string GetFileConnection(string fileChildPath)
        {
            return stringConnection + fileChildPath;
        }

        public static string GetFileChildConnection(string currentAccount)
        {
            return $"\\Data\\{currentUser}\\{currentAccount}.xlsx";
        }
    }
}
