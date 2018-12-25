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
        public bool XoaNKTT(string manhankhautamtru)
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                string sql = "delete from nhankhautamtru where manhankhautamtru=@manhankhautamtru";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@manhankhautamtru", manhankhautamtru);
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
                dataset.Tables["nhankhautamtru"].Rows[row].Delete();
                sqlda.Update(dataset, "nhankhautamtru");
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return false;

        }

        public override bool update(NhanKhauTamTruDTO nktt, int r)
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            try
            {

                string sql = "update nhankhautamtru set diachithuongtru=@diachithuongtru, sosotamtru=@sosotamtru where manhankhautamtru=@manhankhautamtru";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@diachithuongtru", nktt.DiaChiThuongTru);
                cmd.Parameters.AddWithValue("@sosotamtru", nktt.SoSoTamTru);
                cmd.Parameters.AddWithValue("@manhankhautamtru", nktt.MaNhanKhauTamTru);
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
        public DataSet TimKiem(string manhankhautamtru)
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                sqlda = new MySqlDataAdapter("SELECT * FROM nhankhautamtru where manhankhautamtru='" + manhankhautamtru + "'", conn);
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
        public override bool insert_table(NhanKhauTamTruDTO data)
        {
            throw new NotImplementedException();
        }
    }
    
}
