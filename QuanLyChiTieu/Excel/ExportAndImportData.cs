using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClosedXML.Excel;
using QuanLyChiTieu.Modules;
using QuanLyChiTieu.Objects;

namespace QuanLyChiTieu
{
    public interface IImporter
    {
        void ImportKhoanVay(string filePath); // lấy dữ liệu khoản vay cho người dùng

        void ImportTaiKhoan(string filePath); // lấy dữ liệu cho tài khoản người dùng
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

        public void ImportKhoanVay(string filePath)
        {
            try
            {
                using (XLWorkbook workbook = new XLWorkbook(filePath))
                {
                    IXLWorksheet worksheet = workbook.Worksheet(1);

                    foreach (IXLRow row in worksheet.RowsUsed().Skip(1))
                    {
                        DichVuGiaoDich.Instance.Them(row.Cell(1).Value.ToString(), new GiaoDich(row.Cell(2).Value.ToString(),
                            DateTime.Parse(row.Cell(3).Value.ToString()),
                            double.Parse(row.Cell(4).Value.ToString()),
                            row.Cell(5).Value.ToString(),
                            row.Cell(6).Value.ToString()));
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
        void ExportKhoanVay(DataGridView dataGridView, string filePath);
        void ExportNguoiDung(string tenTK, string mkTK, string filePath);

    }

    public class ExcelExporter : IExporter
    {
        public void ExportKhoanVay(DataGridView dataGridView, string filePath)
        {
            try
            {
                using (XLWorkbook workbook = new XLWorkbook())
                {
                    IXLWorksheet worksheet = workbook.Worksheets.Add("Sheet1");

                    for (int i = 1; i < dataGridView.Columns.Count - 2; i++)
                    {
                        worksheet.Cell(1, i).Value = dataGridView.Columns[i].HeaderText;
                    }

                    if (dataGridView.Rows.Count > 0)
                    {
                        for (int i = 0; i < dataGridView.Rows.Count; i++)
                        {
                            for (int j = 1; j < dataGridView.Columns.Count - 2; j++)
                            {
                                worksheet.Cell(i + 2, j).Value = dataGridView.Rows[i].Cells[j].Value.ToString();
                            }
                        }
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
        public void ExportKhoanVay(DataGridView dataGridView, string filePath)
        {
            _exporter.ExportKhoanVay(dataGridView, filePath);
        }

        public void ExportNguoiDung(string tenTk, string mkTK, string filePath)
        {
            _exporter.ExportNguoiDung(tenTk, mkTK, filePath);
        }

        public void ImportKhoanVay(string filePath)
        {
            _importer.ImportKhoanVay(filePath);
        }

        public void ImportTaiKhoan(string filePath)
        {
            _importer.ImportTaiKhoan(filePath);
        }
    }
}
