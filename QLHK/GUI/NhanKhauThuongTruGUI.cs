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
    public partial class NhanKhauThuongTruGUI : Form
    {
        NhanKhauBUS nk;
        NhanKhauThuongTruBUS nktt;
        TieuSuBUS tieuSu;
        TieuSuDTO tieusudto;
        TienAnTienSuBUS tienAn;
        TienAnTienSuDTO tienanDTO;
        public NhanKhauThuongTruDTO nkttDTO;
        SoHoKhauBUS shk;
        public NhanKhauThuongTruGUI()
        {
            InitializeComponent();
            nktt = new NhanKhauThuongTruBUS();
            tieuSu = new TieuSuBUS();
            tienAn = new TienAnTienSuBUS();
            shk = new SoHoKhauBUS();

            //dGVTieuSu.DataSource = null;
            //dGVTieuSu.Rows.Clear();
            //dGVTieuSu.DataSource = nktt.GetAll().Tables["nhankhauthuongtru"];
            LoadtieuSu();
            //dGVTienAnTienSu.DataSource = tienAn.GetAll().Tables[0];
            Loadtienantiensu();
            //themMaDinhDanhBang(); hàm này để chạy 2 cái datafridview bị lỗi.... ô sửa lại đi
        }
        private void NhanKhauThuongTruGUI_Load(object sender, EventArgs e)
        {


        }

        private void themMaDinhDanhBang()
        {
            for (int i = 0; i < dGVTieuSu.RowCount; i++)
                dGVTieuSu.Rows[i].Cells[1].Value = tbmadinhdanh.Text;
            for (int i = 0; i < dGVTienAnTienSu.RowCount; i++)
            {
                dGVTienAnTienSu.Rows[i].Cells[1].Value = tbmadinhdanh.Text;

            }
        }

        private void button_them_Click(object sender, EventArgs e)
        {
            nkttDTO = new NhanKhauThuongTruDTO(tbmadinhdanh.Text, tbNgheNghiep.Text, tbhoten.Text, tbgioitinh.Text,
                tbdantoc.Text, tbhochieu.Text, dtpNgayCap.Value, dtpNgaySinh.Value, tbnguyenquan.Text, tbnoicap.Text,
                tbnoisinh.Text, tbquoctich.Text, tbsodienthoai.Text, tbtongiao.Text, tbMaNKTT.Text,
                tbBietTiengDanToc.Text, tbDCHienTai.Text, tbQHVoiCH.Text == "chuho" ? true : false,
                tbNoiLamViec.Text, tbDCThuongTru.Text, tbQHVoiCH.Text, tbTrinhDoCM.Text,
                tbTrinhDoNN.Text, tbTrinhDoHocVan.Text, tbSoSHK.Text);
            
            if (nktt.Add(nkttDTO))
            {
                MessageBox.Show(this, "Thành công!");

            }
            else
            {
                MessageBox.Show(this, "Lỗi!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void button_sua_Click(object sender, EventArgs e)
        {
            nkttDTO = new NhanKhauThuongTruDTO(tbmadinhdanh.Text, tbNgheNghiep.Text, tbhoten.Text, tbgioitinh.Text,
                tbdantoc.Text, tbhochieu.Text, dtpNgayCap.Value, dtpNgaySinh.Value, tbnguyenquan.Text, tbnoicap.Text,
                tbnoisinh.Text, tbquoctich.Text, tbsodienthoai.Text, tbtongiao.Text, tbMaNKTT.Text,
                tbBietTiengDanToc.Text, tbDCHienTai.Text, tbQHVoiCH.Text == "chuho" ? true : false,
                tbNoiLamViec.Text, tbDCThuongTru.Text, tbQHVoiCH.Text, tbTrinhDoCM.Text,
                tbTrinhDoNN.Text, tbTrinhDoHocVan.Text, tbSoSHK.Text);

            if (nktt.Update(nkttDTO, -1))
            {
                MessageBox.Show(this, "Thành công!");
            }
            else
            {
                MessageBox.Show(this, "Lỗi!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_xoa_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(tbMaNKTT.Text))
            {
                MessageBox.Show(this, "Thiếu!", "Vui Lòng nhập mã nhân khẩu hoặc mã thường trú", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (nktt.XoaNKTT(tbMaNKTT.Text))
            {
                MessageBox.Show(this, "Thành công!");
            }
            else
            {
                MessageBox.Show(this, "Lỗi!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tbDCThuongTru_Enter(object sender, EventArgs e)
        {

            using (ChonDonViHanhChinhGUI a = new ChonDonViHanhChinhGUI())
            {
                a.ShowDialog(this);
                if (a.diaChi != "")
                    tbDCThuongTru.Text = a.diaChi;
            }
        }

        private void tbDCHienTai_Enter(object sender, EventArgs e)
        {
            using (ChonDonViHanhChinhGUI a = new ChonDonViHanhChinhGUI())
            {
                a.ShowDialog(this);
                if (a.diaChi != "")
                    tbDCHienTai.Text = a.diaChi;
            }
        }

        private void tbnguyenquan_Enter(object sender, EventArgs e)
        {
            using (ChonDonViHanhChinhGUI a = new ChonDonViHanhChinhGUI())
            {
                a.ShowDialog(this);
                if (a.diaChi != "")
                    tbnguyenquan.Text = a.diaChi;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            nktt.XoaNKTT(nkttDTO.MaNhanKhauThuongTru);
            nkttDTO = null;
            this.Close();
        }
        private void LoadtieuSu()
        {
            try
            {
                dGVTieuSu.DataSource = null;
                dGVTieuSu.Rows.Clear();
                dGVTieuSu.DataSource = tieuSu.GetAll().Tables["tieusu"];
                /*for (int i = 0; i < dGVTieuSu.Rows.Count; i++)
                {
                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                    dGVTieuSu[dGVTieuSu.ColumnCount - 1, i] = linkCell;
                }*/
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Loadtienantiensu()
        {
            try
            {
                dGVTienAnTienSu.DataSource = null;
                dGVTienAnTienSu.Rows.Clear();
                dGVTienAnTienSu.DataSource = tienAn.GetAll().Tables["tienantiensu"];
                for (int i = 0; i < dGVTienAnTienSu.Rows.Count; i++)
                {
                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                    dGVTienAnTienSu[dGVTienAnTienSu.ColumnCount - 1, i] = linkCell;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void useradd(DataGridView data)
        {
            try
            {
                int lastRow = data.Rows.Count - 2;
                DataGridViewRow nRow = data.Rows[lastRow];
                DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                data[data.ColumnCount - 1, lastRow] = linkCell;
                nRow.Cells["Change"].Value = "Insert";
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        private void doubleclick(DataGridView data, int lastRow)
        {
            try
            {
                DataGridViewRow nRow = data.Rows[lastRow];
                DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                data[data.ColumnCount - 1, lastRow] = linkCell;
                nRow.Cells["Change"].Value = "Update";
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void dGVTieuSu_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            useradd(dGVTieuSu);
        }

        private void dGVTieuSu_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            doubleclick(dGVTieuSu, e.RowIndex);
        }

        private void dGVTienAnTienSu_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            useradd(dGVTienAnTienSu);
        }

        private void dGVTienAnTienSu_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            doubleclick(dGVTienAnTienSu, e.RowIndex);
        }

        private void dGVTieuSu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == dGVTieuSu.ColumnCount - 1)
                {
                    string Task = dGVTieuSu.Rows[e.RowIndex].Cells[dGVTieuSu.ColumnCount - 1].Value.ToString();
                    if (Task == "Delete")
                    {
                        if (MessageBox.Show("Bạn có chắc chắm muốn xóa không?", "Đang xóa...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            int rowIndex = e.RowIndex;
                            tieuSu.Delete(rowIndex);
                        }
                    }
                    else if (Task == "Insert")
                    {
                        int row = dGVTieuSu.Rows.Count - 2;
                        string matieusu = dGVTieuSu.Rows[row].Cells["matieusu"].Value.ToString();
                        string madinhdanh = dGVTieuSu.Rows[row].Cells["madinhdanh"].Value.ToString();
                        string thoigianbatdau = dGVTieuSu.Rows[row].Cells["thoigianbatdau"].Value.ToString();
                        DateTime date_tgbd = DateTime.Parse(thoigianbatdau);
                        string thoigianketthuc = dGVTieuSu.Rows[row].Cells["thoigianketthuc"].Value.ToString();
                        DateTime date_tgkt = DateTime.Parse(thoigianketthuc);
                        string choo = dGVTieuSu.Rows[row].Cells["choo"].Value.ToString();
                        string manghenghiep = dGVTieuSu.Rows[row].Cells["manghenghiep"].Value.ToString();
                        string noilamviec = dGVTieuSu.Rows[row].Cells["noilamviec"].Value.ToString();
                        tieusudto = new TieuSuDTO(matieusu, madinhdanh, date_tgbd, date_tgkt, choo, manghenghiep, noilamviec);
                        tieuSu.Add_Table(tieusudto);
                        dGVTieuSu.Rows.RemoveAt(dGVTieuSu.Rows.Count - 2);
                        dGVTieuSu.Rows[e.RowIndex].Cells[dGVTieuSu.ColumnCount - 1].Value = "Delete";


                    }
                    else if (Task == "Update")
                    {
                        int row = e.RowIndex;
                        string matieusu = dGVTieuSu.Rows[row].Cells["matieusu"].Value.ToString();
                        string madinhdanh = dGVTieuSu.Rows[row].Cells["madinhdanh"].Value.ToString();
                        string thoigianbatdau = dGVTieuSu.Rows[row].Cells["thoigianbatdau"].Value.ToString();
                        DateTime date_tgbd = DateTime.Parse(thoigianbatdau);
                        string thoigianketthuc = dGVTieuSu.Rows[row].Cells["thoigianketthuc"].Value.ToString();
                        DateTime date_tgkt = DateTime.Parse(thoigianketthuc);
                        string choo = dGVTieuSu.Rows[row].Cells["choo"].Value.ToString();
                        string manghenghiep = dGVTieuSu.Rows[row].Cells["manghenghiep"].Value.ToString();
                        string noilamviec = dGVTieuSu.Rows[row].Cells["noilamviec"].Value.ToString();
                        tieusudto = new TieuSuDTO(matieusu, madinhdanh, date_tgbd, date_tgkt, choo, manghenghiep, noilamviec);
                        tieuSu.Update(tieusudto, row);
                        LoadtieuSu();
                    }
                }
            }
            catch(Exception ex)
                    {
                MessageBox.Show(ex.Message);
            }
        }

        private void dGVTienAnTienSu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == dGVTienAnTienSu.ColumnCount - 1)
                {
                    string Task = dGVTienAnTienSu.Rows[e.RowIndex].Cells[dGVTienAnTienSu.ColumnCount - 1].Value.ToString();
                    if (Task == "Delete")
                    {
                        if (MessageBox.Show("Bạn có chắc chắm muốn xóa không?", "Đang xóa...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            int rowIndex = e.RowIndex;
                            tienAn.Delete(rowIndex);
                        }
                    }
                    else if (Task == "Insert")
                    {
                        int row = dGVTienAnTienSu.Rows.Count - 2;
                        string matienantiensu = dGVTienAnTienSu.Rows[row].Cells["matienantiensu"].Value.ToString();
                        string madinhdanh = dGVTienAnTienSu.Rows[row].Cells["madinhdanh"].Value.ToString();
                        string banan = dGVTienAnTienSu.Rows[row].Cells["banan"].Value.ToString();
                        string toidanh = dGVTienAnTienSu.Rows[row].Cells["toidanh"].Value.ToString();
                        string hinhphat = dGVTienAnTienSu.Rows[row].Cells["hinhphat"].Value.ToString();
                        string ngayphat = dGVTienAnTienSu.Rows[row].Cells["ngayphat"].Value.ToString();
                        DateTime date_ngayphat = DateTime.Parse(ngayphat);
                        string ghichu = dGVTienAnTienSu.Rows[row].Cells["ghichu"].Value.ToString();
                        tienanDTO = new TienAnTienSuDTO(matienantiensu, madinhdanh, banan, toidanh, hinhphat, date_ngayphat, ghichu);
                        tienAn.Add_Table(tienanDTO);
                        dGVTienAnTienSu.Rows.RemoveAt(dGVTienAnTienSu.Rows.Count - 2);
                        dGVTienAnTienSu.Rows[e.RowIndex].Cells[dGVTienAnTienSu.ColumnCount - 1].Value = "Delete";


                    }
                    else if (Task == "Update")
                    {
                        int row = e.RowIndex;
                        string matienantiensu = dGVTienAnTienSu.Rows[row].Cells["matienantiensu"].Value.ToString();
                        string madinhdanh = dGVTienAnTienSu.Rows[row].Cells["madinhdanh"].Value.ToString();
                        string banan = dGVTienAnTienSu.Rows[row].Cells["banan"].Value.ToString();
                        string toidanh = dGVTienAnTienSu.Rows[row].Cells["toidanh"].Value.ToString();
                        string hinhphat = dGVTienAnTienSu.Rows[row].Cells["hinhphat"].Value.ToString();
                        string ngayphat = dGVTienAnTienSu.Rows[row].Cells["ngayphat"].Value.ToString();
                        DateTime date_ngayphat = DateTime.Parse(ngayphat);
                        string ghichu = dGVTienAnTienSu.Rows[row].Cells["ghichu"].Value.ToString();
                        tienanDTO = new TienAnTienSuDTO(matienantiensu, madinhdanh, banan, toidanh, hinhphat, date_ngayphat, ghichu);
                        tienAn.Update(tienanDTO, row);
                        Loadtienantiensu();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tbmadinhdanh_Enter(object sender, EventArgs e)
        {
            string madinhdanh = shk.TaoMa12KyTu(tbgioitinh.Text, dtpNgaySinh.Value.Year.ToString());
            MessageBox.Show(madinhdanh);
        }
    }
}
