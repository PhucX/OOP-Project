using QuanLyChiTieu.Modules;
using QuanLyChiTieu.Objects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace QuanLyChiTieu
{
    public partial class fBaoCao : Form
    {
        private DateTime Ngaybatdau;
        private DateTime Ngayketthuc;
        private int Numberofdate;
        private DataTable da_thunhap = new DataTable();
        private DataTable da_chitieu = new DataTable();
        public static fBaoCao Instance
        {
            get
            {
                if (Instance == null)
                    Instance = new fBaoCao();
                return Instance;
            }

            set => Instance = value;
        }
        public fBaoCao()
        {
            InitializeComponent();
            dtpStartDate.Value = DateTime.Today.AddDays(-7);
            ptbEndDate.Value = DateTime.Now;
            guna2Button3.Select();


        }

        private Double Gettongthunhap(DateTime Ngaybatdau, DateTime Ngayketthuc)
        {
            Double tongthunhap = 0;
            tongthunhap += QuanLyChiTieu.Objects.DichVuGiaoDich.Instance.Tongthunhap( Ngaybatdau,  Ngayketthuc);
            tongthunhap += QuanLyChiTieu.Objects.DichVuVay.Instance.Tongthunhap( Ngaybatdau,  Ngayketthuc);
            return tongthunhap;
        }
        private Double Gettongchitieu(DateTime Ngaybatdau, DateTime Ngayketthuc)
        {
            Double tongchitieu = 0;
            tongchitieu += QuanLyChiTieu.Objects.DichVuGiaoDich.Instance.Tongchitieu(Ngaybatdau, Ngayketthuc);
            tongchitieu += QuanLyChiTieu.Objects.DichVuVay.Instance.Tongchitieu( Ngaybatdau, Ngayketthuc);
            return tongchitieu;
        }

        public void LoadData_tmp(DateTime Ngaybatdau, DateTime Ngayketthuc)
        {
            Double[] thunhap = new Double[0];
            Double[] chitieu = new Double[0];
            da_thunhap.Clear();
            da_chitieu.Clear();
            this.Ngaybatdau = Ngaybatdau;
            this.Ngayketthuc = Ngayketthuc;
            this.Numberofdate = (Ngayketthuc - Ngaybatdau).Days + 1;
            thunhap = new Double[this.Numberofdate];
            chitieu = new double[this.Numberofdate];

            foreach (GiaoDich giaodich in QuanLyChiTieu.Objects.DichVuGiaoDich.Instance.DanhSachGiaoDich.Values)
            {
                if (giaodich.NgayGiaoDich >= Ngaybatdau && giaodich.NgayGiaoDich <= Ngayketthuc)
                {
                    int index = (giaodich.NgayGiaoDich - Ngaybatdau).Days;
                    if (index >= 0 && index < thunhap.Length)
                    {
                        if (giaodich.LoaiGiaoDich == "Thu nhập")
                            thunhap[index] += giaodich.SoTienGiaoDich;
                        else
                            chitieu[index] += giaodich.SoTienGiaoDich;
                    }
                }
            }

            foreach (KhoanVay khoanvay in QuanLyChiTieu.Objects.DichVuVay.Instance.DanhSachKhoanVay.Values)
            {
                if (khoanvay.NgayVay >= Ngaybatdau && khoanvay.NgayVay <= Ngayketthuc)
                {
                    int index = (khoanvay.NgayVay - Ngaybatdau).Days;
                    if (index >= 0 && index < thunhap.Length)
                    {
                        if (khoanvay.IdKhoanVay.Contains("debt"))
                            thunhap[index] += khoanvay.SoTienVay;
                        else
                            chitieu[index] += khoanvay.SoTienVay;
                    }
                }
            }

            if (da_thunhap.Columns.Count == 0)
            {
                da_thunhap.Columns.Add("Ngay", typeof(DateTime));
                da_thunhap.Columns.Add("Tongthunhap", typeof(Double));
            }
            if (da_chitieu.Columns.Count == 0)
            {
                da_chitieu.Columns.Add("Ngay", typeof(DateTime));
                da_chitieu.Columns.Add("Tongchitieu", typeof(Double));
            }
            for (DateTime dateTime = Ngaybatdau; dateTime <= Ngayketthuc; dateTime = dateTime.AddDays(1))
            {
                int index = (dateTime - Ngaybatdau).Days;
                if (index >= 0 && index < thunhap.Length)
                {
                    da_thunhap.Rows.Add(dateTime, thunhap[index]);
                    da_chitieu.Rows.Add(dateTime, chitieu[index]);
                }
            }
            guna2HtmlLabel2.Text = Gettongthunhap(Ngaybatdau, Ngayketthuc).ToString();
            guna2HtmlLabel3.Text = Gettongchitieu(Ngaybatdau, Ngayketthuc).ToString();
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            LoadData_tmp(dtpStartDate.Value, ptbEndDate.Value);
            Drawchart(da_thunhap,da_chitieu);
        }
        public void Drawchart(DataTable tablethunhap, DataTable tablechitieu)
        {
            chart1.Series.Clear();
            chart2.Series.Clear();
            chart3.Series.Clear();

            // Tạo các Series cho Thu Nhập và Chi Tiêu
            Series seriesChiTieu = new Series("Tổng Chi Tiêu");
            Series seriesThuNhap = new Series("Tổng Thu Nhập");

            seriesChiTieu.ChartType = SeriesChartType.Column; // Biểu đồ cột cho Chi Tiêu
            seriesThuNhap.ChartType = SeriesChartType.Column; // Biểu đồ cột cho Thu Nhập
            seriesChiTieu.XValueType = ChartValueType.DateTime;
            seriesThuNhap.XValueType = ChartValueType.DateTime;

            // Thêm dữ liệu vào biểu đồ Thu Nhập
            double tongThuNhap;
            foreach (DataRow row in tablethunhap.Rows)
            {
                DateTime ngay = (DateTime)row["Ngay"];
                tongThuNhap = (double)row["Tongthunhap"];
                seriesThuNhap.Points.AddXY(ngay.Date, tongThuNhap);
            }

            chart1.ChartAreas[0].AxisX.LabelStyle.Format = "dd-MM-yyyy";
            chart1.ChartAreas[0].AxisX.Interval = 1;
            chart1.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Days;

            // Thêm dữ liệu vào biểu đồ Chi Tiêu
            double tongChiTieu;
            foreach (DataRow row in tablechitieu.Rows)
            {
                DateTime ngay = (DateTime)row["Ngay"];
                tongChiTieu = (double)row["Tongchitieu"];
                seriesChiTieu.Points.AddXY(ngay.Date, tongChiTieu);
            }

            chart2.ChartAreas[0].AxisX.LabelStyle.Format = "dd-MM-yyyy";
            chart2.ChartAreas[0].AxisX.Interval = 1;
            chart2.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Days;

            chart1.ChartAreas[0].AxisY.Title = "Số tiền (VNĐ)";
            chart2.ChartAreas[0].AxisY.Title = "Số tiền (VNĐ)";

            chart1.Series.Add(seriesThuNhap);
            chart2.Series.Add(seriesChiTieu);

            // Cập nhật Biểu đồ Doughnut
            Series doughnutSeries = new Series("Tổng Thu Nhập/Chi Tiêu");
            doughnutSeries.ChartType = SeriesChartType.Doughnut;
            doughnutSeries.IsValueShownAsLabel = true;
            doughnutSeries.LabelForeColor = Color.White;
            doughnutSeries.Font = new Font("Microsoft Sans Serif", 12F);

            tongThuNhap = Gettongthunhap(Ngaybatdau, Ngayketthuc);
            tongChiTieu = Gettongchitieu(Ngaybatdau, Ngayketthuc);
            doughnutSeries.Points.AddXY("Thu Nhập", tongThuNhap);
            doughnutSeries.Points.AddXY("Chi Tiêu", tongChiTieu);

            chart3.Titles.Clear();
            chart3.Series.Add(doughnutSeries);
            chart3.ChartAreas[0].Area3DStyle.Enable3D = true;
            chart3.Titles.Add("Biểu đồ tỷ lệ Thu Nhập và Chi Tiêu");
        }



        private void guna2Button1_Click(object sender, EventArgs e)
        {
            dtpStartDate.Value= DateTime.Today;
            ptbEndDate.Value= DateTime.Today;
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            DateTime today = DateTime.Today;
            // Đặt ngày bắt đầu là ngày 1 của tháng hiện tại
            dtpStartDate.Value = new DateTime(today.Year, today.Month, 1);

            // Đặt ngày kết thúc là hôm nay
            ptbEndDate.Value = new DateTime(today.Year, today.Month, DateTime.DaysInMonth(today.Year, today.Month));
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            dtpStartDate.Value = DateTime.Today.AddDays(-7);
            ptbEndDate.Value = DateTime.Now;
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            da_thunhap=new DataTable();
            da_chitieu=new DataTable();
            chart1.Series.Clear();
            chart2.Series.Clear();
            chart3.Series.Clear();
        }

        private void fBaoCao_Load(object sender, EventArgs e)
        {

        }
    }
}
