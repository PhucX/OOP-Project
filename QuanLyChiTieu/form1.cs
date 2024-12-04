using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyChiTieu.Excel;
using QuanLyChiTieu.Objects;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using QuanLyChiTieu.Modules;

namespace QuanLyChiTieu
{
    public partial class fDangNhap : Form
    {
        public fDangNhap()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            guna2ShadowPanel1.Visible = true;
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            guna2ShadowPanel1.Visible = false;          
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            
        }
        
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string taiKhoan = txbTaiKhoan.Text;
            fBangDieuKhien form2 = new fBangDieuKhien();

            bool _ = false;
            bool laHopLe = new Excel.ExcelSearcher().Search(Objects.ConnectionFile.GetFileConnectionAccount(), taiKhoan, txbMatKhau.Text, out _);

            if (laHopLe)
            {
                MessageBox.Show("Đăng nhập thành công");
                this.Hide();
                // lưu tài khoản của người dùng hiện tại
                QuanLyChiTieu.Objects.ConnectionFile.currentAccount = taiKhoan;

                // lưu thông tin người dùng
                UsedData.UsedDataUser();

                // Lấy dữ liệu các tài khoản tại folder user
                UsedData.UsedDataAccount();

                // lấy dữ liệu phần giao dịch của user
                UsedData.UsedDataTran();


                // lấy dữ liệu phần khoản vay của user
                UsedData.UsedDataLoan();

                form2.ShowDialog();
                this.Close();
            }
            else
                MessageBox.Show("Tài khoản hay mật khẩu không hợp lệ" +
            " !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void guna2Button2_Click_1(object sender, EventArgs e)
        {
            string taiKhoanMoi = guna2TextBox3.Text;
            string matKhauMoi = guna2TextBox4.Text;
            NguoiDung nguoiDung = new NguoiDung(taiKhoanMoi, matKhauMoi);

            if (!NguoiDung.IsValidAccount(taiKhoanMoi))
            {
                MessageBox.Show("Tài khoản không hợp lệ" + " !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            bool daTonTaiTK = false;
            new Excel.ExcelSearcher().Search(Objects.ConnectionFile.GetFileConnectionAccount(), taiKhoanMoi, matKhauMoi, out daTonTaiTK);

            if (!daTonTaiTK)
            {

                string matKhau2 = guna2TextBox5.Text;
                if (NguoiDung.IsValidPassword(matKhauMoi))
                {
                    if (matKhauMoi == matKhau2)
                    {
                        // lưu tài khoản mới đăng ký vào
                        SaveData.SaveDataUser();

                        // tạo file excel để lưu trữ dữ liệu cho tài khoản mới
                        new DataCreator(new TaoFileTaiKhoan()).TaoFile(ConnectionFile.GetFileConnection("Accounts"), "sheet1");

                        // tạo file excel lưu trữ các cuộc giao dịch
                        new DataCreator(new TaoFileGiaoDich()).TaoFile(ConnectionFile.GetFileConnection("Transaction"), taiKhoanMoi);

                        // tạo file excel lưu trữ các khoản vay
                        new DataCreator(new TaoFileKhoanVay()).TaoFile(ConnectionFile.GetFileConnection("LoanAndDebt"), taiKhoanMoi);

                        // thêm tài khoản mặc định
                        DichVuTaiKhoan.Instance.Them(taiKhoanMoi, new TaiKhoan(taiKhoanMoi, 0, "Tiền mặt"));

                        // xuất dữ liệu tài khoản
                        SaveData.SaveDataAccount();

                        DichVuTaiKhoan.Instance.DanhSachTaiKhoan.Clear();

                        guna2ShadowPanel1.Visible = true;
                    }
                    else
                        MessageBox.Show("Mật khẩu không trùng khớp!");
                }
                else
                    MessageBox.Show("Mật khẩu không hợp lệ!");
            }
            else
                MessageBox.Show("Tài khoản không tồn tại!");
        }
    }
}
