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
    public partial class Form_TrangChinh : Form
    {
        public Form_TrangChinh()
        {
            InitializeComponent();
        }

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_DanhMucNhanVien form_DanhMucNhanVien = new Form_DanhMucNhanVien();
            
            form_DanhMucNhanVien.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void mainLayout_Paint(object sender, PaintEventArgs e)
        {

        }

        private void loạiĐồUốngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_DanhMucDoUong form_DanhMucDoUong = new Form_DanhMucDoUong();
            form_DanhMucDoUong.Show();
        }

        private void LoadTable()
        {

        }

        public void UpdateSession()
        {
            textBox_Ten.Text = SessionVars.username;
            textBox_Role.Text = SessionVars.role; 
        }

        private void textBox_Role_TextChanged(object sender, EventArgs e)
        {

        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            SessionVars.username = null;
            SessionVars.role = null;
            this.Close();
        }

        private void textBox_Ten_TextChanged(object sender, EventArgs e)
        {

        }

        private void thốngKêToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form_DoanhThuTheoNgay form_DoanhThuTheoNgay = new Form_DoanhThuTheoNgay();
            form_DoanhThuTheoNgay.Show();
        }

        private void thốngKêDoanhThuTheoNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_DoanhThuTheoNhanVien form_DoanhThuTheoNhanVien = new Form_DoanhThuTheoNhanVien();
            form_DoanhThuTheoNhanVien.Show();
        }

        private void thốngKêDoanhThuTheoNhânViênToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

        }

        private void thôngTinCáNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_ThongTinCaNhan form_ThongTinCaNhan = new Form_ThongTinCaNhan();
            form_ThongTinCaNhan.Show();
        }
    }
}
