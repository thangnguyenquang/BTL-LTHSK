namespace demo
{
    partial class FormMatHang
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
            this.txtMaMH = new System.Windows.Forms.TextBox();
            this.txtTenMH = new System.Windows.Forms.TextBox();
            this.txtSL = new System.Windows.Forms.TextBox();
            this.txtGiaTien = new System.Windows.Forms.TextBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.dataGridViewMatHang = new System.Windows.Forms.DataGridView();
            this.sMaMH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sTenMH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sTenLH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iSoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fGiaTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.errorProviderThuCung = new System.Windows.Forms.ErrorProvider(this.components);
            this.comboBoxLoaiHang = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMaLH = new System.Windows.Forms.TextBox();
            this.btnThemLH = new System.Windows.Forms.Button();
            this.toolTipThemLHMoi = new System.Windows.Forms.ToolTip(this.components);
            this.txttimkiem = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMatHang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderThuCung)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(43, 35);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã mặt hàng";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(43, 96);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tên mặt hàng";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(605, 35);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Số lượng";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(605, 96);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Giá tiền";
            // 
            // txtMaMH
            // 
            this.txtMaMH.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaMH.Location = new System.Drawing.Point(176, 31);
            this.txtMaMH.Margin = new System.Windows.Forms.Padding(4);
            this.txtMaMH.Name = "txtMaMH";
            this.txtMaMH.Size = new System.Drawing.Size(202, 27);
            this.txtMaMH.TabIndex = 4;
            this.txtMaMH.Validating += new System.ComponentModel.CancelEventHandler(this.txtMaTC_Validating);
            // 
            // txtTenMH
            // 
            this.txtTenMH.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenMH.Location = new System.Drawing.Point(176, 92);
            this.txtTenMH.Margin = new System.Windows.Forms.Padding(4);
            this.txtTenMH.Name = "txtTenMH";
            this.txtTenMH.Size = new System.Drawing.Size(356, 27);
            this.txtTenMH.TabIndex = 5;
            // 
            // txtSL
            // 
            this.txtSL.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSL.Location = new System.Drawing.Point(715, 31);
            this.txtSL.Margin = new System.Windows.Forms.Padding(4);
            this.txtSL.Name = "txtSL";
            this.txtSL.Size = new System.Drawing.Size(185, 27);
            this.txtSL.TabIndex = 6;
            this.txtSL.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSL_KeyPress);
            // 
            // txtGiaTien
            // 
            this.txtGiaTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGiaTien.Location = new System.Drawing.Point(715, 92);
            this.txtGiaTien.Margin = new System.Windows.Forms.Padding(4);
            this.txtGiaTien.Name = "txtGiaTien";
            this.txtGiaTien.Size = new System.Drawing.Size(282, 27);
            this.txtGiaTien.TabIndex = 7;
            this.txtGiaTien.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtGiaTien_KeyPress);
            // 
            // btnThem
            // 
            this.btnThem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.Location = new System.Drawing.Point(111, 230);
            this.btnThem.Margin = new System.Windows.Forms.Padding(4);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(135, 40);
            this.btnThem.TabIndex = 8;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.Location = new System.Drawing.Point(286, 230);
            this.btnSua.Margin = new System.Windows.Forms.Padding(4);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(135, 40);
            this.btnSua.TabIndex = 9;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.Location = new System.Drawing.Point(438, 230);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(4);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(135, 40);
            this.btnXoa.TabIndex = 10;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimKiem.Location = new System.Drawing.Point(599, 230);
            this.btnTimKiem.Margin = new System.Windows.Forms.Padding(4);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(135, 40);
            this.btnTimKiem.TabIndex = 11;
            this.btnTimKiem.Text = "Tìm Kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.Location = new System.Drawing.Point(-17, 196);
            this.btnThoat.Margin = new System.Windows.Forms.Padding(4);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(135, 40);
            this.btnThoat.TabIndex = 12;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // dataGridViewMatHang
            // 
            this.dataGridViewMatHang.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewMatHang.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridViewMatHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMatHang.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.sMaMH,
            this.sTenMH,
            this.sTenLH,
            this.iSoLuong,
            this.fGiaTien});
            this.dataGridViewMatHang.Location = new System.Drawing.Point(-1, 314);
            this.dataGridViewMatHang.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridViewMatHang.Name = "dataGridViewMatHang";
            this.dataGridViewMatHang.ReadOnly = true;
            this.dataGridViewMatHang.RowHeadersWidth = 51;
            this.dataGridViewMatHang.RowTemplate.Height = 24;
            this.dataGridViewMatHang.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewMatHang.Size = new System.Drawing.Size(1041, 397);
            this.dataGridViewMatHang.TabIndex = 13;
            this.dataGridViewMatHang.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewThuCung_CellClick);
            // 
            // sMaMH
            // 
            this.sMaMH.DataPropertyName = "sMaMH";
            this.sMaMH.HeaderText = "Mã mặt hàng";
            this.sMaMH.MinimumWidth = 6;
            this.sMaMH.Name = "sMaMH";
            this.sMaMH.ReadOnly = true;
            // 
            // sTenMH
            // 
            this.sTenMH.DataPropertyName = "sTenMH";
            this.sTenMH.HeaderText = "Tên mặt hàng";
            this.sTenMH.MinimumWidth = 6;
            this.sTenMH.Name = "sTenMH";
            this.sTenMH.ReadOnly = true;
            // 
            // sTenLH
            // 
            this.sTenLH.DataPropertyName = "sTenLH";
            this.sTenLH.HeaderText = "Tên loại hàng";
            this.sTenLH.MinimumWidth = 6;
            this.sTenLH.Name = "sTenLH";
            this.sTenLH.ReadOnly = true;
            // 
            // iSoLuong
            // 
            this.iSoLuong.DataPropertyName = "iSoLuong";
            this.iSoLuong.HeaderText = "Số lượng";
            this.iSoLuong.MinimumWidth = 6;
            this.iSoLuong.Name = "iSoLuong";
            this.iSoLuong.ReadOnly = true;
            // 
            // fGiaTien
            // 
            this.fGiaTien.DataPropertyName = "fGiaTien";
            this.fGiaTien.HeaderText = "Giá tiền";
            this.fGiaTien.MinimumWidth = 6;
            this.fGiaTien.Name = "fGiaTien";
            this.fGiaTien.ReadOnly = true;
            // 
            // errorProviderThuCung
            // 
            this.errorProviderThuCung.ContainerControl = this;
            // 
            // comboBoxLoaiHang
            // 
            this.comboBoxLoaiHang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLoaiHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxLoaiHang.FormattingEnabled = true;
            this.comboBoxLoaiHang.Location = new System.Drawing.Point(176, 156);
            this.comboBoxLoaiHang.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxLoaiHang.Name = "comboBoxLoaiHang";
            this.comboBoxLoaiHang.Size = new System.Drawing.Size(356, 28);
            this.comboBoxLoaiHang.TabIndex = 14;
            this.comboBoxLoaiHang.TextChanged += new System.EventHandler(this.comboBoxLoaiHang_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(43, 159);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(115, 20);
            this.label5.TabIndex = 15;
            this.label5.Text = "Loại mặt hàng";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(605, 159);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 20);
            this.label6.TabIndex = 16;
            this.label6.Text = "Mã loại hàng";
            // 
            // txtMaLH
            // 
            this.txtMaLH.Location = new System.Drawing.Point(715, 156);
            this.txtMaLH.Margin = new System.Windows.Forms.Padding(4);
            this.txtMaLH.Name = "txtMaLH";
            this.txtMaLH.ReadOnly = true;
            this.txtMaLH.ShortcutsEnabled = false;
            this.txtMaLH.Size = new System.Drawing.Size(200, 27);
            this.txtMaLH.TabIndex = 17;
            // 
            // btnThemLH
            // 
            this.btnThemLH.Location = new System.Drawing.Point(938, 156);
            this.btnThemLH.Margin = new System.Windows.Forms.Padding(4);
            this.btnThemLH.Name = "btnThemLH";
            this.btnThemLH.Size = new System.Drawing.Size(59, 27);
            this.btnThemLH.TabIndex = 18;
            this.btnThemLH.Text = "...";
            this.toolTipThemLHMoi.SetToolTip(this.btnThemLH, "Ấn để nhập loại hàng mới");
            this.btnThemLH.UseVisualStyleBackColor = true;
            this.btnThemLH.Click += new System.EventHandler(this.btnThemLH_Click);
            // 
            // toolTipThemLHMoi
            // 
            this.toolTipThemLHMoi.AutoPopDelay = 5000;
            this.toolTipThemLHMoi.InitialDelay = 200;
            this.toolTipThemLHMoi.ReshowDelay = 100;
            // 
            // txttimkiem
            // 
            this.txttimkiem.Location = new System.Drawing.Point(761, 237);
            this.txttimkiem.Name = "txttimkiem";
            this.txttimkiem.Size = new System.Drawing.Size(187, 27);
            this.txttimkiem.TabIndex = 19;
            // 
            // FormMatHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1040, 711);
            this.Controls.Add(this.txttimkiem);
            this.Controls.Add(this.btnThemLH);
            this.Controls.Add(this.txtMaLH);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBoxLoaiHang);
            this.Controls.Add(this.dataGridViewMatHang);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.txtGiaTien);
            this.Controls.Add(this.txtSL);
            this.Controls.Add(this.txtTenMH);
            this.Controls.Add(this.txtMaMH);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormMatHang";
            this.Text = "Mặt hàng";
            this.Load += new System.EventHandler(this.FormMatHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMatHang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderThuCung)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMaMH;
        private System.Windows.Forms.TextBox txtTenMH;
        private System.Windows.Forms.TextBox txtSL;
        private System.Windows.Forms.TextBox txtGiaTien;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.DataGridView dataGridViewMatHang;
        private System.Windows.Forms.ErrorProvider errorProviderThuCung;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBoxLoaiHang;
        private System.Windows.Forms.Button btnThemLH;
        private System.Windows.Forms.TextBox txtMaLH;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridViewTextBoxColumn sMaMH;
        private System.Windows.Forms.DataGridViewTextBoxColumn sTenMH;
        private System.Windows.Forms.DataGridViewTextBoxColumn sTenLH;
        private System.Windows.Forms.DataGridViewTextBoxColumn iSoLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn fGiaTien;
        private System.Windows.Forms.ToolTip toolTipThemLHMoi;
        private System.Windows.Forms.TextBox txttimkiem;
    }
}