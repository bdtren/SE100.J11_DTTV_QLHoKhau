﻿using System;
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
        public NhanKhauThuongTruDTO nkttDTO;

        public NhanKhauThuongTruGUI()
        {
            InitializeComponent();
            nktt = new NhanKhauThuongTruBUS();
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            //dataGridView1.DataSource = nktt.GetAll().Tables["nhankhauthuongtru"];
            dataGridView1.DataSource = nktt.GetAllJoinNhanKhau().Tables[0];
        }
        private void NhanKhauThuongTruGUI_Load(object sender, EventArgs e)
        {

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
                MessageBox.Show(this,"Thành công!");
            }
            else{
                MessageBox.Show(this,"Lỗi!","",MessageBoxButtons.OK,MessageBoxIcon.Error);
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

            if (nktt.Update(nkttDTO,-1))
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
                if(a.diaChi!="")
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
    }
}