using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql;
using DTO;
using MySql.Data.MySqlClient;

namespace DAO
{
    public class CanBoDAO : DBConnection<CanBo>
    {
        public CanBoDAO() : base() { }
        public override DataSet getAll()
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();

                }
                sqlda = new MySqlDataAdapter("SELECT *, 'Delete' as 'Change' FROM canbo", conn);
                cmdbuilder = new MySqlCommandBuilder(sqlda);
                sqlda.InsertCommand = cmdbuilder.GetInsertCommand();
                sqlda.UpdateCommand = cmdbuilder.GetUpdateCommand();
                sqlda.DeleteCommand = cmdbuilder.GetDeleteCommand();
                dataset = new DataSet();
                sqlda.Fill(dataset, "canbo");
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

        public override bool insert(CanBo data)
        {
            try
            {

                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }

                string sql = "insert into canbo values(@macanbo,@manhankhauthuongtru,  @tentaikhoan, @matkhau, @loaicanbo)";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@macanbo", data.MaCanBo);
                cmd.Parameters.AddWithValue("@manhankhauthuongtru", data.MaNhanKhauThuongTru);
                cmd.Parameters.AddWithValue("@tentaikhoan", data.TenTaiKhoan);
                cmd.Parameters.AddWithValue("@matkhau", data.MatKhau);
                cmd.Parameters.AddWithValue("@loaicanbo", data.LoaiCanBo);
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
                dataset.Tables["canbo"].Rows[row].Delete();
                sqlda.Update(dataset, "canbo");
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return false;

        }
        public override bool update(CanBo cb, int r)
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            try
            {
                
                string sql= "update canbo set manhankhauthuongtru= @manhankhauthuongtru, tentaikhoan =@tentaikhoan , matkhau=@matkhau, loaicanbo=@loaicanbo where macanbo =@macanbo";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@manhankhauthuongtru", cb.MaNhanKhauThuongTru);
                cmd.Parameters.AddWithValue("@tentaikhoan", cb.TenTaiKhoan);
                cmd.Parameters.AddWithValue("@matkhau", cb.MatKhau);
                cmd.Parameters.AddWithValue("@loaicanbo", cb.LoaiCanBo);
                cmd.Parameters.AddWithValue("@macanbo", cb.MaCanBo);
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
        public override bool insert_table(CanBo data)
        {
            try
            {
                DataRow dr = dataset.Tables["canbo"].NewRow();
                dr["macanbo"] = data.MaCanBo;
                dr["manhankhauthuongtru"] = data.MaNhanKhauThuongTru;
                dr["tentaikhoan"] = data.TenTaiKhoan;
                dr["matkhau"] = data.MatKhau;
                dr["loaicanbo"] = data.LoaiCanBo;

                dataset.Tables["canbo"].Rows.Add(dr);
                dataset.Tables["canbo"].Rows.RemoveAt(dataset.Tables["canbo"].Rows.Count - 1);
                sqlda.Update(dataset, "canbo");
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
    }
}
