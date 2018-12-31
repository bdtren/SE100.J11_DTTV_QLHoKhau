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
    public partial class DangNhapGUI : DevExpress.XtraEditors.XtraForm
    {
        public DangNhapGUI()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (DangNhapBUS.TimKiem(tbTaiKhoan.Text,tbMatKhau.Text))
            {
                Home home = new Home("canBoDTO");
                this.Hide();
                home.Closed += (s, args) => this.Close();
                home.Show();
            }
            else
            {
                MessageBox.Show(this, "Tên đăng nhập hoặc mật khẩu không đúng!", "Đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
    }
}
