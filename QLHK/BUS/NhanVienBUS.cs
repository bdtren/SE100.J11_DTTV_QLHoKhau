using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using System.Data;

namespace BUS
{
    public class NhanVienBUS
    {
        private NhanVienDAO nhanvienDAO;
        public NhanVienBUS()
        {
            nhanvienDAO = new NhanVienDAO();
        }
        public DataSet GetAllNhanVien()
        {
            return nhanvienDAO.GetAllNhanVien();
        }
        public void SetDataset(int rowindex) => nhanvienDAO.SetDataset(rowindex);
    }
}
