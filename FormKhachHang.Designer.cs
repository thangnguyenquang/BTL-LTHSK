namespace demo
{
    partial class FormKhachHang
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
            this.dataGridViewKhachHang = new System.Windows.Forms.DataGridView();
            this.sMaKH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sTenKH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sDiaChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sSDT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMaKH = new System.Windows.Forms.TextBox();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.errorProviderKH = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtDienThoai = new System.Windows.Forms.TextBox();
            this.contextMenuStripKH = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.xóaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnTimKiem = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewKhachHang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderKH)).BeginInit();
            this.contextMenuStripKH.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewKhachHang
            // 
            this.dataGridViewKhachHang.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewKhachHang.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridViewKhachHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewKhachHang.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.sMaKH,
            this.sTenKH,
            this.sDiaChi,
            this.sSDT});
            this.dataGridViewKhachHang.Location = new System.Drawing.Point(0, 236);
            this.dataGridViewKhachHang.Name = "dataGridViewKhachHang";
            this.dataGridViewKhachHang.ReadOnly = true;
            this.dataGridViewKhachHang.RowHeadersWidth = 60;
            this.dataGridViewKhachHang.RowTemplate.Height = 24;
            this.dataGridViewKhachHang.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewKhachHang.Size = new System.Drawing.Size(930, 405);
            this.dataGridViewKhachHang.TabIndex = 3;
            this.dataGridViewKhachHang.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewKhachHang_CellClick);
            this.dataGridViewKhachHang.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewKhachHang_CellMouseUp);
            // 
            // sMaKH
            // 
            this.sMaKH.DataPropertyName = "sMaKH";
            this.sMaKH.HeaderText = "Mã khách hàng";
            this.sMaKH.MinimumWidth = 6;
            this.sMaKH.Name = "sMaKH";
            this.sMaKH.ReadOnly = true;
            // 
            // sTenKH
            // 
            this.sTenKH.DataPropertyName = "sTenKH";
            this.sTenKH.HeaderText = "Họ tên";
            this.sTenKH.MinimumWidth = 6;
            this.sTenKH.Name = "sTenKH";
            this.sTenKH.ReadOnly = true;
            // 
            // sDiaChi
            // 
            this.sDiaChi.DataPropertyName = "sDiaChi";
            this.sDiaChi.HeaderText = "Địa chỉ";
            this.sDiaChi.MinimumWidth = 6;
            this.sDiaChi.Name = "sDiaChi";
            this.sDiaChi.ReadOnly = true;
            // 
            // sSDT
            // 
            this.sSDT.DataPropertyName = "sSDT";
            this.sSDT.HeaderText = "Điện thoại";
            this.sSDT.MinimumWidth = 6;
            this.sSDT.Name = "sSDT";
            this.sSDT.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label1.Location = new System.Drawing.Point(31, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Mã khách hàng";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label2.Location = new System.Drawing.Point(32, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 41);
            this.label2.TabIndex = 5;
            this.label2.Text = "Họ tên ";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label3.Location = new System.Drawing.Point(493, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 41);
            this.label3.TabIndex = 6;
            this.label3.Text = "Địa chỉ";
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.SystemColors.Control;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label4.Location = new System.Drawing.Point(493, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 41);
            this.label4.TabIndex = 7;
            this.label4.Text = "Điện thoại";
            // 
            // txtMaKH
            // 
            this.txtMaKH.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaKH.Location = new System.Drawing.Point(170, 52);
            this.txtMaKH.Name = "txtMaKH";
            this.txtMaKH.Size = new System.Drawing.Size(170, 27);
            this.txtMaKH.TabIndex = 11;
            this.txtMaKH.Validating += new System.ComponentModel.CancelEventHandler(this.txtMaKH_Validating);
            // 
            // txtHoTen
            // 
            this.txtHoTen.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHoTen.Location = new System.Drawing.Point(170, 100);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(288, 27);
            this.txtHoTen.TabIndex = 12;
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiaChi.Location = new System.Drawing.Point(586, 100);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(303, 27);
            this.txtDiaChi.TabIndex = 13;
            // 
            // btnThem
            // 
            this.btnThem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.Location = new System.Drawing.Point(75, 160);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(114, 32);
            this.btnThem.TabIndex = 15;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.Location = new System.Drawing.Point(223, 160);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(114, 32);
            this.btnSua.TabIndex = 16;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.Location = new System.Drawing.Point(366, 160);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(114, 32);
            this.btnXoa.TabIndex = 17;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.Location = new System.Drawing.Point(669, 160);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(114, 32);
            this.btnThoat.TabIndex = 18;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // errorProviderKH
            // 
            this.errorProviderKH.ContainerControl = this;
            // 
            // txtDienThoai
            // 
            this.txtDienThoai.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDienThoai.Location = new System.Drawing.Point(586, 51);
            this.txtDienThoai.Name = "txtDienThoai";
            this.txtDienThoai.Size = new System.Drawing.Size(174, 27);
            this.txtDienThoai.TabIndex = 14;
            this.txtDienThoai.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDienThoai_KeyPress_1);
            this.txtDienThoai.Validating += new System.ComponentModel.CancelEventHandler(this.txtDienThoai_Validating_1);
            // 
            // contextMenuStripKH
            // 
            this.contextMenuStripKH.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStripKH.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xóaToolStripMenuItem});
            this.contextMenuStripKH.Name = "contextMenuStripKH";
            this.contextMenuStripKH.Size = new System.Drawing.Size(109, 28);
            // 
            // xóaToolStripMenuItem
            // 
            this.xóaToolStripMenuItem.Name = "xóaToolStripMenuItem";
            this.xóaToolStripMenuItem.Size = new System.Drawing.Size(108, 24);
            this.xóaToolStripMenuItem.Text = "Xóa ";
            this.xóaToolStripMenuItem.Click += new System.EventHandler(this.xóaToolStripMenuItem_Click);
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimKiem.Location = new System.Drawing.Point(519, 160);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(114, 32);
            this.btnTimKiem.TabIndex = 21;
            this.btnTimKiem.Text = "Tìm Kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // FormKhachHang
            // 
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(930, 643);
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.txtDienThoai);
            this.Controls.Add(this.txtDiaChi);
            this.Controls.Add(this.txtHoTen);
            this.Controls.Add(this.txtMaKH);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridViewKhachHang);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.InfoText;
            this.Name = "FormKhachHang";
            this.Text = "Khách Hàng";
            this.Load += new System.EventHandler(this.Form3_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewKhachHang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderKH)).EndInit();
            this.contextMenuStripKH.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewKhachHang;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMaKH;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.ErrorProvider errorProviderKH;
        private System.Windows.Forms.TextBox txtDienThoai;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripKH;
        private System.Windows.Forms.ToolStripMenuItem xóaToolStripMenuItem;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.DataGridViewTextBoxColumn sMaKH;
        private System.Windows.Forms.DataGridViewTextBoxColumn sTenKH;
        private System.Windows.Forms.DataGridViewTextBoxColumn sDiaChi;
        private System.Windows.Forms.DataGridViewTextBoxColumn sSDT;
    }
}
