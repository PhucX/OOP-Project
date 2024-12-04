using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace QuanLyChiTieu.Objects
{
    internal class UsedData
    {
        // lấy dữ liệu người dùng
        public static void UsedDataUser()
        {
            string taiKhoan = QuanLyChiTieu.Objects.ConnectionFile.currentAccount;

            new DataManager(new ExcelImporter()).ImportNguoiDung(taiKhoan, Objects.ConnectionFile.GetFileConnectionAccount());
        }

        // Lấy dữ liệu các tài khoản tại folder user
        public static void UsedDataAccount()
        {
            string filepath = QuanLyChiTieu.Objects.ConnectionFile.GetFileConnection("Accounts");
            new DataManager(new ExcelImporter()).ImportTaiKhoan(filepath);
        }
        // lấy dữ liệu giao dịch
        public static void UsedDataTran()
        {
            string currentAccount = QuanLyChiTieu.Objects.ConnectionFile.currentAccount;
            string filepath = QuanLyChiTieu.Objects.ConnectionFile.GetFileConnection("Transaction");
            new DataManager(new ExcelImporter()).ImportGiaoDich(filepath, currentAccount);

        }

        // lấy dữ liệu khoản vay
        public static void UsedDataLoan()
        {
            string currentAccount = QuanLyChiTieu.Objects.ConnectionFile.currentAccount;
            string filepath = QuanLyChiTieu.Objects.ConnectionFile.GetFileConnection("LoanAndDebt");
            new DataManager(new ExcelImporter()).ImportGiaoDich(filepath, currentAccount);
        }
    }
}
