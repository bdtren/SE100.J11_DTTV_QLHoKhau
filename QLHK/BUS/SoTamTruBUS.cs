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
    }
}
