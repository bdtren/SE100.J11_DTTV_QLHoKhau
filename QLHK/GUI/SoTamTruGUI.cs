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
        private string sosotamtru = "";

        public void ResetValueInput()
        {
            txt_MaChuHoTamTru.Clear();
            txt_SoSoTamTru.Clear();
            txt_LyDo.Clear();
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
            cbb_ChoO_TinhThanh.DataSource = sotamtruBus.Get_TinhThanhPho();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string sosotamtru = txt_SoSoTamTru.Text.ToString();
            string machuhotamtru = txt_MaChuHoTamTru.Text.ToString();
            string choohiennay = txt_SoNha.Text + "," + cbb_ChoO_XaPhuong.Text + "," + cbb_ChoO_QuanHuyen.Text + "," + cbb_ChoO_TinhThanh.Text;
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

            string choohiennay = txt_SoNha.Text + "," + cbb_ChoO_XaPhuong.Text + "," + cbb_ChoO_QuanHuyen.Text + "," + cbb_ChoO_TinhThanh.Text;
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

            string[] ChoOHienNay = sotamtruBus.SplitDiaChi(choohiennay);

            txt_LyDo.Text = sotamtruDto.LyDo;
            txt_MaChuHoTamTru.Text = sotamtruDto.MaChuHoTamTru;
            txt_SoSoTamTru.Text = sotamtruDto.SoSoTamTru;
            dt_TuNgay.Value = sotamtruDto.TuNgay;
            dt_DenNgay.Value = sotamtruDto.DenNgay;

            txt_SoNha.Text = ChoOHienNay[0];
            cbb_ChoO_XaPhuong.SelectedIndex = cbb_ChoO_XaPhuong.Items.IndexOf(ChoOHienNay[1]);
            cbb_ChoO_QuanHuyen.SelectedIndex = cbb_ChoO_QuanHuyen.Items.IndexOf(ChoOHienNay[2]);
            cbb_ChoO_TinhThanh.SelectedIndex = cbb_ChoO_TinhThanh.Items.IndexOf(ChoOHienNay[3]);
        }

        private void btnThemNhanKhau_Click(object sender, EventArgs e)
        {
            sosotamtru = txt_SoSoTamTru.Text.ToString();
            NhanKhauTamTruGUI nhankhautamtrufrm = new NhanKhauTamTruGUI(sosotamtru);

            if (nhankhautamtrufrm.ShowDialog() == DialogResult.OK)
            {
                if (nhankhautamtrufrm.Machuho != "")
                {
                    txt_MaChuHoTamTru.Text = nhankhautamtrufrm.Machuho;
                }
            }
        }

        private void cbb_ChoO_TinhThanh_SelectedIndexChanged(object sender, EventArgs e)
        {

            cbb_ChoO_QuanHuyen.DataSource = sotamtruBus.GetListQuanHuyen(cbb_ChoO_TinhThanh.Text);
        }

        private void cbb_ChoO_QuanHuyen_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbb_ChoO_XaPhuong.DataSource = sotamtruBus.GetListXaPhuong(cbb_ChoO_QuanHuyen.Text);
        }
    }
}
