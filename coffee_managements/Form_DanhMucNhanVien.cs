using DoAnLapTrinhMang.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace DoAnLapTrinhMang
{
    public partial class Form_DanhMucNhanVien : Form
    {
        public Form_DanhMucNhanVien()
        {
            InitializeComponent();
            this.Load += Form_DanhMucNhanVien_Load;
            this.menuThem.Click += menuThem_Click;
        }

        private async void Form_DanhMucNhanVien_Load(object sender, EventArgs e)
        {
        }

 

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private async void menuThem_Click(object sender, EventArgs e)
        {
            try
            {
                string maNV = txtMaNV.Text.Trim();
                string sdt = txtSDT.Text.Trim();
                string diaChi = txtDiaChi.Text.Trim();
                MessageBox.Show("Not implemented");
              
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật: " + ex.Message);
            }
        }
    }
}
