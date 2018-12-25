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
            NhanKhauDAO nk = new NhanKhauDAO();
            
            return nk.insert(nktt)&&obj.insert(nktt);
        }
        public override bool Add_Table(NhanKhauThuongTruDTO data)
        {
            throw new NotImplementedException();
        }
        public bool XoaNKTT(string maNKTT)
        {
            DataSet search = obj.TimKiem("where manhankhauthuongtru='" + maNKTT + "'");
            if (search==null||search.Tables[0].Rows.Count == 0) return false;
            NhanKhauDAO nk = new NhanKhauDAO();
            return obj.XoaNKTT(maNKTT)&&nk.delete(search.Tables[0].Rows[0][1].ToString());
        }
        public override bool Delete(int r)
        {
            return obj.delete(r);
        }
        public override bool Update(NhanKhauThuongTruDTO nktt, int r)
        {
            NhanKhauDAO nk = new NhanKhauDAO();
            
            return nk.update(nktt, r)&& obj.update(nktt, r);
        }

        public DataSet TimKiem(string maNKTT)
        {
            return obj.TimKiem(maNKTT);
        }
    }
}
