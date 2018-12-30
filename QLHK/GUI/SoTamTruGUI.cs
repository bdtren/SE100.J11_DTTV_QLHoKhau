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
    public partial class SoTamTruGUI : Form
    {
        SoTamTruDTO sotamtruDto;
        SoTamTruBUS sotamtruBus;
        private string sosotamtru = "";

        //Tạo tự động số sổ tạm trú
        public string GenerateSoSoTamTru()
        {
            string last_sosotamtru= sotamtruBus.getLastID_SoSoTamTru();
            if (last_sosotamtru == "") last_sosotamtru = "TA0000000";
            return sotamtruBus.Generate7Character(last_sosotamtru);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetValueInput();
        }


        //Đặt lại giá trị cho các trường input
        public void ResetValueInput()
        {
            txt_MaChuHoTamTru.Clear();
            txt_SoSoTamTru.Clear();
            txt_LyDo.Clear();
            dt_DenNgay.ResetText();
            dt_TuNgay.ResetText();
            //Khởi tạo mã số sổ tạm trú
            txt_SoSoTamTru.Text = GenerateSoSoTamTru();
        }


        //Cập nhật lại datagridview
        public void LoadDataGridView()
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.DataSource = sotamtruBus.GetAll().Tables["sotamtru"];
        }

        //Kiểm tra nhập đủ thông tin
        public bool isInputTrueSoTamTru()
        {
            if (txt_SoSoTamTru.Text.ToString() == "" || txt_MaChuHoTamTru.Text.ToString() == "")
            {
                return false;
            }
            return true;
        }



        public SoTamTruGUI()
        {
            InitializeComponent();
        }

        private void SoTamTruGUI_Load(object sender, EventArgs e)
        {
            sotamtruBus = new SoTamTruBUS();
            //Xóa các sỗ tạm trú quá hạn mà không gia hạn tạm trú
            if (sotamtruBus.DeleteExperiedSoTamTru()) { }
            else
            {
                MessageBox.Show("Lỗi không hủy được sổ tạm trú quá hạn");
            }

            LoadDataGridView();
            cbb_ChoO_TinhThanh.DataSource = sotamtruBus.Get_TinhThanhPho(); //Lấy danh sách tỉnh thành vào combobox
            //Khởi tạo mã số sổ tạm trú
            txt_SoSoTamTru.Text = GenerateSoSoTamTru();

        }




        //Lấy danh sách mã xã phường 
        private void cbb_ChoO_QuanHuyen_SelectedIndexChanged(object sender, EventArgs e)
        {

            cbb_ChoO_XaPhuong.DataSource = sotamtruBus.GetListXaPhuong(cbb_ChoO_QuanHuyen.Text);
        }


        //Lấy danh sách quận huyện
        private void cbb_ChoO_TinhThanh_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbb_ChoO_QuanHuyen.DataSource = sotamtruBus.GetListQuanHuyen(cbb_ChoO_TinhThanh.Text);
        }


        //Thêm các nhân khẩu tạm trú vào sổ tạm trú này
        private void btnThemNhanKhau_Click(object sender, EventArgs e)
        {
            if (txt_SoSoTamTru.Text.ToString() == "")
            {
                MessageBox.Show("Cần có số sổ tạm trú để thực hiện chức năng này!");
                return;
            }
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


        //Click trên các dòng trong datagridview , lấy dữ liệu dòng đó gán vào các trường input
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

        //Kiểm tra mã chủ hộ và số sổ hộ khẩu có bị xóa hay không?
        public bool FilledInput()
        {
            if(txt_SoSoTamTru.Text.ToString()=="" || txt_MaChuHoTamTru.Text.ToString() == "") { return false; }
            return true;
        }


        //Thêm một sổ tạm trú mới
        private void btnThem_Click(object sender, EventArgs e)
        {

            if (!isInputTrueSoTamTru())
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin!");
                return;
            }


            string sosotamtru = txt_SoSoTamTru.Text.ToString();
            string machuhotamtru = txt_MaChuHoTamTru.Text.ToString();

            //Kiểm tra sự tồn tại của mã số sổ tạm trú
            if (sotamtruBus.ExistedSoTamTru(sosotamtru))
            {
                MessageBox.Show("Sổ tạm trú " + sosotamtru + " đã có ! vui lòng kiểm tra lại!");
                return ;
            }

            //Kiểm tra sự tồn tại của mã nhân khẩu tạm trú để làm chủ hộ
            if (!sotamtruBus.Existed_NhanKhauTamTru(machuhotamtru))
            {
                MessageBox.Show("Chưa đăng ký tạm trú cho nhân khẩu có mã " + machuhotamtru + " !");
                return;
            }
            //Kiểm tra chủ hộ này có nằm trong một sổ tạm trú khác hay không?
            if (sotamtruBus.Duplicated_NhanKhauTamTru(machuhotamtru, sosotamtru))
            {
                MessageBox.Show("Nhân khẩu tạm trú " + machuhotamtru + " đang ở trong sổ tạm trú khác!");
                return;
            }

            string choohiennay = txt_SoNha.Text + "," + cbb_ChoO_XaPhuong.Text + "," + cbb_ChoO_QuanHuyen.Text + "," + cbb_ChoO_TinhThanh.Text;
            string lydo = txt_LyDo.Text.ToString();
            DateTime tungay = dt_TuNgay.Value.Date;
            DateTime denngay = dt_DenNgay.Value.Date;

            sotamtruDto = new SoTamTruDTO(sosotamtru, machuhotamtru, choohiennay, tungay, denngay, lydo);

            if (sotamtruBus.Add(sotamtruDto))
            {
                MessageBox.Show("Đăng ký tạm trú có sổ tạm trú "+sosotamtru+" thành công!");
                LoadDataGridView();
                ResetValueInput();
            }
            else
            {
                MessageBox.Show("Đăng ký tạm trú sổ tạm trú "+sosotamtru+" thất bại!");
            }
        }


        //Sửa một sổ tạm trú
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (!isInputTrueSoTamTru())
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin!");
                return;
            }

            string sosotamtru = txt_SoSoTamTru.Text.ToString();
            string machuhotamtru = txt_MaChuHoTamTru.Text.ToString();

            //Kiểm tra sự tồn tại của mã số sổ tạm trú
            if (!sotamtruBus.ExistedSoTamTru(sosotamtru))
            {
                MessageBox.Show("Sổ tạm trú " + sosotamtru + " chưa tồn tại ! vui lòng kiểm tra lại!");
                return ;
            }

            //Kiểm tra sự tồn tại của mã nhân khẩu tạm trú để làm chủ hộ
            if (!sotamtruBus.Existed_NhanKhauTamTru(machuhotamtru))
            {
                MessageBox.Show("Chưa đăng ký tạm trú cho nhân khẩu có mã " + machuhotamtru + " !");
                return ;
            }
            //Kiểm tra chủ hộ này có nằm trong một sổ tạm trú khác hay không?
            if (sotamtruBus.Duplicated_NhanKhauTamTru(machuhotamtru, sosotamtru))
            {
                MessageBox.Show("Nhân khẩu tạm trú " + machuhotamtru + " đang ở trong sổ tạm trú khác!");
                return ;
            }

            DialogResult dialogResult = MessageBox.Show("Bạn có muốn cập nhật thông tin sổ tạm trú "+sosotamtru+" không?", "Thông báo", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                int r = dataGridView1.CurrentCell.RowIndex;

                string choohiennay = txt_SoNha.Text + "," + cbb_ChoO_XaPhuong.Text + "," + cbb_ChoO_QuanHuyen.Text + "," + cbb_ChoO_TinhThanh.Text;
                DateTime tungay = dt_TuNgay.Value.Date;
                DateTime denngay = dt_DenNgay.Value.Date;
                string lydo = txt_LyDo.Text.ToString();

                SoTamTruDTO sotamtru = new SoTamTruDTO(sosotamtru, machuhotamtru, choohiennay, tungay, denngay, lydo);

                if (sotamtruBus.Update(sotamtru, r))
                {
                    MessageBox.Show("Sửa thông tin sổ tạm trú "+sosotamtru+" thành công!");
                    LoadDataGridView();
                    ResetValueInput();
                    dataGridView1.DataSource = sotamtruBus.TimKiem(sotamtru.SoSoTamTru).Tables[0];
                }
                else
                {
                    MessageBox.Show("Sửa thông tin sổ tạm trú "+sosotamtru+" thất bại!");
                }
            }
            else if (dialogResult == DialogResult.No)
            {
            }
        }


        //Xóa một sổ tạm trú
        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sosotamtru = txt_SoSoTamTru.Text.ToString();
            if (sosotamtru == "")
            {
                MessageBox.Show("Cần có số sổ tạm trú để thực hiện chức năng này!");
                return;
            }

            if (!sotamtruBus.ExistedSoTamTru(sosotamtru))
            {
                MessageBox.Show("Sổ tạm trú "+sosotamtru+" không tồn tại! Vui lòng kiểm tra lại");
            }


            DialogResult dialogResult = MessageBox.Show("Bạn có muốn hủy tạm trú những nhân khẩu có sổ tạm trú "+sosotamtru+" không?", "Thông báo", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {

                if (sotamtruBus.XoaSoTamTru(sosotamtru))
                {
                    MessageBox.Show("Hủy tạm trú "+sosotamtru+" thành công");
                    LoadDataGridView();
                    ResetValueInput();
                }
                else
                {
                    MessageBox.Show("Hủy tạm trú "+sosotamtru+" thất bại");
                }
            }
            else if (dialogResult == DialogResult.No)
            {
            }

        }


        //Tìm một sổ tạm trú
        private void btnTim_Click(object sender, EventArgs e)
        {
            string sosotamtru = txt_SoSoTamTru.Text.ToString();

            if (sosotamtru == "")
            {
                MessageBox.Show("Cần có số sổ tạm trú để thực hiện chức năng này!");
                return;
            }


            if (sotamtruBus.ExistedSoTamTru(sosotamtru))
            {
                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();
                dataGridView1.DataSource = sotamtruBus.TimKiem(sosotamtru).Tables["sotamtru"];
            }
            else
            {
                MessageBox.Show("Sổ tạm trú "+sosotamtru+" không tồn tại! Vui lòng kiếm tra lại!");
                return;
            }


        }


    }
}
