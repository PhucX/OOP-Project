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

        void ImportNguoiDung(string taiKhoan, string filePath); // lấy thông tin người dùng
        void ImportTaiKhoan(string filePath); // lấy dữ liệu cho tài khoản người dùng
        void ImportGiaoDich(string filePath, string sheetName); // lấy dữ liệu cho tài khoản người dùng
        void ImportKhoanVay(string filePath, string sheetName); // lấy dữ liệu khoản vay cho người dùng
    }

    public class ExcelImporter : IImporter
    {
        public void ImportNguoiDung(string taiKhoan, string filePath)
        {
            try
            {
                using (XLWorkbook workbook = new XLWorkbook(filePath))
                {
                    IXLWorksheet worksheet = workbook.Worksheet(1);

                    foreach (IXLRow row in worksheet.RowsUsed().Skip(1))
                    {
                        if(row.Cell(1).Value.ToString() == taiKhoan)
                        {
                            NguoiDung nguoiDung = new NguoiDung(taiKhoan, row.Cell(2).Value.ToString(), row.Cell(3).Value.ToString(), row.Cell(4).Value.ToString(), row.Cell(5).Value.ToString());
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void ImportTaiKhoan(string filePath)
        {
            try
            {
                using (XLWorkbook workbook = new XLWorkbook(filePath))
                {
                    IXLWorksheet worksheet = workbook.Worksheet(1);

                    foreach (IXLRow row in worksheet.RowsUsed().Skip(1))
                    {
                        string tenThe = row.Cell(1).Value.ToString();
                        DichVuTaiKhoan.Instance.Them(tenThe, new TaiKhoan(tenThe, double.Parse(row.Cell(2).Value.ToString()), row.Cell(3).Value.ToString()));
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

                        if (maVay.Contains("debt"))
                        {
                            DichVuVay.Instance.Them(maVay, new KhoanNo(maVay,
                            double.Parse(row.Cell(2).Value.ToString()),
                            double.Parse(row.Cell(3).Value.ToString()),
                            DateTime.Parse(row.Cell(4).Value.ToString()),
                            DateTime.Parse(row.Cell(5).Value.ToString()),
                            row.Cell(6).Value.ToString(), row.Cell(7).Value.ToString()));
                        }
                        else if(maVay.Contains("loan"))
                        {
                            DichVuVay.Instance.Them(maVay, new KhoanChoVay(maVay,
                            double.Parse(row.Cell(2).Value.ToString()),
                            double.Parse(row.Cell(3).Value.ToString()),
                            DateTime.Parse(row.Cell(4).Value.ToString()),
                            DateTime.Parse(row.Cell(5).Value.ToString()),
                            row.Cell(6).Value.ToString(), row.Cell(8).Value.ToString()));
                        }

                        int cnt = 9;
                        var cellValue = row.Cell(9).Value.ToString().Trim();
                        while (!string.IsNullOrEmpty(cellValue)) // Kiểm tra cột kế tiếp
                        {
                            string[] parts = cellValue.Split(',');
                            if (parts.Length < 3)
                                break;

                            DichVuVay.Instance.DanhSachKhoanVay[maVay].ThemDanhSach(new ThanhToan(double.Parse(parts[0]), DateTime.Parse(parts[1].ToString()), parts[3].ToString()));

                            cellValue = row.Cell(++cnt).Value.ToString();
                        }    
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
                            DateTime.Parse(row.Cell(3).Value.ToString()),
                            double.Parse(row.Cell(4).Value.ToString()),
                            row.Cell(2).Value.ToString(),
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
        void ExportNguoiDung(string filePath);
        void ExportTaiKhoan(string filePath);

        void ExportKhoanVay(string taiKhoan, string filePath);
        void ExportGiaoDich(string taiKhoan, string filePath);

    }

    public class ExcelExporter : IExporter
    {
        public void ExportTaiKhoan(string filePath)
        {
            try
            {

                using (XLWorkbook workbook = new XLWorkbook(filePath))
                {
                    // Nếu là file mới thì thêm worksheet
                    IXLWorksheet worksheet = workbook.Worksheets.Worksheet(1);
                    worksheet.Clear();

                    worksheet.Cell(1, 1).Value = "Tên tài khoản";
                    worksheet.Cell(1, 2).Value = "Số dư";
                    worksheet.Cell(1, 3).Value = "Loại thẻ";

                    int lastRowUsed = worksheet.RowsUsed().Count() + 1;

                    // ghi đè bản Excel
                    foreach (var taiKhoan in DichVuTaiKhoan.Instance.DanhSachTaiKhoan)
                    {
                        worksheet.Cell(lastRowUsed, 1).Value = taiKhoan.Value.TenTaiKhoan;
                        worksheet.Cell(lastRowUsed, 2).Value = taiKhoan.Value.SoDu.ToString();
                        worksheet.Cell(lastRowUsed, 3).Value = taiKhoan.Value.LoaiThe.ToString();
                        lastRowUsed++;
                    }
                    // Lưu lại file và ghi đè lên file gốc
                    workbook.SaveAs(filePath);
                }

                MessageBox.Show("Đăng ký thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public void ExportGiaoDich(string taiKhoan, string filePath)
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
                    worksheet.Clear();

                    // Thêm tiêu đề cột
                    worksheet.Cell(1, 1).Value = "Mã giao dịch";
                    worksheet.Cell(1, 2).Value = "Loại giao dịch";
                    worksheet.Cell(1, 3).Value = "Ngày giao dịch";
                    worksheet.Cell(1, 4).Value = "Số tiền";
                    worksheet.Cell(1, 5).Value = "Ghi chú";
                    worksheet.Cell(1, 6).Value = "Ví điện tử";

                    int lastRowUsed = worksheet.RowsUsed().Count() + 1;

                    foreach (var giaoDich in DichVuGiaoDich.Instance.DanhSachGiaoDich)
                    {

                        worksheet.Cell(lastRowUsed, 1).Value = giaoDich.Value.MaGiaoDich;
                        worksheet.Cell(lastRowUsed, 2).Value = giaoDich.Value.LoaiGiaoDich;
                        worksheet.Cell(lastRowUsed, 3).Value = giaoDich.Value.NgayGiaoDich.ToString();
                        worksheet.Cell(lastRowUsed, 4).Value = giaoDich.Value.SoTienGiaoDich.ToString();
                        worksheet.Cell(lastRowUsed, 5).Value = giaoDich.Value.GhiChu;
                        worksheet.Cell(lastRowUsed, 6).Value = giaoDich.Value.ViDienTu;
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
                    worksheet.Clear();

                    // Thêm tiêu đề cột
                    worksheet.Cell(1, 1).Value = "Mã vay";
                    worksheet.Cell(1, 2).Value = "Số tiền vay";
                    worksheet.Cell(1, 3).Value = "Lãi suất";
                    worksheet.Cell(1, 4).Value = "Ngày vay";
                    worksheet.Cell(1, 5).Value = "Ngày đến hạn";
                    worksheet.Cell(1, 6).Value = "Trạng thái";
                    worksheet.Cell(1, 7).Value = "Người cho vay";
                    worksheet.Cell(1, 8).Value = "Người vay";

                    int lastRowUsed = worksheet.RowsUsed().Count() + 1;
                    
                    foreach (var khoanVay in DichVuVay.Instance.DanhSachKhoanVay)
                    {
                        worksheet.Cell(lastRowUsed, 1).Value = khoanVay.Value.IdKhoanVay;
                        worksheet.Cell(lastRowUsed, 2).Value = khoanVay.Value.SoTienVay.ToString();
                        worksheet.Cell(lastRowUsed, 3).Value = khoanVay.Value.LaiSuat.ToString();
                        worksheet.Cell(lastRowUsed, 4).Value = khoanVay.Value.NgayVay.ToString();
                        worksheet.Cell(lastRowUsed, 5).Value = khoanVay.Value.NgayDenHan.ToString();
                        worksheet.Cell(lastRowUsed, 6).Value = khoanVay.Value.TrangThai;
                        

                        if (khoanVay.Value is KhoanNo)
                        {
                            KhoanNo khoanNo = (KhoanNo)khoanVay.Value; // nếu khoản vay là nợ

                            worksheet.Cell(lastRowUsed, 7).Value = khoanNo.NguoiChoVay;
                            worksheet.Cell(lastRowUsed, 8).Value = taiKhoan;
                        }
                        else
                        {
                            KhoanChoVay khoanChoVay = (KhoanChoVay)khoanVay.Value; // khoản vay là cho vay

                            worksheet.Cell(lastRowUsed, 7).Value = taiKhoan;
                            worksheet.Cell(lastRowUsed, 8).Value = khoanChoVay.NguoiVay;
                        }

                        var cellValue = DichVuVay.Instance.DanhSachKhoanVay[khoanVay.Value.IdKhoanVay];

                        int cnt = 9;
                        for (int i = 0; i < cellValue.SoLuongThanhToan();i++)
                        {
                            worksheet.Cell(lastRowUsed, cnt++).Value = $"{cellValue.DanhSachThanhToan[i].SoTienThanhToan},{cellValue.DanhSachThanhToan[i].NgayThanhToan},{cellValue.DanhSachThanhToan[i].TaiKhoanDaThanhToan}";
                        }
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

        public void ExportNguoiDung(string filePath)
        {
            try
            {
                bool isNewFile = !File.Exists(filePath);  // Kiểm tra file có tồn tại không

                using (XLWorkbook workbook = isNewFile ? new XLWorkbook() : new XLWorkbook(filePath))
                {
                    // Nếu là file mới thì thêm worksheet
                    IXLWorksheet worksheet = workbook.Worksheets.FirstOrDefault() ?? workbook.AddWorksheet("Sheet1");

                    // Xác định vị trí dòng cuối cùng của sheet
                    int viTriHienTai = 2;

                    foreach(IXLRow row in  worksheet.RowsUsed().Skip(1))
                    {
                        if(row.Cell(1).Value.ToString() == NguoiDung.TaiKhoanNguoiDung)
                            break;

                        ++viTriHienTai;
                    }

                    worksheet.Cell(viTriHienTai, 1).Value = NguoiDung.TaiKhoanNguoiDung;
                    worksheet.Cell(viTriHienTai, 2).Value = NguoiDung.MatKhau;
                    worksheet.Cell(viTriHienTai, 3).Value = NguoiDung.TenNguoiDung;
                    worksheet.Cell(viTriHienTai, 4).Value = NguoiDung.SoDienThoai;
                    worksheet.Cell(viTriHienTai, 5).Value = NguoiDung.DiaChi;

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
        public void ExportTaiKhoan(string filePath)
        {
            _exporter.ExportTaiKhoan(filePath);
        }

        public void ExportGiaoDich(string taiKhoan, string filePath)
        {
            _exporter.ExportGiaoDich(taiKhoan, filePath);
        }

        public void ExportKhoanVay(string taiKhoan, string filePath)
        {
            _exporter.ExportKhoanVay(taiKhoan, filePath);
        }

        public void ExportNguoiDung(string filePath)
        {
            _exporter.ExportNguoiDung(filePath);
        }
        public void ImportNguoiDung(string taiKhoan, string filePath)
        {
            _importer.ImportNguoiDung(taiKhoan, filePath);
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
