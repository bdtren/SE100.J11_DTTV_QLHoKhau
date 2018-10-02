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
            this.tbContent = new System.Windows.Forms.TextBox();
            this.dgvContent = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContent)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGetData
            // 
            this.btnGetData.Location = new System.Drawing.Point(441, 25);
            this.btnGetData.Name = "btnGetData";
            this.btnGetData.Size = new System.Drawing.Size(75, 23);
            this.btnGetData.TabIndex = 0;
            this.btnGetData.Text = "Get Data";
            this.btnGetData.UseVisualStyleBackColor = true;
            this.btnGetData.Click += new System.EventHandler(this.btnGetData_Click);
            // 
            // tbContent
            // 
            this.tbContent.Location = new System.Drawing.Point(35, 26);
            this.tbContent.Name = "tbContent";
            this.tbContent.Size = new System.Drawing.Size(400, 20);
            this.tbContent.TabIndex = 1;
            // 
            // dgvContent
            // 
            this.dgvContent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvContent.Location = new System.Drawing.Point(35, 70);
            this.dgvContent.Name = "dgvContent";
            this.dgvContent.Size = new System.Drawing.Size(481, 150);
            this.dgvContent.TabIndex = 2;
            // 
            // MainGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 297);
            this.Controls.Add(this.dgvContent);
            this.Controls.Add(this.tbContent);
            this.Controls.Add(this.btnGetData);
            this.Name = "MainGUI";
            this.Text = "Màn hình chính";
            ((System.ComponentModel.ISupportInitialize)(this.dgvContent)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGetData;
        private System.Windows.Forms.TextBox tbContent;
        private System.Windows.Forms.DataGridView dgvContent;
    }
}

