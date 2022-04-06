using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace demo
{
    public partial class FormDangNhap : Form
    {
        public string connectionString = ConfigurationManager.ConnectionStrings["Conn"].ConnectionString;
        public static string UserName = "";
        public FormDangNhap()
        {
            InitializeComponent();
        }

        private void chkHienMatKhau_CheckedChanged(object sender, EventArgs e)
        {
            if (chkHienMatKhau.Checked)
            {
                txtMatKhau.PasswordChar = (char)0;
            }
            else
            {
                txtMatKhau.PasswordChar = '*';
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có muốn thoát ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
                Application.Exit();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "pr_checkdangnhap";
                    cmd.Parameters.AddWithValue("@tentaikhoan", txtTaiKhoan.Text);
                    cmd.Parameters.AddWithValue("@matkhau", txtMatKhau.Text);
                    UserName = txtTaiKhoan.Text;
                   // Sử dụng phương thức ExecuteScalar trong class SqlCommand để lấy
                   // kết quả trả về từ SQL Server.
                    object kq = cmd.ExecuteScalar();
                    int code = (int)kq;
                    if(code == 1)
                    {
                        MessageBox.Show("Chào mừng nhân viên mã : " + UserName + " đăng nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Hide();
                        FormTrangChu form = new FormTrangChu();
                        form.ShowDialog();
                        this.Close();
                    }
                    else if (code == 2)
                    {
                        MessageBox.Show("Mật khẩu không chính xác !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtMatKhau.Text = "";
                        txtMatKhau.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Tài khoản hoặc mật khẩu chưa đúng !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtTaiKhoan.Text = "";
                        txtMatKhau.Text = "";
                        txtTaiKhoan.Focus();
                    }
                }
                conn.Close();
            }
        }

    }
}
