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
            txt_MaDinhDanh.Clear();
            txt_MaNKTamTru.Clear();
            txt_SoSoTamTru.Clear();
            txt_DanToc.Clear();
            txt_GioiTinh.Clear();
            txt_HoChieu.Clear();
            txt_HoTen.Clear();
            txt_MaNgheNghiep.Clear();
            txt_MaNKTamTru.Clear();
            txt_NoiCap.Clear();
            txt_QuocTich.Clear();
            txt_SoDienThoai.Clear();
            txt_SoSoTamTru.Clear();
            txt_TonGiao.Clear();
            dt_NgayCapHoChieu.ResetText();
            dt_NgaySinh.ResetText();
        }




        public void LoadDataGridView()
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.DataSource = nkttBus.GetAll().Tables[0];
        }

        public NhanKhauTamTruGUI()
        {
            InitializeComponent();
        }



        private void NhanKhauTamTruGUI_Load(object sender, EventArgs e)
        {
            nkttBus = new NhanKhauTamTruBUS();
            LoadDataGridView();

            cbb_NQ_TinhThanhPho.DataSource = nkttBus.Get_TinhThanhPho();
            cbb_NS_TinhThanh.DataSource = nkttBus.Get_TinhThanhPho();
            cbb_DC_TinhThanh.DataSource = nkttBus.Get_TinhThanhPho();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string manhankhautamtru = txt_MaNKTamTru.Text.ToString();
            string madinhdanh = txt_MaDinhDanh.Text.ToString();
            string diachithuongtru = cbb_DC_XaPhuong.Text+","+cbb_DC_QuanHuyen.Text+","+cbb_DC_TinhThanh.Text;
            string sosotamtru = txt_SoSoTamTru.Text.ToString();

            string manghenghiep = txt_MaNgheNghiep.Text.ToString();
            string hoten = txt_HoTen.Text.ToString();
            string gioitinh = txt_GioiTinh.Text.ToString();
            string dantoc = txt_DanToc.Text.ToString();
            string hochieu = txt_HoChieu.Text.ToString();
            DateTime ngaycap = dt_NgayCapHoChieu.Value.Date;
            DateTime ngaysinh = dt_NgaySinh.Value.Date;
            string nguyenquan = cbb_NQ_XaPhuong.Text+","+cbb_NQ_QuanHuyen.Text+","+cbb_NQ_TinhThanhPho.Text;
            string noicap = txt_NoiCap.Text.ToString();
            string noisinh = cbb_NS_XaPhuong.Text+","+cbb_NS_QuanHuyen.Text+","+cbb_NS_TinhThanh.Text;
            string quoctich = txt_QuocTich.Text.ToString();
            string sdt = txt_SoDienThoai.Text.ToString();
            string tongiao = txt_TonGiao.Text.ToString();

            nkttDto = new NhanKhauTamTruDTO(manghenghiep, hoten, gioitinh, dantoc, hochieu, ngaycap, ngaysinh, nguyenquan, noicap, noisinh, quoctich, sdt, tongiao, manhankhautamtru, madinhdanh, diachithuongtru, sosotamtru);
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
            string diachithuongtru = "";
            string sosotamtru = txt_SoSoTamTru.Text.ToString();
            string manghenghiep = txt_MaNgheNghiep.Text.ToString();
            string hoten = txt_HoTen.Text.ToString();
            string gioitinh = txt_GioiTinh.Text.ToString();
            string dantoc = txt_DanToc.Text.ToString();
            string hochieu = txt_HoChieu.Text.ToString();
            DateTime ngaycap = dt_NgayCapHoChieu.Value.Date;
            DateTime ngaysinh = dt_NgaySinh.Value.Date;
            string nguyenquan = "";
            string noicap = txt_NoiCap.Text.ToString();
            string noisinh ="";
            string quoctich = txt_QuocTich.Text.ToString();
            string sdt = txt_SoDienThoai.Text.ToString();
            string tongiao = txt_TonGiao.Text.ToString();


            string manhankhautamtru = dataGridView1.Rows[r].Cells[1].Value.ToString(); //Lấy mã nhân khẩu tạm trú
            string madinhdanh = dataGridView1.Rows[r].Cells[0].Value.ToString(); //Lấy mã định danh

            nkttDto = new NhanKhauTamTruDTO(manghenghiep, hoten, gioitinh, dantoc, hochieu, ngaycap, ngaysinh, nguyenquan, noicap, noisinh, quoctich, sdt, tongiao, manhankhautamtru, madinhdanh, diachithuongtru, sosotamtru);
            if (nkttBus.Update(nkttDto, r))
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
            string madinhdanh = txt_MaDinhDanh.Text.ToString();
            if (nkttBus.XoaNKTT(madinhdanh))
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
            string madinhdanh = txt_MaDinhDanh.Text.ToString();
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.DataSource = nkttBus.TimKiem(madinhdanh).Tables[0];
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {      
            string madinhdanh = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            string manhankhautamtru = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            string hoten = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            string gioitinh = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            DateTime ngaysinh = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[4].Value);
            string noisinh = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            string diachithuongtru = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            string dantoc = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            string quoctich = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
            string nguyenquan = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
            string tongiao = dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString();
            string manghenghiep = dataGridView1.Rows[e.RowIndex].Cells[11].Value.ToString();
            string sdt = dataGridView1.Rows[e.RowIndex].Cells[12].Value.ToString();
            string hochieu = dataGridView1.Rows[e.RowIndex].Cells[13].Value.ToString();
            DateTime ngaycap = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[14].Value);
            string noicap = dataGridView1.Rows[e.RowIndex].Cells[15].Value.ToString();
            string sosotamtru = dataGridView1.Rows[e.RowIndex].Cells[16].Value.ToString();


            NhanKhauTamTruDTO nhankhautamtru = new NhanKhauTamTruDTO(manghenghiep, hoten, gioitinh, dantoc, hochieu, ngaycap, ngaysinh, nguyenquan, noicap, noisinh, quoctich, sdt, tongiao, manhankhautamtru, madinhdanh, diachithuongtru, sosotamtru);

            txt_MaDinhDanh.Text = nhankhautamtru.MaDinhDanh;
            txt_MaNKTamTru.Text = nhankhautamtru.MaNhanKhauTamTru;
            txt_HoTen.Text = nhankhautamtru.HoTen;
            txt_GioiTinh.Text = nhankhautamtru.GioiTinh;
            txt_SoSoTamTru.Text = nhankhautamtru.SoSoTamTru;
            dt_NgaySinh.Value = nhankhautamtru.NgaySinh;
            txt_DanToc.Text = nhankhautamtru.DanToc;
            txt_QuocTich.Text = nhankhautamtru.QuocTich;
            txt_TonGiao.Text = nhankhautamtru.TonGiao;
            txt_MaNgheNghiep.Text = nhankhautamtru.MaNgheNghiep;
            txt_SoDienThoai.Text = nhankhautamtru.SDT;
            txt_HoChieu.Text = nhankhautamtru.HoChieu;
            dt_NgayCapHoChieu.Value = nhankhautamtru.NgayCap;
            txt_NoiCap.Text = nhankhautamtru.NoiCap;
            txt_SoSoTamTru.Text = nhankhautamtru.SoSoTamTru;

            string[] nguyenquanArray = nkttBus.SplitDiaChi(nguyenquan);
            cbb_NQ_TinhThanhPho.SelectedIndex = cbb_NQ_TinhThanhPho.Items.IndexOf(nguyenquanArray[2]);
            cbb_NQ_QuanHuyen.SelectedIndex = cbb_NQ_QuanHuyen.Items.IndexOf(nguyenquanArray[1]);
            cbb_NQ_XaPhuong.SelectedIndex = cbb_NQ_XaPhuong.Items.IndexOf(nguyenquanArray[0]);

            string[] noisinhArray = nkttBus.SplitDiaChi(noisinh);
            cbb_NS_XaPhuong.SelectedIndex = cbb_NS_XaPhuong.Items.IndexOf(noisinhArray[0]);
            cbb_NS_QuanHuyen.SelectedIndex = cbb_NS_QuanHuyen.Items.IndexOf(noisinhArray[1]);
            cbb_NS_TinhThanh.SelectedIndex = cbb_NS_TinhThanh.Items.IndexOf(noisinhArray[2]);

            string[] diachiArray = nkttBus.SplitDiaChi(diachithuongtru);
            cbb_DC_XaPhuong.SelectedIndex = cbb_DC_XaPhuong.Items.IndexOf(diachiArray[0]);
            cbb_DC_QuanHuyen.SelectedIndex = cbb_DC_QuanHuyen.Items.IndexOf(diachiArray[1]);
            cbb_DC_TinhThanh.SelectedIndex = cbb_DC_TinhThanh.Items.IndexOf(diachiArray[2]);
        }

        private void cbb_NQ_TinhThanhPho_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = cbb_NQ_TinhThanhPho.Text;
            cbb_NQ_QuanHuyen.DataSource = nkttBus.GetListQuanHuyen(selected);
        }

        private void cbb_NQ_QuanHuyen_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = cbb_NQ_QuanHuyen.Text;
            cbb_NQ_XaPhuong.DataSource = nkttBus.GetListXaPhuong(selected);
        }

        private void cbb_NS_TinhThanh_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = cbb_NS_TinhThanh.Text;
            cbb_NS_QuanHuyen.DataSource = nkttBus.GetListQuanHuyen(selected);
        }

        private void cbb_NS_QuanHuyen_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = cbb_NS_QuanHuyen.Text;
            cbb_NS_XaPhuong.DataSource = nkttBus.GetListXaPhuong(selected);
        }

        private void cbb_DC_TinhThanh_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = cbb_DC_TinhThanh.Text;
            cbb_DC_QuanHuyen.DataSource = nkttBus.GetListQuanHuyen(selected);
        }

        private void cbb_DC_QuanHuyen_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = cbb_DC_QuanHuyen.Text;
            cbb_DC_XaPhuong.DataSource = nkttBus.GetListXaPhuong(selected);
        }
    }
}
