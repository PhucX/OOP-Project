using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClosedXML.Excel;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyChiTieu.Excel
{
    public class ExcelSheetDeleter
    {
        public void RemoveSheet(string filePath, string sheetName)
        {
            try
            {
                // Mở file Excel
                using (var workbook = new XLWorkbook(filePath))
                {
                    var worksheet = workbook.Worksheet(sheetName);
                    if (worksheet != null)
                        // Xóa sheet
                        workbook.Worksheets.Delete(sheetName);

                    // Lưu thay đổi
                    workbook.Save();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
