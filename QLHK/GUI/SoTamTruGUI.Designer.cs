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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_MaChuHoTamTru = new System.Windows.Forms.TextBox();
            this.txt_SoSoTamTru = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_ChoOHienNay = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_LyDo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dt_TuNgay = new System.Windows.Forms.DateTimePicker();
            this.dt_DenNgay = new System.Windows.Forms.DateTimePicker();
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
            this.dataGridView1.Location = new System.Drawing.Point(-3, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(803, 165);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 211);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mã chủ hộ tạm trú";
            // 
            // txt_MaChuHoTamTru
            // 
            this.txt_MaChuHoTamTru.Location = new System.Drawing.Point(136, 208);
            this.txt_MaChuHoTamTru.Name = "txt_MaChuHoTamTru";
            this.txt_MaChuHoTamTru.Size = new System.Drawing.Size(200, 20);
            this.txt_MaChuHoTamTru.TabIndex = 2;
            // 
            // txt_SoSoTamTru
            // 
            this.txt_SoSoTamTru.Location = new System.Drawing.Point(136, 234);
            this.txt_SoSoTamTru.Name = "txt_SoSoTamTru";
            this.txt_SoSoTamTru.Size = new System.Drawing.Size(200, 20);
            this.txt_SoSoTamTru.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 237);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Số sổ tạm trú";
            // 
            // txt_ChoOHienNay
            // 
            this.txt_ChoOHienNay.Location = new System.Drawing.Point(136, 260);
            this.txt_ChoOHienNay.Name = "txt_ChoOHienNay";
            this.txt_ChoOHienNay.Size = new System.Drawing.Size(200, 20);
            this.txt_ChoOHienNay.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 263);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Chổ ở hiện nay";
            // 
            // txt_LyDo
            // 
            this.txt_LyDo.Location = new System.Drawing.Point(136, 345);
            this.txt_LyDo.Name = "txt_LyDo";
            this.txt_LyDo.Size = new System.Drawing.Size(200, 20);
            this.txt_LyDo.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 348);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Lý do";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 292);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Từ ngày";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(25, 320);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Đến ngày";
            // 
            // dt_TuNgay
            // 
            this.dt_TuNgay.Location = new System.Drawing.Point(136, 292);
            this.dt_TuNgay.Name = "dt_TuNgay";
            this.dt_TuNgay.Size = new System.Drawing.Size(200, 20);
            this.dt_TuNgay.TabIndex = 11;
            // 
            // dt_DenNgay
            // 
            this.dt_DenNgay.Location = new System.Drawing.Point(136, 320);
            this.dt_DenNgay.Name = "dt_DenNgay";
            this.dt_DenNgay.Size = new System.Drawing.Size(200, 20);
            this.dt_DenNgay.TabIndex = 12;
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(438, 211);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 23);
            this.btnThem.TabIndex = 13;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(613, 211);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 23);
            this.btnSua.TabIndex = 14;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(438, 289);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 23);
            this.btnXoa.TabIndex = 15;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnTim
            // 
            this.btnTim.Location = new System.Drawing.Point(613, 287);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(75, 23);
            this.btnTim.TabIndex = 16;
            this.btnTim.Text = "Tìm";
            this.btnTim.UseVisualStyleBackColor = true;
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
            // 
            // SoTamTruGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnTim);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.dt_DenNgay);
            this.Controls.Add(this.dt_TuNgay);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt_LyDo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_ChoOHienNay);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_SoSoTamTru);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_MaChuHoTamTru);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "SoTamTruGUI";
            this.Text = "SoTamTruGUI";
            this.Load += new System.EventHandler(this.SoTamTruGUI_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_MaChuHoTamTru;
        private System.Windows.Forms.TextBox txt_SoSoTamTru;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_ChoOHienNay;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_LyDo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dt_TuNgay;
        private System.Windows.Forms.DateTimePicker dt_DenNgay;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnTim;
    }
}