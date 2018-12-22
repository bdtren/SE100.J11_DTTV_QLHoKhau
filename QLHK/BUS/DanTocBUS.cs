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
    public class DanTocBUS
    {
        DanTocDAO objDantoc = new DanTocDAO();
        public DanTocBUS() { }
        public DataSet GetAllDanToc()
        {
            return objDantoc.GetAllDanToc();
        }
        public bool AddDanToc(DanToc dt)
        {
            return objDantoc.AddDanToc(dt);
        }
        public bool XoaDanToc(int r)
        {
            return objDantoc.XoaDanToc(r);
        }
        public bool SuaDanToc(DanToc dt, int r)
        {
            return objDantoc.SuaDanToc(dt, r);
        }
    }
}
