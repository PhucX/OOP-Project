﻿namespace QuanLyChiTieu
{
    partial class fKhoanChoVay
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fKhoanChoVay));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txbTimKiem = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.pnlKhoanVay = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            this.btnLuu = new Guna.UI2.WinForms.Guna2Button();
            this.btnXoa = new Guna.UI2.WinForms.Guna2Button();
            this.btnThem = new Guna.UI2.WinForms.Guna2Button();
            this.ptbTimKiem = new Guna.UI2.WinForms.Guna2PictureBox();
            this.dgvKhoanChoVay = new Guna.UI2.WinForms.Guna2DataGridView();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.chon = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.maVay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nguoiVay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ngayGiaoDich = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.soTienVay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.laiSuat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.trangThai = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.xoaColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.suaColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.pnlKhoanVay.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbTimKiem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhoanChoVay)).BeginInit();
            this.SuspendLayout();
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
            this.txbTimKiem.Location = new System.Drawing.Point(41, 81);
            this.txbTimKiem.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txbTimKiem.Name = "txbTimKiem";
            this.txbTimKiem.PasswordChar = '\0';
            this.txbTimKiem.PlaceholderText = "Search";
            this.txbTimKiem.SelectedText = "";
            this.txbTimKiem.Size = new System.Drawing.Size(236, 37);
            this.txbTimKiem.TabIndex = 40;
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Cambria", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(41, 3);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(408, 49);
            this.guna2HtmlLabel1.TabIndex = 39;
            this.guna2HtmlLabel1.Text = "Lịch sử khoản cho vay";
            // 
            // pnlKhoanVay
            // 
            this.pnlKhoanVay.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pnlKhoanVay.BorderRadius = 40;
            this.pnlKhoanVay.Controls.Add(this.btnLuu);
            this.pnlKhoanVay.Controls.Add(this.btnXoa);
            this.pnlKhoanVay.Controls.Add(this.btnThem);
            this.pnlKhoanVay.Controls.Add(this.ptbTimKiem);
            this.pnlKhoanVay.Controls.Add(this.txbTimKiem);
            this.pnlKhoanVay.Controls.Add(this.guna2HtmlLabel1);
            this.pnlKhoanVay.Controls.Add(this.dgvKhoanChoVay);
            this.pnlKhoanVay.Location = new System.Drawing.Point(37, 11);
            this.pnlKhoanVay.Name = "pnlKhoanVay";
            this.pnlKhoanVay.Size = new System.Drawing.Size(842, 564);
            this.pnlKhoanVay.TabIndex = 43;
            // 
            // btnLuu
            // 
            this.btnLuu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLuu.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnLuu.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnLuu.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLuu.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnLuu.FillColor = System.Drawing.Color.Transparent;
            this.btnLuu.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnLuu.ForeColor = System.Drawing.Color.White;
            this.btnLuu.Image = ((System.Drawing.Image)(resources.GetObject("btnLuu.Image")));
            this.btnLuu.ImageSize = new System.Drawing.Size(35, 35);
            this.btnLuu.Location = new System.Drawing.Point(741, 81);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(41, 40);
            this.btnLuu.TabIndex = 47;
            // 
            // btnXoa
            // 
            this.btnXoa.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXoa.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnXoa.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnXoa.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnXoa.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnXoa.FillColor = System.Drawing.Color.Transparent;
            this.btnXoa.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnXoa.ForeColor = System.Drawing.Color.White;
            this.btnXoa.Image = ((System.Drawing.Image)(resources.GetObject("btnXoa.Image")));
            this.btnXoa.ImageSize = new System.Drawing.Size(35, 35);
            this.btnXoa.Location = new System.Drawing.Point(694, 81);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(41, 40);
            this.btnXoa.TabIndex = 46;
            // 
            // btnThem
            // 
            this.btnThem.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThem.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnThem.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnThem.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnThem.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnThem.FillColor = System.Drawing.Color.Transparent;
            this.btnThem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.Image = ((System.Drawing.Image)(resources.GetObject("btnThem.Image")));
            this.btnThem.ImageSize = new System.Drawing.Size(35, 35);
            this.btnThem.Location = new System.Drawing.Point(647, 81);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(41, 40);
            this.btnThem.TabIndex = 45;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // ptbTimKiem
            // 
            this.ptbTimKiem.BackColor = System.Drawing.Color.Transparent;
            this.ptbTimKiem.Image = ((System.Drawing.Image)(resources.GetObject("ptbTimKiem.Image")));
            this.ptbTimKiem.ImageRotate = 0F;
            this.ptbTimKiem.Location = new System.Drawing.Point(283, 81);
            this.ptbTimKiem.Name = "ptbTimKiem";
            this.ptbTimKiem.Size = new System.Drawing.Size(34, 37);
            this.ptbTimKiem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptbTimKiem.TabIndex = 42;
            this.ptbTimKiem.TabStop = false;
            // 
            // dgvKhoanChoVay
            // 
            this.dgvKhoanChoVay.AllowUserToAddRows = false;
            this.dgvKhoanChoVay.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.dgvKhoanChoVay.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvKhoanChoVay.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Cambria", 12F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvKhoanChoVay.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvKhoanChoVay.ColumnHeadersHeight = 20;
            this.dgvKhoanChoVay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvKhoanChoVay.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chon,
            this.maVay,
            this.nguoiVay,
            this.ngayGiaoDich,
            this.soTienVay,
            this.laiSuat,
            this.trangThai,
            this.xoaColumn,
            this.suaColumn});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Cambria", 12F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvKhoanChoVay.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvKhoanChoVay.Font = new System.Drawing.Font("Cambria", 12F);
            this.dgvKhoanChoVay.GridColor = System.Drawing.Color.Red;
            this.dgvKhoanChoVay.Location = new System.Drawing.Point(41, 124);
            this.dgvKhoanChoVay.Name = "dgvKhoanChoVay";
            this.dgvKhoanChoVay.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvKhoanChoVay.RowHeadersVisible = false;
            this.dgvKhoanChoVay.RowHeadersWidth = 51;
            this.dgvKhoanChoVay.Size = new System.Drawing.Size(730, 414);
            this.dgvKhoanChoVay.TabIndex = 38;
            this.dgvKhoanChoVay.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvKhoanChoVay.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvKhoanChoVay.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvKhoanChoVay.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvKhoanChoVay.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvKhoanChoVay.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvKhoanChoVay.ThemeStyle.GridColor = System.Drawing.Color.Red;
            this.dgvKhoanChoVay.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvKhoanChoVay.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvKhoanChoVay.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvKhoanChoVay.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvKhoanChoVay.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvKhoanChoVay.ThemeStyle.HeaderStyle.Height = 20;
            this.dgvKhoanChoVay.ThemeStyle.ReadOnly = false;
            this.dgvKhoanChoVay.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvKhoanChoVay.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvKhoanChoVay.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvKhoanChoVay.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvKhoanChoVay.ThemeStyle.RowsStyle.Height = 22;
            this.dgvKhoanChoVay.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvKhoanChoVay.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvKhoanChoVay.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKhoanChoVay_CellClick);
            this.dgvKhoanChoVay.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvKhoanChoVay_CellFormatting);
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.FillWeight = 47.41153F;
            this.dataGridViewImageColumn1.HeaderText = "";
            this.dataGridViewImageColumn1.Image = global::QuanLyChiTieu.Properties.Resources.delete_icon;
            this.dataGridViewImageColumn1.MinimumWidth = 6;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn1.Width = 48;
            // 
            // dataGridViewImageColumn2
            // 
            this.dataGridViewImageColumn2.FillWeight = 49.43225F;
            this.dataGridViewImageColumn2.HeaderText = "";
            this.dataGridViewImageColumn2.Image = global::QuanLyChiTieu.Properties.Resources.edit_icon;
            this.dataGridViewImageColumn2.MinimumWidth = 6;
            this.dataGridViewImageColumn2.Name = "dataGridViewImageColumn2";
            this.dataGridViewImageColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewImageColumn2.Width = 50;
            // 
            // chon
            // 
            this.chon.FillWeight = 19.75643F;
            this.chon.HeaderText = "#";
            this.chon.MinimumWidth = 6;
            this.chon.Name = "chon";
            this.chon.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.chon.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // maVay
            // 
            this.maVay.HeaderText = "Mã Vay";
            this.maVay.MinimumWidth = 6;
            this.maVay.Name = "maVay";
            this.maVay.ReadOnly = true;
            // 
            // nguoiVay
            // 
            this.nguoiVay.FillWeight = 151.708F;
            this.nguoiVay.HeaderText = "Người vay ";
            this.nguoiVay.MinimumWidth = 6;
            this.nguoiVay.Name = "nguoiVay";
            this.nguoiVay.ReadOnly = true;
            // 
            // ngayGiaoDich
            // 
            this.ngayGiaoDich.FillWeight = 130.4702F;
            this.ngayGiaoDich.HeaderText = "Ngày đến hạn ";
            this.ngayGiaoDich.MinimumWidth = 6;
            this.ngayGiaoDich.Name = "ngayGiaoDich";
            this.ngayGiaoDich.ReadOnly = true;
            // 
            // soTienVay
            // 
            this.soTienVay.FillWeight = 99.92779F;
            this.soTienVay.HeaderText = "Số tiền vay";
            this.soTienVay.MinimumWidth = 6;
            this.soTienVay.Name = "soTienVay";
            this.soTienVay.ReadOnly = true;
            // 
            // laiSuat
            // 
            this.laiSuat.FillWeight = 116.408F;
            this.laiSuat.HeaderText = "Lãi Suất";
            this.laiSuat.MinimumWidth = 6;
            this.laiSuat.Name = "laiSuat";
            this.laiSuat.ReadOnly = true;
            // 
            // trangThai
            // 
            this.trangThai.FillWeight = 114.8858F;
            this.trangThai.HeaderText = "Trạng Thái";
            this.trangThai.Items.AddRange(new object[] {
            "Chưa thanh toán",
            "Đã thanh toán",
            "Quá hạn"});
            this.trangThai.MinimumWidth = 6;
            this.trangThai.Name = "trangThai";
            this.trangThai.ReadOnly = true;
            // 
            // xoaColumn
            // 
            this.xoaColumn.FillWeight = 47.41153F;
            this.xoaColumn.HeaderText = "";
            this.xoaColumn.Image = global::QuanLyChiTieu.Properties.Resources.delete_icon;
            this.xoaColumn.MinimumWidth = 6;
            this.xoaColumn.Name = "xoaColumn";
            this.xoaColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // suaColumn
            // 
            this.suaColumn.FillWeight = 49.43225F;
            this.suaColumn.HeaderText = "";
            this.suaColumn.Image = global::QuanLyChiTieu.Properties.Resources.edit_icon;
            this.suaColumn.MinimumWidth = 6;
            this.suaColumn.Name = "suaColumn";
            this.suaColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.suaColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // fKhoanChoVay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(917, 586);
            this.Controls.Add(this.pnlKhoanVay);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "fKhoanChoVay";
            this.Text = "fKhoanChoVay";
            this.pnlKhoanVay.ResumeLayout(false);
            this.pnlKhoanVay.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbTimKiem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhoanChoVay)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btnLuu;
        private Guna.UI2.WinForms.Guna2Button btnXoa;
        private Guna.UI2.WinForms.Guna2Button btnThem;
        private Guna.UI2.WinForms.Guna2PictureBox ptbTimKiem;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn2;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private Guna.UI2.WinForms.Guna2TextBox txbTimKiem;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2CustomGradientPanel pnlKhoanVay;
        private Guna.UI2.WinForms.Guna2DataGridView dgvKhoanChoVay;
        private System.Windows.Forms.DataGridViewCheckBoxColumn chon;
        private System.Windows.Forms.DataGridViewTextBoxColumn maVay;
        private System.Windows.Forms.DataGridViewTextBoxColumn nguoiVay;
        private System.Windows.Forms.DataGridViewTextBoxColumn ngayGiaoDich;
        private System.Windows.Forms.DataGridViewTextBoxColumn soTienVay;
        private System.Windows.Forms.DataGridViewTextBoxColumn laiSuat;
        private System.Windows.Forms.DataGridViewComboBoxColumn trangThai;
        private System.Windows.Forms.DataGridViewImageColumn xoaColumn;
        private System.Windows.Forms.DataGridViewImageColumn suaColumn;
    }
}