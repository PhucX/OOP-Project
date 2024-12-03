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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlGiaoDich = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            this.btnLuu = new Guna.UI2.WinForms.Guna2Button();
            this.btnXoa = new Guna.UI2.WinForms.Guna2Button();
            this.btnThem = new Guna.UI2.WinForms.Guna2Button();
            this.ptbTimKiem = new Guna.UI2.WinForms.Guna2PictureBox();
            this.txbTimKiem = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.dgvGiaoDich = new Guna.UI2.WinForms.Guna2DataGridView();
            this.chon = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Idgiaodich = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.loaiGiaoDich = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ngayGiaoDich = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.soTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ghiChu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.xoaColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.suaColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.pnlGiaoDich.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbTimKiem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGiaoDich)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlGiaoDich
            // 
            this.pnlGiaoDich.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pnlGiaoDich.BorderRadius = 40;
            this.pnlGiaoDich.Controls.Add(this.btnLuu);
            this.pnlGiaoDich.Controls.Add(this.btnXoa);
            this.pnlGiaoDich.Controls.Add(this.btnThem);
            this.pnlGiaoDich.Controls.Add(this.ptbTimKiem);
            this.pnlGiaoDich.Controls.Add(this.txbTimKiem);
            this.pnlGiaoDich.Controls.Add(this.guna2HtmlLabel1);
            this.pnlGiaoDich.Controls.Add(this.dgvGiaoDich);
            this.pnlGiaoDich.Location = new System.Drawing.Point(35, 10);
            this.pnlGiaoDich.Name = "pnlGiaoDich";
            this.pnlGiaoDich.Size = new System.Drawing.Size(842, 564);
            this.pnlGiaoDich.TabIndex = 41;
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
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
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
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
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
            this.ptbTimKiem.Click += new System.EventHandler(this.ptbTimKiem_Click);
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
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(387, 61);
            this.guna2HtmlLabel1.TabIndex = 39;
            this.guna2HtmlLabel1.Text = "Lịch sử giao dịch";
            // 
            // dgvGiaoDich
            // 
            this.dgvGiaoDich.AllowUserToAddRows = false;
            this.dgvGiaoDich.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.dgvGiaoDich.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvGiaoDich.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.None;
            this.dgvGiaoDich.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Cambria", 12F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvGiaoDich.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvGiaoDich.ColumnHeadersHeight = 40;
            this.dgvGiaoDich.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvGiaoDich.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chon,
            this.Idgiaodich,
            this.loaiGiaoDich,
            this.ngayGiaoDich,
            this.soTien,
            this.ghiChu,
            this.xoaColumn,
            this.suaColumn});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Cambria", 12F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvGiaoDich.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvGiaoDich.Font = new System.Drawing.Font("Cambria", 12F);
            this.dgvGiaoDich.GridColor = System.Drawing.Color.Red;
            this.dgvGiaoDich.Location = new System.Drawing.Point(41, 124);
            this.dgvGiaoDich.Name = "dgvGiaoDich";
            this.dgvGiaoDich.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvGiaoDich.RowHeadersVisible = false;
            this.dgvGiaoDich.RowHeadersWidth = 51;
            this.dgvGiaoDich.Size = new System.Drawing.Size(742, 406);
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
            this.dgvGiaoDich.ThemeStyle.HeaderStyle.Height = 40;
            this.dgvGiaoDich.ThemeStyle.ReadOnly = false;
            this.dgvGiaoDich.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvGiaoDich.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvGiaoDich.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvGiaoDich.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvGiaoDich.ThemeStyle.RowsStyle.Height = 22;
            this.dgvGiaoDich.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvGiaoDich.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvGiaoDich.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.guna2DataGridView1_CellClick);
            this.dgvGiaoDich.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.guna2DataGridView1_CellClick);
            this.dgvGiaoDich.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.guna2DataGridView1_CellFormatting);
            // 
            // chon
            // 
            this.chon.FillWeight = 34.37838F;
            this.chon.HeaderText = "#";
            this.chon.MinimumWidth = 6;
            this.chon.Name = "chon";
            this.chon.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.chon.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.chon.Width = 40;
            // 
            // Idgiaodich
            // 
            this.Idgiaodich.HeaderText = "ID giao dịch";
            this.Idgiaodich.MinimumWidth = 6;
            this.Idgiaodich.Name = "Idgiaodich";
            this.Idgiaodich.Width = 125;
            // 
            // loaiGiaoDich
            // 
            this.loaiGiaoDich.FillWeight = 135F;
            this.loaiGiaoDich.HeaderText = "Loại giao dịch";
            this.loaiGiaoDich.MinimumWidth = 6;
            this.loaiGiaoDich.Name = "loaiGiaoDich";
            this.loaiGiaoDich.Width = 159;
            // 
            // ngayGiaoDich
            // 
            this.ngayGiaoDich.FillWeight = 117.7023F;
            this.ngayGiaoDich.HeaderText = "Ngày giao dịch";
            this.ngayGiaoDich.MinimumWidth = 6;
            this.ngayGiaoDich.Name = "ngayGiaoDich";
            this.ngayGiaoDich.Width = 138;
            // 
            // soTien
            // 
            this.soTien.FillWeight = 72.45506F;
            this.soTien.HeaderText = "Số tiền";
            this.soTien.MinimumWidth = 6;
            this.soTien.Name = "soTien";
            this.soTien.Width = 85;
            // 
            // ghiChu
            // 
            this.ghiChu.FillWeight = 98.99228F;
            this.ghiChu.HeaderText = "Ghi Chú ";
            this.ghiChu.MinimumWidth = 6;
            this.ghiChu.Name = "ghiChu";
            this.ghiChu.Width = 117;
            // 
            // xoaColumn
            // 
            this.xoaColumn.FillWeight = 71.472F;
            this.xoaColumn.HeaderText = "";
            this.xoaColumn.Image = global::QuanLyChiTieu.Properties.Resources.delete_icon;
            this.xoaColumn.MinimumWidth = 6;
            this.xoaColumn.Name = "xoaColumn";
            this.xoaColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.xoaColumn.Width = 84;
            // 
            // suaColumn
            // 
            this.suaColumn.HeaderText = "";
            this.suaColumn.Image = global::QuanLyChiTieu.Properties.Resources.edit_icon;
            this.suaColumn.MinimumWidth = 6;
            this.suaColumn.Name = "suaColumn";
            this.suaColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.suaColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.suaColumn.Width = 117;
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
            // fGiaoDich
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(917, 586);
            this.Controls.Add(this.pnlGiaoDich);
            this.Font = new System.Drawing.Font("Cambria", 15.75F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "fGiaoDich";
            this.ShowIcon = false;
            this.Text = "fGiaoDich";
            this.Load += new System.EventHandler(this.fGiaoDich_Load);
            this.pnlGiaoDich.ResumeLayout(false);
            this.pnlGiaoDich.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbTimKiem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGiaoDich)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2CustomGradientPanel pnlGiaoDich;
        private Guna.UI2.WinForms.Guna2PictureBox ptbTimKiem;
        private Guna.UI2.WinForms.Guna2TextBox txbTimKiem;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2DataGridView dgvGiaoDich;
        private Guna.UI2.WinForms.Guna2Button btnXoa;
        private Guna.UI2.WinForms.Guna2Button btnThem;
        private Guna.UI2.WinForms.Guna2Button btnLuu;
        private DataGridViewImageColumn dataGridViewImageColumn1;
        private DataGridViewImageColumn dataGridViewImageColumn2;
        private DataGridViewCheckBoxColumn chon;
        private DataGridViewTextBoxColumn Idgiaodich;
        private DataGridViewTextBoxColumn loaiGiaoDich;
        private DataGridViewTextBoxColumn ngayGiaoDich;
        private DataGridViewTextBoxColumn soTien;
        private DataGridViewTextBoxColumn ghiChu;
        private DataGridViewImageColumn xoaColumn;
        private DataGridViewImageColumn suaColumn;
    }
}