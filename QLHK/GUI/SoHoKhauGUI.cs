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
    public partial class SoHoKhauGUI : Form
    {
        SoHoKhauBUS shk;
        SoHoKhauDTO shkDTO;
        public SoHoKhauGUI()
        {
            shk = new SoHoKhauBUS();
            shkDTO = new SoHoKhauDTO();
            InitializeComponent();

            var bindingList = new BindingList<NhanKhauThuongTruDTO>(shkDTO.NhanKhau);
            var source = new BindingSource(bindingList, null);
            dataGridView1.DataSource = source;

        }

        private void SoHoKhauGUI_Load(object sender, EventArgs e)
        {

        }

        private void tbChuHo_Enter(object sender, EventArgs e)
        {
            
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            using (NhanKhauThuongTruGUI a = new NhanKhauThuongTruGUI())
            {
                a.ShowDialog(this);
                if (a.nkttDTO != null&& !String.IsNullOrEmpty(a.nkttDTO.MaNhanKhauThuongTru))
                    shkDTO.NhanKhau.Add(a.nkttDTO);

                var bindingList = new BindingList<NhanKhauThuongTruDTO>(shkDTO.NhanKhau);
                var source = new BindingSource(bindingList, null);
                dataGridView1.DataSource = source;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {

        }
    }
}
