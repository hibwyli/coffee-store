using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DoAnLapTrinhMang
{
    public partial class Form_TrangChinh : Form
    {
        public Form_TrangChinh()
        {
            InitializeComponent();
            MaDoUong.HeaderText = "Mã đồ uống";
            MaDoUong.Items.AddRange("Option 1", "Option 2", "Option 3");


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
            textBox1.Text = SessionVars.username;
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

        private void thôngTinCáNhânToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Form_ThongTinCaNhan form_ThongTinCaNhan = new Form_ThongTinCaNhan();
            form_ThongTinCaNhan.Show();
        }

        private void dataGridView_HoaDon_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dataGridView_HoaDon.CurrentCell.ColumnIndex == dataGridView_HoaDon.Columns["MaDoUong"].Index)
            {
                System.Windows.Forms.ComboBox combo = e.Control as System.Windows.Forms.ComboBox;
                if (combo != null)
                {
                    combo.SelectionChangeCommitted -= Combo_SelectionChangeCommitted;
                    combo.SelectionChangeCommitted += Combo_SelectionChangeCommitted;
                }
            }
        }

        private void Combo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            System.Windows.Forms.ComboBox combo = sender as System.Windows.Forms.ComboBox;
            if (combo != null)
            {
                int rowIndex = dataGridView_HoaDon.CurrentCell.RowIndex;
                DataGridViewRow row = dataGridView_HoaDon.Rows[rowIndex];

                // Lấy giá trị trực tiếp từ combo
                var selectedValue = combo.SelectedItem.ToString();

                // Điền dữ liệu mẫu
                row.Cells["TenDoUong"].Value = selectedValue; // Dùng trực tiếp từ combo
                row.Cells["SoLuong"].Value = 3;
                row.Cells["DonGia"].Value = 3000000;

                // Tính thành tiền
                int quantity = 3;
                int unitPrice = 3000000;
                row.Cells["ThanhTien"].Value = quantity * unitPrice;

                UpdateTotalLabel();
            }
        }
        

        private void dataGridView_HoaDon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5 && e.RowIndex >= 0) // rowIndex 0 is valid
            {
                DataGridViewRow row = dataGridView_HoaDon.Rows[e.RowIndex];
                if (!row.IsNewRow) // check if it's not the new row
                {
                    dataGridView_HoaDon.Rows.RemoveAt(e.RowIndex);
                    UpdateTotalLabel();

                }
            }

        }
        private void UpdateTotalLabel()
        {
            int total = 0;

            foreach (DataGridViewRow row in dataGridView_HoaDon.Rows)
            {
                // Bỏ qua hàng mới (hàng để thêm)
                if (row.Cells[4].Value != null)
                {
                    total += Convert.ToInt32(row.Cells[4].Value);
                }
            }

            label4.Text = total.ToString("N0") + " VND"; // N0 để format với dấu phẩy
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // create hoa don , push hoa don len server
            MessageBox.Show("Not implement create hoa don!");
        }

        private void Form_TrangChinh_Load(object sender, EventArgs e)
        {

        }

        private void chatBoxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_ChatBox form_ChatBox = new Form_ChatBox();
            form_ChatBox.Show();
        }
    }
}

