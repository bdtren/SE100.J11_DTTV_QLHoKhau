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
        NhanKhauThuongTruBUS thuongTru;
        NhanKhauTamTruBUS tamTru;
        HocSinhSinhVienBUS hssvbus;
        HocSinhSinhVienDTO hssvdto;
        TienAnTienSuBUS tienAn;

        public HocSinhSinhVienGUI()
        {

            InitializeComponent();
            hssvbus = new HocSinhSinhVienBUS();
            tienAn = new TienAnTienSuBUS();
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.DataSource = tienAn.TimKiem("madinhdanh=''").Tables["tienantiensu"];

        }

        private void HocSinhSinhVienGUI_Load(object sender, EventArgs e)
        {

        }

        
        private void button_timkiem_Click(object sender, EventArgs e)
        {
            string query = null;
            string mssv = textBox_mssv.Text.ToString();
            string madinhdanh = textBox_madinhdanh.Text.ToString();
            string truong = textBox_truong.Text.ToString();
            string diachi = textBox_diachithuongtru.Text.ToString();
            string vipham = textBox_vipham.Text.ToString();
            if (mssv != "") query = query + " mssv='"+mssv+"'";
            if (madinhdanh != "")
            {
                if (query != null) query = query + " and madinhdanh='" + madinhdanh + "'";
                else query =" madinhdanh='" + madinhdanh + "'";
            }
            
            if ( truong!= "")
            {
                if(query!=null) query = query + " and truong='" + truong + "'";
                else query =" truong='" + truong + "'";
            }
            if ( diachi!= "")
            {
                if (query != null) query = query + " and diachi='" + diachi + "'";
                else query =" diachi='" + diachi + "'";
            }
            if (query != null) query = " where" + query;
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.DataSource = hssvbus.TimKiem(query).Tables["hocsinhsinhvien"];
            textBox_mssv.Clear();
            textBox_madinhdanh.Clear();
            textBox_truong.Clear();
            textBox_diachithuongtru.Clear();
            textBox_vipham.Clear();
        }

        private void button_Them_Click(object sender, EventArgs e)
        {
            string mssv = textBox_mssv.Text.ToString();
            string madinhdanh = textBox_madinhdanh.Text.ToString();
            string truong = textBox_truong.Text.ToString();
            string diachi = textBox_diachithuongtru.Text.ToString();
            DateTime tgbd = date_batdau.Value.Date;
            DateTime tgkt = date_ketthuc.Value.Date;
            string vipham = textBox_vipham.Text.ToString();
            hssvdto = new HocSinhSinhVienDTO(mssv, madinhdanh, truong, diachi, tgbd, tgkt, vipham);
            if (hssvbus.Add(hssvdto))
            {
                MessageBox.Show("Them thanh cong");
                
            }
            else
            {
                MessageBox.Show("Them khong thanh cong");
            }
            textBox_mssv.Clear();
            textBox_madinhdanh.Clear();
            textBox_truong.Clear();
            textBox_diachithuongtru.Clear();
            textBox_vipham.Clear();
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.DataSource = hssvbus.GetAll().Tables["hocsinhsinhvien"];
        }

        private void button_xoa_Click(object sender, EventArgs e)
        {
            string mssv = textBox_mssv.Text.ToString();
            if (hssvbus.XoaHSSV(mssv))
            {
                MessageBox.Show("Xoa Thanh Cong");

            }
            else
            {
                MessageBox.Show("Xoa khong thanh cong");
            }
            textBox_mssv.Clear();
            textBox_madinhdanh.Clear();
            textBox_truong.Clear();
            textBox_diachithuongtru.Clear();
            textBox_vipham.Clear();
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.DataSource = hssvbus.GetAll().Tables["hocsinhsinhvien"];
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox_mssv.Clear();
            textBox_madinhdanh.Clear();
            textBox_truong.Clear();
            textBox_diachithuongtru.Clear();
            textBox_vipham.Clear();
            int r = e.RowIndex;
            if (r >= dataGridView1.RowCount - 1||r<0) return;
            string mssv = dataGridView1.Rows[r].Cells["mssv"].Value.ToString();
            string madinhdanh = dataGridView1.Rows[r].Cells["madinhdanh"].Value.ToString();
            string truong = dataGridView1.Rows[r].Cells["truong"].Value.ToString();
            string diachi = dataGridView1.Rows[r].Cells["diachithuongtru"].Value.ToString();
            DateTime tgbd = DateTime.Parse(dataGridView1.Rows[r].Cells["thoigianbatdautamtruthuongtru"].Value.ToString());
            DateTime tgkt = DateTime.Parse(dataGridView1.Rows[r].Cells["thoigianketthuctamtruthuongtru"].Value.ToString());
            string vipham = dataGridView1.Rows[r].Cells["vipham"].Value.ToString();
            HocSinhSinhVienDTO hssv = new HocSinhSinhVienDTO(mssv, madinhdanh, truong, diachi, tgbd, tgkt, vipham);
            textBox_mssv.Text = hssv.MSSV;
            textBox_madinhdanh.Text = hssv.MaDinhDanh;
            textBox_truong.Text = hssv.Truong;
            textBox_diachithuongtru.Text = hssv.DiaChiThuongTru;
            date_batdau.Value = hssv.TGBDTTTT;
            date_ketthuc.Value = hssv.TGKTTTTT;
            textBox_vipham.Text = hssv.ViPham;
        }

        private void button_sua_Click(object sender, EventArgs e)
        {
            string mssv = textBox_mssv.Text.ToString();
            string madinhdanh = textBox_madinhdanh.Text.ToString();
            string truong = textBox_truong.Text.ToString();
            string diachi = textBox_diachithuongtru.Text.ToString();
            DateTime tgbd = date_batdau.Value.Date;
            DateTime tgkt = date_ketthuc.Value.Date;
            string vipham = textBox_vipham.Text.ToString();
            hssvdto = new HocSinhSinhVienDTO(mssv, madinhdanh, truong, diachi, tgbd, tgkt, vipham);
            if (hssvbus.Update(hssvdto,-1))
            {
                MessageBox.Show("Sua thanh cong");
                
            }
            else
            {
                MessageBox.Show("Sua khong thanh cong");
            }
            textBox_mssv.Clear();
            textBox_madinhdanh.Clear();
            textBox_truong.Clear();
            textBox_diachithuongtru.Clear();
            textBox_vipham.Clear();
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.DataSource = hssvbus.GetAll().Tables["hocsinhsinhvien"];
        }

        private void textBox_madinhdanh_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.DataSource = tienAn.TimKiem("madinhdanh LIKE '%" + textBox_madinhdanh.Text + "%'").Tables["tienantiensu"];
        }
    }
}
