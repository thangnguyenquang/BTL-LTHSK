using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace demo
{
    public partial class FormTrangChu : Form
    {
        public FormTrangChu()
        {
            InitializeComponent();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn đóng Form lại hay không ? ", "FormClosing", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                e.Cancel = false;
            }
            else
                e.Cancel = true;//Không đóng Form nữa
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                MessageBox.Show("Ban nhan chuot trai");
            else if (e.Button == MouseButtons.Right)
                MessageBox.Show("Ban nhan chuot phai");
            else MessageBox.Show("Ban nhan chuot giua!");
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void kháchHàngToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            FormKhachHang formKhachHang = new FormKhachHang();
            //formKhachHang.MdiParent = this;
            formKhachHang.ShowDialog();
            this.Close();
        }

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormNhanVien formNhanVien = new FormNhanVien();
            //formNhanVien.MdiParent = this; 
            formNhanVien.ShowDialog();
            this.Close();
        }

        private void thúCưngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormMatHang formThuCung = new FormMatHang();
            //formNhanVien.MdiParent = this; 
            formThuCung.ShowDialog();
            this.Close();
        }

        private void sảnPhẩmChoThúCưngToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormMatHang formMatHang = new FormMatHang();
            //formNhanVien.MdiParent = this; 
            formMatHang.ShowDialog();
            this.Close();
        }

        private void thanhToánToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormHoaDon formHoaDon = new FormHoaDon();
            //formNhanVien.MdiParent = this; 
            formHoaDon.ShowDialog();
            this.Close();
        }
    }
}
