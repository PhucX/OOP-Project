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
        private static string stringConnection = $"{Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).FullName).FullName.ToString()}";

        public static string GetFileConnection(string filepath)
        {
            return stringConnection + filepath;
        }
    }
}
