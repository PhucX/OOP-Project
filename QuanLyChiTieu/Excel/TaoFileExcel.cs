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
using QuanLyChiTieu.Modules;
using System.Text.RegularExpressions;

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
                        worksheet.Cell(1, 1).Value = "Tên tài khoản";
                        worksheet.Cell(1, 2).Value = "Số dư";
                        worksheet.Cell(1, 3).Value = "Loại thẻ";

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
                        worksheet.Cell(1, 1).Value = "Mã vay";
                        worksheet.Cell(1, 2).Value = "Số tiền vay";
                        worksheet.Cell(1, 3).Value = "Lãi suất";
                        worksheet.Cell(1, 4).Value = "Ngày vay";
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

        public void ThemSheet(string filePath, string sheetName)
        {
            try
            {
                using (XLWorkbook workbook = new XLWorkbook(filePath))
                {
                    // Thêm một worksheet mới vào workbook
                    IXLWorksheet worksheet = workbook.AddWorksheet(sheetName);

                    // Lưu workbook vào file Excel
                    workbook.Save();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi tạo file Excel: " + ex.Message);
            }
        }

        public void ThemKhoanNo(string filePath, string sheetName, KhoanNo khoanNo)
        {
            try
            {
                using (XLWorkbook workbook = new XLWorkbook(filePath))
                {
                    // Thêm một worksheet mới vào workbook
                    IXLWorksheet worksheet = workbook.Worksheet(sheetName);

                    int lastRowUsed = worksheet.RowsUsed().Count() + 1;

                    string maVay = "loan";
                    for (int i = 0; i < khoanNo.IdKhoanVay.Count(); i++)
                        maVay += khoanNo.IdKhoanVay[i];


                    worksheet.Cell(lastRowUsed, 1).Value = "loan" + maVay;
                    worksheet.Cell(lastRowUsed, 2).Value = khoanNo.SoTienVay.ToString();
                    worksheet.Cell(lastRowUsed, 3).Value = khoanNo.LaiSuat.ToString();
                    worksheet.Cell(lastRowUsed, 4).Value = khoanNo.NgayVay.ToString();
                    worksheet.Cell(lastRowUsed, 5).Value = khoanNo.NgayDenHan.ToString();
                    worksheet.Cell(lastRowUsed, 6).Value = khoanNo.TrangThai;
                    worksheet.Cell(lastRowUsed, 7).Value = khoanNo.NguoiChoVay;
                    worksheet.Cell(lastRowUsed, 8).Value = NguoiDung.TaiKhoanNguoiDung;

                    // Lưu workbook vào file Excel
                    workbook.Save();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi tạo file Excel: " + ex.Message);
            }
        }

        public void ThemKhoanChoVay(string filePath, string sheetName, KhoanChoVay khoanChoVay)
        {
            try
            {
                using (XLWorkbook workbook = new XLWorkbook(filePath))
                {
                    // Thêm một worksheet mới vào workbook
                    IXLWorksheet worksheet = workbook.Worksheet(sheetName);

                    int lastRowUsed = worksheet.RowsUsed().Count() + 1;

                    worksheet.Cell(lastRowUsed, 1).Value = khoanChoVay.IdKhoanVay;
                    worksheet.Cell(lastRowUsed, 2).Value = khoanChoVay.SoTienVay.ToString();
                    worksheet.Cell(lastRowUsed, 3).Value = khoanChoVay.LaiSuat.ToString();
                    worksheet.Cell(lastRowUsed, 4).Value = khoanChoVay.NgayVay.ToString();
                    worksheet.Cell(lastRowUsed, 5).Value = khoanChoVay.NgayDenHan.ToString();
                    worksheet.Cell(lastRowUsed, 6).Value = khoanChoVay.TrangThai;
                    worksheet.Cell(lastRowUsed, 7).Value = NguoiDung.TaiKhoanNguoiDung;
                    worksheet.Cell(lastRowUsed, 8).Value = sheetName;

                    // Lưu workbook vào file Excel
                    workbook.Save();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi tạo file Excel: " + ex.Message);
            }
        }
    }
}
