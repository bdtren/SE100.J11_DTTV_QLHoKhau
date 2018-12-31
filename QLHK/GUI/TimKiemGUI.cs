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
    public partial class TimKiemGUI : Form
    {
        NhanKhauBUS nk;
        SoHoKhauBUS shk;
        SoTamTruBUS stt;

        NhanKhau nkDTO;
        NhanKhauThuongTruDTO nkthDTO;
        NhanKhauTamTruDTO nkttDTO;
        SoHoKhauDTO shkDTO;
        SoTamTruDTO sttDTO;

        public TimKiemGUI()
        {
            InitializeComponent();
            nk = new NhanKhauBUS();
            shk = new SoHoKhauBUS();
            stt = new SoTamTruBUS();

        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (rdHoKhau.Checked)
            {
                if(/*3 tầng tìm kiếm hộ khẩu, sổ tạm trú*/ false)
                    
                {
                    MessageBox.Show(this, "Không thể tìm thấy hộ khẩu(sổ tạm trú)!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if(/*là hộ khẩu*/ true)
                using (SoHoKhauGUI a = new SoHoKhauGUI(tbTimKiem.Text))
                {
                        //DataSet ds = shk.TimKiem("sosohokhau='" + tbTimKiem.Text + "'");
                        //DataRow dt = ds.Tables["sohokhau"].Rows[0];
                        //a.ShowDialog(this);
                        //shkDTO = new SoHoKhauDTO(dt["sosohokhau"].ToString(), dt["machuho"].ToString(), dt["diachi"].ToString()
                        //    , (DateTime)dt["ngaycap"], dt["sodangky"].ToString());

                        shkDTO = a.shkDTO;
                }
            }
            else
            {
                if (/*3 tầng tìm kiếm nhân khẩu thường trú, tạm trú*/ false)

                {
                    MessageBox.Show(this, "Không thể tìm thấy nhân khẩu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (/*là nhân khẩu thường trú*/ true)
                    using (NhanKhauThuongTruGUI a = new NhanKhauThuongTruGUI(tbTimKiem.Text,-1))
                    {
                        //DataSet ds = shk.TimKiem("sosohokhau='" + tbTimKiem.Text + "'");
                        //DataRow dt = ds.Tables["sohokhau"].Rows[0];
                        //a.ShowDialog(this);
                        //shkDTO = new SoHoKhauDTO(dt["sosohokhau"].ToString(), dt["machuho"].ToString(), dt["diachi"].ToString()
                        //    , (DateTime)dt["ngaycap"], dt["sodangky"].ToString());
                        nkthDTO = a.nkttDTO;
                    }
            }
        }
    }
}
