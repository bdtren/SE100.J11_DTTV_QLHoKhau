namespace GUI
{
    partial class NhanKhauTamTruGUI
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_MaNKTamTru = new System.Windows.Forms.TextBox();
            this.txt_MaDinhDanh = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_DiaChiThuongTru = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_SoSoTamTru = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnTim = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(-2, -2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(802, 224);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 246);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mã nhân khẩu tạm trú";
            // 
            // txt_MaNKTamTru
            // 
            this.txt_MaNKTamTru.Location = new System.Drawing.Point(146, 243);
            this.txt_MaNKTamTru.Name = "txt_MaNKTamTru";
            this.txt_MaNKTamTru.Size = new System.Drawing.Size(161, 20);
            this.txt_MaNKTamTru.TabIndex = 2;
            // 
            // txt_MaDinhDanh
            // 
            this.txt_MaDinhDanh.Location = new System.Drawing.Point(146, 281);
            this.txt_MaDinhDanh.Name = "txt_MaDinhDanh";
            this.txt_MaDinhDanh.Size = new System.Drawing.Size(161, 20);
            this.txt_MaDinhDanh.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 284);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Mã định danh";
            // 
            // txt_DiaChiThuongTru
            // 
            this.txt_DiaChiThuongTru.Location = new System.Drawing.Point(146, 326);
            this.txt_DiaChiThuongTru.Name = "txt_DiaChiThuongTru";
            this.txt_DiaChiThuongTru.Size = new System.Drawing.Size(161, 20);
            this.txt_DiaChiThuongTru.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 329);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Địa chỉ thường trú";
            // 
            // txt_SoSoTamTru
            // 
            this.txt_SoSoTamTru.Location = new System.Drawing.Point(146, 365);
            this.txt_SoSoTamTru.Name = "txt_SoSoTamTru";
            this.txt_SoSoTamTru.Size = new System.Drawing.Size(161, 20);
            this.txt_SoSoTamTru.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 368);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Số sổ tạm trú";
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(456, 243);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 23);
            this.btnThem.TabIndex = 9;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(456, 329);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 23);
            this.btnSua.TabIndex = 10;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(664, 240);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 23);
            this.btnXoa.TabIndex = 11;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnTim
            // 
            this.btnTim.Location = new System.Drawing.Point(664, 329);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(75, 23);
            this.btnTim.TabIndex = 12;
            this.btnTim.Text = "Tìm";
            this.btnTim.UseVisualStyleBackColor = true;
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
            // 
            // NhanKhauTamTruGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnTim);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.txt_SoSoTamTru);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_DiaChiThuongTru);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_MaDinhDanh);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_MaNKTamTru);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "NhanKhauTamTruGUI";
            this.Text = "NhanKhauTamTruGUI";
            this.Load += new System.EventHandler(this.NhanKhauTamTruGUI_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_MaNKTamTru;
        private System.Windows.Forms.TextBox txt_MaDinhDanh;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_DiaChiThuongTru;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_SoSoTamTru;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnTim;
    }
}