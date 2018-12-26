using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;
using System.Data;

namespace BUS
{
    public class NhanKhauTamTruBUS: AbstractFormBUS<NhanKhauTamTruDTO>
    {
        NhanKhauTamTruDAO objnktt = new NhanKhauTamTruDAO();
        public override DataSet GetAll()
        {
            return objnktt.getAll();
        }
        public override bool Add(NhanKhauTamTruDTO nhankhautamtru)
        {
            return objnktt.insert(nhankhautamtru);
        }

        public bool XoaNKTT(string manhankhautamtru)
        {
            return objnktt.XoaNKTT(manhankhautamtru);
        }
        public override bool Delete(int r)
        {
            return objnktt.delete(r);
        }
        public override bool Update(NhanKhauTamTruDTO nhankhautamtru, int r)
        {
            return objnktt.update(nhankhautamtru, r);
        }

        public DataSet TimKiem(string manhankhautamtru)
        {
            return objnktt.TimKiem(manhankhautamtru);
        }
        public override bool Add_Table(NhanKhauTamTruDTO data)
        {
            throw new NotImplementedException();
        }
    }
}
