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
    public partial class NhanKhauThuongTruGUI : Form
    {
        NhanKhauBUS nk;
        NhanKhauThuongTruBUS nktt;
        NhanKhauThuongTruDTO nkttDTO;
        public NhanKhauThuongTruGUI()
        {
            InitializeComponent();
            nktt = new NhanKhauThuongTruBUS();
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            //dataGridView1.DataSource = nktt.GetAll().Tables["nhankhauthuongtru"];
            dataGridView1.DataSource = nktt.GetAllJoinNhanKhau().Tables[0];
        }

        private void button_them_Click(object sender, EventArgs e)
        {
            nkttDTO = new NhanKhauThuongTruDTO(tbmadinhdanh.Text, tbhoten.Text, tbgioitinh.Text,
                tbdantoc.Text, tbhochieu.Text, dtpNgayCap.Value, dtpNgaySinh.Value, tbnguyenquan.Text, tbnoicap.Text,
                tbnoisinh.Text, tbquoctich.Text, tbsodienthoai.Text, tbtongiao.Text, tbMaNKTT.Text,
                tbBietTiengDanToc.Text, tbDCHienTai.Text, tbQHVoiCH.Text == "chuho" ? true : false,
                tbNoiLamViec.Text, tbDCThuongTru.Text, tbQHVoiCH.Text, tbTrinhDoCM.Text,
                tbTrinhDoNN.Text, tbTrinhDoHocVan.Text, tbSoSHK.Text);

            if (nktt.Add(nkttDTO))
            {
                MessageBox.Show(this,"Thành công!");
            }
            else{
                MessageBox.Show(this,"Lỗi!","",MessageBoxButtons.OK,MessageBoxIcon.Error);

            }
        }
    }
}
