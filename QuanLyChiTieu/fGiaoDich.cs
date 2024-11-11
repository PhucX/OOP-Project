using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyChiTieu
{
    
    
    public partial class fGiaoDich : Form
    {
        public fGiaoDich()
        {
            InitializeComponent();
        }


        private void ptbThem_Click_1(object sender, EventArgs e)
        {
            
        }

        private void bntThemGiaoDich_Click(object sender, EventArgs e)
        {
            
        }

        private void ptbSua_Click(object sender, EventArgs e)
        {
            fSuaGiaoDich fSuaGiaoDich = new fSuaGiaoDich();
            fSuaGiaoDich.TopLevel = false;
            fSuaGiaoDich.FormBorderStyle = FormBorderStyle.None;
            this.pnlGiaoDich.Controls.Add(fSuaGiaoDich);
            this.pnlGiaoDich.Tag = fSuaGiaoDich;
            fSuaGiaoDich.BringToFront();
            fSuaGiaoDich.Show();
            
        }

        private void btnSuaGiaoDich_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
