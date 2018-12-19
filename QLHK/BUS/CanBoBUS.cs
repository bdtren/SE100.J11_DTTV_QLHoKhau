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
    public class CanBoBUS
    {
        CanBoDAO objcb = new CanBoDAO();
        public DataSet GetAllCanBo()
        {
            return objcb.GetAllCanBo();
        }
        public bool AddCanBo(CanBo cb)
        {
            return objcb.AddCanBo(cb);
        }
        public bool XoaCanBo(int row)
        {
            return objcb.XoaCanBo(row);
        }
        public bool SuaCanBo(CanBo cb, int r)
        {
            return objcb.SuaCanBo(cb, r);
        }
    }
}
