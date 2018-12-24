using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BUS;

namespace GUI
{
    public partial class HocSinhSinhVienGUI : Form
    {
        HocSinhSinhVienBUS hssvbus;
        HocSinhSinhVienDTO hssvdto;

        public HocSinhSinhVienGUI()
        {
            
            InitializeComponent();
            hssvbus = new HocSinhSinhVienBUS();
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.DataSource = hssvbus.GetAll().Tables["hocsinhsinhvien"];
        }

        private void HocSinhSinhVienGUI_Load(object sender, EventArgs e)
        {
            
        }

        private void button_timkiem_Click(object sender, EventArgs e)
        {
            string mssv = textBox_mssv.Text.ToString();
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.DataSource = hssvbus.TimKiem(mssv).Tables["hocsinhsinhvien"];
        }

        private void button_Them_Click(object sender, EventArgs e)
        {
            string mssv = textBox_mssv.Text.ToString();
            string madinhdanh = textBox_madinhdanh.Text.ToString();
            string truong = textBox_truong.Text.ToString();
            string diachi = textBox_diachithuongtru.Text.ToString();
            DateTime tgbd =date_batdau.Value.Date;
            DateTime tgkt=date_ketthuc.Value.Date;
            string vipham = textBox_vipham.Text.ToString();
            hssvdto = new HocSinhSinhVienDTO(mssv, madinhdanh, truong, diachi, tgbd, tgkt, vipham);
            if (hssvbus.Add(hssvdto))
            {
                MessageBox.Show("Them thanh cong");
                textBox_mssv.Clear();
                textBox_madinhdanh.Clear();
                textBox_truong.Clear();
                textBox_diachithuongtru.Clear();
                textBox_vipham.Clear();
            }
            else
            {
                MessageBox.Show("Them khong thanh cong");
            }
        }
    }
}
