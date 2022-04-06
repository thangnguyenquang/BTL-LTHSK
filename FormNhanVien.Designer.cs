namespace demo
{
    partial class FormNhanVien
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMaNV = new System.Windows.Forms.TextBox();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.txtDienThoai = new System.Windows.Forms.TextBox();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.txtNgaySinh = new System.Windows.Forms.DateTimePicker();
            this.rbtnNam = new System.Windows.Forms.RadioButton();
            this.rbtnNu = new System.Windows.Forms.RadioButton();
            this.dataGridViewNhanVien = new System.Windows.Forms.DataGridView();
            this.sMaNV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sTenNV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sGioiTinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sDiaChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dNgaySinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sSDT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.errorProviderNhanVien = new System.Windows.Forms.ErrorProvider(this.components);
            this.contextMenuStripNV = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.xóaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sửaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStripTimKiem = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mãNhânViênToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tênNhânViênToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.điệnThoạiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewNhanVien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderNhanVien)).BeginInit();
            this.contextMenuStripNV.SuspendLayout();
            this.contextMenuStripTimKiem.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(44, 53);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã nhân viên";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(44, 112);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Họ tên";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(682, 172);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Giới tính";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(682, 52);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Ngày sinh";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(44, 173);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Địa chỉ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(682, 108);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 20);
            this.label6.TabIndex = 5;
            this.label6.Text = "Điện thoại";
            // 
            // txtMaNV
            // 
            this.txtMaNV.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaNV.Location = new System.Drawing.Point(164, 49);
            this.txtMaNV.Margin = new System.Windows.Forms.Padding(4);
            this.txtMaNV.Name = "txtMaNV";
            this.txtMaNV.Size = new System.Drawing.Size(203, 27);
            this.txtMaNV.TabIndex = 6;
            this.txtMaNV.Validating += new System.ComponentModel.CancelEventHandler(this.txtMaNV_Validating);
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiaChi.Location = new System.Drawing.Point(164, 169);
            this.txtDiaChi.Margin = new System.Windows.Forms.Padding(4);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(480, 27);
            this.txtDiaChi.TabIndex = 7;
            // 
            // txtDienThoai
            // 
            this.txtDienThoai.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDienThoai.Location = new System.Drawing.Point(783, 112);
            this.txtDienThoai.Margin = new System.Windows.Forms.Padding(4);
            this.txtDienThoai.Name = "txtDienThoai";
            this.txtDienThoai.Size = new System.Drawing.Size(228, 27);
            this.txtDienThoai.TabIndex = 8;
            this.txtDienThoai.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDienThoai_KeyPress);
            this.txtDienThoai.Validating += new System.ComponentModel.CancelEventHandler(this.txtDienThoai_Validating);
            // 
            // txtHoTen
            // 
            this.txtHoTen.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHoTen.Location = new System.Drawing.Point(164, 108);
            this.txtHoTen.Margin = new System.Windows.Forms.Padding(4);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(332, 27);
            this.txtHoTen.TabIndex = 9;
            // 
            // txtNgaySinh
            // 
            this.txtNgaySinh.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNgaySinh.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtNgaySinh.Location = new System.Drawing.Point(783, 53);
            this.txtNgaySinh.Margin = new System.Windows.Forms.Padding(4);
            this.txtNgaySinh.Name = "txtNgaySinh";
            this.txtNgaySinh.Size = new System.Drawing.Size(228, 27);
            this.txtNgaySinh.TabIndex = 10;
            this.txtNgaySinh.Value = new System.DateTime(2022, 3, 9, 16, 44, 50, 0);
            this.txtNgaySinh.Validating += new System.ComponentModel.CancelEventHandler(this.txtNgaySinh_Validating);
            // 
            // rbtnNam
            // 
            this.rbtnNam.AutoSize = true;
            this.rbtnNam.Checked = true;
            this.rbtnNam.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnNam.Location = new System.Drawing.Point(791, 174);
            this.rbtnNam.Margin = new System.Windows.Forms.Padding(4);
            this.rbtnNam.Name = "rbtnNam";
            this.rbtnNam.Size = new System.Drawing.Size(65, 24);
            this.rbtnNam.TabIndex = 11;
            this.rbtnNam.TabStop = true;
            this.rbtnNam.Text = "Nam";
            this.rbtnNam.UseVisualStyleBackColor = true;
            // 
            // rbtnNu
            // 
            this.rbtnNu.AutoSize = true;
            this.rbtnNu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnNu.Location = new System.Drawing.Point(911, 174);
            this.rbtnNu.Margin = new System.Windows.Forms.Padding(4);
            this.rbtnNu.Name = "rbtnNu";
            this.rbtnNu.Size = new System.Drawing.Size(51, 24);
            this.rbtnNu.TabIndex = 12;
            this.rbtnNu.Text = "Nữ";
            this.rbtnNu.UseVisualStyleBackColor = true;
            // 
            // dataGridViewNhanVien
            // 
            this.dataGridViewNhanVien.AllowUserToOrderColumns = true;
            this.dataGridViewNhanVien.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewNhanVien.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridViewNhanVien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewNhanVien.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.sMaNV,
            this.sTenNV,
            this.sGioiTinh,
            this.sDiaChi,
            this.dNgaySinh,
            this.sSDT});
            this.dataGridViewNhanVien.Location = new System.Drawing.Point(0, 333);
            this.dataGridViewNhanVien.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridViewNhanVien.Name = "dataGridViewNhanVien";
            this.dataGridViewNhanVien.ReadOnly = true;
            this.dataGridViewNhanVien.RowHeadersWidth = 51;
            this.dataGridViewNhanVien.RowTemplate.Height = 24;
            this.dataGridViewNhanVien.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewNhanVien.Size = new System.Drawing.Size(1090, 332);
            this.dataGridViewNhanVien.TabIndex = 13;
            this.dataGridViewNhanVien.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewNhanVien_CellClick);
            this.dataGridViewNhanVien.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewNhanVien_CellMouseUp);
            // 
            // sMaNV
            // 
            this.sMaNV.DataPropertyName = "sMaNV";
            this.sMaNV.HeaderText = "Mã nhân viên";
            this.sMaNV.MinimumWidth = 6;
            this.sMaNV.Name = "sMaNV";
            this.sMaNV.ReadOnly = true;
            // 
            // sTenNV
            // 
            this.sTenNV.DataPropertyName = "sTenNV";
            this.sTenNV.HeaderText = "Tên nhân viên";
            this.sTenNV.MinimumWidth = 6;
            this.sTenNV.Name = "sTenNV";
            this.sTenNV.ReadOnly = true;
            // 
            // sGioiTinh
            // 
            this.sGioiTinh.DataPropertyName = "sGioiTinh";
            this.sGioiTinh.HeaderText = "Giới tính";
            this.sGioiTinh.MinimumWidth = 6;
            this.sGioiTinh.Name = "sGioiTinh";
            this.sGioiTinh.ReadOnly = true;
            // 
            // sDiaChi
            // 
            this.sDiaChi.DataPropertyName = "sDiaChi";
            this.sDiaChi.HeaderText = "Địa chỉ";
            this.sDiaChi.MinimumWidth = 6;
            this.sDiaChi.Name = "sDiaChi";
            this.sDiaChi.ReadOnly = true;
            // 
            // dNgaySinh
            // 
            this.dNgaySinh.DataPropertyName = "dNgaySinh";
            this.dNgaySinh.HeaderText = "Ngày sinh";
            this.dNgaySinh.MinimumWidth = 6;
            this.dNgaySinh.Name = "dNgaySinh";
            this.dNgaySinh.ReadOnly = true;
            // 
            // sSDT
            // 
            this.sSDT.DataPropertyName = "sSDT";
            this.sSDT.HeaderText = "Số điện thoại";
            this.sSDT.MinimumWidth = 6;
            this.sSDT.Name = "sSDT";
            this.sSDT.ReadOnly = true;
            // 
            // btnThem
            // 
            this.btnThem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.Location = new System.Drawing.Point(98, 245);
            this.btnThem.Margin = new System.Windows.Forms.Padding(4);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(135, 40);
            this.btnThem.TabIndex = 14;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.Location = new System.Drawing.Point(275, 245);
            this.btnSua.Margin = new System.Windows.Forms.Padding(4);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(135, 40);
            this.btnSua.TabIndex = 15;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.Location = new System.Drawing.Point(461, 245);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(4);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(135, 40);
            this.btnXoa.TabIndex = 16;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.Location = new System.Drawing.Point(13, 206);
            this.btnThoat.Margin = new System.Windows.Forms.Padding(4);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(135, 40);
            this.btnThoat.TabIndex = 17;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimKiem.Location = new System.Drawing.Point(618, 245);
            this.btnTimKiem.Margin = new System.Windows.Forms.Padding(4);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(135, 40);
            this.btnTimKiem.TabIndex = 18;
            this.btnTimKiem.Text = "Tìm Kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // errorProviderNhanVien
            // 
            this.errorProviderNhanVien.ContainerControl = this;
            // 
            // contextMenuStripNV
            // 
            this.contextMenuStripNV.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStripNV.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xóaToolStripMenuItem,
            this.sửaToolStripMenuItem});
            this.contextMenuStripNV.Name = "contextMenuStripNV";
            this.contextMenuStripNV.Size = new System.Drawing.Size(105, 52);
            // 
            // xóaToolStripMenuItem
            // 
            this.xóaToolStripMenuItem.Name = "xóaToolStripMenuItem";
            this.xóaToolStripMenuItem.Size = new System.Drawing.Size(104, 24);
            this.xóaToolStripMenuItem.Text = "Xóa";
            this.xóaToolStripMenuItem.Click += new System.EventHandler(this.xóaToolStripMenuItem_Click);
            // 
            // sửaToolStripMenuItem
            // 
            this.sửaToolStripMenuItem.Name = "sửaToolStripMenuItem";
            this.sửaToolStripMenuItem.Size = new System.Drawing.Size(104, 24);
            this.sửaToolStripMenuItem.Text = "Sửa";
            // 
            // contextMenuStripTimKiem
            // 
            this.contextMenuStripTimKiem.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStripTimKiem.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mãNhânViênToolStripMenuItem,
            this.tênNhânViênToolStripMenuItem,
            this.điệnThoạiToolStripMenuItem});
            this.contextMenuStripTimKiem.Name = "contextMenuStripTimKiem";
            this.contextMenuStripTimKiem.Size = new System.Drawing.Size(174, 76);
            // 
            // mãNhânViênToolStripMenuItem
            // 
            this.mãNhânViênToolStripMenuItem.Name = "mãNhânViênToolStripMenuItem";
            this.mãNhânViênToolStripMenuItem.Size = new System.Drawing.Size(173, 24);
            this.mãNhânViênToolStripMenuItem.Text = "Mã Nhân Viên";
            // 
            // tênNhânViênToolStripMenuItem
            // 
            this.tênNhânViênToolStripMenuItem.Name = "tênNhânViênToolStripMenuItem";
            this.tênNhânViênToolStripMenuItem.Size = new System.Drawing.Size(173, 24);
            this.tênNhânViênToolStripMenuItem.Text = "Tên Nhân Viên";
            // 
            // điệnThoạiToolStripMenuItem
            // 
            this.điệnThoạiToolStripMenuItem.Name = "điệnThoạiToolStripMenuItem";
            this.điệnThoạiToolStripMenuItem.Size = new System.Drawing.Size(173, 24);
            this.điệnThoạiToolStripMenuItem.Text = "Điện Thoại";
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(792, 252);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(268, 27);
            this.txtTimKiem.TabIndex = 19;
            // 
            // FormNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1091, 665);
            this.Controls.Add(this.txtTimKiem);
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.dataGridViewNhanVien);
            this.Controls.Add(this.rbtnNu);
            this.Controls.Add(this.rbtnNam);
            this.Controls.Add(this.txtNgaySinh);
            this.Controls.Add(this.txtHoTen);
            this.Controls.Add(this.txtDienThoai);
            this.Controls.Add(this.txtDiaChi);
            this.Controls.Add(this.txtMaNV);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormNhanVien";
            this.Text = "Nhân Viên";
            this.Load += new System.EventHandler(this.FormNhanVien_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewNhanVien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderNhanVien)).EndInit();
            this.contextMenuStripNV.ResumeLayout(false);
            this.contextMenuStripTimKiem.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtMaNV;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.TextBox txtDienThoai;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.DateTimePicker txtNgaySinh;
        private System.Windows.Forms.RadioButton rbtnNam;
        private System.Windows.Forms.RadioButton rbtnNu;
        private System.Windows.Forms.DataGridView dataGridViewNhanVien;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.ErrorProvider errorProviderNhanVien;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripNV;
        private System.Windows.Forms.ToolStripMenuItem xóaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sửaToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn sMaNV;
        private System.Windows.Forms.DataGridViewTextBoxColumn sTenNV;
        private System.Windows.Forms.DataGridViewTextBoxColumn sGioiTinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn sDiaChi;
        private System.Windows.Forms.DataGridViewTextBoxColumn dNgaySinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn sSDT;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripTimKiem;
        private System.Windows.Forms.ToolStripMenuItem mãNhânViênToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tênNhânViênToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem điệnThoạiToolStripMenuItem;
        private System.Windows.Forms.TextBox txtTimKiem;
    }
}