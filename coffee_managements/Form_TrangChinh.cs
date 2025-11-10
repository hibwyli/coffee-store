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
    }
}
