namespace GUI
{
    partial class SoTamTruGUI
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnThemNhanKhau = new System.Windows.Forms.Button();
            this.btnTim = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.txt_SoNha = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cbb_ChoO_XaPhuong = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cbb_ChoO_QuanHuyen = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbb_ChoO_TinhThanh = new System.Windows.Forms.ComboBox();
            this.dt_DenNgay = new System.Windows.Forms.DateTimePicker();
            this.dt_TuNgay = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_LyDo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_SoSoTamTru = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_MaChuHoTamTru = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnThemNhanKhau);
            this.groupBox2.Controls.Add(this.btnTim);
            this.groupBox2.Controls.Add(this.btnXoa);
            this.groupBox2.Controls.Add(this.btnSua);
            this.groupBox2.Controls.Add(this.btnThem);
            this.groupBox2.Location = new System.Drawing.Point(491, 7);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(234, 300);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thao tác";
            // 
            // btnThemNhanKhau
            // 
            this.btnThemNhanKhau.Location = new System.Drawing.Point(68, 29);
            this.btnThemNhanKhau.Name = "btnThemNhanKhau";
            this.btnThemNhanKhau.Size = new System.Drawing.Size(141, 40);
            this.btnThemNhanKhau.TabIndex = 17;
            this.btnThemNhanKhau.Text = "Thêm nhân khẩu tạm trú";
            this.btnThemNhanKhau.UseVisualStyleBackColor = true;
            this.btnThemNhanKhau.Click += new System.EventHandler(this.btnThemNhanKhau_Click);
            // 
            // btnTim
            // 
            this.btnTim.Location = new System.Drawing.Point(68, 240);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(141, 38);
            this.btnTim.TabIndex = 16;
            this.btnTim.Text = "Tìm sổ tạm trú";
            this.btnTim.UseVisualStyleBackColor = true;
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(68, 190);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(141, 38);
            this.btnXoa.TabIndex = 15;
            this.btnXoa.Text = "Hủy đăng ký tạm trú";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(68, 138);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(141, 38);
            this.btnSua.TabIndex = 14;
            this.btnSua.Text = "Sửa thông tin sổ tạm trú";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(68, 84);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(141, 36);
            this.btnThem.TabIndex = 13;
            this.btnThem.Text = "Đăng ký tạm trú";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // txt_SoNha
            // 
            this.txt_SoNha.Location = new System.Drawing.Point(241, 165);
            this.txt_SoNha.Name = "txt_SoNha";
            this.txt_SoNha.Size = new System.Drawing.Size(148, 20);
            this.txt_SoNha.TabIndex = 20;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(127, 171);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 13);
            this.label10.TabIndex = 19;
            this.label10.Text = "Số nhà";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(127, 141);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(100, 13);
            this.label9.TabIndex = 18;
            this.label9.Text = "Xã. phường, thị trấn";
            // 
            // cbb_ChoO_XaPhuong
            // 
            this.cbb_ChoO_XaPhuong.FormattingEnabled = true;
            this.cbb_ChoO_XaPhuong.Location = new System.Drawing.Point(241, 138);
            this.cbb_ChoO_XaPhuong.Name = "cbb_ChoO_XaPhuong";
            this.cbb_ChoO_XaPhuong.Size = new System.Drawing.Size(148, 21);
            this.cbb_ChoO_XaPhuong.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(127, 114);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Quận/Huyện";
            // 
            // cbb_ChoO_QuanHuyen
            // 
            this.cbb_ChoO_QuanHuyen.FormattingEnabled = true;
            this.cbb_ChoO_QuanHuyen.Location = new System.Drawing.Point(241, 111);
            this.cbb_ChoO_QuanHuyen.Name = "cbb_ChoO_QuanHuyen";
            this.cbb_ChoO_QuanHuyen.Size = new System.Drawing.Size(148, 21);
            this.cbb_ChoO_QuanHuyen.TabIndex = 15;
            this.cbb_ChoO_QuanHuyen.SelectedIndexChanged += new System.EventHandler(this.cbb_ChoO_QuanHuyen_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(127, 87);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Tỉnh/Thành";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txt_SoNha);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.cbb_ChoO_XaPhuong);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.cbb_ChoO_QuanHuyen);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.cbb_ChoO_TinhThanh);
            this.groupBox1.Controls.Add(this.dt_DenNgay);
            this.groupBox1.Controls.Add(this.dt_TuNgay);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txt_LyDo);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txt_SoSoTamTru);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txt_MaChuHoTamTru);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(1, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(440, 300);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin sổ tạm trú";
            // 
            // cbb_ChoO_TinhThanh
            // 
            this.cbb_ChoO_TinhThanh.FormattingEnabled = true;
            this.cbb_ChoO_TinhThanh.Location = new System.Drawing.Point(241, 84);
            this.cbb_ChoO_TinhThanh.Name = "cbb_ChoO_TinhThanh";
            this.cbb_ChoO_TinhThanh.Size = new System.Drawing.Size(148, 21);
            this.cbb_ChoO_TinhThanh.TabIndex = 13;
            this.cbb_ChoO_TinhThanh.SelectedIndexChanged += new System.EventHandler(this.cbb_ChoO_TinhThanh_SelectedIndexChanged);
            // 
            // dt_DenNgay
            // 
            this.dt_DenNgay.Location = new System.Drawing.Point(127, 225);
            this.dt_DenNgay.Name = "dt_DenNgay";
            this.dt_DenNgay.Size = new System.Drawing.Size(262, 20);
            this.dt_DenNgay.TabIndex = 12;
            // 
            // dt_TuNgay
            // 
            this.dt_TuNgay.Location = new System.Drawing.Point(127, 197);
            this.dt_TuNgay.Name = "dt_TuNgay";
            this.dt_TuNgay.Size = new System.Drawing.Size(262, 20);
            this.dt_TuNgay.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 225);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Đến ngày";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 197);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Từ ngày";
            // 
            // txt_LyDo
            // 
            this.txt_LyDo.Location = new System.Drawing.Point(127, 250);
            this.txt_LyDo.Name = "txt_LyDo";
            this.txt_LyDo.Size = new System.Drawing.Size(262, 20);
            this.txt_LyDo.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 253);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Lý do";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Chổ ở hiện nay";
            // 
            // txt_SoSoTamTru
            // 
            this.txt_SoSoTamTru.Location = new System.Drawing.Point(127, 58);
            this.txt_SoSoTamTru.Name = "txt_SoSoTamTru";
            this.txt_SoSoTamTru.Size = new System.Drawing.Size(262, 20);
            this.txt_SoSoTamTru.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(16, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Số sổ tạm trú";
            // 
            // txt_MaChuHoTamTru
            // 
            this.txt_MaChuHoTamTru.Location = new System.Drawing.Point(127, 32);
            this.txt_MaChuHoTamTru.Name = "txt_MaChuHoTamTru";
            this.txt_MaChuHoTamTru.Size = new System.Drawing.Size(262, 20);
            this.txt_MaChuHoTamTru.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(16, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mã chủ hộ tạm trú";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(1, 313);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(724, 184);
            this.dataGridView1.TabIndex = 20;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // SoTamTruGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(731, 494);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "SoTamTruGUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SoTamTruGUI";
            this.Load += new System.EventHandler(this.SoTamTruGUI_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnThemNhanKhau;
        private System.Windows.Forms.Button btnTim;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.TextBox txt_SoNha;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbb_ChoO_XaPhuong;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbb_ChoO_QuanHuyen;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbb_ChoO_TinhThanh;
        private System.Windows.Forms.DateTimePicker dt_DenNgay;
        private System.Windows.Forms.DateTimePicker dt_TuNgay;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_LyDo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_SoSoTamTru;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_MaChuHoTamTru;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}