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


namespace GUI
{
    public partial class fr_CBDuLieu : DevExpress.XtraEditors.XtraForm
    {
        CanBoBUS canbobus;
        CanBo canbo;
        Admin admin;
        AdminBUS adminbus;
        HocSinhSinhVienBUS hssvbus;
        public fr_CBDuLieu()
        {
            InitializeComponent();
            canbobus = new CanBoBUS();
            adminbus = new AdminBUS();
            hssvbus = new HocSinhSinhVienBUS();
        }
        
        private void LoadData()
        {
            switch (comboBox1.Text)
            {
                case "Cán bộ":
                        try
                        {
                            dataGridView1.DataSource = canbobus.GetAllCanBo().Tables["canbo"];
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
                case "Admin":
                    try
                    {
                        dataGridView1.DataSource = adminbus.GetAllAdmin().Tables["admin1"];
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
                case "Học sinh, sinh viên":
                    try
                    {
                        dataGridView1.DataSource = hssvbus.GetAllHSSV().Tables["hocsinhsinhvien"];
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

                case "Nhân khẩu":

                    break;
                case "Nhân khẩu thường trú":

                    break;
                case "Nhân khẩu tạm trú":

                    break;
                case "Sổ hộ khẩu":

                    break;
                case "Sổ tạm trú":

                    break;
                case "Tạm vắng":

                    break;
                case "Tiền án tiền sự":

                    break;
                case "Tiểu sử":

                    break;
                case "Tôn giáo":

                    break;
                case "Trình độ":

                    break;


            }
            dataGridView1.DefaultCellStyle.ForeColor = Color.Black;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (comboBox1.Text)
            {
                case "Cán bộ":
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
                                        canbobus.XoaCanBo(rowIndex);
                                    }
                                }
                                else if (Task == "Insert")
                                {
                                    int row = dataGridView1.Rows.Count - 2;
                                    canbo = new CanBo(dataGridView1.Rows[row].Cells["macanbo"].Value.ToString(), dataGridView1.Rows[row].Cells["tendangnhap"].Value.ToString(), dataGridView1.Rows[row].Cells["matkhau"].Value.ToString());
                                    canbobus.AddCanBo(canbo);
                                    dataGridView1.Rows.RemoveAt(dataGridView1.Rows.Count - 2);
                                    dataGridView1.Rows[e.RowIndex].Cells[dataGridView1.ColumnCount - 1].Value = "Delete";
                                }
                                else if (Task == "Update")
                                {
                                    int r = e.RowIndex;
                                    canbo = new CanBo(dataGridView1.Rows[r].Cells["macanbo"].Value.ToString(), dataGridView1.Rows[r].Cells["tendangnhap"].Value.ToString(), dataGridView1.Rows[r].Cells["matkhau"].Value.ToString());
                                    canbobus.SuaCanBo(canbo, r);
                                    dataGridView1.Rows[r].Cells[dataGridView1.ColumnCount - 1].Value = "Delete";
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
                case "Admin":
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
                                        adminbus.XoaAdmin(rowIndex);
                                        LoadData();
                                    }
                                }
                                else if (Task == "Insert")
                                {
                                    int row = dataGridView1.Rows.Count - 2;
                                    admin = new Admin(dataGridView1.Rows[row].Cells["macanbo"].Value.ToString(), dataGridView1.Rows[row].Cells["mabaomat"].Value.ToString());
                                    adminbus.AddAdmin(admin);
                                    dataGridView1.Rows.RemoveAt(dataGridView1.Rows.Count - 2);
                                    dataGridView1.Rows[e.RowIndex].Cells[dataGridView1.ColumnCount - 1].Value = "Delete";
                                }
                                else if (Task == "Update")
                                {
                                    int r = e.RowIndex;
                                    admin = new Admin(dataGridView1.Rows[r].Cells["macanbo"].Value.ToString(), dataGridView1.Rows[r].Cells["mabaomat"].Value.ToString());
                                    adminbus.SuaAdmin(admin, r);
                                    dataGridView1.Rows[r].Cells[dataGridView1.ColumnCount - 1].Value = "Delete";
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
                case "Học sinh, sinh viên":
                    /*{
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
                                        hssvbus.XoaHSSV(rowIndex);
                                    }
                                }
                                else if (Task == "Insert")
                                {
                                    int row = dataGridView1.Rows.Count - 2;
                                    string str_manhankhau = dataGridView1.Rows[row].Cells["manhankhau"].Value.ToString();
                                    string str_mssv = dataGridView1.Rows[row].Cells["mssv"].Value.ToString();
                                    string str_truong = dataGridView1.Rows[row].Cells["truong"].Value.ToString();
                                    string str_diachithuongtru = dataGridView1.Rows[row].Cells["diachithuongtru"].Value.ToString();
                                    string str_tgbdtt = dataGridView1.Rows[row].Cells["thoigianbatdautamtruthuongtru"].Value.ToString();
                                    DateTime date_tgbdtt = DateTime.Parse(str_tgbdtt);
                                    string str_tgkttt = dataGridView1.Rows[row].Cells["thoigianketthuctamtruthuongtru"].Value.ToString();
                                    DateTime date_tgkttt = DateTime.Parse(str_tgkttt);
                                    string str_vipham= dataGridView1.Rows[row].Cells["vipham"].Value.ToString();
                                    hssv = new HocSinhSinhVien(str_manhankhau, str_mssv, str_truong, str_diachithuongtru, date_tgbdtt,date_tgkttt, str_vipham);
                                    hssvbus.AddHSSV(hssv);
                                    dataGridView1.Rows.RemoveAt(dataGridView1.Rows.Count - 2);
                                    dataGridView1.Rows[e.RowIndex].Cells[dataGridView1.ColumnCount - 1].Value = "Delete";
                                }
                                else if (Task == "Update")
                                {
                                    int row = e.RowIndex;
                                    string str_manhankhau = dataGridView1.Rows[row].Cells["manhankhau"].Value.ToString();
                                    string str_mssv = dataGridView1.Rows[row].Cells["mssv"].Value.ToString();
                                    string str_truong = dataGridView1.Rows[row].Cells["truong"].Value.ToString();
                                    string str_diachithuongtru = dataGridView1.Rows[row].Cells["diachithuongtru"].Value.ToString();
                                    string str_tgbdtt = dataGridView1.Rows[row].Cells["thoigianbatdautamtruthuongtru"].Value.ToString();
                                    DateTime date_tgbdtt = DateTime.Parse(str_tgbdtt);
                                    string str_tgkttt = dataGridView1.Rows[row].Cells["thoigianketthuctamtruthuongtru"].Value.ToString();
                                    DateTime date_tgkttt = DateTime.Parse(str_tgkttt);
                                    string str_vipham = dataGridView1.Rows[row].Cells["vipham"].Value.ToString();
                                    hssv = new HocSinhSinhVien(str_manhankhau, str_mssv, str_truong, str_diachithuongtru, date_tgbdtt, date_tgkttt, str_vipham);
                                    hssvbus.SuaHSSV(hssv, row);
                                    dataGridView1.Rows[row].Cells[dataGridView1.ColumnCount - 1].Value = "Delete";
                                    LoadData();
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }*/
                    //break;
                case "Nhân khẩu":

                    break;
                case "Nhân khẩu thường trú":

                    break;
                case "Nhân khẩu tạm trú":

                    break;
                case "Sổ hộ khẩu":

                    break;
                case "Sổ tạm trú":

                    break;
                case "Tạm vắng":

                    break;
                case "Tiền án tiền sự":

                    break;
                case "Tiểu sử":

                    break;
                case "Tôn giáo":

                    break;
                case "Trình độ":

                    break;
            }
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
