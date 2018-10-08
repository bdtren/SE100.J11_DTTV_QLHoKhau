namespace GUI
{
    partial class MainGUI
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
            this.btnGetData = new System.Windows.Forms.Button();
            this.dgvContent = new System.Windows.Forms.DataGridView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.cbbTables = new System.Windows.Forms.ComboBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.menuAdmin = new System.Windows.Forms.MenuStrip();
            this.miXem = new System.Windows.Forms.ToolStripMenuItem();
            this.miChinhSua = new System.Windows.Forms.ToolStripMenuItem();
            this.miThem = new System.Windows.Forms.ToolStripMenuItem();
            this.miSua = new System.Windows.Forms.ToolStripMenuItem();
            this.miXoa = new System.Windows.Forms.ToolStripMenuItem();
            this.rtbQuery = new System.Windows.Forms.RichTextBox();
            this.btnQuery = new System.Windows.Forms.Button();
            this.dgvQueryResult = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContent)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.menuAdmin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQueryResult)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGetData
            // 
            this.btnGetData.Location = new System.Drawing.Point(425, 22);
            this.btnGetData.Name = "btnGetData";
            this.btnGetData.Size = new System.Drawing.Size(75, 23);
            this.btnGetData.TabIndex = 0;
            this.btnGetData.Text = "Xem Bảng";
            this.btnGetData.UseVisualStyleBackColor = true;
            this.btnGetData.Click += new System.EventHandler(this.btnGetData_Click);
            // 
            // dgvContent
            // 
            this.dgvContent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvContent.Location = new System.Drawing.Point(6, 61);
            this.dgvContent.Name = "dgvContent";
            this.dgvContent.Size = new System.Drawing.Size(494, 181);
            this.dgvContent.TabIndex = 2;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 36);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(514, 286);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.cbbTables);
            this.tabPage1.Controls.Add(this.dgvContent);
            this.tabPage1.Controls.Add(this.btnGetData);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(506, 260);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Xem thường";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // cbbTables
            // 
            this.cbbTables.FormattingEnabled = true;
            this.cbbTables.Location = new System.Drawing.Point(6, 22);
            this.cbbTables.Name = "cbbTables";
            this.cbbTables.Size = new System.Drawing.Size(202, 21);
            this.cbbTables.TabIndex = 3;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgvQueryResult);
            this.tabPage2.Controls.Add(this.btnQuery);
            this.tabPage2.Controls.Add(this.rtbQuery);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(506, 260);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Xem bằng truy vấn";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // menuAdmin
            // 
            this.menuAdmin.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miXem,
            this.miChinhSua});
            this.menuAdmin.Location = new System.Drawing.Point(0, 0);
            this.menuAdmin.Name = "menuAdmin";
            this.menuAdmin.Size = new System.Drawing.Size(538, 24);
            this.menuAdmin.TabIndex = 4;
            this.menuAdmin.Text = "Menu Quản trị viên";
            // 
            // miXem
            // 
            this.miXem.Name = "miXem";
            this.miXem.Size = new System.Drawing.Size(43, 20);
            this.miXem.Text = "Xem";
            // 
            // miChinhSua
            // 
            this.miChinhSua.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miThem,
            this.miSua,
            this.miXoa});
            this.miChinhSua.Name = "miChinhSua";
            this.miChinhSua.Size = new System.Drawing.Size(72, 20);
            this.miChinhSua.Text = "Chỉnh sửa";
            // 
            // miThem
            // 
            this.miThem.Name = "miThem";
            this.miThem.Size = new System.Drawing.Size(105, 22);
            this.miThem.Text = "Thêm";
            // 
            // miSua
            // 
            this.miSua.Name = "miSua";
            this.miSua.Size = new System.Drawing.Size(105, 22);
            this.miSua.Text = "Sửa";
            // 
            // miXoa
            // 
            this.miXoa.Name = "miXoa";
            this.miXoa.Size = new System.Drawing.Size(105, 22);
            this.miXoa.Text = "Xóa";
            // 
            // rtbQuery
            // 
            this.rtbQuery.Location = new System.Drawing.Point(16, 18);
            this.rtbQuery.Name = "rtbQuery";
            this.rtbQuery.Size = new System.Drawing.Size(403, 72);
            this.rtbQuery.TabIndex = 0;
            this.rtbQuery.Text = "";
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(425, 42);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.TabIndex = 1;
            this.btnQuery.Text = "Truy Vấn";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // dgvQueryResult
            // 
            this.dgvQueryResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvQueryResult.Location = new System.Drawing.Point(16, 97);
            this.dgvQueryResult.Name = "dgvQueryResult";
            this.dgvQueryResult.Size = new System.Drawing.Size(484, 150);
            this.dgvQueryResult.TabIndex = 2;
            // 
            // MainGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 322);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuAdmin);
            this.MainMenuStrip = this.menuAdmin;
            this.Name = "MainGUI";
            this.Text = "Quản trị viên";
            ((System.ComponentModel.ISupportInitialize)(this.dgvContent)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.menuAdmin.ResumeLayout(false);
            this.menuAdmin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQueryResult)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGetData;
        private System.Windows.Forms.DataGridView dgvContent;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.MenuStrip menuAdmin;
        private System.Windows.Forms.ToolStripMenuItem miXem;
        private System.Windows.Forms.ToolStripMenuItem miChinhSua;
        private System.Windows.Forms.ToolStripMenuItem miThem;
        private System.Windows.Forms.ToolStripMenuItem miSua;
        private System.Windows.Forms.ToolStripMenuItem miXoa;
        private System.Windows.Forms.ComboBox cbbTables;
        private System.Windows.Forms.DataGridView dgvQueryResult;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.RichTextBox rtbQuery;
    }
}

