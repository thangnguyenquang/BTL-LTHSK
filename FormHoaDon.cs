using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using COMExcel = Microsoft.Office.Interop.Excel;

namespace demo
{
    public partial class FormHoaDon : Form
    {
        public FormHoaDon()
        {
            InitializeComponent();
        }
        public static bool btnThemKH_clicked = false;
        public string connectionString = ConfigurationManager.ConnectionStrings["Conn"].ConnectionString;

        private void txtSlTC_Enter(object sender, EventArgs e)
        {
            if (txtSlMH.Text == "Nhập số lượng mặt hàng")
            {
                txtSlMH.Text = "";
                txtSlMH.ForeColor = Color.Black;
            }
        }

        private void txtSlTC_Leave(object sender, EventArgs e)
        {
            if (txtSlMH.Text == "")
            {
                txtSlMH.Text = "Nhập số lượng mặt hàng";
                txtSlMH.ForeColor = Color.LightSlateGray;
            }
        }

        //123 => một trăm hai ba đồng
        //1,123,000=>một triệu một trăm hai ba nghìn đồng
        //1,123,345,000 => một tỉ một trăm hai ba triệu ba trăm bốn lăm ngàn đồng
        string[] mNumText = "không;một;hai;ba;bốn;năm;sáu;bảy;tám;chín".Split(';');
        //Viết hàm chuyển số hàng chục, giá trị truyền vào là số cần chuyển và một biến đọc phần lẻ hay không ví dụ 101 => một trăm lẻ một
        private string DocHangChuc(double so, bool daydu)
        {
            string chuoi = "";
            //Hàm để lấy số hàng chục ví dụ 21/10 = 2
            Int64 chuc = Convert.ToInt64(Math.Floor((double)(so / 10)));
            //Lấy số hàng đơn vị bằng phép chia 21 % 10 = 1
            Int64 donvi = (Int64)so % 10;
            //Nếu số hàng chục tồn tại tức >=20
            if (chuc > 1)
            {
                chuoi = " " + mNumText[chuc] + " mươi";
                if (donvi == 1)
                {
                    chuoi += " mốt";
                }
            }
            else if (chuc == 1)
            {//Số hàng chục từ 10-19
                chuoi = " mười";
                if (donvi == 1)
                {
                    chuoi += " một";
                }
            }
            else if (daydu && donvi > 0)
            {//Nếu hàng đơn vị khác 0 và có các số hàng trăm ví dụ 101 => thì biến daydu = true => và sẽ đọc một trăm lẻ một
                chuoi = " lẻ";
            }
            if (donvi == 5 && chuc >= 1)
            {//Nếu đơn vị là số 5 và có hàng chục thì chuỗi sẽ là " lăm" chứ không phải là " năm"
                chuoi += " lăm";
            }
            else if (donvi > 1 || (donvi == 1 && chuc == 0))
            {
                chuoi += " " + mNumText[donvi];
            }
            return chuoi;
        }
        private string DocHangTram(double so, bool daydu)
        {
            string chuoi = "";
            //Lấy số hàng trăm ví du 434 / 100 = 4 (hàm Floor sẽ làm tròn số nguyên bé nhất)
            Int64 tram = Convert.ToInt64(Math.Floor((double)so / 100));
            //Lấy phần còn lại của hàng trăm 434 % 100 = 34 (dư 34)
            so = so % 100;
            if (daydu || tram > 0)
            {
                chuoi = " " + mNumText[tram] + " trăm";
                chuoi += DocHangChuc(so, true);
            }
            else
            {
                chuoi = DocHangChuc(so, false);
            }
            return chuoi;
        }
        private string DocHangTrieu(double so, bool daydu)
        {
            string chuoi = "";
            //Lấy số hàng triệu
            Int64 trieu = Convert.ToInt64(Math.Floor((double)so / 1000000));
            //Lấy phần dư sau số hàng triệu ví dụ 2,123,000 => so = 123,000
            so = so % 1000000;
            if (trieu > 0)
            {
                chuoi = DocHangTram(trieu, daydu) + " triệu";
                daydu = true;
            }
            //Lấy số hàng nghìn
            Int64 nghin = Convert.ToInt64(Math.Floor((double)so / 1000));
            //Lấy phần dư sau số hàng nghin 
            so = so % 1000;
            if (nghin > 0)
            {
                chuoi += DocHangTram(nghin, daydu) + " nghìn";
                daydu = true;
            }
            if (so > 0)
            {
                chuoi += DocHangTram(so, daydu);
            }
            return chuoi;
        }
        //Chuyển tổng tiền từ số sang chữ
        public string ChuyenSoSangChu(double so)
        {
            if (so == 0)
                return mNumText[0];
            string chuoi = "", hauto = "";
            Int64 ty;
            do
            {
                //Lấy số hàng tỷ
                ty = Convert.ToInt64(Math.Floor((double)so / 1000000000));
                //Lấy phần dư sau số hàng tỷ
                so = so % 1000000000;
                if (ty > 0)
                {
                    chuoi = DocHangTrieu(so, true) + hauto + chuoi;
                }
                else
                {
                    chuoi = DocHangTrieu(so, false) + hauto + chuoi;
                }
                hauto = " tỷ";
            } while (ty > 0);
            return chuoi + " đồng";
        }

    //Chuyển đổi từ PM sang dạng 24h
    public static string ConvertTimeTo24(string hour)
    {
        string h = "";
        switch (hour)
        {
            case "1":
                h = "13";
                break;
            case "2":
                h = "14";
                break;
            case "3":
                h = "15";
                break;
            case "4":
                h = "16";
                break;
            case "5":
                h = "17";
                break;
            case "6":
                h = "18";
                break;
            case "7":
                h = "19";
                break;
            case "8":
                h = "20";
                break;
            case "9":
                h = "21";
                break;
            case "10":
                h = "22";
                break;
            case "11":
                h = "23";
                break;
            case "12":
                h = "0";
                break;
        }
        return h;
    } 

        //Hàm tạo khóa (mã hóa đơn) có dạng: TientoNgaythangnam_giophutgiay
        public static string CreateKey(string tiento)
        {
            string key = tiento;
            string[] partsDay;
            partsDay = DateTime.Now.ToShortDateString().Split('/');
            //Ví dụ 07/08/2009
            string d = String.Format("{0}{1}{2}", partsDay[0], partsDay[1], partsDay[2]);
            key = key + d;
            string[] partsTime;
            partsTime = DateTime.Now.ToLongTimeString().Split(':');
            //Ví dụ 7:08:03 PM hoặc 7:08:03 AM
            if (partsTime[2].Substring(3, 2) == "PM")
                partsTime[0] = ConvertTimeTo24(partsTime[0]);
            if (partsTime[2].Substring(3, 2) == "AM")
                if (partsTime[0].Length == 1)
                    partsTime[0] = "0" + partsTime[0];
            //Xóa ký tự trắng và PM hoặc AM
            partsTime[2] = partsTime[2].Remove(2, 3);
            string t;
            t = String.Format("{0}{1}{2}", partsTime[0], partsTime[1], partsTime[2]);
            key = key + t;
            return key;
        }

        private void ResetValuesHD()
        {
            txtMaHD.Text = "";
            txtNgayLapHD.Text = "";
            //comboBoxMaNV.Text = "";
            //comboBoxMaKH.Text = "";
            labelTongTienChu.Text = "Tổng tiền bằng chữ: ";
            comboBoxMH.Text = "";
            txtTongTien.Text = "0";
        }

        private void ResetValuesMatHang()
        {
            comboBoxMH.Text = "";
            txtSlMH.Text = "";
            txtGiamGia.Text = "";
        }


        //Đổ dữ liệu từ cơ sở dữ liệu vào comboBox
        private void fillComboBox(string sql, ComboBox comboBox, string giaTri, string hienThi)
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

        //Hiển thị dữ liệu thông tin các mặt hàng lên datagridview
        private void hienDanhSach()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string sql = "SELECT tblCTHoaDon.sMaMH, sTenMH, fSLMH, fGiaTien, fGiamGia, fThanhTien " +
                         " FROM tblMatHang, tblCTHoaDon where tblCTHoaDon.sMaHD = N" + "'" + txtMaHD.Text + "'" +
                         " and tblMatHang.sMaMH = tblCTHoaDon.sMaMH ";
            connection.Open();
            SqlCommand com = new SqlCommand(sql, connection); //bat dau truy van
            com.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(com); //chuyen du lieu ve
            DataTable dt = new DataTable(); //tạo một kho ảo để lưu trữ dữ liệu
            da.Fill(dt);  // đổ dữ liệu vào kho
            connection.Close();  // đóng kết nối
            dataGridViewChiTietHD.DataSource = dt; //đổ dữ liệu vào datagridview
        }

        //Hiển thị thông tin chung lên hóa đơn
        private void hienThongTinHD()
        {
            string sql;
            sql = "SELECT dNgayLap FROM tblHoaDon WHERE sMaHD = N'" + txtMaHD.Text + "'";
            txtNgayLapHD.Text = GetFieldValues(sql);
            sql = "SELECT sMaNV FROM tblHoaDon WHERE sMaHD = N'" + comboBoxMaNV.SelectedValue + "'";
            comboBoxMaNV.Text = GetFieldValues(sql);
            sql = "SELECT sMaKH FROM tblHoaDon WHERE sMaHD = N'" + comboBoxMaKH.SelectedValue + "'";
            comboBoxMaKH.Text = GetFieldValues(sql);
            sql = "SELECT fTongTien FROM tblHoaDon WHERE sMaHD = N'" + txtMaHD.Text + "'";
            txtTongTien.Text = GetFieldValues(sql);
            labelTongTienChu.Text = "Tổng tiền bằng chữ: " + ChuyenSoSangChu(Convert.ToDouble(txtTongTien.Text));
        }
        //thường thì câu câu 1 hiển thị câu 2 tìm kiếm 3 crystal rp
        //Câu 1 ở Thông tin chung thay Mã KH bằng danh sách tên khách hàng
        //cấu 2 Sửa lại chức năng tìm kiếm theo tên Khách Hàng dạng tương đối
        // câu 3 Thêm cột thành tiền và lập hóa đơn theo năm

        //Insert phải thỏa mãn k có 2 nhân viên trùng chức vụ trong 1 phòng ban xem thầy cô có thế hỏi câu hỏi gì
        //cái gì cơ đưa btl mình xem mớ ok gửi file qua ha k team đi mình xem qua thoi bt963vam mình out tí nhé nhát bạn vào lại ok
        // Tìm kiếm theo mã hoặc gần đúng theo tên.
        // Report nhập phòng ban in ra danh sách nhân viên theo tham số truyền vào.
        private void btnThemHDMoi_Click(object sender, EventArgs e)
        {
            btnHuyHD.Enabled = false;
            btnXacNhanHD.Enabled = true;
            btnInHD.Enabled = false;
            ResetValuesHD();
            if (comboBoxMaNV.Text.Trim().Length == 0 || txtTenNV.Text.Trim().Length == 0)
                MessageBox.Show("Vui lòng nhập thông tin nhân viên để thêm hóa đơn mới");  
            else if (comboBoxMaKH.Text.Trim().Length == 0)
                MessageBox.Show("Vui lòng nhập mã khách hàng để thêm hóa đơn mới");
            else if (txtTenKH.Text == "")
                MessageBox.Show("Vui lòng nhập tên khách hàng để thêm hóa đơn mới");
            else if (txtDiaChi.Text.Trim().Length == 0)
                MessageBox.Show("Vui lòng nhập địa chỉ khách hàng để thêm hóa đơn mới");
            else if (txtDienThoai.Text.Trim().Length == 0)
                MessageBox.Show("Vui lòng nhập số điện thoại khách hàng để thêm hóa đơn mới");
            else if (txtDienThoai.Text.StartsWith("0") == false)
                MessageBox.Show("Số điện thoại bắt đầu bằng số 0 ");
            else if (txtDienThoai.Text.Length >= 11 || txtDienThoai.Text.Length < 10)
                MessageBox.Show("Số điện thoại không hợp lệ");
            else
            {
                //Thêm khách hàng vừa nhập tại form hoa don vào bảng
                //khách hàng nếu nút thêm khách hàng được ấn
                if (btnThemKH_clicked)
                {
                    string sql = "select sMaKH from tblKhachHang where sMaKH = " + "'" + comboBoxMaKH.Text + "'";
                    if (CheckKey(sql))
                    {
                        MessageBox.Show("Mã khách hàng bạn vừa thêm đã tồn tại, vui lòng nhập mã khác", "Thông báo");
                        comboBoxMaKH.SelectedIndex = -1;
                        comboBoxMaKH.Focus();
                    }
                    else
                    {
                        using (SqlConnection conn = new SqlConnection(connectionString))
                        {
                            using (SqlCommand cmd = conn.CreateCommand())
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.CommandText = "pr_themKhachHang";
                                cmd.Parameters.AddWithValue("@maKH", comboBoxMaKH.Text);
                                cmd.Parameters.AddWithValue("@tenKH", txtTenKH.Text);
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
                                conn.Close();
                            }
                        }
                        btnThemHDMoi.Enabled = false;
                        //Tạo mã hóa đơn tự động
                        txtMaHD.Text = CreateKey("HD");
                        //Lấy thời gian hiện tại là thời gian lập hóa đơn
                        txtNgayLapHD.Text = DateTime.Now.ToString();
                        //Thêm các thông tin chung vào bảng hóa đơn
                        using (SqlConnection conn = new SqlConnection(connectionString))
                        {
                            using (SqlCommand cmd = conn.CreateCommand())
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.CommandText = "pr_themHoaDon";
                                cmd.Parameters.AddWithValue("@maHD", txtMaHD.Text);
                                cmd.Parameters.AddWithValue("@ngayLap", txtNgayLapHD.Text);
                                cmd.Parameters.AddWithValue("@maNV", comboBoxMaNV.SelectedValue);
                                cmd.Parameters.AddWithValue("@maKH", comboBoxMaKH.Text);
                                cmd.Parameters.AddWithValue("@tongTien", txtTongTien.Text);
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
                    }    
                }
                else
                {
                    btnThemHDMoi.Enabled = false;
                    //Tạo mã hóa đơn tự động
                    txtMaHD.Text = CreateKey("HD");
                    //Lấy thời gian hiện tại là thời gian lập hóa đơn
                    txtNgayLapHD.Text = DateTime.Now.ToString();
                    //Thêm các thông tin chung vào bảng hóa đơn
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        using (SqlCommand cmd = conn.CreateCommand())
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = "pr_themHoaDon";
                            cmd.Parameters.AddWithValue("@maHD", txtMaHD.Text);
                            cmd.Parameters.AddWithValue("@ngayLap", txtNgayLapHD.Text);
                            cmd.Parameters.AddWithValue("@maNV", comboBoxMaNV.SelectedValue);
                            cmd.Parameters.AddWithValue("@maKH", comboBoxMaKH.SelectedValue);
                            cmd.Parameters.AddWithValue("@tongTien", txtTongTien.Text);
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
                }    
            }
            hienDanhSach();
        }

        //Lưu thông tin các mặt hàng vào bảng tblCTHoaDon
        private void btnThemMHVaoHD_Click(object sender, EventArgs e)
        {
            string sql;

            if (comboBoxMH.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mặt hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                comboBoxMH.Focus();
                return;
            }
            else if ((txtSlMH.Text.Trim().Length == 0) || (txtSlMH.Text == "0") || (txtSlMH.Text == "Nhập số lượng mặt hàng"))
            {
                MessageBox.Show("Bạn phải nhập số lượng mặt hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSlMH.Text = "";
                txtSlMH.Focus();
                return;
            }
            else if ((txtGiamGia.Text.Trim().Length == 0) || (txtGiamGia.Text == "Nhập giảm giá %"))
            {
                MessageBox.Show("Bạn phải nhập giảm giá", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtGiamGia.Focus();
                return;
            }
            else if (Convert.ToDouble(txtGiamGia.Text) < 0 || Convert.ToDouble(txtGiamGia.Text) > 100)
            {
                MessageBox.Show("Giảm giá lớn hơn hoặc bằng 0 và nhỏ hơn hoặc bằng 100", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtGiamGia.Focus();
                return;
            }
            else
            {
                //Lấy ra mã mặt hàng qua tên mặt hàng trên comboBoxMH
                string maMH;
                sql = "Select sMaMH from tblMatHang where sTenMH = N'" + comboBoxMH.SelectedValue + "'";
                maMH = GetFieldValues(sql);

                //Kiểm tra mã mặt hàng đã có trong datagridview các mặt hàng (CTHoaDon) chưa
                sql = "SELECT sMaMH FROM tblCTHoaDon WHERE sMaMH = N'" + maMH + "' AND sMaHD = N'" + txtMaHD.Text.Trim() + "'";
                if (CheckKey(sql))
                {
                    MessageBox.Show("Mặt hàng này đã có trong hóa đơn, bạn phải nhập mặt hàng khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ResetValuesMatHang();
                    comboBoxMH.Focus();
                    return;
                }

                // Kiểm tra xem số lượng hàng trong kho còn đủ để cung cấp không?
                int sl = Convert.ToInt32(GetFieldValues("SELECT iSoLuong FROM tblMatHang WHERE sTenMH = N'" + comboBoxMH.SelectedValue + "'"));
                if (Convert.ToInt32(txtSlMH.Text) > sl)
                {
                    MessageBox.Show("Không đủ mặt hàng để bán, số lượng mặt hàng này chỉ còn " + sl, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtSlMH.Text = "";
                    txtSlMH.Focus();
                    return;
                }

                //Lấy ra giá tiền mặt hàng qua tên hoặc mã mặt hàng để tính thành tiền
                sql = "select fGiaTien from tblMatHang where sTenMH = N" + "'" + comboBoxMH.SelectedValue + "'";
                double giaTien = Convert.ToDouble(GetFieldValues(sql));

                //Thành tiền 
                double thanhTien = (giaTien - (giaTien * Convert.ToDouble(txtGiamGia.Text) / 100)) * Convert.ToDouble(txtSlMH.Text);

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "pr_themCTHoaDon";
                        cmd.Parameters.AddWithValue("@maHD", txtMaHD.Text);
                        cmd.Parameters.AddWithValue("@maMH", maMH);
                        cmd.Parameters.AddWithValue("@SLMH", txtSlMH.Text);
                        cmd.Parameters.AddWithValue("@giamGia", txtGiamGia.Text);
                        cmd.Parameters.AddWithValue("@thanhTien", thanhTien);
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
                        hienDanhSach();
                        conn.Close();
                        //Lấy ra tổng tiền hóa đơn từ tblHoaDon
                        sql = "select fTongTien from tblHoaDon where sMaHD = N'" + txtMaHD.Text + "'";
                        double tongTien = Convert.ToDouble(GetFieldValues(sql));
                        txtTongTien.Text = Convert.ToString(tongTien);
                        labelTongTienChu.Text = "Tổng tiền bằng chữ: " + ChuyenSoSangChu(tongTien);
                    }
                }
            ResetValuesMatHang();
            }

        }

        private void txtGiamGia_Enter(object sender, EventArgs e)
        {
            if (txtGiamGia.Text == "Nhập giảm giá %")
            {
                txtGiamGia.Text = "";
                txtGiamGia.ForeColor = Color.Black;
            }
        }

        private void txtGiamGia_Leave(object sender, EventArgs e)
        {
            if (txtGiamGia.Text == "")
            {
                txtGiamGia.Text = "Nhập giảm giá %";
                txtGiamGia.ForeColor = Color.LightSlateGray;
            }
        }

        private void FormHoaDon_Load(object sender, EventArgs e)
        {
            string sql;
            txtTongTien.Text = "0";
            //Đổ mã nhân viên từ cơ sở dữ liệu vào comboBox
            sql = "SELECT sMaNV, sTenNV from tblNhanVien";
            fillComboBox(sql, comboBoxMaNV, "sMaNV", "sMaNV");
            comboBoxMaNV.SelectedIndex = -1;
            //Đổ mã khách hàng từ cơ sở dữ liệu vào comboBox
            sql = "SELECT sMaKH, sTenKH from tblKhachHang";
            fillComboBox(sql, comboBoxMaKH, "sMaKH", "sMaKH");
            comboBoxMaKH.SelectedIndex = -1;
            //Đổ tên mặt hàng từ cơ sở dữ liệu vào comboBox
            sql = "SELECT sMaMH, sTenMH from tblMatHang";
            fillComboBox(sql, comboBoxMH, "sTenMH", "sTenMH");
            comboBoxMH.SelectedIndex = -1;

            //Hiển thị thông tin của một hóa đơn được gọi từ form tìm kiếm
            /*if (txtMaHD.Text != "")
            {
                LoadInfoHoaDon();//tìm kiếm và hiển thị hóa đơn(tblHoaDon) theo ngày
                btnXoa.Enabled = true;
                btnInHoaDon.Enabled = true;
            }*/
            hienDanhSach();
        }

        private void dataGridViewChiTietHD_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                dataGridViewChiTietHD.Rows[e.RowIndex].Selected = true;
                contextMenuStripMatHang.Show(dataGridViewChiTietHD, e.Location);
                contextMenuStripMatHang.Show(Cursor.Position);
            }
        }

        private void xóaMặtHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string maMHXoa = (string)dataGridViewChiTietHD.CurrentRow.Cells["sMaMH"].Value;
            if (MessageBox.Show(string.Format("Bạn có muốn xóa mặt hàng có mã : {0} ?", maMHXoa), "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("DELETE FROM tblCTHoaDon WHERE sMaHD = " + "'" + txtMaHD.Text + "'" +
                        " and sMaMH = " + "'" + maMHXoa + "'", con))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@sMaMH", maMHXoa);
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                    con.Close();
                    string sql = "select fTongTien from tblHoaDon where sMaHD = N'" + txtMaHD.Text + "'";
                    double tongTien = Convert.ToDouble(GetFieldValues(sql));
                    txtTongTien.Text = Convert.ToString(tongTien);
                    labelTongTienChu.Text = "Tổng tiền bằng chữ: " + ChuyenSoSangChu(tongTien);
                }
            }
            hienDanhSach();
        }

        private void btnHuyHD_Click(object sender, EventArgs e)
        {
            if(txtMaHD.Text.Length == 0)
            {
                MessageBox.Show("Không có hóa đơn để xóa");
            }
            else
            {
                if(MessageBox.Show("Bạn có muốn xóa hóa đơn này ?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "pr_xoaHD_CTHD";
                        cmd.Parameters.AddWithValue("@maHD", txtMaHD.Text);
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
                ResetValuesHD();
                ResetValuesMatHang();
                hienDanhSach();
                btnHuyHD.Enabled = false;
                btnInHD.Enabled = false;
            }
        }

        private void comboBoxMaNV_TextChanged(object sender, EventArgs e)
        {
            string sql;
            if (comboBoxMaNV.Text == "")
                txtTenNV.Text = "";
            // Khi chọn mã nhân viên thì tên nhân viên tự động hiện ra
            sql = "Select sTenNV from tblNhanVien where sMaNV = N'" + comboBoxMaNV.SelectedValue + "'";
            txtTenNV.Text = GetFieldValues(sql);
        }

        private void comboBoxMaKH_TextChanged(object sender, EventArgs e)
        {
            string sql;
            if (comboBoxMaKH.Text == "")
            {
                txtTenKH.Text = "";
                txtDiaChi.Text = "";
                txtDienThoai.Text = "";
            }
            // Khi chọn mã khách hàng thì tên khách hàng tự động hiện ra
            sql = "Select sTenKH from tblKhachHang where sMaKH = N'" + comboBoxMaKH.SelectedValue + "'";
            txtTenKH.Text = GetFieldValues(sql);
            // Khi chọn mã khách hàng thì địa chỉ khách hàng tự động hiện ra
            sql = "Select sDiaChi from tblKhachHang where sMaKH = N'" + comboBoxMaKH.SelectedValue + "'";
            txtDiaChi.Text = GetFieldValues(sql);
            // Khi chọn mã khách hàng thì sô điện thoại khách hàng tự động hiện ra
            sql = "Select sSDT from tblKhachHang where sMaKH = N'" + comboBoxMaKH.SelectedValue + "'";
            txtDienThoai.Text = GetFieldValues(sql);
        }

        private void txtSlMH_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else e.Handled = true;
        }

        private void txtGiamGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Xác thực rằng phím vừa nhấn không phải CTRL hoặc không phải dạng số
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // Nếu bạn muốn, bạn có thể cho phép nhập số thực với dấu chấm
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void btnThemKH_Click(object sender, EventArgs e)
        {
            btnThemKH_clicked = true;
            comboBoxMaKH.DropDownStyle = ComboBoxStyle.DropDown;
            comboBoxMaKH.SelectedIndex = -1;
            txtTenKH.ReadOnly = false;
            txtDiaChi.ReadOnly = false;
            txtDienThoai.ReadOnly = false;
            
        }

        private void btnXacNhanHD_Click(object sender, EventArgs e)
        {
            if (comboBoxMaNV.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải nhập thông nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                comboBoxMaNV.Focus();
                return;
            }
            else if (comboBoxMaKH.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải nhập thông tin khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                comboBoxMaKH.Focus();
                return;
            }
            else if (txtTongTien.Text.Trim().Length == 0 || txtTongTien.Text.Trim() == "0")
            {
                MessageBox.Show("Chưa có mặt hàng nào được thêm vào hóa đơn ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                btnHuyHD.Enabled = true;
                btnXacNhanHD.Enabled = false;
                btnInHD.Enabled = true;
                btnThemHDMoi.Enabled = true;
                MessageBox.Show("Hóa đơn bán hàng đã được lưu ", "Thông báo");
            }
        }

        private void txtDienThoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else e.Handled = true;
        }

        private void btnInHD_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuInHD.Show(btnInHD, e.Location);
                contextMenuInHD.Show(Cursor.Position);
            }
        }

        private void inHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Khởi động chương trình Excel
            COMExcel .Application exApp = new COMExcel.Application();
            COMExcel.Workbook exBook; //Trong 1 chương trình Excel có nhiều Workbook
            COMExcel.Worksheet exSheet; //Trong 1 Workbook có nhiều Worksheet
            COMExcel.Range exRange;
            string sql;
            int hang = 0, cot = 0;
            DataTable tblThongtinHD, tblThongtinHang;
            exBook = exApp.Workbooks.Add(COMExcel.XlWBATemplate.xlWBATWorksheet);
            exSheet = exBook.Worksheets[1];
            // Định dạng chung
            exRange = exSheet.Cells[1, 1];
            exRange.Range["A1:Z300"].Font.Name = "Times new roman"; //Font chữ
            exRange.Range["A1:B3"].Font.Size = 10;
            exRange.Range["A1:B3"].Font.Bold = true;
            exRange.Range["A1:B3"].Font.ColorIndex = 5; //Màu xanh da trời
            exRange.Range["A1:A1"].ColumnWidth = 7;
            exRange.Range["B1:B1"].ColumnWidth = 15;
            exRange.Range["A1:B1"].MergeCells = true;
            exRange.Range["A1:B1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A1:B1"].Value = "Shop Thú Cưng";
            exRange.Range["A2:B2"].MergeCells = true;
            exRange.Range["A2:B2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A2:B2"].Value = "Thường Tín - Hà Nội";
            exRange.Range["A3:B3"].MergeCells = true;
            exRange.Range["A3:B3"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A3:B3"].Value = "Điện thoại: 0902212345";
            exRange.Range["C2:E2"].Font.Size = 16;
            exRange.Range["C2:E2"].Font.Bold = true;
            exRange.Range["C2:E2"].Font.ColorIndex = 3; //Màu đỏ
            exRange.Range["C2:E2"].MergeCells = true;
            exRange.Range["C2:E2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C2:E2"].Value = "HÓA ĐƠN BÁN HÀNG";

            // Biểu diễn thông tin chung của hóa đơn bán
            SqlConnection connection = new SqlConnection(connectionString);
            sql = "SELECT HD.sMaHD, HD.dNgayLap, HD.fTongTien, KH.sTenKH, KH.sDiaCHi,KH.sSDT, NV.sTenNV " +
                  "FROM tblKhachHang as KH, tblHoaDon as HD, tblNhanVien as NV " +
                  "where HD.sMaHD = N" + "'" + txtMaHD.Text + "'" + "and HD.sMaNV = NV.sMANV and HD.sMaKH = KH.sMaKH ";
            connection.Open();
            SqlCommand com = new SqlCommand(sql, connection); //bat dau truy van
            com.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(com); //chuyen du lieu ve
            tblThongtinHD = new DataTable(); //tạo một kho ảo để lưu trữ dữ liệu
            da.Fill(tblThongtinHD);  // đổ dữ liệu vào kho
            connection.Close();  // đóng kết nối

            exRange.Range["B6:C9"].Font.Size = 12;
            exRange.Range["B5:B5"].Value = "Mã hóa đơn:";
            exRange.Range["C5:E5"].MergeCells = true;
            exRange.Range["C5:E5"].Value = tblThongtinHD.Rows[0][0].ToString();
            exRange.Range["B6:B6"].Value = "Thời gian lập:";
            exRange.Range["C6:E6"].MergeCells = true;
            exRange.Range["C6:E6"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
            exRange.Range["C6:E6"].Value = tblThongtinHD.Rows[0][1].ToString();
            exRange.Range["B7:B7"].Value = "Khách hàng:";
            exRange.Range["C7:E7"].MergeCells = true;
            exRange.Range["C7:E7"].Value = tblThongtinHD.Rows[0][3].ToString();
            exRange.Range["B8:B8"].Value = "Địa chỉ:";
            exRange.Range["C8:E8"].MergeCells = true;
            exRange.Range["C8:E8"].Value = tblThongtinHD.Rows[0][4].ToString();
            exRange.Range["B9:B9"].Value = "Điện thoại:";
            exRange.Range["C9:E9"].MergeCells = true;
            exRange.Range["C9:E9"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
            exRange.Range["C9:E9"].Value = tblThongtinHD.Rows[0][5].ToString();
            //Lấy thông tin các mặt hàng
            sql = "SELECT b.TenHang, a.SoLuong, b.DonGiaBan, a.GiamGia, a.ThanhTien " +
                  "FROM tblChiTietHDBan AS a , tblHang AS b WHERE a.MaHDBan = N'" +
                  txtMaHD.Text + "' AND a.MaHang = b.MaHang";

            sql = "SELECT MH.sTenMH, CTHD.fSLMH, MH.fGiaTien, CTHD.fGiamGia, CTHD.fThanhTien " +
                         " FROM tblMatHang as MH, tblCTHoaDon as CTHD " +
                         "where CTHD.sMaHD = N" + "'" + txtMaHD.Text + "'" + " and MH.sMaMH = CTHD.sMaMH ";
            connection.Open(); 
            SqlCommand com2 = new SqlCommand(sql, connection); //bat dau truy van
            com.CommandType = CommandType.Text;
            SqlDataAdapter da2 = new SqlDataAdapter(com2); //chuyen du lieu ve
            tblThongtinHang = new DataTable(); //tạo một kho ảo để lưu trữ dữ liệu
            da2.Fill(tblThongtinHang);  // đổ dữ liệu vào kho
            connection.Close();  // đóng kết nối

            //Tạo dòng tiêu đề bảng
            exRange.Range["A11:F11"].Font.Bold = true;
            exRange.Range["A11:F11"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C11:F11"].ColumnWidth = 12;
            exRange.Range["A11:A11"].Value = "STT";
            exRange.Range["B11:B11"].Value = "Tên hàng";
            exRange.Range["C11:C11"].Value = "Số lượng";
            exRange.Range["D11:D11"].Value = "Đơn giá";
            exRange.Range["E11:E11"].Value = "Giảm giá";
            exRange.Range["F11:F11"].Value = "Thành tiền";
            for (hang = 0; hang < tblThongtinHang.Rows.Count; hang++)
            {
                //Điền số thứ tự vào cột 1 từ dòng 12
                exSheet.Cells[1][hang + 12] = hang + 1;
                for (cot = 0; cot < tblThongtinHang.Columns.Count; cot++)
                //Điền thông tin hàng từ cột thứ 2, dòng 12
                {
                    exSheet.Cells[cot + 2][hang + 12] = tblThongtinHang.Rows[hang][cot].ToString();
                    if (cot == 3) exSheet.Cells[cot + 2][hang + 12] = tblThongtinHang.Rows[hang][cot].ToString() + "%";
                }
            }
            exRange = exSheet.Cells[cot][hang + 14];
            exRange.Font.Bold = true;
            exRange.Value2 = "Tổng tiền:";
            exRange = exSheet.Cells[cot + 1][hang + 14];
            exRange.Font.Bold = true;
            exRange.Value2 = tblThongtinHD.Rows[0][2].ToString();
            exRange = exSheet.Cells[1][hang + 15]; //Ô A1 
            exRange.Range["A1:F1"].MergeCells = true;
            exRange.Range["A1:F1"].Font.Bold = true;
            exRange.Range["A1:F1"].Font.Italic = true;
            exRange.Range["A1:F1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
            exRange.Range["A1:F1"].Value = "Tổng tiền bằng chữ: " + ChuyenSoSangChu(Convert.ToDouble(tblThongtinHD.Rows[0][2].ToString()));
            exRange = exSheet.Cells[4][hang + 17]; //Ô A1 
            exRange.Range["A1:C1"].MergeCells = true;
            exRange.Range["A1:C1"].Font.Italic = true;
            exRange.Range["A1:C1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            DateTime d = Convert.ToDateTime(tblThongtinHD.Rows[0][1]);
            exRange.Range["A1:C1"].Value = "Hà Nội, ngày " + d.Day + " tháng " + d.Month + " năm " + d.Year;
            exRange.Range["A2:C2"].MergeCells = true;
            exRange.Range["A2:C2"].Font.Italic = true;
            exRange.Range["A2:C2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A2:C2"].Value = "Nhân viên bán hàng";
            exRange.Range["A5:C5"].MergeCells = true;
            exRange.Range["A5:C5"].Font.Italic = true;
            exRange.Range["A5:C5"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A5:C5"].Value = tblThongtinHD.Rows[0][6];
            exApp.Visible = true;
        }

        private void btnInHD_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand com = connection.CreateCommand(); //bat dau truy van
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "pr_HoaDonBanHang";
            com.Parameters.Clear();
            com.Parameters.AddWithValue("@maHD", txtMaHD.Text);
            SqlDataAdapter da = new SqlDataAdapter(com); //chuyen du lieu ve
            DataTable dt = new DataTable(); //tạo một kho ảo để lưu trữ dữ liệu
            da.SelectCommand = com;
            da.Fill(dt);  // đổ dữ liệu vào kho

            CrystalReportHoaDonBan crystalReportHoaDonBan = new CrystalReportHoaDonBan();
            crystalReportHoaDonBan.SetDataSource(dt);
            TextObject tongTienBangChuInHD = (TextObject)crystalReportHoaDonBan.Section4.ReportObjects["otxtTongTienChu"];
            double tongTien = Convert.ToDouble(dt.Rows[0]["fTongTien"]);
            tongTienBangChuInHD.Text = ChuyenSoSangChu(tongTien);

            FormBaoCaoHoaDonBan formBaoCaoHoaDonBan = new FormBaoCaoHoaDonBan();
            formBaoCaoHoaDonBan.crystalReportViewerHD.ReportSource = crystalReportHoaDonBan;
            formBaoCaoHoaDonBan.ShowDialog();

            connection.Close();  // đóng kết nối
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát không ? ", "Xác nhận ", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Hide();
                FormTrangChu formTrangChu = new FormTrangChu();
                formTrangChu.ShowDialog();
                this.Close();
            }
        }
    }
}
