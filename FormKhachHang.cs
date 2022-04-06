using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

namespace demo
{
    public partial class FormKhachHang : Form
    {
        public FormKhachHang()
        {
            InitializeComponent();
            dataGridViewKhachHang.Columns[2].Width = 300;
            dataGridViewKhachHang.Columns[0].Width = 140;
            dataGridViewKhachHang.Columns[1].Width = 250;
        }

        public string connectionString = ConfigurationManager.ConnectionStrings["Conn"].ConnectionString;

        private void hienDanhSach()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string sql = "SELECT * FROM tblKhachHang";
            connection.Open();
            SqlCommand com = new SqlCommand(sql, connection); //bat dau truy van
            com.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(com); //chuyen du lieu ve
            DataTable dt = new DataTable(); //tạo một kho ảo để lưu trữ dữ liệu
            da.Fill(dt);  // đổ dữ liệu vào kho
            connection.Close();  // đóng kết nối
            dataGridViewKhachHang.DataSource = dt; //đổ dữ liệu vào datagridview
            dataGridViewKhachHang.Focus();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            hienDanhSach();
        }

        /*case 2627:  // Unique constraint error
        case 547:   // Constraint check violation
        case 2601:  // Duplicated key row error
                    // Constraint violation exception*/

        public bool CheckKey(string sql)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlDataAdapter dap = new SqlDataAdapter(sql, connection);
            DataTable table = new DataTable();
            dap.Fill(table);
            if (table.Rows.Count > 0)
                return true;
            else return false;
        }

        private void resetTextBoxKH()
        {
            txtMaKH.Text = "";
            txtHoTen.Text = "";
            txtDienThoai.Text = "";
            txtDiaChi.Text = "";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtHoTen.Text == "")
                errorProviderKH.SetError(txtHoTen, "Vui lòng nhập tên khách hàng");
            else errorProviderKH.SetError(txtHoTen, "");
            if (txtMaKH.Text == "")
                errorProviderKH.SetError(txtMaKH, "Vui lòng nhập mã");
            else errorProviderKH.SetError(txtMaKH, "");

            if (txtDiaChi.Text.Trim().Length == 0)
            {
                errorProviderKH.SetError(txtDiaChi, "Vui lòng nhập địa chỉ ! ");
            }
            else errorProviderKH.SetError(txtDiaChi, "");

            if (txtDienThoai.Text.Trim().Length == 0)
            {
                errorProviderKH.SetError(txtDienThoai, "Vui lòng nhập số điện thoại ! ");
            }
            else errorProviderKH.SetError(txtDienThoai, "");
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "pr_themKhachHang";
                    cmd.Parameters.AddWithValue("@maKH", txtMaKH.Text);
                    cmd.Parameters.AddWithValue("@tenKH", txtHoTen.Text);
                    cmd.Parameters.AddWithValue("@diaChi", txtDiaChi.Text);
                    cmd.Parameters.AddWithValue("@SDT", txtDienThoai.Text);
                    conn.Open();
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Đã xảy ra lỗi ! ", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    resetTextBoxKH();
                    hienDanhSach();
                    conn.Close();
                }
            }
        }

        private void txtMaKH_Validating(object sender, CancelEventArgs e)
        {
            string sql = "select sMaKH from tblKhachHang where sMaKH = " + "'" + txtMaKH.Text + "'";
            if (CheckKey(sql))
            {
                errorProviderKH.SetError(txtMaKH, "Mã khách hàng đã tồn tại ! ");
            }
            else errorProviderKH.SetError(txtMaKH, "");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string maKHXoa = (string)dataGridViewKhachHang.CurrentRow.Cells["sMaKH"].Value;
            string sql = "Select sMaKH from tblKhachHang where sMaKH = N" + "'" + maKHXoa + "'";
            if (CheckKey(sql))
            {
                MessageBox.Show("Xóa khách hàng này sẽ gây ảnh hưởng tới dữ liệu hóa đơn, không thể xóa", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                if (MessageBox.Show(string.Format("Bạn có muốn xóa khách hàng có mã : {0} ?", maKHXoa), "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand("DELETE FROM tblKhachHang WHERE sMaKH = " + "'" + maKHXoa + "'", con))
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.Parameters.AddWithValue("@sMaKH", maKHXoa);
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                    }
                }
                hienDanhSach();
            }
        }

        private void dataGridViewKhachHang_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                dataGridViewKhachHang.Rows[e.RowIndex].Selected = true;
                contextMenuStripKH.Show(dataGridViewKhachHang, e.Location);
                contextMenuStripKH.Show(Cursor.Position);
            }
        }

        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string maKHXoa = (string)dataGridViewKhachHang.CurrentRow.Cells["sMaKH"].Value;
            string sql = "Select sMaKH from tblKhachHang where sMaKH = N" + "'" + maKHXoa + "'";
            if (CheckKey(sql))
            {
                MessageBox.Show("Xóa khách hàng này sẽ gây ảnh hưởng tới dữ liệu hóa đơn, không thể xóa", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                if (MessageBox.Show(string.Format("Bạn có muốn xóa khách hàng có mã : {0} ?", maKHXoa), "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand("DELETE FROM tblKhachHang WHERE sMaKH = " + "'" + maKHXoa + "'", con))
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.Parameters.AddWithValue("@sMaKH", maKHXoa);
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                    }
                }
                hienDanhSach();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string maKHSua = (string)dataGridViewKhachHang.CurrentRow.Cells["sMaKH"].Value;
            if (MessageBox.Show(string.Format("Bạn có muốn sửa khách hàng có mã : {0} ?", maKHSua), "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "pr_SuaKhachHang";
                        cmd.Parameters.AddWithValue("@maKH", maKHSua);
                        cmd.Parameters.AddWithValue("@tenKH", txtHoTen.Text);
                        cmd.Parameters.AddWithValue("@diaChi", txtDiaChi.Text);
                        cmd.Parameters.AddWithValue("@SDT", txtDienThoai.Text);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                }
            }
            hienDanhSach();
        }

        private void txtDienThoai_Validating(object sender, CancelEventArgs e)
        {
            if (txtDienThoai.Text == "")
                errorProviderKH.SetError(txtDienThoai, "Vui lòng nhập số điện thoại");
            else
            {
                if (txtDienThoai.Text.StartsWith("0") == false)
                    errorProviderKH.SetError(txtDienThoai, "Số điện thoại bắt đầu bằng số 0 ");
                else if (txtDienThoai.Text.Length >= 11 || txtDienThoai.Text.Length < 10)
                    errorProviderKH.SetError(txtDienThoai, "Số điện thoại không hợp lệ");
                else errorProviderKH.SetError(txtDienThoai, "");
            }
        }

        //Chỉ cho nhập số vào ô điện thoại
        private void txtDienThoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) )
            {
                e.Handled = true;
            }
        }

        private void txtHoTen_Validating(object sender, CancelEventArgs e)
        {
            if (txtHoTen.Text == "")
                errorProviderKH.SetError(txtHoTen, "Vui lòng nhập tên khách hàng");
            else errorProviderKH.SetError(txtHoTen, "");
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát không ? ", "Xác nhận ", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Hide();
                FormTrangChu formTrangChu  = new FormTrangChu(); 
                formTrangChu.ShowDialog();
                this.Close();
            }
        }

        private void dataGridViewKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaKH.Text = Convert.ToString(dataGridViewKhachHang.CurrentRow.Cells["sMaKH"].Value);
            txtMaKH.Enabled = false;
            txtHoTen.Text = Convert.ToString(dataGridViewKhachHang.CurrentRow.Cells["sTenKH"].Value);
            txtDiaChi.Text = Convert.ToString(dataGridViewKhachHang.CurrentRow.Cells["sDiaChi"].Value);
            txtDienThoai.Text = Convert.ToString(dataGridViewKhachHang.CurrentRow.Cells["sSDT"].Value);
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string sql = "Select * from tblKhachHang where sTenKH LIKE '%" +
                txtHoTen.Text + "%' or " + "sDiaChi like '%" + txtDiaChi.Text + "%' or " +
                "sSDT like '%" + txtDienThoai.Text + "%' ";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand com = new SqlCommand(sql, connection); //bat dau truy van
            com.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(com); //chuyen du lieu ve
            DataTable dt = new DataTable(); //tạo một kho ảo để lưu trữ dữ liệu
            da.Fill(dt);  // đổ dữ liệu vào kho
            connection.Close();  // đóng kết nối
            dataGridViewKhachHang.DataSource = dt; //đổ dữ liệu vào datagridview
        }

        private void txtDienThoai_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else e.Handled = true;
        }

        private void txtDienThoai_Validating_1(object sender, CancelEventArgs e)
        {
            if (txtDienThoai.Text == "")
                errorProviderKH.SetError(txtDienThoai, "Vui lòng nhập số điện thoại");
            else
            {
                if (txtDienThoai.Text.StartsWith("0") == false)
                    errorProviderKH.SetError(txtDienThoai, "Số điện thoại bắt đầu bằng số 0 ");
                else if (txtDienThoai.Text.Length >= 11 || txtDienThoai.Text.Length < 10)
                    errorProviderKH.SetError(txtDienThoai, "Số điện thoại không hợp lệ");
                else errorProviderKH.SetError(txtDienThoai, "");
            }
        }

    }
}
