using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClosedXML.Excel;
using System.IO;
using QuanLyChiTieu.Objects;
using DocumentFormat.OpenXml.Spreadsheet;
using System.Windows.Forms;

namespace QuanLyChiTieu.Excel
{
    public abstract class IExcelFileCreator
    {
        public abstract void TaoFile(string filePath, string sheetName);
    }
    public class TaoFileTaiKhoan : IExcelFileCreator
    {
        public override void TaoFile(string filePath, string sheetName)
        {
            if (File.Exists(filePath))
                return;
            else
            {
                try
                {
                    using (XLWorkbook workbook = new XLWorkbook())
                    {
                        // Thêm một worksheet mới vào workbook
                        IXLWorksheet worksheet = workbook.AddWorksheet(sheetName);

                        // Thêm tiêu đề cột
                        worksheet.Cell(1, 1).Value = "Mã thẻ";
                        worksheet.Cell(1, 2).Value = "Tên tài khoản";
                        worksheet.Cell(1, 3).Value = "Loại tài khoản";
                        worksheet.Cell(1, 4).Value = "Số dư";

                        // Lưu workbook vào file Excel
                        workbook.SaveAs(filePath);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi khi tạo file Excel: " + ex.Message);
                }
            }
        }
    }

    public class TaoFileGiaoDich : IExcelFileCreator
    {
        public override void TaoFile(string filePath, string sheetName)
        {
            if (File.Exists(filePath))
                return;
            else
            {
                try
                {
                    using (XLWorkbook workbook = new XLWorkbook())
                    {
                        // Thêm một worksheet mới vào workbook
                        IXLWorksheet worksheet = workbook.AddWorksheet(sheetName);

                        // Thêm tiêu đề cột
                        worksheet.Cell(1, 1).Value = "Mã giao dịch";
                        worksheet.Cell(1, 3).Value = "Ngày giao dịch";
                        worksheet.Cell(1, 4).Value = "Số tiền";
                        worksheet.Cell(1, 2).Value = "Loại giao dịch";
                        worksheet.Cell(1, 5).Value = "Ghi chú";

                        // Lưu workbook vào file Excel
                        workbook.SaveAs(filePath);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi khi tạo file Excel: " + ex.Message);
                }
            }
        }
    }

    public class TaoFileKhoanVay : IExcelFileCreator
    {
        public override void TaoFile(string filePath, string sheetName)
        {
            if (File.Exists(filePath))
                return;
            else
            {
                try
                {
                    using (XLWorkbook workbook = new XLWorkbook())
                    {
                        // Thêm một worksheet mới vào workbook
                        IXLWorksheet worksheet = workbook.AddWorksheet(sheetName);

                        // Thêm tiêu đề cột
                        worksheet.Cell(1, 1).Value = "Mã khoản nợ";
                        worksheet.Cell(1, 2).Value = "Mã cho vay";
                        worksheet.Cell(1, 3).Value = "Số tiền vay";
                        worksheet.Cell(1, 4).Value = "Lãi suất";
                        worksheet.Cell(1, 5).Value = "Ngày đến hạn";
                        worksheet.Cell(1, 6).Value = "Trạng thái";
                        worksheet.Cell(1, 7).Value = "Người cho vay";
                        worksheet.Cell(1, 8).Value = "Người vay";

                        // Lưu workbook vào file Excel
                        workbook.SaveAs(filePath);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi khi tạo file Excel: " + ex.Message);
                }
            }
        }
    }

    public class DataCreator
    {
        private IExcelFileCreator _creator;

        public DataCreator(IExcelFileCreator _creator)
        {
            this._creator = _creator;
        }

        public void TaoFile(string filePath, string sheetName)
        {
            _creator.TaoFile(filePath, sheetName);
        }
    }
}
