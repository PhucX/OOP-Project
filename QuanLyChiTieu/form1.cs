using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyChiTieu.Excel;
using QuanLyChiTieu.Objects;
using System.Windows.Forms;
using System.Text.RegularExpressions;

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

        // Kiểm tra xem tài khoản có hợp lệ không
        public bool IsValidAccount(string account)
        {
            // Kiểm tra độ dài tài khoản (ví dụ, từ 5 đến 20 ký tự)
            if (account.Length < 5 || account.Length > 20)
            {
                MessageBox.Show("Tài khoản phải có độ dài từ 5 đến 20 ký tự.");
                return false;
            }

            // Kiểm tra ký tự hợp lệ (chỉ cho phép chữ cái, chữ số và dấu gạch dưới)
            string pattern = @"^[a-zA-Z0-9_]+$";
            if (!Regex.IsMatch(account, pattern))
            {
                MessageBox.Show("Tài khoản chỉ được phép chứa chữ cái, chữ số và dấu gạch dưới.");
                return false;
            }

            return true;
        }

        public bool IsValidPassword(string password)
        {
            // Kiểm tra độ dài (ít nhất 8 ký tự)
            if (password.Length < 8)
            {
                MessageBox.Show("Mật khẩu phải có ít nhất 8 ký tự.");
                return false;
            }

            // Kiểm tra có chữ hoa
            if (!Regex.IsMatch(password, @"[A-Z]"))
            {
                MessageBox.Show("Mật khẩu phải chứa ít nhất một chữ cái hoa.");
                return false;
            }

            // Kiểm tra có chữ thường
            if (!Regex.IsMatch(password, @"[a-z]"))
            {
                MessageBox.Show("Mật khẩu phải chứa ít nhất một chữ cái thường.");
                return false;
            }

            // Kiểm tra có số
            if (!Regex.IsMatch(password, @"[0-9]"))
            {
                MessageBox.Show("Mật khẩu phải chứa ít nhất một số.");
                return false;
            }

            // Kiểm tra có ký tự đặc biệt
            if (!Regex.IsMatch(password, @"[\W_]"))
            {
                MessageBox.Show("Mật khẩu phải chứa ít nhất một ký tự đặc biệt.");
                return false;
            }

            // Nếu tất cả các điều kiện đều thỏa mãn
            return true;
        }
        private void btnDangNhap_Click(object sender, EventArgs e)
        {

            fBangDieuKhien form2 = new fBangDieuKhien();

            bool _ = false;
            bool laHopLe = new Excel.ExcelSearcher().Search(Objects.Connection.GetFileConnection("\\Data\\Account.xlsx"), txbTaiKhoan.Text, txbMatKhau.Text, out _);

            if (laHopLe)
            {
                MessageBox.Show("Đăng nhập thành công");
                this.Hide();
                // Lấy dữ liệu các tài khoản tại folder user
                new DataManager(new ExcelImporter()).ImportTaiKhoan(Connection.GetFileConnection($"\\Data\\{txbTaiKhoan.Text}\\Accounts.xlsx"));

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
            if (!IsValidAccount(taiKhoanMoi))
            {
                MessageBox.Show("Tài khoản không hợp lệ" + " !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            bool daTonTaiTK = false;
            new Excel.ExcelSearcher().Search(Objects.Connection.GetFileConnection("\\Data\\Account.xlsx"), taiKhoanMoi, matKhauMoi, out daTonTaiTK);

            if (!daTonTaiTK)
            {

                string matKhau2 = guna2TextBox5.Text;
                if (IsValidPassword(matKhauMoi))
                {
                    if (matKhauMoi == matKhau2)
                    {
                        // lưu tài khoản mới đăng ký vào
                        new DataManager(new ExcelExporter()).ExportNguoiDung(taiKhoanMoi, matKhauMoi, Connection.GetFileConnection("\\Data\\Account.xlsx"));

                        // tạo file excel để lưu trữ dữ liệu cho tài khoản mới
                        new DataCreator(new TaoFileTaiKhoan()).TaoFile(Connection.GetFileConnection($"\\Data\\{taiKhoanMoi}\\Accounts.xlsx"), taiKhoanMoi);

                        // tạo file excel lưu trữ các cuộc giao dịch
                        new DataCreator(new TaoFileGiaoDich()).TaoFile(Connection.GetFileConnection($"\\Data\\{taiKhoanMoi}\\Transaction.xlsx"), taiKhoanMoi);

                        // tạo file excel lưu trữ các khoản vay
                        new DataCreator(new TaoFileKhoanVay()).TaoFile(Connection.GetFileConnection($"\\Data\\{taiKhoanMoi}\\LoanAndDebt.xlsx"), taiKhoanMoi);

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
