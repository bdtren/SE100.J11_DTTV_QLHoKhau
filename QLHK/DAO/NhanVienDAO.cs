using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class NhanVienDAO: DBConnection
    {

        public NhanVienDAO(): base() { }
        public DataSet GetAllNhanVien()
        {
            string query = "SELECT *, 'Delete' as Deleete FROM NHANVIEN;";
            return getQuery(query);
        }
        public void SetDataset(int rowindex) => UpdateDataset(rowindex);

    }
}
