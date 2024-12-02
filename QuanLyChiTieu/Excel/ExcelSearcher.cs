using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace QuanLyChiTieu.Excel
{
    internal class ExcelSearcher
    {
        public bool Search(string filePath, string taiKhoan, string matKhau, out bool daTonTaiTK)
        {
            try
            {
                daTonTaiTK = false;
                using (XLWorkbook workbook = new XLWorkbook(filePath))
                {
                    IXLWorksheet worksheet = workbook.Worksheet(1);
                    foreach (IXLRow row in worksheet.RowsUsed().Skip(1))
                    {
                        // Kiểm tra ô tài khoản có tồn tại không
                        string taiKhoan2 = row.Cell(1).GetValue<string>(); // Tài khoản ở cột 1
                        string matKhau2 = row.Cell(2).GetValue<string>(); // Mật khẩu ở cột 2

                        // Kiểm tra tài khoản có tồn tại không
                        if (taiKhoan2 == taiKhoan)
                        {
                            daTonTaiTK = true;

                            // Nếu tài khoản tồn tại, kiểm tra mật khẩu
                            if (matKhau2 == matKhau)
                                return true; // Đăng nhập thành công
                            else
                                return false; // Mật khẩu không đúng
                        }
                    }               
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                daTonTaiTK = false;
                return false;
            }
        }
    }
}
