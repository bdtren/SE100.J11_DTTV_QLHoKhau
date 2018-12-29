using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;
using System.Data;
using System.Windows.Forms;

namespace BUS
{
    public class SoTamTruBUS:AbstractFormBUS<SoTamTruDTO>
    {
        SoTamTruDAO SoTamTru = new SoTamTruDAO();
        public override DataSet GetAll()
        {
            return SoTamTru.getAllSoTamTru();
        }
        public override bool Add(SoTamTruDTO sotamtru)
        {
            return SoTamTru.insert(sotamtru);
        }
        public override bool Add_Table(SoTamTruDTO data)
        {
            throw new NotImplementedException();
        }
        public bool XoaSoTamTru(string manhankhautamtru)
        {
            return SoTamTru.XoaSoTamTru(manhankhautamtru);
        }
        public override bool Delete(int r)
        {
            return SoTamTru.delete(r);
        }
        public override bool Update(SoTamTruDTO sotamtru, int r)
        {
            return SoTamTru.update(sotamtru, r);
        }

        public DataSet TimKiem(string sosotamtru)
        {
            return SoTamTru.TimKiem(sosotamtru);
        }

        public bool DeleteExperiedSoTamTru()
        {
           return SoTamTru.DeleteExperiedSoTamTru();  
        }


        //Load Data For Combobox
        //Lấy mã tỉnh thành phố

        public BindingSource Get_TinhThanhPho()
        {

            List<string> TinhThanh_List = new List<string>();
            TinhThanh_List = SoTamTru.GetListTinhThanh();

            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = TinhThanh_List;
            return bindingSource;
        }


        public BindingSource GetListQuanHuyen(string tentinhthanhpho)
        {
            List<string> QuanHuyen_List = new List<string>();
            QuanHuyen_List = SoTamTru.GetListQuanHuyen(tentinhthanhpho);

            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = QuanHuyen_List;
            return bindingSource;
        }

        public BindingSource GetListXaPhuong(string tenquanhuyen)
        {
            List<string> XaPhuong_List = new List<string>();
            XaPhuong_List = SoTamTru.GetListXaPhuong(tenquanhuyen);

            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = XaPhuong_List;
            return bindingSource;
        }


        public string[] SplitDiaChi(string diachi)
        {
            string data = diachi;
            string[] result = data.Split(',');
            return result;
        }


        //Hàm Phát sinh mã tự động
        //Lấy số sổ tạm trú cuối cùng từ bảng sổ tạm trú
        public string getLastID_SoSoTamTru()
        {
            return SoTamTru.getLastID_SoSoTamTru();
        }


        //Lấy mã nhân khẩu tạm trú cuối cùng từ bảng nhân khẩu tạm trú
        public string getLastID_MaNhanKhauTamTru()
        {
            return SoTamTru.getLastID_MaNhanKhauTamTru();
        }


        //Lấy mã tiểu sử cuối cùng từ bảng tiểu sử
        public string getLastID_MaTieuSu()
        {
            return SoTamTru.getLastID_MaTieuSu();
        }


        //Lấy mã tiền án tiền sự cuối cùng từ bảng tiền án tiền sự
        public string getLastID_MaTienAnTienSu()
        {
            return SoTamTru.getLastID_MaTienAnTienSu();
        }


        //Lấy mã định danh cuối cùng từ bảng nhân khẩu
        public string getLastID_MaDinhDanh()
        {
            return SoTamTru.getLastID_MaDinhDanh();
        }


        //Phát sinh mã tự động
        public string Generate7Character(string mabandau)
        {
            return TangMa7KyTu(mabandau);
        }

        public string GenerateMaDinhDanh(string gioitinh, string namsinh)
        {
            return SoTamTru.TangMa12Kytu(gioitinh, namsinh);
        }



        /// <summary>
        /// Hàm tạo mã tự động 7 kí tự
        /// </summary>
        /// <param name="mabandau"></param>
        /// <returns></returns>
        public string TangMa7KyTu(string mabandau)
        {
            string str1 = mabandau.Substring(0, 2);
            string str2 = mabandau.Substring(2);
            int i_str2 = Int32.Parse(str2) + 1;
            string str3 = i_str2.ToString();
            string str4 = null;
            for (int i = 0; i < (7 - str3.Length); i++)
            {
                str4 = str4 + "0";
            }
            string chuoikq = str1 + str4 + str3;
            return chuoikq;
        }
    }
}
