using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BUS;
using DAO;
using DTO;

namespace GUI_DX
{
    public partial class LoginGUI : DevExpress.XtraEditors.XtraForm
    {
        public LoginGUI()
        {
            InitializeComponent();
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            checkLogin();
        }

        private void tbUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                checkLogin();
            }
        }
        private void tbPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                checkLogin();
            }
        }


        protected void checkLogin()
        {
            if (tbUsername.Text == "" || tbPassword.Text == "")
            {
                MessageBox.Show(this, "Vui lòng điền đầy đủ tài khoản và mật khẩu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DataSet ds = DBConnection_MySQL.getData("SELECT * FROM TAIKHOAN WHERE TAIKHOAN='"
                    + tbUsername.Text + "' AND MATKHAU='" + tbPassword.Text + "'");
                if (ds == null || ds.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show(this, "Tài khoản hoặc mật khẩu không đúng!\n" + DBConnection_MySQL.ErrorString, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    this.Hide();
                    var mainGUI = new MainGUI();
                    mainGUI.Closed += (s, args) => this.Close();
                    mainGUI.Show();
                }
            }
        }
    }
}

