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
    public partial class NhanKhauTamVangGUI : Form
    {
        NhanKhau nk = new NhanKhau();
        public NhanKhauTamVangGUI()
        {
            InitializeComponent();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (false)
            {
                MessageBox.Show(this, "Không thể tìm thấy nhân khẩu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            nk = new NhanKhau();
            MessageBox.Show(this, "Đã tìm thấy nhân khẩu với tên "+nk.HoTen+"!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);


        }

        private void tbnguyenquan_Enter(object sender, EventArgs e)
        {

        }

        private void tbDCHienTai_Enter(object sender, EventArgs e)
        {

        }

        private void tbDCThuongTru_Enter(object sender, EventArgs e)
        {

        }
    }
}
