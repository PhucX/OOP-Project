using QuanLyChiTieu.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyChiTieu.Objects
{
    internal class SaveData
    {
        // lưu dữ liệu người dùng
        public static void SaveDataUser()
        {
            new DataManager(new ExcelExporter()).ExportNguoiDung(Objects.ConnectionFile.GetFileConnectionAccount());
        }

        public static void SaveDataAccount()
        {
            string filepath = QuanLyChiTieu.Objects.ConnectionFile.GetFileConnection("Accounts");
            new DataManager(new ExcelExporter()).ExportTaiKhoan(filepath);
        }

        // lưu dữ liệu giao dịch
        public static void SaveDataTran()
        {
            string taiKhoan = QuanLyChiTieu.Objects.ConnectionFile.currentAccount;
            string filepath = QuanLyChiTieu.Objects.ConnectionFile.GetFileConnection("Transaction");
            new DataManager(new ExcelExporter()).ExportGiaoDich(taiKhoan, filepath);
        }

        // lưu dữ liệu khoản vay
        public static void SaveDataLoan()
        {
            string taiKhoan = NguoiDung.TaiKhoanNguoiDung;
            string filepath = QuanLyChiTieu.Objects.ConnectionFile.GetFileConnection("LoanAndDebt");
            new DataManager(new ExcelExporter()).ExportKhoanVay(taiKhoan, filepath);
        }
    }
}
