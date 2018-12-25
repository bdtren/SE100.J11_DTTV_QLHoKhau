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
    public class NhanKhauTamTruDAO:DBConnection<NhanKhauTamTruDTO>
    {
        public NhanKhauTamTruDAO() : base() { }

        public override DataSet getAll()
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                sqlda = new MySqlDataAdapter("SELECT *, 'Delete' as 'Change' FROM nhankhautamtru", conn);
                cmdbuilder = new MySqlCommandBuilder(sqlda);
                sqlda.InsertCommand = cmdbuilder.GetInsertCommand();
                sqlda.UpdateCommand = cmdbuilder.GetUpdateCommand();
                sqlda.DeleteCommand = cmdbuilder.GetDeleteCommand();
                dataset = new DataSet();
                sqlda.Fill(dataset, "nhankhautamtru");
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

        public override bool insert(NhanKhauTamTruDTO nktt)
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                string sql = "insert into nhankhautamtru values(@manhankhautamtru, @madinhdanh, @diachithuongtru, @sosotamtru)";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@manhankhautamtru", nktt.MaNhanKhauTamTru);
                cmd.Parameters.AddWithValue("@madinhdanh", nktt.MaDinhDanh);
                cmd.Parameters.AddWithValue("@diachithuongtru", nktt.DiaChiThuongTru);
                cmd.Parameters.AddWithValue("@sosotamtru", nktt.SoSoTamTru);
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
        public bool XoaHHSV(string mssv)
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                string sql = "delete from hocsinhsinhvien where mssv=@mssv";
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
        public override bool delete(int row)
        {
            try
            {
                dataset.Tables["hocsinhsinhvien"].Rows[row].Delete();
                sqlda.Update(dataset, "hocsinhsinhvien");
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return false;

        }

        public override bool update(NhanKhauTamTruDTO hssv, int r)
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            try
            {
                //string sql = "update hocsinhsinhvien set truong=@truong, diachithuongtru=@diachithuongtru, tgbdtttt=@tgbdtttt, tgkttttt=@tgkttttt, vipham=@vipham where mssv=@mssv";
                //MySqlCommand cmd = new MySqlCommand(sql, conn);
                //cmd.Parameters.AddWithValue("@mssv", hssv.MSSV);
                //cmd.Parameters.AddWithValue("@truong", hssv.Truong);
                //cmd.Parameters.AddWithValue("@diachithuongtru", hssv.DiaChiThuongTru);
                //cmd.Parameters.AddWithValue("@tgbdtttt", hssv.TGBDTTTT.ToString("yyyy/MM/dd"));
                //cmd.Parameters.AddWithValue("@tgkttttt", hssv.TGKTTTTT.ToString("yyyy/MM/dd"));
                //cmd.Parameters.AddWithValue("@vipham)", hssv.ViPham);
                //cmd.ExecuteNonQuery();
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
        public override bool insert_table(NhanKhauTamTruDTO data)
        {
            throw new NotImplementedException();
        }
    }
    
}
