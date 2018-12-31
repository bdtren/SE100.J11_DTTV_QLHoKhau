using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BUS;
using DAO;


namespace GUI
{
    public partial class fr_CBDuLieu : DevExpress.XtraEditors.XtraForm
    {
        CanBoBUS canbobus;
        CanBoDTO canbo;
        HocSinhSinhVienDTO hssv;
        HocSinhSinhVienBUS hssvbus;
        NhanKhauBUS nhankhaubus;
        NhanKhau nhankhau;
        TienAnTienSuDTO tienantiensu;
        TienAnTienSuBUS tienantiensubus;
        TieuSuDTO tieusu;
        TieuSuBUS tieusubus;
      //  NgheNghiepDTO nghenghiep;
    //    NgheNghiepBUS nghenghiepbus;
        QuanHuyenDTO quanhuyen;
        QuanHuyenBUS quanhuyenbus;
        TinhThanhPhoDTO tinhthanhpho;
        TinhThanhPhoBUS tinhthanhphobus;
        XaPhuongThiTranDTO xaphuongthitran;
        XaPhuongThiTranBUS xaphuongthitranbus;
        NhanKhauTamTruDTO nktamtru;
        NhanKhauTamTruBUS nktamtrubus;
        NhanKhauThuongTruDTO nkthuongtru;
        NhanKhauThuongTruBUS nkthuongtrubus;
        SoHoKhauDTO sohokhau;
        SoHoKhauBUS sohokhaubus;
        SoTamTruDTO sotamtru;
        SoTamTruBUS sotamtrubus;


        public fr_CBDuLieu()
        {
            InitializeComponent();
            canbobus = new CanBoBUS();
            hssvbus = new HocSinhSinhVienBUS();
            nhankhaubus = new NhanKhauBUS();
            tienantiensubus = new TienAnTienSuBUS();
            tieusubus = new TieuSuBUS();
           // nghenghiepbus = new NgheNghiepBUS();
            quanhuyenbus = new QuanHuyenBUS();
            tinhthanhphobus = new TinhThanhPhoBUS();
            xaphuongthitranbus = new XaPhuongThiTranBUS();
            nktamtrubus = new NhanKhauTamTruBUS();
            nkthuongtrubus = new NhanKhauThuongTruBUS();
            sohokhaubus = new SoHoKhauBUS();
            sotamtrubus = new SoTamTruBUS();


            DataSet tables = DBConnection<int>.getData("show tables from qlhk");
            foreach (DataRow item in tables.Tables[0].Rows)
            {
                comboBox1.Items.Add(item[0].ToString());
            }
        }

        private void LoadData()
        {
            switch (comboBox1.Text)
            {
                case "canbo":
                    try
                    {
                        dataGridView1.DataSource = canbobus.GetAll().Tables["canbo"];
                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {
                            DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                            dataGridView1[dataGridView1.ColumnCount - 1, i] = linkCell;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;
                case "hocsinhsinhvien":
                    try
                    {
                        dataGridView1.DataSource = hssvbus.GetAll().Tables["hocsinhsinhvien"];
                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {
                            DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                            dataGridView1[dataGridView1.ColumnCount - 1, i] = linkCell;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;

                case "nhankhau":
                    try
                    {
                        dataGridView1.DataSource = nhankhaubus.GetAll().Tables["nhankhau"];
                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {
                            DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                            dataGridView1[dataGridView1.ColumnCount - 1, i] = linkCell;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;

                case "nhankhautamvang":

                    break;
                case "nhankhautamtru":
                    try
                    {
                        dataGridView1.DataSource = nktamtrubus.GetAll().Tables["nhankhautamtru"];
                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {
                            DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                            dataGridView1[dataGridView1.ColumnCount - 1, i] = linkCell;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;
                case "nhankhauthuongtru":
                    try
                    {
                        dataGridView1.DataSource = nkthuongtrubus.GetAll().Tables["nhankhauthuongtru"];
                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {
                            DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                            dataGridView1[dataGridView1.ColumnCount - 1, i] = linkCell;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;
                case "quanhuyen":
                    try
                    {
                        dataGridView1.DataSource = quanhuyenbus.GetAll().Tables["quanhuyen"];
                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {
                            DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                            dataGridView1[dataGridView1.ColumnCount - 1, i] = linkCell;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;
                case "sohokhau":
                    try
                    {
                        dataGridView1.DataSource = sohokhaubus.GetAll().Tables["sohokhau"];
                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {
                            DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                            dataGridView1[dataGridView1.ColumnCount - 1, i] = linkCell;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;
                case "sotamtru":
                    try
                    {
                        dataGridView1.DataSource = sotamtrubus.GetAll().Tables["sotamtru"];
                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {
                            DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                            dataGridView1[dataGridView1.ColumnCount - 1, i] = linkCell;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;
                case "tienantiensu":
                    try
                    {
                        dataGridView1.DataSource = tienantiensubus.GetAll().Tables["tienantiensu"];
                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {
                            DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                            dataGridView1[dataGridView1.ColumnCount - 1, i] = linkCell;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;
                case "tieusu":
                    try
                    {
                        dataGridView1.DataSource = tieusubus.GetAll().Tables["tieusu"];
                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {
                            DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                            dataGridView1[dataGridView1.ColumnCount - 1, i] = linkCell;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;
                case "tinhthanhpho":
                    try
                    {
                        dataGridView1.DataSource = tinhthanhphobus.GetAll().Tables["tinhthanhpho"];
                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {
                            DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                            dataGridView1[dataGridView1.ColumnCount - 1, i] = linkCell;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;
                case "xaphuongthitran":
                    try
                    {
                        dataGridView1.DataSource = xaphuongthitranbus.GetAll().Tables["xaphuongthitran"];
                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {
                            DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                            dataGridView1[dataGridView1.ColumnCount - 1, i] = linkCell;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;
            }
            dataGridView1.DefaultCellStyle.ForeColor = Color.Black;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          /* switch (comboBox1.Text)
            {
                case "hocsinhsinhvien":
                    {
                        try
                        {
                            if (e.ColumnIndex == dataGridView1.ColumnCount - 1)
                            {
                                string Task = dataGridView1.Rows[e.RowIndex].Cells[dataGridView1.ColumnCount - 1].Value.ToString();
                                if (Task == "Delete")
                                {
                                    if (MessageBox.Show("Bạn có chắc chắm muốn xóa không?", "Đang xóa...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                    {
                                        int rowIndex = e.RowIndex;
                                        hssvbus.Delete(rowIndex);
                                    }
                                }
                                else if (Task == "Insert")
                                {
                                    int row = dataGridView1.Rows.Count - 2;
                                    string str_madinhdanh = dataGridView1.Rows[row].Cells["madinhdanh"].Value.ToString();
                                    string str_mssv = dataGridView1.Rows[row].Cells["mssv"].Value.ToString();
                                    string str_truong = dataGridView1.Rows[row].Cells["truong"].Value.ToString();
                                    string str_diachithuongtru = dataGridView1.Rows[row].Cells["diachithuongtru"].Value.ToString();
                                    string str_tgbdtt = dataGridView1.Rows[row].Cells["thoigianbatdautamtruthuongtru"].Value.ToString();
                                    DateTime date_tgbdtt = DateTime.Parse(str_tgbdtt);
                                    string str_tgkttt = dataGridView1.Rows[row].Cells["thoigianketthuctamtruthuongtru"].Value.ToString();
                                    DateTime date_tgkttt = DateTime.Parse(str_tgkttt);
                                    string str_vipham = dataGridView1.Rows[row].Cells["vipham"].Value.ToString();
                                    hssv = new HocSinhSinhVienDTO(str_mssv, str_madinhdanh, str_truong, str_diachithuongtru, date_tgbdtt, date_tgkttt, str_vipham);
                                    hssvbus.Add_Table(hssv);
                                    dataGridView1.Rows.RemoveAt(dataGridView1.Rows.Count - 2);
                                    dataGridView1.Rows[e.RowIndex].Cells[dataGridView1.ColumnCount - 1].Value = "Delete";



                                }
                                else if (Task == "Update")
                                {
                                    int row = e.RowIndex;
                                    string str_madinhdanh = dataGridView1.Rows[row].Cells["madinhdanh"].Value.ToString();
                                    string str_mssv = dataGridView1.Rows[row].Cells["mssv"].Value.ToString();
                                    string str_truong = dataGridView1.Rows[row].Cells["truong"].Value.ToString();
                                    string str_diachithuongtru = dataGridView1.Rows[row].Cells["diachithuongtru"].Value.ToString();
                                    string str_tgbdtt = dataGridView1.Rows[row].Cells["thoigianbatdautamtruthuongtru"].Value.ToString();
                                    DateTime date_tgbdtt = DateTime.Parse(str_tgbdtt);
                                    string str_tgkttt = dataGridView1.Rows[row].Cells["thoigianketthuctamtruthuongtru"].Value.ToString();
                                    DateTime date_tgkttt = DateTime.Parse(str_tgkttt);
                                    string str_vipham = dataGridView1.Rows[row].Cells["vipham"].Value.ToString();
                                    hssv = new HocSinhSinhVienDTO(str_mssv, str_madinhdanh, str_truong, str_diachithuongtru, date_tgbdtt, date_tgkttt, str_vipham);
                                    hssvbus.Update(hssv, row);
                                    LoadData();
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    break;
                case "nghenghiep":
                    try
                    {
                        if (e.ColumnIndex == dataGridView1.ColumnCount - 1)
                        {
                            string Task = dataGridView1.Rows[e.RowIndex].Cells[dataGridView1.ColumnCount - 1].Value.ToString();
                            if (Task == "Delete")
                            {
                                if (MessageBox.Show("Bạn có chắc chắm muốn xóa không?", "Đang xóa...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    int rowIndex = e.RowIndex;
                                    nghenghiepbus.Delete(rowIndex);
                                }
                            }
                            else if (Task == "Insert")
                            {
                                int row = dataGridView1.Rows.Count - 2;
                                string str_manghenghiep = dataGridView1.Rows[row].Cells["manghenghiep"].Value.ToString();
                                string str_tennghenghiep = dataGridView1.Rows[row].Cells["tennghenghiep"].Value.ToString();
                                nghenghiep = new NgheNghiepDTO(str_manghenghiep, str_tennghenghiep);
                                nghenghiepbus.Add_Table(nghenghiep);
                                dataGridView1.Rows.RemoveAt(dataGridView1.Rows.Count - 2);
                                dataGridView1.Rows[e.RowIndex].Cells[dataGridView1.ColumnCount - 1].Value = "Delete";


                            }
                            else if (Task == "Update")
                            {
                                int row = e.RowIndex;
                                string str_manghenghiep = dataGridView1.Rows[row].Cells["manghenghiep"].Value.ToString();
                                string str_tennghenghiep = dataGridView1.Rows[row].Cells["tennghenghiep"].Value.ToString();
                                nghenghiep = new NgheNghiepDTO(str_manghenghiep, str_tennghenghiep);
                                nghenghiepbus.Update(nghenghiep, row);
                                LoadData();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;
                case "nhankhau":
                    try
                    {
                        if (e.ColumnIndex == dataGridView1.ColumnCount - 1)
                        {
                            string Task = dataGridView1.Rows[e.RowIndex].Cells[dataGridView1.ColumnCount - 1].Value.ToString();
                            if (Task == "Delete")
                            {
                                if (MessageBox.Show("Bạn có chắc chắm muốn xóa không?", "Đang xóa...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    int rowIndex = e.RowIndex;
                                    nhankhaubus.Delete(rowIndex);
                                }
                            }
                            else if (Task == "Insert")
                            {
                                int row = dataGridView1.Rows.Count - 2;
                                string str_madinhdanh = dataGridView1.Rows[row].Cells["madinhdanh"].Value.ToString();
                                string str_manghenghiep = dataGridView1.Rows[row].Cells["manghenghiep"].Value.ToString();
                                string str_hoten = dataGridView1.Rows[row].Cells["hoten"].Value.ToString();
                                string str_gioitinh = dataGridView1.Rows[row].Cells["gioitinh"].Value.ToString();
                                string str_dantoc = dataGridView1.Rows[row].Cells["dantoc"].Value.ToString();
                                string str_hochieu = dataGridView1.Rows[row].Cells["hochieu"].Value.ToString();

                                string str_ngaycap = dataGridView1.Rows[row].Cells["ngaycap"].Value.ToString();
                                DateTime date_ngaycap = DateTime.Parse(str_ngaycap);
                                string str_ngaysinh = dataGridView1.Rows[row].Cells["ngaysinh"].Value.ToString();
                                DateTime date_ngaysinh = DateTime.Parse(str_ngaysinh);
                                string str_nguyenquan = dataGridView1.Rows[row].Cells["nguyenquan"].Value.ToString();
                                string str_noicap = dataGridView1.Rows[row].Cells["noicap"].Value.ToString();
                                string str_noisinh = dataGridView1.Rows[row].Cells["noisinh"].Value.ToString();
                                string str_quoctich = dataGridView1.Rows[row].Cells["quoctich"].Value.ToString();
                                string str_sdt = dataGridView1.Rows[row].Cells["sdt"].Value.ToString();
                                string str_tongiao = dataGridView1.Rows[row].Cells["tongiao"].Value.ToString();
                                nhankhau = new NhanKhau(str_madinhdanh, str_manghenghiep, str_hoten, str_gioitinh, str_dantoc, str_hochieu, date_ngaycap, date_ngaysinh, str_nguyenquan, str_noicap, str_noisinh, str_quoctich, str_sdt, str_tongiao);
                                nhankhaubus.Add_Table(nhankhau);
                                dataGridView1.Rows.RemoveAt(dataGridView1.Rows.Count - 2);
                                dataGridView1.Rows[e.RowIndex].Cells[dataGridView1.ColumnCount - 1].Value = "Delete";


                            }
                            else if (Task == "Update")
                            {
                                int row = e.RowIndex;
                                string str_madinhdanh = dataGridView1.Rows[row].Cells["madinhdanh"].Value.ToString();
                                string str_manghenghiep = dataGridView1.Rows[row].Cells["manghenghiep"].Value.ToString();
                                string str_hoten = dataGridView1.Rows[row].Cells["hoten"].Value.ToString();
                                string str_gioitinh = dataGridView1.Rows[row].Cells["gioitinh"].Value.ToString();
                                string str_dantoc = dataGridView1.Rows[row].Cells["dantoc"].Value.ToString();
                                string str_hochieu = dataGridView1.Rows[row].Cells["hochieu"].Value.ToString();
                                string str_ngaycap = dataGridView1.Rows[row].Cells["ngaycap"].Value.ToString();
                                DateTime date_ngaycap = DateTime.Parse(str_ngaycap);
                                string str_ngaysinh = dataGridView1.Rows[row].Cells["ngaysinh"].Value.ToString();
                                DateTime date_ngaysinh = DateTime.Parse(str_ngaysinh);
                                string str_nguyenquan = dataGridView1.Rows[row].Cells["nguyenquan"].Value.ToString();
                                string str_noicap = dataGridView1.Rows[row].Cells["noicap"].Value.ToString();
                                string str_noisinh = dataGridView1.Rows[row].Cells["noisinh"].Value.ToString();

                                string str_quoctich = dataGridView1.Rows[row].Cells["quoctich"].Value.ToString();
                                string str_sdt = dataGridView1.Rows[row].Cells["sdt"].Value.ToString();
                                string str_tongiao = dataGridView1.Rows[row].Cells["tongiao"].Value.ToString();
                                nhankhau = new NhanKhau(str_madinhdanh, str_manghenghiep, str_hoten, str_gioitinh, str_dantoc, str_hochieu, date_ngaycap, date_ngaysinh, str_nguyenquan, str_noicap, str_noisinh, str_quoctich, str_sdt, str_tongiao);

                                nhankhaubus.Update(nhankhau, row);
                                LoadData();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;
                case "nhankhautamtru":
                    try
                    {
                        if (e.ColumnIndex == dataGridView1.ColumnCount - 1)
                        {
                            string Task = dataGridView1.Rows[e.RowIndex].Cells[dataGridView1.ColumnCount - 1].Value.ToString();
                            if (Task == "Delete")
                            {
                                if (MessageBox.Show("Bạn có chắc chắm muốn xóa không?", "Đang xóa...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    int rowIndex = e.RowIndex;
                                    nktamtrubus.Delete(rowIndex);
                                }
                            }
                            else if (Task == "Insert")
                            {
                                int row = dataGridView1.Rows.Count - 2;
                                string manhankhautamtru = dataGridView1.Rows[row].Cells["manhankhautamtru"].Value.ToString();
                                string madinhdanh = dataGridView1.Rows[row].Cells["madinhdanh"].Value.ToString();
                                string diachithuongtru = dataGridView1.Rows[row].Cells["diachithuongtru"].Value.ToString();
                                string sosotamtru = dataGridView1.Rows[row].Cells["sosotamtru"].Value.ToString();
                                nktamtru = new NhanKhauTamTruDTO(manhankhautamtru, madinhdanh, diachithuongtru, sosotamtru);
                                nhankhaubus.Add_Table(nktamtru);
                                dataGridView1.Rows.RemoveAt(dataGridView1.Rows.Count - 2);
                                dataGridView1.Rows[e.RowIndex].Cells[dataGridView1.ColumnCount - 1].Value = "Delete";


                            }
                            else if (Task == "Update")
                            {
                                int row = e.RowIndex;
                                string manhankhautamtru = dataGridView1.Rows[row].Cells["manhankhautamtru"].Value.ToString();
                                string madinhdanh = dataGridView1.Rows[row].Cells["madinhdanh"].Value.ToString();
                                string diachithuongtru = dataGridView1.Rows[row].Cells["diachithuongtru"].Value.ToString();
                                string sosotamtru = dataGridView1.Rows[row].Cells["sosotamtru"].Value.ToString();
                                nktamtru = new NhanKhauTamTruDTO(manhankhautamtru, madinhdanh, diachithuongtru, sosotamtru);
                                nhankhaubus.Add_Table(nktamtru);
                                nhankhaubus.Update(nktamtru, row);
                                LoadData();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;
                case "nhankhautamvang":

                    break;
                case "nhankhauthuongtru":

                    break;
                case "sohokhau":
                    try
                    {
                        if (e.ColumnIndex == dataGridView1.ColumnCount - 1)
                        {
                            string Task = dataGridView1.Rows[e.RowIndex].Cells[dataGridView1.ColumnCount - 1].Value.ToString();
                            if (Task == "Delete")
                            {
                                if (MessageBox.Show("Bạn có chắc chắm muốn xóa không?", "Đang xóa...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    int rowIndex = e.RowIndex;
                                    sohokhaubus.Delete(rowIndex);
                                }
                            }
                            else if (Task == "Insert") 
                            { /*
                                int row = dataGridView1.Rows.Count - 2;
                                string sosohokhau = dataGridView1.Rows[row].Cells["sosohokhau"].Value.ToString();
                                string machuho = dataGridView1.Rows[row].Cells["machuho"].Value.ToString();

                                nghenghiep = new NgheNghiepDTO(str_manghenghiep, str_tennghenghiep);
                                nghenghiepbus.Add_Table(nghenghiep);
                                dataGridView1.Rows.RemoveAt(dataGridView1.Rows.Count - 2);
                                dataGridView1.Rows[e.RowIndex].Cells[dataGridView1.ColumnCount - 1].Value = "Delete";
                                */
                                
                /*           }
                            else if (Task == "Update")
                            {
                                int row = e.RowIndex;
                                string str_manghenghiep = dataGridView1.Rows[row].Cells["manghenghiep"].Value.ToString();
                                string str_tennghenghiep = dataGridView1.Rows[row].Cells["tennghenghiep"].Value.ToString();
                                nghenghiep = new NgheNghiepDTO(str_manghenghiep, str_tennghenghiep);
                                nghenghiepbus.Update(nghenghiep, row);
                                LoadData();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;
                case "sotamtru":

                    break;

                case "tienantiensu":
                    try
                    {
                        if (e.ColumnIndex == dataGridView1.ColumnCount - 1)
                        {
                            string Task = dataGridView1.Rows[e.RowIndex].Cells[dataGridView1.ColumnCount - 1].Value.ToString();
                            if (Task == "Delete")
                            {
                                if (MessageBox.Show("Bạn có chắc chắm muốn xóa không?", "Đang xóa...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    int rowIndex = e.RowIndex;
                                    tienantiensubus.Delete(rowIndex);
                                }
                            }
                            else if (Task == "Insert")
                            {
                                int row = dataGridView1.Rows.Count - 2;
                                string matienantiensu = dataGridView1.Rows[row].Cells["matienantiensu"].Value.ToString();
                                string madinhdanh = dataGridView1.Rows[row].Cells["madinhdanh"].Value.ToString();
                                string banan = dataGridView1.Rows[row].Cells["banan"].Value.ToString();
                                string toidanh = dataGridView1.Rows[row].Cells["toidanh"].Value.ToString();
                                string hinhphat = dataGridView1.Rows[row].Cells["hinhphat"].Value.ToString();
                                string ngayphat = dataGridView1.Rows[row].Cells["ngayphat"].Value.ToString();
                                DateTime date_ngayphat = DateTime.Parse(ngayphat);
                                string ghichu = dataGridView1.Rows[row].Cells["ghichu"].Value.ToString();
                                tienantiensu = new TienAnTienSuDTO(matienantiensu, madinhdanh, banan, toidanh, hinhphat, date_ngayphat, ghichu);
                                tienantiensubus.Add_Table(tienantiensu);
                                dataGridView1.Rows.RemoveAt(dataGridView1.Rows.Count - 2);
                                dataGridView1.Rows[e.RowIndex].Cells[dataGridView1.ColumnCount - 1].Value = "Delete";


                            }
                            else if (Task == "Update")
                            {
                                int row = e.RowIndex;
                                string matienantiensu = dataGridView1.Rows[row].Cells["matienantiensu"].Value.ToString();
                                string madinhdanh = dataGridView1.Rows[row].Cells["madinhdanh"].Value.ToString();
                                string banan = dataGridView1.Rows[row].Cells["banan"].Value.ToString();
                                string toidanh = dataGridView1.Rows[row].Cells["toidanh"].Value.ToString();
                                string hinhphat = dataGridView1.Rows[row].Cells["hinhphat"].Value.ToString();
                                string ngayphat = dataGridView1.Rows[row].Cells["ngayphat"].Value.ToString();
                                DateTime date_ngayphat = DateTime.Parse(ngayphat);
                                string ghichu = dataGridView1.Rows[row].Cells["ghichu"].Value.ToString();
                                tienantiensu = new TienAnTienSuDTO(matienantiensu, madinhdanh, banan, toidanh, hinhphat, date_ngayphat, ghichu);
                                tienantiensubus.Update(tienantiensu, row);
                                LoadData();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;
                case "tieusu":
                    try
                    {
                        if (e.ColumnIndex == dataGridView1.ColumnCount - 1)
                        {
                            string Task = dataGridView1.Rows[e.RowIndex].Cells[dataGridView1.ColumnCount - 1].Value.ToString();
                            if (Task == "Delete")
                            {
                                if (MessageBox.Show("Bạn có chắc chắm muốn xóa không?", "Đang xóa...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    int rowIndex = e.RowIndex;
                                    tieusubus.Delete(rowIndex);
                                }
                            }
                            else if (Task == "Insert")
                            {
                                int row = dataGridView1.Rows.Count - 2;
                                string matieusu = dataGridView1.Rows[row].Cells["matieusu"].Value.ToString();
                                string madinhdanh = dataGridView1.Rows[row].Cells["madinhdanh"].Value.ToString();
                                string thoigianbatdau = dataGridView1.Rows[row].Cells["thoigianbatdau"].Value.ToString();
                                DateTime date_tgbd = DateTime.Parse(thoigianbatdau);
                                string thoigianketthuc = dataGridView1.Rows[row].Cells["thoigianketthuc"].Value.ToString();
                                DateTime date_tgkt = DateTime.Parse(thoigianketthuc);
                                string choo = dataGridView1.Rows[row].Cells["choo"].Value.ToString();
                                string manghenghiep = dataGridView1.Rows[row].Cells["manghenghiep"].Value.ToString();
                                string noilamviec = dataGridView1.Rows[row].Cells["noilamviec"].Value.ToString();
                                tieusu = new TieuSuDTO(matieusu, madinhdanh, date_tgbd, date_tgkt, choo, manghenghiep, noilamviec);
                                tieusubus.Add_Table(tieusu);
                                dataGridView1.Rows.RemoveAt(dataGridView1.Rows.Count - 2);
                                dataGridView1.Rows[e.RowIndex].Cells[dataGridView1.ColumnCount - 1].Value = "Delete";


                            }
                            else if (Task == "Update")
                            {
                                int row = e.RowIndex;
                                string matieusu = dataGridView1.Rows[row].Cells["matieusu"].Value.ToString();
                                string madinhdanh = dataGridView1.Rows[row].Cells["madinhdanh"].Value.ToString();
                                string thoigianbatdau = dataGridView1.Rows[row].Cells["thoigianbatdau"].Value.ToString();
                                DateTime date_tgbd = DateTime.Parse(thoigianbatdau);
                                string thoigianketthuc = dataGridView1.Rows[row].Cells["thoigianketthuc"].Value.ToString();
                                DateTime date_tgkt = DateTime.Parse(thoigianketthuc);
                                string choo = dataGridView1.Rows[row].Cells["choo"].Value.ToString();
                                string manghenghiep = dataGridView1.Rows[row].Cells["manghenghiep"].Value.ToString();
                                string noilamviec = dataGridView1.Rows[row].Cells["noilamviec"].Value.ToString();
                                tieusu = new TieuSuDTO(matieusu, madinhdanh, date_tgbd, date_tgkt, choo, manghenghiep, noilamviec);
                                tieusubus.Update(tieusu, row);
                                LoadData();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;
                case "tinhthanhpho":
                    try
                    {
                        if (e.ColumnIndex == dataGridView1.ColumnCount - 1)
                        {
                            string Task = dataGridView1.Rows[e.RowIndex].Cells[dataGridView1.ColumnCount - 1].Value.ToString();
                            if (Task == "Delete")
                            {
                                if (MessageBox.Show("Bạn có chắc chắm muốn xóa không?", "Đang xóa...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    int rowIndex = e.RowIndex;
                                    tinhthanhphobus.Delete(rowIndex);
                                }
                            }
                            else if (Task == "Insert")
                            {
                                int row = dataGridView1.Rows.Count - 2;
                                string matp = dataGridView1.Rows[row].Cells["matp"].Value.ToString();
                                string ten = dataGridView1.Rows[row].Cells["ten"].Value.ToString();
                                string kieu = dataGridView1.Rows[row].Cells["kieu"].Value.ToString();
                                tinhthanhpho = new TinhThanhPhoDTO(matp, ten, kieu);
                                tinhthanhphobus.Add_Table(tinhthanhpho);
                                dataGridView1.Rows.RemoveAt(dataGridView1.Rows.Count - 2);
                                dataGridView1.Rows[e.RowIndex].Cells[dataGridView1.ColumnCount - 1].Value = "Delete";
                            }
                            else if (Task == "Update")
                            {
                                int row = e.RowIndex;
                                string matp = dataGridView1.Rows[row].Cells["matp"].Value.ToString();
                                string ten = dataGridView1.Rows[row].Cells["ten"].Value.ToString();
                                string kieu = dataGridView1.Rows[row].Cells["kieu"].Value.ToString();
                                tinhthanhpho = new TinhThanhPhoDTO(matp, ten, kieu);
                                tinhthanhphobus.Update(tinhthanhpho, row);
                                LoadData();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;
                case "quanhuyen":
                    try
                    {
                        if (e.ColumnIndex == dataGridView1.ColumnCount - 1)
                        {
                            string Task = dataGridView1.Rows[e.RowIndex].Cells[dataGridView1.ColumnCount - 1].Value.ToString();
                            if (Task == "Delete")
                            {
                                if (MessageBox.Show("Bạn có chắc chắm muốn xóa không?", "Đang xóa...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    int rowIndex = e.RowIndex;
                                    quanhuyenbus.Delete(rowIndex);
                                }
                            }
                            else if (Task == "Insert")
                            {
                                int row = dataGridView1.Rows.Count - 2;
                                string maqh = dataGridView1.Rows[row].Cells["maqh"].Value.ToString();
                                string ten = dataGridView1.Rows[row].Cells["ten"].Value.ToString();
                                string kieu = dataGridView1.Rows[row].Cells["kieu"].Value.ToString();
                                string matp = dataGridView1.Rows[row].Cells["matp"].Value.ToString();

                                quanhuyen = new QuanHuyenDTO(maqh, ten, kieu, matp);
                                quanhuyenbus.Add_Table(quanhuyen);
                                dataGridView1.Rows.RemoveAt(dataGridView1.Rows.Count - 2);
                                dataGridView1.Rows[e.RowIndex].Cells[dataGridView1.ColumnCount - 1].Value = "Delete";
                            }
                            else if (Task == "Update")
                            {
                                int row = e.RowIndex;
                                string maqh = dataGridView1.Rows[row].Cells["maqh"].Value.ToString();
                                string ten = dataGridView1.Rows[row].Cells["ten"].Value.ToString();
                                string kieu = dataGridView1.Rows[row].Cells["kieu"].Value.ToString();
                                string matp = dataGridView1.Rows[row].Cells["matp"].Value.ToString();

                                quanhuyen = new QuanHuyenDTO(maqh, ten, kieu, matp);
                                quanhuyenbus.Update(quanhuyen, row);
                                LoadData();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;
                case "xaphuongthitran":
                    try
                    {
                        if (e.ColumnIndex == dataGridView1.ColumnCount - 1)
                        {
                            string Task = dataGridView1.Rows[e.RowIndex].Cells[dataGridView1.ColumnCount - 1].Value.ToString();
                            if (Task == "Delete")
                            {
                                if (MessageBox.Show("Bạn có chắc chắm muốn xóa không?", "Đang xóa...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    int rowIndex = e.RowIndex;
                                    xaphuongthitranbus.Delete(rowIndex);
                                }
                            }
                            else if (Task == "Insert")
                            {
                                int row = dataGridView1.Rows.Count - 2;
                                string maxp = dataGridView1.Rows[row].Cells["maxp"].Value.ToString();
                                string ten = dataGridView1.Rows[row].Cells["ten"].Value.ToString();
                                string kieu = dataGridView1.Rows[row].Cells["kieu"].Value.ToString();
                                string maqh= dataGridView1.Rows[row].Cells["maqh"].Value.ToString();
                                xaphuongthitran = new XaPhuongThiTranDTO(maxp, ten, kieu, maqh);
                                xaphuongthitranbus.Add_Table(xaphuongthitran);
                                dataGridView1.Rows.RemoveAt(dataGridView1.Rows.Count - 2);
                                dataGridView1.Rows[e.RowIndex].Cells[dataGridView1.ColumnCount - 1].Value = "Delete";


                            }
                            else if (Task == "Update")
                            {
                                int row = e.RowIndex;
                                string maxp = dataGridView1.Rows[row].Cells["maxp"].Value.ToString();
                                string ten = dataGridView1.Rows[row].Cells["ten"].Value.ToString();
                                string kieu = dataGridView1.Rows[row].Cells["kieu"].Value.ToString();
                                string maqh = dataGridView1.Rows[row].Cells["maqh"].Value.ToString();
                                xaphuongthitran = new XaPhuongThiTranDTO(maxp, ten, kieu, maqh);
                                xaphuongthitranbus.Update(xaphuongthitran, row);
                                LoadData();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;
            } */
        }


        private void dataGridView1_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            try
            {
                int lastRow = dataGridView1.Rows.Count - 2;
                DataGridViewRow nRow = dataGridView1.Rows[lastRow];
                DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                dataGridView1[dataGridView1.ColumnCount - 1, lastRow] = linkCell;
                nRow.Cells["Change"].Value = "Insert";
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int lastRow = e.RowIndex;
                DataGridViewRow nRow = dataGridView1.Rows[lastRow];
                DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                dataGridView1[dataGridView1.ColumnCount - 1, lastRow] = linkCell;
                nRow.Cells["Change"].Value = "Update";
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            LoadData();
        }

        private void fr_CBDuLieu_Load(object sender, EventArgs e)
        {

        }
    }
}
