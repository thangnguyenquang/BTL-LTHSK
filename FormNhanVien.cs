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
    public partial class FormNhanVien : Form
    {
        public FormNhanVien()
        {
            InitializeComponent();
            dataGridViewNhanVien.Columns[3].Width = 290;
            dataGridViewNhanVien.Columns[0].Width = 140;
            dataGridViewNhanVien.Columns[1].Width = 240;
            dataGridViewNhanVien.Columns[2].Width = 120;
        }
        public string connectionString = ConfigurationManager.ConnectionStrings["Conn"].ConnectionString;

        private void hienDanhSach()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string sql = "SELECT * FROM tblNhanVien";
            connection.Open();
            SqlCommand com = new SqlCommand(sql, connection); //bat dau truy van
            com.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(com); //chuyen du lieu ve
            DataTable dt = new DataTable(); //tạo một kho ảo để lưu trữ dữ liệu
            da.Fill(dt);  // đổ dữ liệu vào kho
            connection.Close();  // đóng kết nối
            dataGridViewNhanVien.DataSource = dt; //đổ dữ liệu vào datagridview
        }

        //Hàm kiểm tra khoá trùng
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

        private void resetTextBoxNV()
        {
            txtMaNV.Text = "";
            txtHoTen.Text = "";
            txtNgaySinh.Text = "";
            txtDienThoai.Text = "";
            txtDiaChi.Text = "";
        }


        private void btnThem_Click(object sender, EventArgs e)
        {
            string gioiTinh;
            if (rbtnNam.Checked == true)
                gioiTinh = "Nam";
            else if (rbtnNu.Checked == true)
                gioiTinh = "Nữ";
            else
                gioiTinh = "";

            if (txtMaNV.Text.Trim().Length == 0)
            {
                errorProviderNhanVien.SetError(txtMaNV, "Vui lòng nhập mã nhân viên ! ");
            }
            else errorProviderNhanVien.SetError(txtMaNV, "");

            if (txtHoTen.Text.Trim().Length == 0)
            {
                errorProviderNhanVien.SetError(txtHoTen, "Vui lòng nhập tên nhân viên ! ");
            }
            else errorProviderNhanVien.SetError(txtHoTen, "");

            if (txtDiaChi.Text.Trim().Length == 0)
            {
                errorProviderNhanVien.SetError(txtDiaChi, "Vui lòng nhập địa chỉ ! ");
            }
            else errorProviderNhanVien.SetError(txtDiaChi, "");

            if (txtDienThoai.Text.Trim().Length == 0)
            {
                errorProviderNhanVien.SetError(txtDienThoai, "Vui lòng nhập số điện thoại ! ");
            }
            else errorProviderNhanVien.SetError(txtDienThoai, "");

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "pr_themNhanVien";
                    cmd.Parameters.AddWithValue("@maNV", txtMaNV.Text);
                    cmd.Parameters.AddWithValue("@tenNV", txtHoTen.Text);
                    cmd.Parameters.AddWithValue("@gioiTinh", gioiTinh);
                    cmd.Parameters.AddWithValue("@diaChi", txtDiaChi.Text);
                    cmd.Parameters.AddWithValue("@ngaySinh", txtNgaySinh.Text);
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
                    resetTextBoxNV();
                    hienDanhSach();
                    conn.Close();
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát không ? ", "Xác nhận ", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Hide();
                FormTrangChu formTrangChu = new FormTrangChu();
                formTrangChu.ShowDialog();
                this.Close();
            }    
        }

        private void FormNhanVien_Load(object sender, EventArgs e)
        {
            hienDanhSach();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string maNVXoa = (string)dataGridViewNhanVien.CurrentRow.Cells["sMaNV"].Value;
            string sql = "Select sMaNV from tblHoaDon where sMaNV = N" + "'" + maNVXoa + "'";
            if (CheckKey(sql))
            {
                MessageBox.Show("Xóa nhân viên sẽ gây ảnh hưởng tới dữ liệu hóa đơn, không thể xóa", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                if (MessageBox.Show(string.Format("Bạn có muốn xóa khách hàng có mã : {0} ?", maNVXoa), "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand("DELETE FROM tblNhanVien WHERE sMaNV = " + "'" + maNVXoa + "'", con))
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.Parameters.AddWithValue("@sMaNV", maNVXoa);
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                    }
                    hienDanhSach();
                }    
            }
        }

            private void dataGridViewNhanVien_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                dataGridViewNhanVien.Rows[e.RowIndex].Selected = true;
                contextMenuStripNV.Show(dataGridViewNhanVien, e.Location);
                contextMenuStripNV.Show(Cursor.Position);
            }
        }

        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string maNVXoa = (string)dataGridViewNhanVien.CurrentRow.Cells["sMaNV"].Value;
            string sql = "Select sMaNV from tblHoaDon where sMaNV = N" + "'" + maNVXoa + "'";
            if (CheckKey(sql))
            {
                MessageBox.Show("Xóa nhân viên này sẽ gây ảnh hưởng tới dữ liệu hóa đơn, không thể xóa", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                if (MessageBox.Show(string.Format("Bạn có muốn xóa khách hàng có mã : {0} ?", maNVXoa), "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand("DELETE FROM tblNhanVien WHERE sMaNV = " + "'" + maNVXoa + "'", con))
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.Parameters.AddWithValue("@sMaNV", maNVXoa);
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                    }
                    hienDanhSach();
                }
            }
        }

        private void txtDienThoai_Validating(object sender, CancelEventArgs e)
        {
            if (txtDienThoai.Text == "")
                errorProviderNhanVien.SetError(txtDienThoai, "Vui lòng nhập số điện thoại");
            else
            {
                if (txtDienThoai.Text.StartsWith("0") == false)
                    errorProviderNhanVien.SetError(txtDienThoai, "Số điện thoại bắt đầu bằng số 0 ");
                else if (txtDienThoai.Text.Length >= 11 || txtDienThoai.Text.Length < 10)
                    errorProviderNhanVien.SetError(txtDienThoai, "Số điện thoại không hợp lệ");
                else errorProviderNhanVien.SetError(txtDienThoai, "");
            }
        }

        private void txtDienThoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txtNgaySinh_Validating(object sender, CancelEventArgs e)
        {
            DateTime ngaySinh = Convert.ToDateTime(txtNgaySinh.Text);
            if (DateTime.Compare(ngaySinh.Date, DateTime.Now.Date) >= 0)
                errorProviderNhanVien.SetError(txtNgaySinh, "Ngày sinh phải nhỏ hơn ngày hiện tại");
            else
                errorProviderNhanVien.SetError(txtNgaySinh, "");
        }

        private void txtMaNV_Validating(object sender, CancelEventArgs e)
        {
            string sql = "select sMaNV from tblNhanVien where sMaNV = " + "'" + txtMaNV.Text + "'";
            if (CheckKey(sql))
            {
                errorProviderNhanVien.SetError(txtMaNV, "Mã nhân viên đã tồn tại ! ");
            }
            else 
                errorProviderNhanVien.SetError(txtMaNV, "");
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string gioiTinh;
            if (rbtnNam.Checked == true)
                gioiTinh = "Nam";
            else if (rbtnNu.Checked == true)
                gioiTinh = "Nữ";
            else
                gioiTinh = "";
            string maNVSua = (string)dataGridViewNhanVien.CurrentRow.Cells["sMaNV"].Value;
            if (MessageBox.Show(string.Format("Bạn có muốn sửa khách hàng có mã : {0} ?", maNVSua), "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "pr_SuaNhanVien";
                        cmd.Parameters.AddWithValue("@maNV", maNVSua);
                        cmd.Parameters.AddWithValue("@tenNV", txtHoTen.Text);
                        cmd.Parameters.AddWithValue("@gioiTinh", gioiTinh);
                        cmd.Parameters.AddWithValue("@diaChi", txtDiaChi.Text);
                        cmd.Parameters.AddWithValue("@ngaySinh", txtNgaySinh.Text);
                        cmd.Parameters.AddWithValue("@SDT", txtDienThoai.Text);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                }
            }
            hienDanhSach();
        }

        private void dataGridViewNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaNV.Text = Convert.ToString(dataGridViewNhanVien.CurrentRow.Cells["sMaNV"].Value);
            txtMaNV.Enabled = false;
            txtHoTen.Text = Convert.ToString(dataGridViewNhanVien.CurrentRow.Cells["sTenNV"].Value);
            txtNgaySinh.Text = Convert.ToString(dataGridViewNhanVien.CurrentRow.Cells["dNgaySinh"].Value);
            txtDiaChi.Text = Convert.ToString(dataGridViewNhanVien.CurrentRow.Cells["sDiaChi"].Value);
            txtDienThoai.Text = Convert.ToString(dataGridViewNhanVien.CurrentRow.Cells["sSDT"].Value);
        }

        private void btnTimKiem_Click(object sender, EventArgs e) 
        {
            string sql = "select * from tblNhanVien where sTenNV like N'%" + txtTimKiem.Text + "%'";

            SqlConnection connection = new SqlConnection(connectionString); 
            connection.Open();//Mở kết nối
            SqlCommand com = new SqlCommand(sql, connection); //bat dau truy van
            com.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(com); //chuyen du lieu ve
            DataTable dt = new DataTable(); //tạo một kho ảo để lưu trữ dữ liệu
            da.Fill(dt);  // đổ dữ liệu vào kho
            connection.Close();  // đóng kết nối
            dataGridViewNhanVien.DataSource = dt; //đổ dữ liệu vào datagridview
        }
    }
}
