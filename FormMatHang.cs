using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace demo
{
    public partial class FormMatHang : Form
    {
        public FormMatHang()
        {
            InitializeComponent();
            dataGridViewMatHang.Columns[0].Width = 150;
            dataGridViewMatHang.Columns[1].Width = 270;
            dataGridViewMatHang.Columns[2].Width = 240;
            dataGridViewMatHang.Columns[3].Width = 150;
        }
        public static bool btnThemLH_clicked = false;
        public string connectionString = ConfigurationManager.ConnectionStrings["Conn"].ConnectionString;

        private void hienDanhSach()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string sql = "SELECT sMaMH, sTenMH, sTenLH, iSoLuong, fGiaTien " +
                         " FROM tblMatHang, tblLoaiMatHang " +
                         " where tblMatHang.sMaLH = tblLoaiMatHang.sMaLH ";
            connection.Open();
            SqlCommand com = new SqlCommand(sql, connection); //bat dau truy van
            com.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(com); //chuyen du lieu ve
            DataTable dt = new DataTable(); //tạo một kho ảo để lưu trữ dữ liệu
            da.Fill(dt);  // đổ dữ liệu vào kho
            connection.Close();  // đóng kết nối
            dataGridViewMatHang.DataSource = dt; //đổ dữ liệu vào datagridview
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

        private void resetTextBoxMH()
        {
            txtMaMH.Text = "";
            txtTenMH.Text = "";
            txtSL.Text = "";
            txtGiaTien.Text = "";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtMaMH.Text.Trim().Length == 0)
                MessageBox.Show("Vui lòng nhập mã mặt hàng");
            else if (txtTenMH.Text.Trim().Length == 0)
                MessageBox.Show("Vui lòng nhập tên mặt hàng");
            else if (txtSL.Text.Trim().Length == 0)
                MessageBox.Show("Vui lòng nhập số lượng mặt hàng");
            else if (txtGiaTien.Text.Trim().Length == 0)
                MessageBox.Show("Vui lòng nhập giá tiền mặt hàng");
            else if (comboBoxLoaiHang.Text.Trim().Length == 0)
                MessageBox.Show("Vui lòng nhập loại mặt hàng");
            else if(txtMaLH.Text.Trim().Length == 0)
                MessageBox.Show("Vui lòng nhập mã của loại mặt hàng");
            else
            {
                //Thêm loại hàng vừa nhập tại form mặt hàng
                //khi nút thêm loại hàng mới được ấn
                if(btnThemLH_clicked)
                {
                    string sql = "select sMaLH from tblLoaiMatHang where sMaLH = " + "'" + txtMaLH.Text + "'";
                    if (CheckKey(sql))
                    {
                        MessageBox.Show("Mã loại hàng bạn vừa nhập đã tồn tại, vui lòng nhập mã khác", "Thông báo");
                        txtMaLH.Text = "";
                        txtMaLH.Focus();
                    }
                    else if(CheckKey("select sTenLH from tblLoaiMatHang where sTenLH = " + "'" + comboBoxLoaiHang.Text + "'"))
                    {
                        MessageBox.Show("Tên loại hàng bạn vừa nhập đã tồn tại, vui lòng nhập tên khác", "Thông báo");
                        comboBoxLoaiHang.Text = "";
                        comboBoxLoaiHang.Focus();
                    }
                    else
                    {
                        //Thêm loại hàng mới
                        using (SqlConnection conn = new SqlConnection(connectionString))
                        {
                            using (SqlCommand cmd = conn.CreateCommand())
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.CommandText = "pr_themLoaiMatHang";
                                cmd.Parameters.AddWithValue("@maLH", txtMaLH.Text);
                                cmd.Parameters.AddWithValue("@tenLH", comboBoxLoaiHang.Text);
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
                                conn.Close();
                            }
                        }
                        //Thêm mặt hàng mới
                        using (SqlConnection conn = new SqlConnection(connectionString))
                        {
                            using (SqlCommand cmd = conn.CreateCommand())
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.CommandText = "pr_themMatHang";
                                cmd.Parameters.AddWithValue("@maMH", txtMaMH.Text);
                                cmd.Parameters.AddWithValue("@tenMH", txtTenMH.Text);
                                cmd.Parameters.AddWithValue("@maLH", txtMaLH.Text);
                                cmd.Parameters.AddWithValue("@soLuong", txtSL.Text);
                                cmd.Parameters.AddWithValue("@giaTien", txtGiaTien.Text);
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
                                resetTextBoxMH();
                                conn.Close();
                            }
                        }
                    }    
                }
                else
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        using (SqlCommand cmd = conn.CreateCommand())
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = "pr_themMatHang";
                            cmd.Parameters.AddWithValue("@maMH", txtMaMH.Text);
                            cmd.Parameters.AddWithValue("@tenMH", txtTenMH.Text);
                            cmd.Parameters.AddWithValue("@maLH", txtMaLH.Text);
                            cmd.Parameters.AddWithValue("@soLuong", txtSL.Text);
                            cmd.Parameters.AddWithValue("@giaTien", txtGiaTien.Text);
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
                            resetTextBoxMH();
                            conn.Close();
                        }
                    }
                }
            }
            hienDanhSach();
        }

        /*private void txtGiaTien_TextChanged(object sender, EventArgs e)
        {
            CultureInfo culture = new CultureInfo("vi-VN");
            decimal value = decimal.Parse(txtGiaTien.Text, NumberStyles.Float);
            txtGiaTien.Text = String.Format(culture, "{0:N0}", value);
            txtGiaTien.Select(txtGiaTien.Text.Length, 0);
        }*/

        private void txtSL_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) )
            {
                e.Handled = true;
            }
        }

        private void txtGiaTien_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string maMHSua = (string)dataGridViewMatHang.CurrentRow.Cells["sMaMH"].Value;
            if (MessageBox.Show(string.Format("Bạn có muốn sửa mặt hàng có mã : {0} ?", maMHSua), "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "pr_suaMatHang";
                        cmd.Parameters.AddWithValue("@maMH", maMHSua);
                        cmd.Parameters.AddWithValue("@tenMH", txtTenMH.Text);
                        cmd.Parameters.AddWithValue("@maLH", comboBoxLoaiHang.SelectedValue);
                        cmd.Parameters.AddWithValue("@soLuong", txtSL.Text);
                        cmd.Parameters.AddWithValue("@giaTien", txtGiaTien.Text);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                }
            }
            hienDanhSach();
        }

        private void dataGridViewThuCung_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaMH.Text = Convert.ToString(dataGridViewMatHang.CurrentRow.Cells["sMaMH"].Value);
            txtMaMH.Enabled = false;
            txtTenMH.Text = Convert.ToString(dataGridViewMatHang.CurrentRow.Cells["sTenMH"].Value);
            txtMaLH.Text = Convert.ToString(dataGridViewMatHang.CurrentRow.Cells["sMaLH"].Value);
            txtSL.Text = Convert.ToString(dataGridViewMatHang.CurrentRow.Cells["iSoLuong"].Value);
            txtGiaTien.Text = Convert.ToString(dataGridViewMatHang.CurrentRow.Cells["fGiaTien"].Value);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string maMHXoa = (string)dataGridViewMatHang.CurrentRow.Cells["sMaMH"].Value;
            if (MessageBox.Show(string.Format("Bạn có muốn xóa mặt hàng có mã : {0} ?", maMHXoa), "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("DELETE FROM tblMatHang WHERE sMaMH = " + "'" + maMHXoa + "'", con))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@sMaMH", maMHXoa);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }
            hienDanhSach();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn có muốn thoát không ? ", "Xác nhận ", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Hide();
                FormTrangChu formTrangChu = new FormTrangChu();
                formTrangChu.ShowDialog();
                this.Close();
            }       
        }

        private void txtMaTC_Validating(object sender, CancelEventArgs e)
        {
            string sql = "select sMaMH from tblMatHang where sMaMH = " + "'" + txtMaMH.Text + "'";
            if (CheckKey(sql))
            {
                errorProviderThuCung.SetError(txtMaMH, "Mã mặt hàng đã tồn tại ! ");
            }
            else
                errorProviderThuCung.SetError(txtMaMH, "");
        }

        //Đổ dữ liệu từ cơ sở dữ liệu vào comboBox
        private void fillComboBox (string sql, ComboBox comboBox, string giaTri, string hienThi)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand com = new SqlCommand(sql, connection); //bat dau truy van
            com.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(com); //chuyen du lieu ve
            DataTable dt = new DataTable(); //tạo một kho ảo để lưu trữ dữ liệu
            da.Fill(dt);  // đổ dữ liệu vào kho
            connection.Close();  // đóng kết nối
            comboBox.DataSource = dt;
            comboBox.ValueMember = giaTri; //Trường giá trị
            comboBox.DisplayMember = hienThi; //Trường hiển thị
        }

        private void FormMatHang_Load(object sender, EventArgs e)
        {
            string sql;
            sql = "SELECT * from tblLoaiMatHang";
            fillComboBox(sql, comboBoxLoaiHang, "sTenLH", "sTenLH");
            comboBoxLoaiHang.SelectedIndex = -1;
            hienDanhSach();
        }

        //Lấy dữ liệu qua câu lệnh sql
        public string GetFieldValues(string sql)
        {
            string duLieu = "";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.CommandType = CommandType.Text;
                    conn.Open();
                    using (SqlDataReader rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                            duLieu = rd.GetValue(0).ToString();
                        rd.Close();
                    }
                    conn.Close();
                }
            }
            return duLieu;
        }

        private void comboBoxLoaiHang_TextChanged(object sender, EventArgs e)
        {
            string sql;
            if (comboBoxLoaiHang.Text == "")
                txtMaLH.Text = "";
            // Khi chọn tên loại hàng thì mã loại hàng tự động hiện ra
            sql = "Select sMaLH from tblLoaiMatHang where sTenLH = N'" + comboBoxLoaiHang.SelectedValue + "'";
            txtMaLH.Text = GetFieldValues(sql);
        }

        private void btnThemLH_Click(object sender, EventArgs e)
        {
            btnThemLH_clicked = true;
            comboBoxLoaiHang.DropDownStyle = ComboBoxStyle.DropDown;
            comboBoxLoaiHang.SelectedIndex = -1;
            txtMaLH.ReadOnly = false;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string sql = "select * from tblMatHang where sTenMH like N'%" + txttimkiem.Text + "%'";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand com = new SqlCommand(sql, connection);
            com.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            connection.Close();
            dataGridViewMatHang.DataSource = dt;
        }
    }
}
