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
        void Import(string filePath);
    }

    public class ExcelImporter : IImporter
    {
        public void Import(string filePath)
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
        void Export(DataGridView dataGridView, string filePath);
    }

    public class ExcelExporter : IExporter
    {
        public void Export(DataGridView dataGridView, string filePath)
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
                        for (int i = 1; i < dataGridView.Rows.Count - 2; i++)
                        {
                            for (int j = 1; j < dataGridView.Columns.Count - 2; j++)
                            {
                                worksheet.Cell(i + 2, j + 1).Value = dataGridView.Rows[i].Cells[j].Value.ToString();
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
        public void ExportData(DataGridView dataGridView, string filePath)
        {
            _exporter.Export(dataGridView, filePath);
        }

        public void ImportData(string filePath)
        {
            _importer.Import(filePath);
        }
    }
}
