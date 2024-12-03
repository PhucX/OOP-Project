using System.Drawing;
using System.Windows.Forms;

namespace QuanLyChiTieu
{
    partial class fGiaoDich
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fGiaoDich));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.btnGiaoDich = new Guna.UI2.WinForms.Guna2Button();
            this.btnKhoanVay = new Guna.UI2.WinForms.Guna2Button();
            this.btnKhoanChoVay = new Guna.UI2.WinForms.Guna2Button();
            this.pnlGiaoDich1 = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            this.pnlGiaoDich = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            this.btnLuu = new Guna.UI2.WinForms.Guna2Button();
            this.btnXoa = new Guna.UI2.WinForms.Guna2Button();
            this.btnThem = new Guna.UI2.WinForms.Guna2Button();
            this.ptbTimKiem = new Guna.UI2.WinForms.Guna2PictureBox();
            this.txbTimKiem = new Guna.UI2.WinForms.Guna2TextBox();
            this.dgvGiaoDich = new Guna.UI2.WinForms.Guna2DataGridView();
            this.Select = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Idgiaodich = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.loaiGiaoDich = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ngayGiaoDich = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.soTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ghiChu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.xoaColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.suaColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.pnlGiaoDich1.SuspendLayout();
            this.pnlGiaoDich.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbTimKiem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGiaoDich)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Cambria", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(41, 3);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(208, 34);
            this.guna2HtmlLabel1.TabIndex = 39;
            this.guna2HtmlLabel1.Text = "Lịch sử giao dịch";
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.FillWeight = 71.472F;
            this.dataGridViewImageColumn1.HeaderText = "";
            this.dataGridViewImageColumn1.Image = global::QuanLyChiTieu.Properties.Resources.delete_icon;
            this.dataGridViewImageColumn1.MinimumWidth = 6;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn1.Width = 84;
            // 
            // dataGridViewImageColumn2
            // 
            this.dataGridViewImageColumn2.HeaderText = "";
            this.dataGridViewImageColumn2.Image = global::QuanLyChiTieu.Properties.Resources.edit_icon;
            this.dataGridViewImageColumn2.MinimumWidth = 6;
            this.dataGridViewImageColumn2.Name = "dataGridViewImageColumn2";
            this.dataGridViewImageColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewImageColumn2.Width = 117;
            // 
            // btnGiaoDich
            // 
            this.btnGiaoDich.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnGiaoDich.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnGiaoDich.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnGiaoDich.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnGiaoDich.FillColor = System.Drawing.Color.Silver;
            this.btnGiaoDich.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnGiaoDich.ForeColor = System.Drawing.Color.White;
            this.btnGiaoDich.Location = new System.Drawing.Point(41, 43);
            this.btnGiaoDich.Name = "btnGiaoDich";
            this.btnGiaoDich.Size = new System.Drawing.Size(109, 24);
            this.btnGiaoDich.TabIndex = 42;
            this.btnGiaoDich.Text = "Giao Dich";
            this.btnGiaoDich.Click += new System.EventHandler(this.btnGiaoDich_Click);
            // 
            // btnKhoanVay
            // 
            this.btnKhoanVay.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnKhoanVay.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnKhoanVay.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnKhoanVay.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnKhoanVay.FillColor = System.Drawing.Color.Silver;
            this.btnKhoanVay.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnKhoanVay.ForeColor = System.Drawing.Color.White;
            this.btnKhoanVay.Location = new System.Drawing.Point(156, 43);
            this.btnKhoanVay.Name = "btnKhoanVay";
            this.btnKhoanVay.Size = new System.Drawing.Size(107, 24);
            this.btnKhoanVay.TabIndex = 43;
            this.btnKhoanVay.Text = "Khoản vay";
            this.btnKhoanVay.Click += new System.EventHandler(this.btnKhoanVay_Click);
            // 
            // btnKhoanChoVay
            // 
            this.btnKhoanChoVay.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnKhoanChoVay.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnKhoanChoVay.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnKhoanChoVay.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnKhoanChoVay.FillColor = System.Drawing.Color.Silver;
            this.btnKhoanChoVay.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnKhoanChoVay.ForeColor = System.Drawing.Color.White;
            this.btnKhoanChoVay.Location = new System.Drawing.Point(269, 43);
            this.btnKhoanChoVay.Name = "btnKhoanChoVay";
            this.btnKhoanChoVay.Size = new System.Drawing.Size(107, 24);
            this.btnKhoanChoVay.TabIndex = 44;
            this.btnKhoanChoVay.Text = "Khoản cho vay";
            this.btnKhoanChoVay.Click += new System.EventHandler(this.btnKhoanChoVay_Click);
            // 
            // pnlGiaoDich1
            // 
            this.pnlGiaoDich1.AutoScroll = true;
            this.pnlGiaoDich1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pnlGiaoDich1.BorderRadius = 40;
            this.pnlGiaoDich1.Controls.Add(this.pnlGiaoDich);
            this.pnlGiaoDich1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlGiaoDich1.Location = new System.Drawing.Point(0, 85);
            this.pnlGiaoDich1.Name = "pnlGiaoDich1";
            this.pnlGiaoDich1.Size = new System.Drawing.Size(858, 501);
            this.pnlGiaoDich1.TabIndex = 48;
            // 
            // pnlGiaoDich
            // 
            this.pnlGiaoDich.AutoScroll = true;
            this.pnlGiaoDich.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pnlGiaoDich.BorderRadius = 40;
            this.pnlGiaoDich.Controls.Add(this.btnLuu);
            this.pnlGiaoDich.Controls.Add(this.btnXoa);
            this.pnlGiaoDich.Controls.Add(this.btnThem);
            this.pnlGiaoDich.Controls.Add(this.ptbTimKiem);
            this.pnlGiaoDich.Controls.Add(this.txbTimKiem);
            this.pnlGiaoDich.Controls.Add(this.dgvGiaoDich);
            this.pnlGiaoDich.Location = new System.Drawing.Point(3, 0);
            this.pnlGiaoDich.Name = "pnlGiaoDich";
            this.pnlGiaoDich.Size = new System.Drawing.Size(855, 492);
            this.pnlGiaoDich.TabIndex = 49;
            // 
            // btnLuu
            // 
            this.btnLuu.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnLuu.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnLuu.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLuu.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnLuu.FillColor = System.Drawing.Color.Transparent;
            this.btnLuu.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnLuu.ForeColor = System.Drawing.Color.White;
            this.btnLuu.Image = ((System.Drawing.Image)(resources.GetObject("btnLuu.Image")));
            this.btnLuu.ImageSize = new System.Drawing.Size(35, 35);
            this.btnLuu.Location = new System.Drawing.Point(665, 16);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(49, 40);
            this.btnLuu.TabIndex = 47;
            // 
            // btnXoa
            // 
            this.btnXoa.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnXoa.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnXoa.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnXoa.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnXoa.FillColor = System.Drawing.Color.Transparent;
            this.btnXoa.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnXoa.ForeColor = System.Drawing.Color.White;
            this.btnXoa.Image = ((System.Drawing.Image)(resources.GetObject("btnXoa.Image")));
            this.btnXoa.ImageSize = new System.Drawing.Size(35, 35);
            this.btnXoa.Location = new System.Drawing.Point(619, 16);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(49, 40);
            this.btnXoa.TabIndex = 46;
            // 
            // btnThem
            // 
            this.btnThem.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnThem.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnThem.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnThem.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnThem.FillColor = System.Drawing.Color.Transparent;
            this.btnThem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.Image = ((System.Drawing.Image)(resources.GetObject("btnThem.Image")));
            this.btnThem.ImageSize = new System.Drawing.Size(35, 35);
            this.btnThem.Location = new System.Drawing.Point(571, 16);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(49, 40);
            this.btnThem.TabIndex = 45;
            // 
            // ptbTimKiem
            // 
            this.ptbTimKiem.BackColor = System.Drawing.Color.Transparent;
            this.ptbTimKiem.Image = ((System.Drawing.Image)(resources.GetObject("ptbTimKiem.Image")));
            this.ptbTimKiem.ImageRotate = 0F;
            this.ptbTimKiem.Location = new System.Drawing.Point(247, 16);
            this.ptbTimKiem.Name = "ptbTimKiem";
            this.ptbTimKiem.Size = new System.Drawing.Size(34, 37);
            this.ptbTimKiem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptbTimKiem.TabIndex = 42;
            this.ptbTimKiem.TabStop = false;
            // 
            // txbTimKiem
            // 
            this.txbTimKiem.BackColor = System.Drawing.Color.White;
            this.txbTimKiem.BorderColor = System.Drawing.Color.Gray;
            this.txbTimKiem.BorderRadius = 15;
            this.txbTimKiem.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txbTimKiem.DefaultText = "";
            this.txbTimKiem.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txbTimKiem.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txbTimKiem.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txbTimKiem.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txbTimKiem.FillColor = System.Drawing.Color.WhiteSmoke;
            this.txbTimKiem.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txbTimKiem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txbTimKiem.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txbTimKiem.Location = new System.Drawing.Point(5, 16);
            this.txbTimKiem.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txbTimKiem.Name = "txbTimKiem";
            this.txbTimKiem.PasswordChar = '\0';
            this.txbTimKiem.PlaceholderText = "Search";
            this.txbTimKiem.SelectedText = "";
            this.txbTimKiem.Size = new System.Drawing.Size(236, 37);
            this.txbTimKiem.TabIndex = 40;
            // 
            // dgvGiaoDich
            // 
            this.dgvGiaoDich.AllowUserToAddRows = false;
            this.dgvGiaoDich.AllowUserToDeleteRows = false;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.dgvGiaoDich.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvGiaoDich.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Cambria", 12F);
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvGiaoDich.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.dgvGiaoDich.ColumnHeadersHeight = 20;
            this.dgvGiaoDich.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvGiaoDich.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Select,
            this.Idgiaodich,
            this.loaiGiaoDich,
            this.ngayGiaoDich,
            this.soTien,
            this.ghiChu,
            this.xoaColumn,
            this.suaColumn});
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Cambria", 12F);
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvGiaoDich.DefaultCellStyle = dataGridViewCellStyle12;
            this.dgvGiaoDich.Font = new System.Drawing.Font("Cambria", 12F);
            this.dgvGiaoDich.GridColor = System.Drawing.Color.Red;
            this.dgvGiaoDich.Location = new System.Drawing.Point(5, 60);
            this.dgvGiaoDich.Name = "dgvGiaoDich";
            this.dgvGiaoDich.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvGiaoDich.RowHeadersVisible = false;
            this.dgvGiaoDich.RowHeadersWidth = 51;
            this.dgvGiaoDich.Size = new System.Drawing.Size(709, 405);
            this.dgvGiaoDich.TabIndex = 38;
            this.dgvGiaoDich.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvGiaoDich.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvGiaoDich.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvGiaoDich.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvGiaoDich.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvGiaoDich.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvGiaoDich.ThemeStyle.GridColor = System.Drawing.Color.Red;
            this.dgvGiaoDich.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvGiaoDich.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvGiaoDich.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvGiaoDich.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvGiaoDich.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvGiaoDich.ThemeStyle.HeaderStyle.Height = 20;
            this.dgvGiaoDich.ThemeStyle.ReadOnly = false;
            this.dgvGiaoDich.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvGiaoDich.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvGiaoDich.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvGiaoDich.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvGiaoDich.ThemeStyle.RowsStyle.Height = 22;
            this.dgvGiaoDich.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvGiaoDich.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // Select
            // 
            this.Select.DataPropertyName = "Id";
            this.Select.FalseValue = "False";
            this.Select.FillWeight = 35F;
            this.Select.HeaderText = "#";
            this.Select.IndeterminateValue = "False";
            this.Select.MinimumWidth = 6;
            this.Select.Name = "Select";
            this.Select.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Select.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Select.TrueValue = "True";
            // 
            // Idgiaodich
            // 
            this.Idgiaodich.FillWeight = 125F;
            this.Idgiaodich.HeaderText = "ID giao dich";
            this.Idgiaodich.MinimumWidth = 6;
            this.Idgiaodich.Name = "Idgiaodich";
            this.Idgiaodich.ReadOnly = true;
            // 
            // loaiGiaoDich
            // 
            this.loaiGiaoDich.FillWeight = 135F;
            this.loaiGiaoDich.HeaderText = "Loại giao dịch";
            this.loaiGiaoDich.MinimumWidth = 6;
            this.loaiGiaoDich.Name = "loaiGiaoDich";
            this.loaiGiaoDich.ReadOnly = true;
            // 
            // ngayGiaoDich
            // 
            this.ngayGiaoDich.FillWeight = 117.7023F;
            this.ngayGiaoDich.HeaderText = "Ngày giao dịch";
            this.ngayGiaoDich.MinimumWidth = 6;
            this.ngayGiaoDich.Name = "ngayGiaoDich";
            this.ngayGiaoDich.ReadOnly = true;
            // 
            // soTien
            // 
            this.soTien.FillWeight = 72.45506F;
            this.soTien.HeaderText = "Số tiền";
            this.soTien.MinimumWidth = 6;
            this.soTien.Name = "soTien";
            this.soTien.ReadOnly = true;
            // 
            // ghiChu
            // 
            this.ghiChu.FillWeight = 98.99228F;
            this.ghiChu.HeaderText = "Ghi Chú ";
            this.ghiChu.MinimumWidth = 6;
            this.ghiChu.Name = "ghiChu";
            this.ghiChu.ReadOnly = true;
            this.ghiChu.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // xoaColumn
            // 
            this.xoaColumn.FillWeight = 71.472F;
            this.xoaColumn.HeaderText = "";
            this.xoaColumn.Image = global::QuanLyChiTieu.Properties.Resources.delete_icon;
            this.xoaColumn.MinimumWidth = 6;
            this.xoaColumn.Name = "xoaColumn";
            this.xoaColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // suaColumn
            // 
            this.suaColumn.HeaderText = "";
            this.suaColumn.Image = global::QuanLyChiTieu.Properties.Resources.edit_icon;
            this.suaColumn.MinimumWidth = 6;
            this.suaColumn.Name = "suaColumn";
            this.suaColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.suaColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // fGiaoDich
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(858, 586);
            this.Controls.Add(this.pnlGiaoDich1);
            this.Controls.Add(this.btnKhoanChoVay);
            this.Controls.Add(this.btnKhoanVay);
            this.Controls.Add(this.btnGiaoDich);
            this.Controls.Add(this.guna2HtmlLabel1);
            this.Font = new System.Drawing.Font("Cambria", 15.75F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "fGiaoDich";
            this.ShowIcon = false;
            this.Text = "fGiaoDich";
            this.Load += new System.EventHandler(this.fGiaoDich_Load);
            this.pnlGiaoDich1.ResumeLayout(false);
            this.pnlGiaoDich.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ptbTimKiem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGiaoDich)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private DataGridViewImageColumn dataGridViewImageColumn1;
        private DataGridViewImageColumn dataGridViewImageColumn2;
        private Guna.UI2.WinForms.Guna2Button btnGiaoDich;
        private Guna.UI2.WinForms.Guna2Button btnKhoanVay;
        private Guna.UI2.WinForms.Guna2Button btnKhoanChoVay;
        private Guna.UI2.WinForms.Guna2CustomGradientPanel pnlGiaoDich1;
        private Guna.UI2.WinForms.Guna2CustomGradientPanel pnlGiaoDich;
        private Guna.UI2.WinForms.Guna2Button btnLuu;
        private Guna.UI2.WinForms.Guna2Button btnXoa;
        private Guna.UI2.WinForms.Guna2Button btnThem;
        private Guna.UI2.WinForms.Guna2PictureBox ptbTimKiem;
        private Guna.UI2.WinForms.Guna2TextBox txbTimKiem;
        private Guna.UI2.WinForms.Guna2DataGridView dgvGiaoDich;
        private DataGridViewCheckBoxColumn Select;
        private DataGridViewTextBoxColumn Idgiaodich;
        private DataGridViewTextBoxColumn loaiGiaoDich;
        private DataGridViewTextBoxColumn ngayGiaoDich;
        private DataGridViewTextBoxColumn soTien;
        private DataGridViewTextBoxColumn ghiChu;
        private DataGridViewImageColumn xoaColumn;
        private DataGridViewImageColumn suaColumn;
    }
}
