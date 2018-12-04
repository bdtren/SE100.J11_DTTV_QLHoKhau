namespace GUI_DX
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
        ///
        private void InitializeComponent()
        {
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.cbbTables = new System.Windows.Forms.ComboBox();
            this.btnGetData = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnQuery = new System.Windows.Forms.Button();
            this.rtbQuery = new System.Windows.Forms.RichTextBox();
            this.menuAdmin = new System.Windows.Forms.MenuStrip();
            this.miXem = new System.Windows.Forms.ToolStripMenuItem();
            this.miChinhSua = new System.Windows.Forms.ToolStripMenuItem();
            this.miThem = new System.Windows.Forms.ToolStripMenuItem();
            this.miSua = new System.Windows.Forms.ToolStripMenuItem();
            this.miXoa = new System.Windows.Forms.ToolStripMenuItem();
            this.gvContent = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcContent = new DevExpress.XtraGrid.GridControl();
            this.gcQueryResult = new DevExpress.XtraGrid.GridControl();
            this.gvQueryResult = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.menuAdmin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvContent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcContent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcQueryResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvQueryResult)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.CaptionLocation = DevExpress.Utils.Locations.Top;
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(528, 347);
            this.groupControl1.TabIndex = 6;
            this.groupControl1.Text = "layoutControlGroup";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 57);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(514, 286);
            this.tabControl1.TabIndex = 7;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.gcContent);
            this.tabPage1.Controls.Add(this.cbbTables);
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
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.gcQueryResult);
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
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(428, 6);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.TabIndex = 1;
            this.btnQuery.Text = "Truy Vấn";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // rtbQuery
            // 
            this.rtbQuery.Location = new System.Drawing.Point(6, 6);
            this.rtbQuery.Name = "rtbQuery";
            this.rtbQuery.Size = new System.Drawing.Size(413, 69);
            this.rtbQuery.TabIndex = 0;
            this.rtbQuery.Text = "";
            // 
            // menuAdmin
            // 
            this.menuAdmin.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miXem,
            this.miChinhSua});
            this.menuAdmin.Location = new System.Drawing.Point(0, 0);
            this.menuAdmin.Name = "menuAdmin";
            this.menuAdmin.Size = new System.Drawing.Size(528, 24);
            this.menuAdmin.TabIndex = 8;
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
            // gvContent
            // 
            this.gvContent.GridControl = this.gcContent;
            this.gvContent.Name = "gvContent";
            this.gvContent.OptionsView.ShowFooter = true;
            // 
            // gridView2
            // 
            this.gridView2.GridControl = this.gcContent;
            this.gridView2.Name = "gridView2";
            // 
            // gcContent
            // 
            this.gcContent.Location = new System.Drawing.Point(6, 49);
            this.gcContent.MainView = this.gvContent;
            this.gcContent.Name = "gcContent";
            this.gcContent.Size = new System.Drawing.Size(494, 200);
            this.gcContent.TabIndex = 0;
            this.gcContent.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2,
            this.gvContent});
            // 
            // gcQueryResult
            // 
            this.gcQueryResult.Location = new System.Drawing.Point(6, 81);
            this.gcQueryResult.MainView = this.gvQueryResult;
            this.gcQueryResult.Name = "gcQueryResult";
            this.gcQueryResult.Size = new System.Drawing.Size(494, 176);
            this.gcQueryResult.TabIndex = 0;
            this.gcQueryResult.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvQueryResult});
            // 
            // gvQueryResult
            // 
            this.gvQueryResult.GridControl = this.gcQueryResult;
            this.gvQueryResult.Name = "gvQueryResult";
            // 
            // MainGUI
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 347);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuAdmin);
            this.Controls.Add(this.groupControl1);
            this.Name = "MainGUI";
            this.Text = "Quản lý Admin";
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.menuAdmin.ResumeLayout(false);
            this.menuAdmin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvContent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcContent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcQueryResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvQueryResult)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ComboBox cbbTables;
        private System.Windows.Forms.Button btnGetData;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.RichTextBox rtbQuery;
        private System.Windows.Forms.MenuStrip menuAdmin;
        private System.Windows.Forms.ToolStripMenuItem miXem;
        private System.Windows.Forms.ToolStripMenuItem miChinhSua;
        private System.Windows.Forms.ToolStripMenuItem miThem;
        private System.Windows.Forms.ToolStripMenuItem miSua;
        private System.Windows.Forms.ToolStripMenuItem miXoa;
        private DevExpress.XtraGrid.GridControl gcContent;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Views.Grid.GridView gvContent;
        private DevExpress.XtraGrid.GridControl gcQueryResult;
        private DevExpress.XtraGrid.Views.Grid.GridView gvQueryResult;
    }
}