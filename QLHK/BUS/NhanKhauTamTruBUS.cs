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
    public class NhanKhauTamTruBUS: AbstractFormBUS<NhanKhauTamTruDTO>
    {
        NhanKhauTamTruDAO objnktt = new NhanKhauTamTruDAO();
        public override DataSet GetAll()
        {
            return objnktt.getAll();
        }
        public DataSet GetAllNhanKhauTamTru(string sosotamtru)
        {
            return objnktt.getAllNhanKhauTT(sosotamtru);
        }
        public override bool Add(NhanKhauTamTruDTO nhankhautamtru)
        {

            return objnktt.insert(nhankhautamtru);
        }

        public bool XoaNKTT(string madinhdanh)
        {
            return objnktt.XoaNKTT(madinhdanh);
        }
        public override bool Delete(int r)
        {
            return objnktt.delete(r);
        }
        public override bool Update(NhanKhauTamTruDTO nhankhautamtru, int r)
        {
            return objnktt.updateNhanKhauTamTru(nhankhautamtru, r);
        }

        public DataSet TimKiem(string madinhdanh)
        {
            return objnktt.TimKiem(madinhdanh);
        }
        public override bool Add_Table(NhanKhauTamTruDTO data)
        {
            throw new NotImplementedException();
        }


        //Load Data For Combobox
        //Lấy mã tỉnh thành phố
        public BindingSource Get_TinhThanhPho()
        {

            List<string> TinhThanh_List = new List<string>();
            TinhThanh_List = objnktt.GetListTinhThanh();

            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = TinhThanh_List;
            return bindingSource;
        }


        public BindingSource GetListQuanHuyen(string tentinhthanhpho)
        {
            List<string> QuanHuyen_List = new List<string>();
            QuanHuyen_List = objnktt.GetListQuanHuyen(tentinhthanhpho);

            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = QuanHuyen_List;
            return bindingSource;
        }

        public BindingSource GetListXaPhuong(string tenquanhuyen)
        {
            List<string> XaPhuong_List = new List<string>();
            XaPhuong_List = objnktt.GetListXaPhuong(tenquanhuyen);

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


        //Get Nghề nghiệp
        public BindingSource GetListNgheNghiep()
        {
            NgheNghiepBUS busNN = new NgheNghiepBUS();
            DataSet dtNgheNghiep = busNN.GetAll();
            List<string> listNghenghiep = new List<string>();

            //Lấy danh sách nghề nghiệp dưới dạng list string từ dataset
            listNghenghiep = dtNgheNghiep.Tables[0].AsEnumerable()
                      .Select(r => r.Field<string>("tennghenghiep"))
                      .ToList();

            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = listNghenghiep;
            return bindingSource;
        }

        //Lấy mã nghề nghiệp từ tên nghề nghiệp
        public string GetMaNgheNghiep(string tennghenghiep)
        {
            return objnktt.FindMaNgheNghiep(tennghenghiep);
        }

        //Lấy tên nghề từ mã nghề
        public string GetTenNgheNghiep(string manghenghiep)
        {
            return objnktt.FindTenNgheNghiep(manghenghiep);
        }

        //
        //XỬ LÍ VỚI TIỀN ÁN TIỀN SỰ
        //
        public DataSet GetTienAnTienSu(string madinhdanh)
        {
            return objnktt.getTienAnTienSu(madinhdanh);
        }

        public bool DeleteTienAnTienSu(string matienan)
        {
            return objnktt.DeleteTienAn(matienan);
        }


        //
        //XỬ LÍ VỚI TIỂU SỬ
        //
        public DataSet GetTieuSu(string madinhdanh)
        {
            return objnktt.getTieuSu(madinhdanh);
        }


        public bool DeleteTieuSu(string matieusu)
        {
            return objnktt.DeleteTieuSu(matieusu);
        }
    }
}
