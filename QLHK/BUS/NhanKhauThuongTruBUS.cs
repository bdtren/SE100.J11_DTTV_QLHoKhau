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
    public class NhanKhauThuongTruBUS: AbstractFormBUS<NhanKhauThuongTruDTO>
    {
        NhanKhauThuongTruDAO obj = new NhanKhauThuongTruDAO();
        public override DataSet GetAll()
        {
            return obj.getAll();
        }
        public DataSet GetAllJoinNhanKhau()
        {
            return obj.getAllJoinNhanKhau();
        }
        public override bool Add(NhanKhauThuongTruDTO nktt)
        {
            return obj.insert(nktt);
        }

        public bool XoaNKTT(string maNKTT)
        {
            return obj.XoaNKTT(maNKTT);
        }
        public override bool Delete(int r)
        {
            return obj.delete(r);
        }
        public override bool Update(NhanKhauThuongTruDTO nktt, int r)
        {
            return obj.update(nktt, r);
        }

        public DataSet TimKiem(string maNKTT)
        {
            return obj.TimKiem(maNKTT);
        }
    }
}
