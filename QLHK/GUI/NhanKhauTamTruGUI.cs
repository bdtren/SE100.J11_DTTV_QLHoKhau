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

        private string machuho = "";
        private string sosotamtru = "";
        private string manghenghiep = "";
        public string Machuho
        {
            get { return machuho; }
            set { machuho = Machuho; }
        }
        private int count = 0;  //Xác định chủ hộ nếu count = 0;

        ///
        ///TẠO MÃ TỰ ĐỘNG
        SoTamTruBUS sotamtru;
        //Tạo mã tiền án tiền sự
        public string GenerateMaTienAnTienSu()
        {
            sotamtru = new SoTamTruBUS();
            string last_ID = sotamtru.getLastID_MaTienAnTienSu();
            if (last_ID == "") last_ID = "TA0000000";
            return sotamtru.Generate7Character(last_ID);
        }


        //Tạo mã tiểu sử
        public string GenerateMaTieuSu()
        {
            sotamtru = new SoTamTruBUS();
            string last_ID = sotamtru.getLastID_MaTieuSu();
            if (last_ID == "") last_ID = "TS0000000";
            return sotamtru.Generate7Character(last_ID);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            GenerateAllID();
        }

        //Tạo mã nhân khẩu tạm trú
        public string GenerateMaNhanKhauTamTru()
        {
            sotamtru = new SoTamTruBUS();
            string last_ID = sotamtru.getLastID_MaNhanKhauTamTru();
            if (last_ID == "") last_ID = "TA0000000";
            return sotamtru.Generate7Character(last_ID);
        }


        public void GenerateAllID()
        {
            txt_MaTienAn.Text = GenerateMaTienAnTienSu();
            txt_MaTieuSu.Text = GenerateMaTieuSu();
            txt_MaNKTamTru.Text = GenerateMaNhanKhauTamTru();
            TaoMaDinhDanh();
            LoadDataGridView();
        }

        ///KẾT THÚC TẠO MÃ TỰ ĐỘNG
        ///


        ///Kiểm tra null input
        public bool isInputTrueThongTinTamTru()
        {
            if (txt_HoTen.Text.ToString() == "" || txt_DanToc.Text.ToString()=="" || cbbNgheNghiep.Text.ToString()=="" || txt_QuocTich.Text.ToString() == "")
            {
                return false;
            }
            return true;
        }

        public bool isInputTrueTieuSu()
        {
            if (cbbNgheNghiep.Text.ToString() == "") return false;
            return true;
        }

        public bool isInputTrueTienAn()
        {
            if(txt_HinhPhat.Text.ToString()=="" || txt_BanAn.Text.ToString()=="" || txtToiDanh.Text.ToString() == "")
            {
                return false;
            }
            return true;
        }


        ///Kết thúc Kiểm tra null input


        //Xóa các trường Input
        public void ResetValueInput()
        {
            txt_MaDinhDanh.Clear();
            txt_MaNKTamTru.Clear();
            txt_DanToc.Clear();
            txt_HoChieu.Clear();
            txt_HoTen.Clear();
            txt_MaNKTamTru.Clear();
            txt_NoiCap.Clear();
            txt_QuocTich.Clear();
            txt_SoDienThoai.Clear();
            txt_TonGiao.Clear();
            dt_NgayCapHoChieu.ResetText();
            dt_NgaySinh.ResetText();
            ResetInputTienAn();
            ResetInputTieuSu();
            TaoMaDinhDanh();
        }

        //Cập nhật datagridview
        public void LoadDataGridView()
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.DataSource = nkttBus.GetAllNhanKhauTamTru(txt_SoSoTamTru.Text.ToString()).Tables[0];

            LoadDataGridViewTienAN();
            LoadDataGridViewTieuSu();
        }


        public NhanKhauTamTruGUI(string Sosotamtru)
        {
            InitializeComponent();
            this.sosotamtru = Sosotamtru;
        }

        private void NhanKhauTamTruGUI_Load(object sender, EventArgs e)
        {
            nkttBus = new NhanKhauTamTruBUS();
            cbb_NQ_TinhThanhPho.DataSource = nkttBus.Get_TinhThanhPho();
            cbb_NS_TinhThanh.DataSource = nkttBus.Get_TinhThanhPho();
            cbb_DC_TinhThanh.DataSource = nkttBus.Get_TinhThanhPho();
            txt_SoSoTamTru.Text = sosotamtru;
            cbbNgheNghiep.DataSource = nkttBus.GetListNgheNghiep();
            cbb_TieuSu_NgheNghiep.DataSource = nkttBus.GetListNgheNghiep();
            cbb_TieuSu_TinhThanh.DataSource = nkttBus.Get_TinhThanhPho();
            LoadDataGridView();

            GenerateAllID();
        }

        
        //
        //SỰ KIỆN LIÊN QUAN ĐẾN THAY ĐỔI TRONG COMBOBOX
        //
        private void cbb_NQ_TinhThanhPho_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbb_NQ_QuanHuyen.DataSource = nkttBus.GetListQuanHuyen(cbb_NQ_TinhThanhPho.Text);
        }

        private void cbb_NQ_QuanHuyen_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbb_NQ_XaPhuong.DataSource = nkttBus.GetListXaPhuong(cbb_NQ_QuanHuyen.Text);
        }

        private void cbb_NS_TinhThanh_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbb_NS_QuanHuyen.DataSource = nkttBus.GetListQuanHuyen(cbb_NS_TinhThanh.Text);
        }

        private void cbb_NS_QuanHuyen_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbb_NS_XaPhuong.DataSource = nkttBus.GetListXaPhuong(cbb_NS_QuanHuyen.Text);
        }

        private void cbb_DC_TinhThanh_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbb_DC_QuanHuyen.DataSource = nkttBus.GetListQuanHuyen(cbb_DC_TinhThanh.Text);
        }

        private void cbb_DC_QuanHuyen_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbb_DC_XaPhuong.DataSource = nkttBus.GetListXaPhuong(cbb_DC_QuanHuyen.Text);
        }


        //Lấy mã nghề nghiệp từ tên nghề nghiệp
        private void cbbNgheNghiep_SelectedIndexChanged(object sender, EventArgs e)
        {
            manghenghiep = nkttBus.GetMaNgheNghiep(cbbNgheNghiep.Text);
        }

        //Thêm một nhân khẩu tạm trú
        private void btnThem_Click(object sender, EventArgs e)
        {
            string manhankhautamtru = txt_MaNKTamTru.Text.ToString();
            string madinhdanh = txt_MaDinhDanh.Text.ToString();

            if(manhankhautamtru=="" || madinhdanh=="")
            {
                MessageBox.Show("Cần có mã nhân khẩu tạm trú và mã định danh để thực hiện chức năng này");
                return;
            }

            //Nhập không đầy đủ
            if (!isInputTrueThongTinTamTru())
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin!");
                return;
            }
            string hoten = txt_HoTen.Text.ToString();

            SoTamTruBUS sotamtruBus = new SoTamTruBUS();
            if (sotamtruBus.Existed_NhanKhau(madinhdanh))
            {
                MessageBox.Show("Nhân khẩu tạm trú "+hoten+" đã có trong hệ thống !");
                return;
            }

            string diachithuongtru = cbb_DC_XaPhuong.Text + "," + cbb_DC_QuanHuyen.Text + "," + cbb_DC_TinhThanh.Text;
            string sosotamtru = txt_SoSoTamTru.Text.ToString();

            string manghenghiep = nkttBus.GetMaNgheNghiep(cbbNgheNghiep.Text);


            string gioitinh = "";
            if (rdNam.Checked) gioitinh = "nam";
            else gioitinh = "nu";

            string dantoc = txt_DanToc.Text.ToString();
            string hochieu = txt_HoChieu.Text.ToString();
            DateTime ngaycap = dt_NgayCapHoChieu.Value.Date;
            DateTime ngaysinh = dt_NgaySinh.Value.Date;
            string nguyenquan = cbb_NQ_XaPhuong.Text + "," + cbb_NQ_QuanHuyen.Text + "," + cbb_NQ_TinhThanhPho.Text;
            string noicap = txt_NoiCap.Text.ToString();
            string noisinh = cbb_NS_XaPhuong.Text + "," + cbb_NS_QuanHuyen.Text + "," + cbb_NS_TinhThanh.Text;
            string quoctich = txt_QuocTich.Text.ToString();
            string sdt = txt_SoDienThoai.Text.ToString();
            string tongiao = txt_TonGiao.Text.ToString();

            nkttDto = new NhanKhauTamTruDTO(manghenghiep, hoten, gioitinh, dantoc, hochieu, ngaycap, ngaysinh, nguyenquan, noicap, noisinh, quoctich, sdt, tongiao, manhankhautamtru, madinhdanh, diachithuongtru, sosotamtru);
            if (nkttBus.Add(nkttDto))
            {
                MessageBox.Show("Thêm nhân khẩu tạm trú "+hoten+" thành công");
                ResetValueInput();
                LoadDataGridView();

                //Tạo mã tự động
                GenerateAllID();

                if (count == 0) //người đầu tiên làm chủ hộ
                {
                    machuho = manhankhautamtru;
                }
            }
            else
            {
                MessageBox.Show("Thêm nhân khẩu tạm trú " + hoten + "thất bại");
            }
        }


        //Sửa thông tin nhân khẩu tạm trú
        private void btnSua_Click(object sender, EventArgs e)
        {

            string manhankhautamtru = txt_MaNKTamTru.Text.ToString(); //Lấy mã nhân khẩu tạm trú
            string madinhdanh = txt_MaDinhDanh.Text.ToString(); //Lấy mã định danh
            string hoten = txt_HoTen.Text.ToString();

            if (manhankhautamtru == "" || madinhdanh == "" || hoten=="")
            {
                MessageBox.Show("Cần có mã định danh và họ tên để thực hiện chức năng này");
                return;
            }
            SoTamTruBUS sotamtruBus = new SoTamTruBUS();
            if (!sotamtruBus.Existed_NhanKhau(madinhdanh))
            {
                MessageBox.Show("Nhân khẩu tạm trú " + hoten + " không tồn tại !");
                return;
            }

            //Nhập không đầy đủ
            if (!isInputTrueThongTinTamTru())
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin!");
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Bạn có muốn cập nhật thông tin nhân khẩu: "+hoten+" không?", "Thông báo", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string diachithuongtru = cbb_DC_XaPhuong.Text + "," + cbb_DC_QuanHuyen.Text + "," + cbb_DC_TinhThanh.Text;
                string sosotamtru = txt_SoSoTamTru.Text.ToString();
                string manghenghiep = nkttBus.GetMaNgheNghiep(cbbNgheNghiep.Text);

                string gioitinh = "";
                if (rdNam.Checked) gioitinh = "nam";
                else gioitinh = "nu";

                string dantoc = txt_DanToc.Text.ToString();
                string hochieu = txt_HoChieu.Text.ToString();
                DateTime ngaycap = dt_NgayCapHoChieu.Value.Date;
                DateTime ngaysinh = dt_NgaySinh.Value.Date;
                string nguyenquan = cbb_NQ_XaPhuong.Text + "," + cbb_NQ_QuanHuyen.Text + "," + cbb_NQ_TinhThanhPho.Text;
                string noicap = txt_NoiCap.Text.ToString();
                string noisinh = cbb_NS_XaPhuong.Text + "," + cbb_NS_QuanHuyen.Text + "," + cbb_NS_TinhThanh.Text;
                string quoctich = txt_QuocTich.Text.ToString();
                string sdt = txt_SoDienThoai.Text.ToString();
                string tongiao = txt_TonGiao.Text.ToString();

                nkttDto = new NhanKhauTamTruDTO(manghenghiep, hoten, gioitinh, dantoc, hochieu, ngaycap, ngaysinh, nguyenquan, noicap, noisinh, quoctich, sdt, tongiao, manhankhautamtru, madinhdanh, diachithuongtru, sosotamtru);
                if (nkttBus.Update(nkttDto, 0))
                {
                    MessageBox.Show("Cập nhật thông tin nhân khẩu "+hoten+" thành công");
                    LoadDataGridView();
                    ResetValueInput();
                    GenerateAllID();
                    dataGridView1.DataSource = nkttBus.TimKiem(madinhdanh).Tables[0];
                }
                else
                {
                    MessageBox.Show("Cập nhật thông tin nhân khẩu "+hoten+" thất bại");
                }
            }
            else if (dialogResult == DialogResult.No)
            {
                
            } 
           
        }


        //Xóa một nhân khẩu tạm trú
        private void btnXoa_Click(object sender, EventArgs e)
        {
            string madinhdanh = txt_MaDinhDanh.Text.ToString();
            string hoten = txt_HoTen.Text.ToString();

            if (madinhdanh == "")
            {
                MessageBox.Show("Cần mã định danh để thực hiện chức năng này");
                return;
            }

            SoTamTruBUS sotamtruBus = new SoTamTruBUS();
            if (!sotamtruBus.Existed_NhanKhau(madinhdanh))
            {
                MessageBox.Show("Nhân khẩu tạm trú "+hoten+" không tồn tại !");
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Bạn có muốn hủy tạm trú cho nhân khẩu: "+hoten+" ?", "Thông báo", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (nkttBus.XoaNKTT(madinhdanh))
                {
                    MessageBox.Show("Hủy tạm trú nhân khẩu : "+hoten+" thành công!");
                    ResetValueInput();
                    LoadDataGridView();
                    GenerateAllID();
                }
                else
                {
                    MessageBox.Show("Hủy tạm trú nhân khẩu : " + hoten + " thất bại!");
                }
            }
            else if (dialogResult == DialogResult.No)
            {
            }

        }

        //Lấy thông tin từ datagridview vào input
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

            string gt = nhankhautamtru.GioiTinh;
            if ( gt == "nam")
                this.rdNam.Checked = true;
            else
                this.rdNu.Checked = true;


            txt_SoSoTamTru.Text = nhankhautamtru.SoSoTamTru;
            dt_NgaySinh.Value = nhankhautamtru.NgaySinh;
            txt_DanToc.Text = nhankhautamtru.DanToc;
            txt_QuocTich.Text = nhankhautamtru.QuocTich;
            txt_TonGiao.Text = nhankhautamtru.TonGiao;
            cbbNgheNghiep.SelectedIndex = cbbNgheNghiep.Items.IndexOf(nkttBus.GetTenNgheNghiep(nhankhautamtru.MaNgheNghiep));
            txt_SoDienThoai.Text = nhankhautamtru.SDT;
            txt_HoChieu.Text = nhankhautamtru.HoChieu;
            dt_NgayCapHoChieu.Value = nhankhautamtru.NgayCap;
            txt_NoiCap.Text = nhankhautamtru.NoiCap;
            txt_SoSoTamTru.Text = nhankhautamtru.SoSoTamTru;
            txt_MaDinhDanh.Text = nhankhautamtru.MaDinhDanh;

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

            //Hiễn thị tiền án tiền sự
            LoadDataGridViewTienAN();
            LoadDataGridViewTieuSu();
            ResetInputTienAn();
            ResetInputTieuSu();
            txt_MaTienAn.Text = GenerateMaTienAnTienSu();
            txt_MaTieuSu.Text = GenerateMaTieuSu();
        }

        private void btnXong_Click(object sender, EventArgs e)
        {
            Machuho = machuho;
        }


        //Tìm nhân khẩu tạm trú qua mã định danh
        private void btnTim_Click(object sender, EventArgs e)
        {
            string madinhdanh = txt_MaDinhDanh.Text.ToString();
            if (madinhdanh == "")
            {
                MessageBox.Show("Cần mã định danh để thực hiện chức năng này");
                return;
            }

            SoTamTruBUS sotamtruBus = new SoTamTruBUS();
            if (!sotamtruBus.Existed_NhanKhau(madinhdanh))
            {
                MessageBox.Show("Nhân khẩu tạm trú có mã định danh: "+madinhdanh+" không tồn tại!");
                return;
            }

            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.DataSource = nkttBus.TimKiem(madinhdanh).Tables[0];
        }



        /// <summary>
        /// XỬ LÍ VỚI GROUP TIỀN ÁN TIỀN SỰ
        /// </summary>
        

        private void LoadDataGridViewTienAN()
        {
            dtGV_TienAnTienSu.DataSource = null;
            dtGV_TienAnTienSu.Rows.Clear();
            dtGV_TienAnTienSu.DataSource = nkttBus.GetTienAnTienSu(txt_MaDinhDanh.Text).Tables[0];
        }

        private void ResetInputTienAn()
        {
            txt_MaTienAn.Clear();
            txt_BanAn.Clear();
            txtToiDanh.Clear();
            txt_HinhPhat.Clear();
            txtGhiChu.Clear();
            dtNgayPhat.ResetText();
            txt_MaTienAn.Text = GenerateMaTienAnTienSu();
        }


        private void btnThemTienAn_Click(object sender, EventArgs e)
        {
            string matienan = txt_MaTienAn.Text.ToString();
            string madinhdanh = txt_MaDinhDanh.Text.ToString();

            if (matienan == "" || madinhdanh == "")
            {
                MessageBox.Show("Cần có mã tiền án tiền sự, mã định danh để thực hiện chức năng này");
                return;
            }

            SoTamTruBUS sttBus = new SoTamTruBUS();
            if (!sttBus.Existed_NhanKhau(madinhdanh))
            {
                MessageBox.Show("Cần tạo thông tin tạm trú cho nhân khẩu có mã định danh:" + madinhdanh + " trước khi thêm tiền án tiền sự");
                return;
            }

            //Nhập không đầy đủ
            if (!isInputTrueTienAn())
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin!");
                return;
            }


            string banan = txt_BanAn.Text.ToString();
            string toidanh = txtToiDanh.Text.ToString();
            string hinhphat = txt_HinhPhat.Text.ToString();
            DateTime ngayphat = dtNgayPhat.Value.Date;
            string ghichu = txtGhiChu.Text.ToString();

            TienAnTienSuDTO tienan = new TienAnTienSuDTO(matienan, madinhdanh,banan,toidanh,hinhphat,ngayphat,ghichu);

            TienAnTienSuBUS tienanbus = new TienAnTienSuBUS();
            if (tienanbus.Add(tienan))
            {
                MessageBox.Show("Thêm tiền án tiền sự "+matienan+" cho nhân khẩu " + txt_HoTen.Text.ToString() + " thành công!");
                ResetInputTienAn();
                LoadDataGridViewTienAN();             
            }
            else
            {
                MessageBox.Show("Thêm tiền án tiền sự "+matienan+" cho nhân khẩu " + txt_HoTen.Text.ToString() + " thất bại!");
            }

        }

        //Click cell datagridview Tiền án
        private void dtGV_TienAnTienSu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string matienan = dtGV_TienAnTienSu.Rows[e.RowIndex].Cells[0].Value.ToString();
            string madinhdanh = txt_MaDinhDanh.Text.ToString();
            string banan = dtGV_TienAnTienSu.Rows[e.RowIndex].Cells[1].Value.ToString();
            string toidanh = dtGV_TienAnTienSu.Rows[e.RowIndex].Cells[2].Value.ToString();
            string hinhphat = dtGV_TienAnTienSu.Rows[e.RowIndex].Cells[3].Value.ToString();
            DateTime ngayphat = Convert.ToDateTime(dtGV_TienAnTienSu.Rows[e.RowIndex].Cells[4].Value.ToString());
            string ghichu = dtGV_TienAnTienSu.Rows[e.RowIndex].Cells[5].Value.ToString();

            TienAnTienSuDTO tienan = new TienAnTienSuDTO(matienan, madinhdanh, banan, toidanh, hinhphat, ngayphat, ghichu);

            txt_MaTienAn.Text = tienan.MaTienAnTienSu;
            txt_BanAn.Text = tienan.BanAn;
            txtToiDanh.Text = tienan.ToiDanh;
            txt_HinhPhat.Text = tienan.HinhPhat;
            dtNgayPhat.Value = tienan.NgayPhat;
            txtGhiChu.Text = tienan.GhiChu;

        }



        private void btnXoaTienAn_Click(object sender, EventArgs e)
        {
            string matienan = txt_MaTienAn.Text.ToString();

            if (matienan == "")
            {
                MessageBox.Show("Cần có mã tiền án tiền sự để thực hiện chức năng này");
                return;
            }

            SoTamTruBUS sttBus = new SoTamTruBUS();
            if (!sttBus.Existed_TienAn(matienan))
            {
                MessageBox.Show("Mã tiền án " + matienan + "không tồn tại trong hệ thống!");
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Bạn có muốn xóa tiền án tiền sự "+matienan+" của nhân khẩu " + txt_HoTen.Text.ToString() + " không?", "Thông báo", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (nkttBus.DeleteTienAnTienSu(matienan))
                {
                    MessageBox.Show("Xóa tiền án tiền sự "+matienan+" cho nhân khẩu " + txt_HoTen.Text.ToString() + " thành công!");
                    LoadDataGridViewTienAN();
                    ResetInputTienAn();
                }
                else
                {
                    MessageBox.Show("Xóa tiền án tiền sự "+matienan+" cho nhân khẩu " + txt_HoTen.Text.ToString() + " thất bại!");
                }
            }
            else if (dialogResult == DialogResult.No)
            {
            }


        }
        
  
        private void btnSuaTienAn_Click(object sender, EventArgs e)
        {
            string matienan = txt_MaTienAn.Text.ToString();

            if (matienan == "")
            {
                MessageBox.Show("Cần có mã tiền án tiền sự để thực hiện chức năng này");
                return;
            }

            SoTamTruBUS sttBus = new SoTamTruBUS();
            if (!sttBus.Existed_TienAn(matienan))
            {
                MessageBox.Show("Mã tiền án " + matienan + "không tồn tại trong hệ thống!");
                return;
            }

            //Nhập không đầy đủ
            if (!isInputTrueTienAn())
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin!");
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Bạn có muốn sửa tiền án tiền sự "+matienan+" của nhân khẩu " + txt_HoTen.Text.ToString() + " không?", "Thông báo", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string madinhdanh = txt_MaDinhDanh.Text.ToString();
                string banan = txt_BanAn.Text.ToString();
                string toidanh = txtToiDanh.Text.ToString();
                string hinhphat = txt_HinhPhat.Text.ToString();
                DateTime ngayphat = dtNgayPhat.Value.Date;
                string ghichu = txtGhiChu.Text.ToString();

                TienAnTienSuDTO tienan = new TienAnTienSuDTO(matienan, madinhdanh, banan, toidanh, hinhphat, ngayphat, ghichu);

                TienAnTienSuBUS tienanbus = new TienAnTienSuBUS();
                if (tienanbus.Update(tienan, 0))
                {
                    MessageBox.Show("Sửa tiền án tiền sự "+matienan+" cho nhân khẩu " + txt_HoTen.Text.ToString() + " thành công!");
                    ResetInputTienAn();
                    LoadDataGridViewTienAN();
                }
                else
                {
                    MessageBox.Show("Sửa tiền án tiền sự "+matienan+" cho nhân khẩu " + txt_HoTen.Text.ToString() + " thất bại!");
                }
            }
            else if (dialogResult == DialogResult.No)
            {
            }
        }



        /// <summary>
        /// XỬ LÍ VỚI TIỂU SỬ
        /// </summary>
        /// 
        public void LoadDataGridViewTieuSu()
        {
            dtGV_TieuSu.DataSource = null;
            dtGV_TieuSu.Rows.Clear();
            dtGV_TieuSu.DataSource = nkttBus.GetTieuSu(txt_MaDinhDanh.Text).Tables[0];
        }

        public void ResetInputTieuSu()
        {
            txt_MaTieuSu.Clear();
            dtThoiGianBatDau.ResetText();
            dtThoiGianKetThuc.ResetText();
            txt_NoiLamViec.Clear();
            txt_MaTieuSu.Text = GenerateMaTieuSu();
        }


        //Combox nghề nghiệp & tỉnh thành event
        private void cbb_TieuSu_TinhThanh_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbb_TieuSu_QuanHuyen.DataSource = nkttBus.GetListQuanHuyen(cbb_TieuSu_TinhThanh.Text);
        }

        private void cbb_TieuSu_QuanHuyen_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbb_TieuSu_XaPhuong.DataSource = nkttBus.GetListXaPhuong(cbb_TieuSu_QuanHuyen.Text);
        }

        private void btnThemTieuSu_Click(object sender, EventArgs e)
        {
            string matieusu = txt_MaTieuSu.Text.ToString();
            string madinhdanh = txt_MaDinhDanh.Text.ToString();
            DateTime thoigianbatdau = dtThoiGianBatDau.Value.Date;
            DateTime thoigianketthuc = dtThoiGianKetThuc.Value.Date;
            string choo = txt_TieuSu_SoNha.Text.ToString() + "," + cbb_TieuSu_XaPhuong.Text.ToString() + "," + cbb_TieuSu_QuanHuyen.Text.ToString() + "," + cbb_TieuSu_TinhThanh.Text.ToString();
            string manghenghiep = nkttBus.GetMaNgheNghiep(cbb_TieuSu_NgheNghiep.Text.ToString());
            string noilamviec = txt_NoiLamViec.Text.ToString();

            if(matieusu=="")
            {
                MessageBox.Show("Cần có mã tiểu sử để thực hiện chức năng này");
                return;
            }

            SoTamTruBUS sttBus = new SoTamTruBUS();
            if (!sttBus.Existed_NhanKhau(madinhdanh))
            {
                MessageBox.Show("Cần tạo thông tin tạm trú cho nhân khẩu có mã định danh:" + madinhdanh + " trước khi thêm tiểu sử");
                return;
            }


            //Nhập không đầy đủ
            if (!isInputTrueTieuSu())
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin!");
                return;
            }

            TieuSuDTO tieusu = new TieuSuDTO(matieusu, madinhdanh, thoigianbatdau, thoigianketthuc, choo, manghenghiep, noilamviec);

            TieuSuBUS tieusuBus = new TieuSuBUS();

            if (tieusuBus.Add(tieusu))
            {
                MessageBox.Show("Thêm tiểu sử "+matieusu+" cho nhân khẩu " + txt_HoTen.Text.ToString() + " thành công !");
                LoadDataGridViewTieuSu();
                ResetInputTieuSu();
            }
            else
            {
                MessageBox.Show("Thêm tiểu sử "+matieusu+" cho nhân khẩu " + txt_HoTen.Text.ToString() + " thất bại !");
            }

        }

        private void dtGV_TieuSu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string matieusu = dtGV_TieuSu.Rows[e.RowIndex].Cells[0].Value.ToString();
            string madinhdanh = txt_MaDinhDanh.Text.ToString();
            DateTime thoigianbatdau = Convert.ToDateTime(dtGV_TieuSu.Rows[e.RowIndex].Cells[1].Value.ToString());
            DateTime thoigianketthuc = Convert.ToDateTime(dtGV_TieuSu.Rows[e.RowIndex].Cells[2].Value.ToString());
            string choo = dtGV_TieuSu.Rows[e.RowIndex].Cells[3].Value.ToString();
            string manghenghiep = dtGV_TieuSu.Rows[e.RowIndex].Cells[4].Value.ToString();
            string noilamviec = dtGV_TieuSu.Rows[e.RowIndex].Cells[5].Value.ToString();


            TieuSuDTO tieusu = new TieuSuDTO(matieusu, madinhdanh, thoigianbatdau, thoigianketthuc, choo, manghenghiep, noilamviec);

        
            cbb_TieuSu_NgheNghiep.SelectedIndex = cbb_TieuSu_NgheNghiep.Items.IndexOf(nkttBus.GetTenNgheNghiep(tieusu.MaNgheNghiep));

            txt_MaTieuSu.Text = tieusu.MaTieuSu;
            dtThoiGianBatDau.Value = tieusu.ThoiGianBatDau;
            dtThoiGianKetThuc.Value = tieusu.ThoiGianKetThuc;
            txt_NoiLamViec.Text = tieusu.NoiLamViec;

            string[] chooArray = nkttBus.SplitDiaChi(tieusu.ChoO);
            cbb_TieuSu_TinhThanh.SelectedIndex = cbb_TieuSu_TinhThanh.Items.IndexOf(chooArray[3]);
            cbb_TieuSu_QuanHuyen.SelectedIndex = cbb_TieuSu_QuanHuyen.Items.IndexOf(chooArray[2]);
            cbb_TieuSu_XaPhuong.SelectedIndex = cbb_TieuSu_XaPhuong.Items.IndexOf(chooArray[1]);
            txt_TieuSu_SoNha.Text = chooArray[0];
        }


        private void btnXoaTieuSu_Click(object sender, EventArgs e)
        {
            string matieusu = txt_MaTieuSu.Text.ToString();
            if (matieusu == "")
            {
                MessageBox.Show("Cần có mã tiểu sử để thực hiện chức năng này");
                return;
            }
            SoTamTruBUS sttBus = new SoTamTruBUS();
            if (!sttBus.Existed_TieuSu(matieusu))
            {
                MessageBox.Show("Tiểu sử có mã " + matieusu + "chưa có trong hệ thống");
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Bạn có muốn xóa tiểu sử "+matieusu+" cho nhân khẩu " + txt_HoTen.Text.ToString() + " không?", "Thông báo", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (nkttBus.DeleteTieuSu(matieusu))
                {
                    MessageBox.Show("Xóa tiểu sử "+matieusu+" cho nhân khẩu " + txt_HoTen.Text.ToString() + " thành công!");
                    LoadDataGridViewTieuSu();
                    ResetInputTieuSu();
                }
                else
                {
                    MessageBox.Show("Xóa tiểu sử "+matieusu+" cho nhân khẩu " + txt_HoTen.Text.ToString() + " thất bại!");
                }
            }
            else if (dialogResult == DialogResult.No)
            {
            }
        }

        private void btnSuaTieuSu_Click(object sender, EventArgs e)
        {
            string matieusu = txt_MaTieuSu.Text.ToString();

            if (matieusu == "")
            {
                MessageBox.Show("Cần có mã tiểu sử để thực hiện chức năng này");
                return;
            }

            SoTamTruBUS sttBus = new SoTamTruBUS();
            if (!sttBus.Existed_TieuSu(matieusu))
            {
                MessageBox.Show("Tiểu sử có mã " + matieusu + "chưa có trong hệ thống");
                return;
            }

            //Nhập không đầy đủ
            if (!isInputTrueTieuSu())
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin!");
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Bạn có muốn sửa tiểu sử "+matieusu+" của nhân khẩu " + txt_HoTen.Text.ToString() + " không?", "Thông báo", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string madinhdanh = txt_MaDinhDanh.Text.ToString();
                DateTime thoigianbatdau = dtThoiGianBatDau.Value.Date;
                DateTime thoigianketthuc = dtThoiGianKetThuc.Value.Date;
                string choo = txt_TieuSu_SoNha.Text.ToString() + "," + cbb_TieuSu_XaPhuong.Text.ToString() + "," + cbb_TieuSu_QuanHuyen.Text.ToString() + "," + cbb_TieuSu_TinhThanh.Text.ToString();
                string manghenghiep = nkttBus.GetMaNgheNghiep(cbb_TieuSu_NgheNghiep.Text.ToString());
                string noilamviec = txt_NoiLamViec.Text.ToString();

                TieuSuDTO tieusu = new TieuSuDTO(matieusu, madinhdanh, thoigianbatdau, thoigianketthuc, choo, manghenghiep, noilamviec);

                TieuSuBUS tieusuBus = new TieuSuBUS();

                if (tieusuBus.Update(tieusu, 0))
                {
                    MessageBox.Show("Sửa tiểu sử "+matieusu+" cho nhân khẩu "+txt_HoTen.Text.ToString()+" thành công !");
                    LoadDataGridViewTieuSu();
                    ResetInputTieuSu();
                }
                else
                {
                    MessageBox.Show("Sửa tiểu sử "+matieusu+" cho nhân khẩu "+txt_HoTen.Text.ToString()+" thất bại !");
                }
            }
            else if (dialogResult == DialogResult.No)
            {
            }
        }




        /// <summary>
        /// Phát sinh mã định danh ở đây
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        public string GioiTinh()
        {
            if (rdNam.Checked) return "nam";
            else return "nu";
        }

        public void TaoMaDinhDanh()
        {
            string gt = GioiTinh();
            string year = dt_NgaySinh.Value.Year.ToString();
            sotamtru = new SoTamTruBUS();
            txt_MaDinhDanh.Text = sotamtru.GenerateMaDinhDanh(gt, year);
        }

        private void rdNam_CheckedChanged(object sender, EventArgs e)
        {
            TaoMaDinhDanh();
        }

        private void rdNu_CheckedChanged(object sender, EventArgs e)
        {
            TaoMaDinhDanh();
        }

        private void dt_NgaySinh_ValueChanged(object sender, EventArgs e)
        {
            TaoMaDinhDanh();
        }
    }
}
