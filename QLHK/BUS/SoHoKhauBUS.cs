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
    public class SoHoKhauBUS: AbstractFormBUS<SoHoKhauDTO>
    {
        SoHoKhauDAO obj = new SoHoKhauDAO();
        public override DataSet GetAll()
        {
            return obj.getAll();
        }
        public override bool Add(SoHoKhauDTO sohk)
        {
            
            return obj.insert(sohk);
        }
        public override bool Add_Table(SoHoKhauDTO data)
        {
            return obj.insert_table(data);
        }
        public bool XoaSoHK(string soSoHoKhau)
        {
            return obj.XoaSoHK(soSoHoKhau);
        }
        public override bool Delete(int r)
        {
            return obj.delete(r);
        }
        public override bool Update(SoHoKhauDTO sohk, int r)
        {   
            return  obj.update(sohk, r);
        }

        public DataSet TimKiem(string query)
        {
            return obj.TimKiem(query);
        }

    }
}
