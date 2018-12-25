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
    public partial class NhanKhauTamTruGUI : Form
    {
        NhanKhauTamTruBUS nkttBus;
        NhanKhauTamTruDTO nkttDto;

        public void ResetValueInput()
        {
            txt_DiaChiThuongTru.Clear();
            txt_MaDinhDanh.Clear();
            txt_MaNKTamTru.Clear();
            txt_SoSoTamTru.Clear();
        }

        public void LoadDataGridView()
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.DataSource = nkttBus.GetAll().Tables["nhankhautamtru"];
        }

        public NhanKhauTamTruGUI()
        {
            InitializeComponent();
        }



        private void NhanKhauTamTruGUI_Load(object sender, EventArgs e)
        {
            nkttBus = new NhanKhauTamTruBUS();
            LoadDataGridView();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string manhankhautamtru = txt_MaNKTamTru.Text.ToString();
            string madinhdanh = txt_MaDinhDanh.Text.ToString();
            string diachithuongtru = txt_DiaChiThuongTru.Text.ToString();
            string sosotamtru = txt_SoSoTamTru.Text.ToString();

            nkttDto = new NhanKhauTamTruDTO(manhankhautamtru, madinhdanh, diachithuongtru, sosotamtru);
            if (nkttBus.Add(nkttDto))
            {
                MessageBox.Show("Thêm nhân khẩu tạm trú thành công");
                ResetValueInput();
                LoadDataGridView();
            }
            else
            {
                MessageBox.Show("Thêm không thành công");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            int r = dataGridView1.CurrentCell.RowIndex;
            string diachithuongtru = txt_DiaChiThuongTru.Text.ToString();
            string sosotamtru = txt_SoSoTamTru.Text.ToString();

            string manhankhautamtru = dataGridView1.Rows[r].Cells[0].Value.ToString(); //Lấy mã nhân khẩu tạm trú
            string madinhdanh = dataGridView1.Rows[r].Cells[1].Value.ToString(); //Lấy mã định danh

            NhanKhauTamTruDTO nhanKhauTamTru = new NhanKhauTamTruDTO(manhankhautamtru, madinhdanh, diachithuongtru, sosotamtru);
            if (nkttBus.Update(nhanKhauTamTru, r))
            {
                MessageBox.Show("Cập nhật dữ liệu thành công");
                ResetValueInput();
                LoadDataGridView();
            }
            else
            {
                MessageBox.Show("Cập nhật không thành công");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string manhankhautamtru = txt_MaNKTamTru.Text.ToString();
            if (nkttBus.XoaNKTT(manhankhautamtru))
            {
                MessageBox.Show("Xóa nhân khẩu tạm trú thành công!");
                ResetValueInput();
                LoadDataGridView();
            }
            else
            {
                MessageBox.Show("Xóa không thành công!");
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string manhankhautamtru = txt_MaNKTamTru.Text.ToString();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = nkttBus.TimKiem(manhankhautamtru).Tables["nhankhautamtru"];
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string manhankhautamtru = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            string madinhdanh = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            string diachithuongtru = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            string sosotamtru = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();

            NhanKhauTamTruDTO nhankhautamtru = new NhanKhauTamTruDTO(manhankhautamtru, madinhdanh, diachithuongtru, sosotamtru);

            txt_MaNKTamTru.Text = nhankhautamtru.MaNhanKhauTamTru;
            txt_MaDinhDanh.Text = nhankhautamtru.MaDinhDanh;
            txt_DiaChiThuongTru.Text = nhankhautamtru.DiaChiThuongTru;
            txt_SoSoTamTru.Text = nhankhautamtru.SoSoTamTru;
        }
    }
}
