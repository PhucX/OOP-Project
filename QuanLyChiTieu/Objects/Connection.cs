using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyChiTieu.Objects
{
    internal class Connection
    {
        private static string stringConnection = $"{Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).FullName).FullName.ToString()}\\Data\\data.xlsx";

        public static string GetFileConnection()
        {
            return stringConnection;
        }
    }
}
