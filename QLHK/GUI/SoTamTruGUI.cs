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
    public partial class SoTamTruGUI : Form
    {
        SoTamTruDTO sotamtruDto;
        SoTamTruBUS sotamtruBus;

        public void ResetValueInput()
        {
            txt_MaChuHoTamTru.Clear();
            txt_SoSoTamTru.Clear();
            txt_LyDo.Clear();
            txt_ChoOHienNay.Clear();
            dt_DenNgay.ResetText();
            dt_TuNgay.ResetText();
        }

        public void LoadDataGridView()
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.DataSource = sotamtruBus.GetAll().Tables["sotamtru"];
        }

        public SoTamTruGUI()
        {
            InitializeComponent();
        }

        private void SoTamTruGUI_Load(object sender, EventArgs e)
        {
            sotamtruBus = new SoTamTruBUS();
            LoadDataGridView();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string sosotamtru = txt_SoSoTamTru.Text.ToString();
            string machuhotamtru = txt_MaChuHoTamTru.Text.ToString();
            string choohiennay = txt_ChoOHienNay.Text.ToString();
            string lydo = txt_LyDo.Text.ToString();
            DateTime tungay = dt_TuNgay.Value.Date;
            DateTime denngay = dt_DenNgay.Value.Date;

            sotamtruDto = new SoTamTruDTO(sosotamtru, machuhotamtru, choohiennay, tungay, denngay, lydo);

            if (sotamtruBus.Add(sotamtruDto))
            {
                MessageBox.Show("Đã thêm thành công!");
                LoadDataGridView();
                ResetValueInput();
            }
            else
            {
                MessageBox.Show("Thêm thất bại!");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            int r = dataGridView1.CurrentCell.RowIndex;
            string sosotamtru = dataGridView1.Rows[r].Cells[0].Value.ToString(); //Lấy số sổ tạm trú
            string machuhotamtru = dataGridView1.Rows[r].Cells[1].Value.ToString(); //Lấy mã sổ chủ hộ tạm trú

            string choohiennay = txt_ChoOHienNay.Text.ToString();
            DateTime tungay = dt_TuNgay.Value.Date;
            DateTime denngay = dt_DenNgay.Value.Date;
            string lydo = txt_LyDo.Text.ToString();

            SoTamTruDTO sotamtru = new SoTamTruDTO(sosotamtru, machuhotamtru, choohiennay, tungay, denngay, lydo);

            if (sotamtruBus.Update(sotamtru, r))
            {
                MessageBox.Show("Sửa thành công!");
                LoadDataGridView();
                ResetValueInput();
            }
            else
            {
                MessageBox.Show("Sửa thất bại!");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sosotamtru = txt_SoSoTamTru.Text.ToString();
            if (sotamtruBus.XoaSoTamTru(sosotamtru))
            {
                MessageBox.Show("Xóa thành công");
                LoadDataGridView();
                ResetValueInput();
            }
            else
            {
                MessageBox.Show("Xóa thất bại");
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string sosotamtru = txt_SoSoTamTru.Text.ToString();
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.DataSource = sotamtruBus.TimKiem(sosotamtru).Tables["sotamtru"];
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string sosotamtru = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            string machuhotamtru = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            string choohiennay = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            DateTime tungay = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[3].Value);
            DateTime denngay = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[4].Value);
            string lydo = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();

            sotamtruDto = new SoTamTruDTO(sosotamtru, machuhotamtru, choohiennay, tungay, denngay, lydo);

            txt_ChoOHienNay.Text = sotamtruDto.ChoOHienNay;
            txt_LyDo.Text = sotamtruDto.LyDo;
            txt_MaChuHoTamTru.Text = sotamtruDto.MaChuHoTamTru;
            txt_SoSoTamTru.Text = sotamtruDto.SoSoTamTru;
            dt_TuNgay.Value = sotamtruDto.TuNgay;
            dt_DenNgay.Value = sotamtruDto.DenNgay;
        }

        private void btnThemNhanKhau_Click(object sender, EventArgs e)
        {
            NhanKhauTamTruGUI nhankhautamtrufrm = new NhanKhauTamTruGUI();
            nhankhautamtrufrm.ShowDialog();
        }
    }
}
