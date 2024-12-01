using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using ClosedXML.Excel;
using QuanLyChiTieu.Modules;
using QuanLyChiTieu.Objects;

namespace QuanLyChiTieu
{
    public interface IImporter
    {

        void ImportTaiKhoan(string filePath); // lấy dữ liệu cho tài khoản người dùng

        void ImportGiaoDich(string filePath, string sheetName); // lấy dữ liệu cho tài khoản người dùng
        void ImportKhoanVay(string filePath, string sheetName); // lấy dữ liệu khoản vay cho người dùng
    }

    public class ExcelImporter : IImporter
    {
        public void ImportTaiKhoan(string filePath)
        {
            try
            {
                using (XLWorkbook workbook = new XLWorkbook(filePath))
                {
                    IXLWorksheet worksheet = workbook.Worksheet(1);

                    foreach (IXLRow row in worksheet.RowsUsed().Skip(1))
                    {
                        string maThe = row.Cell(1).Value.ToString();
                        DichVuTaiKhoan.Instance.Them(maThe, new TaiKhoan(maThe, row.Cell(2).Value.ToString(), row.Cell(3).Value.ToString(), double.Parse(row.Cell(4).Value.ToString())));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ImportKhoanVay(string filePath, string sheetName)
        {
            try
            {
                using (XLWorkbook workbook = new XLWorkbook(filePath))
                {
                    IXLWorksheet worksheet = workbook.Worksheet(sheetName);

                    foreach (IXLRow row in worksheet.RowsUsed().Skip(1))
                    {
                        string maVay = row.Cell(1).Value.ToString();

                        DichVuVay.Instance.Them(maVay, new KhoanNo(maVay,
                            double.Parse(row.Cell(3).Value.ToString()),
                            double.Parse(row.Cell(4).Value.ToString()),
                            DateTime.Parse(row.Cell(5).Value.ToString()),
                            row.Cell(6).Value.ToString(), row.Cell(7).Value.ToString()));

                        maVay = row.Cell(2).Value.ToString();

                        DichVuVay.Instance.Them(maVay, new KhoanChoVay(maVay,
                            double.Parse(row.Cell(3).Value.ToString()),
                            double.Parse(row.Cell(4).Value.ToString()),
                            DateTime.Parse(row.Cell(5).Value.ToString()),
                            row.Cell(6).Value.ToString(), row.Cell(8).Value.ToString()));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ImportGiaoDich(string filePath, string sheetName)
        {
            try
            {
                using (XLWorkbook workbook = new XLWorkbook(filePath))
                {
                    IXLWorksheet worksheet = workbook.Worksheet(sheetName);

                    foreach (IXLRow row in worksheet.RowsUsed().Skip(1))
                    {
                        string maVay = row.Cell(1).Value.ToString();
                        
                        DichVuGiaoDich.Instance.Them(maVay, new GiaoDich(maVay,
                            DateTime.Parse(row.Cell(2).Value.ToString()),
                            double.Parse(row.Cell(3).Value.ToString()),
                            row.Cell(4).Value.ToString(),
                            row.Cell(5).Value.ToString()));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    public interface IExporter
    {
        void ExportKhoanVay(string taiKhoan, string filePath);
        void ExportNguoiDung(string tenTK, string mkTK, string filePath);

    }

    public class ExcelExporter : IExporter
    {
        public void ExportKhoanVay(string taiKhoan, string filePath)
        {
            try
            {
                bool isNewFile = !File.Exists(filePath);  // Kiểm tra file có tồn tại không

                using (XLWorkbook workbook = isNewFile ? new XLWorkbook() : new XLWorkbook(filePath))
                {
                    IXLWorksheet worksheet;
                    int count = workbook.Worksheets.Count;
                    if (count == 0)
                        worksheet = workbook.Worksheets.Add(taiKhoan);
                    else
                    {
                        bool isSheetExists = workbook.Worksheets.Contains(taiKhoan);

                        if (!isSheetExists)
                            worksheet = workbook.Worksheets.Add(taiKhoan, count + 1);
                        else
                            worksheet = workbook.Worksheets.Worksheet(taiKhoan);
                    }

                    // Thêm tiêu đề cột
                    worksheet.Cell(1, 1).Value = "Mã khoản nợ";
                    worksheet.Cell(1, 2).Value = "Mã cho vay";
                    worksheet.Cell(1, 3).Value = "Số tiền vay";
                    worksheet.Cell(1, 4).Value = "Lãi suất";
                    worksheet.Cell(1, 5).Value = "Ngày đến hạn";
                    worksheet.Cell(1, 6).Value = "Trạng thái";
                    worksheet.Cell(1, 7).Value = "Người cho vay";
                    worksheet.Cell(1, 8).Value = "Người vay";

                    int lastRowUsed = worksheet.RowsUsed().Count() + 1;
                    
                    foreach (var khoanVay in DichVuVay.Instance.DanhSachKhoanVay.Where(khoanNo => khoanNo.Value is KhoanNo).ToList())
                    {
                        KhoanNo khoanNo = khoanVay.Value as KhoanNo;

                        worksheet.Cell(lastRowUsed, 1).Value = khoanNo.IdKhoanVay.ToString();
                        worksheet.Cell(lastRowUsed, 2).Value = "loan" + khoanNo.IdKhoanVay.Substring(4);
                        worksheet.Cell(lastRowUsed, 3).Value = khoanNo.SoTienVay.ToString();
                        worksheet.Cell(lastRowUsed, 4).Value = khoanNo.LaiSuat.ToString();
                        worksheet.Cell(lastRowUsed, 5).Value = khoanNo.NgayDenHan.ToString();
                        worksheet.Cell(lastRowUsed, 6).Value = khoanNo.TrangThai.ToString();
                        worksheet.Cell(lastRowUsed, 7).Value = khoanNo.NguoiChoVay.ToString();
                        worksheet.Cell(lastRowUsed, 8).Value = taiKhoan;

                        lastRowUsed += 1; // tăng chỉ số hàng đã dùng thêm 1
                    }

                    FileInfo excelFile = new FileInfo(filePath);
                    workbook.SaveAs(filePath);
                }

                MessageBox.Show("Dữ liệu đã được xuất ra file Excel thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ExportNguoiDung(string tenTK, string mkTK, string filePath)
        {
            try
            {
                bool isNewFile = !File.Exists(filePath);  // Kiểm tra file có tồn tại không

                using (XLWorkbook workbook = isNewFile ? new XLWorkbook() : new XLWorkbook(filePath))
                {
                    // Nếu là file mới thì thêm worksheet
                    IXLWorksheet worksheet = workbook.Worksheets.FirstOrDefault() ?? workbook.AddWorksheet("Sheet1");

                    // Xác định vị trí dòng cuối cùng của sheet
                    int lastRow = worksheet.RowsUsed().Count();

                    // Thêm dữ liệu từ DataGridView vào cuối sheet
                    worksheet.Cell(lastRow + 1, 1).Value = tenTK;
                    worksheet.Cell(lastRow + 1, 2).Value = mkTK;

                    // Lưu lại file Excel
                    if (isNewFile)
                        workbook.SaveAs(filePath);  // Lưu lần đầu tiên nếu là file mới
                    else
                        workbook.Save();  // Lưu thay đổi vào file hiện có
                }

                MessageBox.Show("Đăng ký thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }

    public class DataManager
    {
        private IImporter _importer;
        private IExporter _exporter;

        public DataManager(IImporter importer)
        {
            _importer = importer;
        }

        public DataManager(IExporter exporter)
        {
            _exporter = exporter;
        }
        public void ExportKhoanVay(string taiKhoan, string filePath)
        {
            _exporter.ExportKhoanVay(taiKhoan, filePath);
        }

        public void ExportNguoiDung(string tenTk, string mkTK, string filePath)
        {
            _exporter.ExportNguoiDung(tenTk, mkTK, filePath);
        }
        public void ImportTaiKhoan(string filePath)
        {
            _importer.ImportTaiKhoan(filePath);
        }

        public void ImportKhoanVay(string filePath, string sheetName)
        {
            _importer.ImportKhoanVay(filePath, sheetName);
        }


        public void ImportGiaoDich(string filePath, string sheetName)
        {
            _importer.ImportGiaoDich(filePath, sheetName);
        }
    }
}
