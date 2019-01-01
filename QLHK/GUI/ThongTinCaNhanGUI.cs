using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DTO;

namespace GUI
{
    public partial class ThongTinCaNhanGUI : Form
    {
        CanBoDTO canbo;
        public ThongTinCaNhanGUI()
        {
            InitializeComponent();
        }
        #region Các hàm phụ hỗ trợ
        private void fillData()
        {
            
        }
        #endregion
        public ThongTinCaNhanGUI(CanBoDTO cb)
        {
            InitializeComponent();
            canbo = cb;
        }

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            lblMatKhau.Visible = lblMatKhau2.Visible = tbMatKhau.Visible = tbMatKhau2.Visible = btnOK.Visible = true;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (tbMatKhau.Text!=tbMatKhau2.Text||string.IsNullOrEmpty(tbMatKhau.Text))
            {
                MessageBox.Show(this, "Mật khẩu không trùng khớp!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            /*set mật khẩu bảng cán bộ*/

            MessageBox.Show(this, "Thay đổi mật khẩu thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            tbMatKhau.Clear();
            tbMatKhau2.Clear();
            lblMatKhau.Visible = lblMatKhau2.Visible = tbMatKhau.Visible = tbMatKhau2.Visible = btnOK.Visible = false;



        }
    }
}
