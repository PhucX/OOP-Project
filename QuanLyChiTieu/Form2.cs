using Guna.UI2.WinForms;
using QuanLyChiTieu.Objects;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace QuanLyChiTieu
{
    public partial class fBangDieuKhien : Form
    {
        private Form activeForm;

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

        public fBangDieuKhien()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
            OpenChildForm(new fTrangChu(), btnTrangChu);
        }

        private void OpenChildForm(Form childForm, object btnSender)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            this.panelDesktop.Controls.Add(childForm);
            this.panelDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void UpdatePanel(Guna2Button btn)
        {
            pnlThanhTruot.Height = btn.Height;
            pnlThanhTruot.Top = btn.Top;
            pnlThanhTruot.Left = btn.Left;
            btn.BackColor = Color.FromArgb(12, 139, 60);
            pnlThanhTruot.BringToFront();
        }

        private void ResetButtonColor(Guna2Button btn)
        {
            btn.BackColor = Color.FromArgb(134, 190, 57);
        }

        private void btnTrangChu_Click(object sender, EventArgs e)
        {
            UpdatePanel(btnTrangChu);
            OpenChildForm(new fTrangChu(), btnTrangChu);
        }

        private void btnGiaoDich_Click(object sender, EventArgs e)
        {
            UpdatePanel(btnGiaoDich);
            OpenChildForm(new fGiaoDich(), btnGiaoDich);
            
        }

        private void btnKhoanVay_Click(object sender, EventArgs e)
        {
            UpdatePanel(btnKhoanVay);
            OpenChildForm(new fKhoanVay(), btnKhoanVay);
        }
        private void btnKhoanChoVay_Click(object sender, EventArgs e)
        {
            UpdatePanel(btnKhoanChoVay);
            OpenChildForm(new fKhoanChoVay(), btnKhoanChoVay);
        }
        private void btnTraCuuQuanLy_Click(object sender, EventArgs e)
        {
            UpdatePanel(btnTraCuuQuanLy);
            OpenChildForm(new fTranCuuQuanLy(), btnTraCuuQuanLy);
        }

        private void btnBaoCao_Click(object sender, EventArgs e)
        {
            UpdatePanel(btnBaoCao);
            OpenChildForm(new fBaoCao(), btnBaoCao);
        }

        private void btnSoDu_Click(object sender, EventArgs e)
        {
            UpdatePanel(btnSoDu);
        }

        private void btnThongTin_Click(object sender, EventArgs e)
        {
            UpdatePanel(btnThongTin);
        }
        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            OpenChildForm(new fNguoiDung(), guna2PictureBox1);
        }
        // Sự kiện rời khỏi nút
        private void btnTrangChu_Leave(object sender, EventArgs e)
        {
            ResetButtonColor(btnTrangChu);
        }

        private void btnGiaoDich_Leave(object sender, EventArgs e)
        {
            ResetButtonColor(btnGiaoDich);
        }

        private void btnKhoanVay_Leave(object sender, EventArgs e)
        {
            ResetButtonColor(btnKhoanVay);
        }

        private void btnTraCuuQuanLy_Leave(object sender, EventArgs e)
        {
            ResetButtonColor(btnTraCuuQuanLy);
        }

        private void btnBaoCao_Leave(object sender, EventArgs e)
        {
            ResetButtonColor(btnBaoCao);
        }

        private void btnSoDu_Leave(object sender, EventArgs e)
        {
            ResetButtonColor(btnSoDu);
        }

        private void btnThongTin_Leave(object sender, EventArgs e)
        {
            ResetButtonColor(btnThongTin);
        }
        private void btnKhoanChoVay_Leave(object sender, EventArgs e)
        {
            ResetButtonColor(btnKhoanChoVay);
        }
        private void panelDesktop_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2PictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            new fNguoiDung().ShowDialog();
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            //SaveData.SaveDataUser();
            //SaveData.SaveDataAccount();
            //SaveData.SaveDataLoan();
            //SaveData.SaveDataTran();
        }
    }
}
