using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class HocSinhSinhVienDAO: NgheNghiepDAO
    {
        public HocSinhSinhVienDAO() : base() { }
        public DataSet GetAllHSSV()
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                sqlda = new MySqlDataAdapter("SELECT * FROM hocsinhsinhvien", conn);
                cmdbuilder = new MySqlCommandBuilder(sqlda);
                sqlda.InsertCommand = cmdbuilder.GetInsertCommand();
                sqlda.UpdateCommand = cmdbuilder.GetUpdateCommand();
                sqlda.DeleteCommand = cmdbuilder.GetDeleteCommand();
                dataset = new DataSet();
                sqlda.Fill(dataset, "hocsinhsinhvien");
                return dataset;


            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                conn.Close();
            }
            return null;
        }
        public bool AddHSSV(HocSinhSinhVienDTO hssv)
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                string sql = "insert into hocsinhsinhvien values(@mssv, @madinhdanh, @manghenghiep, @truong, @diachithuongtru, @tgbdtttt, @tgkttttt, @vipham)";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@mssv", hssv.MSSV);
                cmd.Parameters.AddWithValue("@madinhdanh", hssv.MaDinhDanh);
                cmd.Parameters.AddWithValue("@manghenghiep", hssv.MaNgheNghiep);
                cmd.Parameters.AddWithValue("@truong", hssv.Truong);
                cmd.Parameters.AddWithValue("@diachithuongtru", hssv.DiaChiThuongTru);
                cmd.Parameters.AddWithValue("@tgbdtttt", hssv.TGBDTTTT.ToString("yyyy/MM/dd"));
                cmd.Parameters.AddWithValue("@tgkttttt", hssv.TGKTTTTT.ToString("yyyy/MM/dd"));
                cmd.Parameters.AddWithValue("@vipham", hssv.ViPham);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                conn.Close();
            }
            return true;

        }
        public bool XoaHHSV(string mssv)
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                string sql = "delete from hocsinhsinhvien where mmssv=@mssv";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@mssv", mssv);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            finally
            {
                conn.Close();
            }
            return true;

        }
        public bool SuaHSSV(HocSinhSinhVienDTO hssv)
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            try
            {
                string sql = "update hocsinhsinhvien set truong=@truong, diachithuongtru=@diachithuongtru, tgbdtttt=@tgbdtttt, tgkttttt=@tgkttttt, vipham=@vipham where mssv=@mssv";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@mssv", hssv.MSSV);
                cmd.Parameters.AddWithValue("@truong", hssv.Truong);
                cmd.Parameters.AddWithValue("@diachithuongtru", hssv.DiaChiThuongTru);
                cmd.Parameters.AddWithValue("@tgbdtttt", hssv.TGBDTTTT.ToString("yyyy/MM/dd"));
                cmd.Parameters.AddWithValue("@tgkttttt", hssv.TGKTTTTT.ToString("yyyy/MM/dd"));
                cmd.Parameters.AddWithValue("@vipham)", hssv.ViPham);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            finally
            {
                conn.Close();
            }
            return false;
        }
        public DataSet TimKiem(string mssv)
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                sqlda = new MySqlDataAdapter("SELECT * FROM hocsinhsinhvien where mssv='"+mssv+"'", conn);
                cmdbuilder = new MySqlCommandBuilder(sqlda);
                sqlda.InsertCommand = cmdbuilder.GetInsertCommand();
                sqlda.UpdateCommand = cmdbuilder.GetUpdateCommand();
                sqlda.DeleteCommand = cmdbuilder.GetDeleteCommand();
                dataset = new DataSet();
                sqlda.Fill(dataset, "hocsinhsinhvien");
                return dataset;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                conn.Close();
            }
            return null;
        }
    }
    
}
