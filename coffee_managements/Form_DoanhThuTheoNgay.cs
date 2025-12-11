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
    public partial class Form_DoanhThuTheoNgay : Form
    {
        public Form_DoanhThuTheoNgay()
        {
            InitializeComponent();
        }

        private void btnLocDuLieu_Click(object sender, EventArgs e)
        {
            DateTime selectedDate = dateTimePicker1.Value;

            // In ra console
            Console.WriteLine(selectedDate);           // 11/12/2025 14:30:15
            Console.WriteLine(selectedDate.Date);      // 11/12/2025 00:00:00 (chỉ ngày)
            Console.WriteLine(selectedDate.ToString("yyyy-MM-dd HH:mm:ss"));
        }
    }
}
