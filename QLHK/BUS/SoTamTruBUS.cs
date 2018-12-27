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
            return SoTamTru.getAll();
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

    }
}
