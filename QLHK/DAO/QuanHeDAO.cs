using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using MySql.Data.MySqlClient;

namespace DAO
{
    public class QuanHeDAO:DBConnection
    {
        public QuanHeDAO() : base() { }
        public DataSet GetAllQuanHe()
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();

                }
                sqlda = new MySqlDataAdapter("SELECT *, 'Delete' as 'Change' FROM quanhe", conn);
                cmdbuilder = new MySqlCommandBuilder(sqlda);
                sqlda.InsertCommand = cmdbuilder.GetInsertCommand();
                sqlda.UpdateCommand = cmdbuilder.GetUpdateCommand();
                sqlda.DeleteCommand = cmdbuilder.GetDeleteCommand();
                dataset = new DataSet();
                sqlda.Fill(dataset, "quanhe");
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
        public bool AddQuanHe(QuanHe qh)
        {
            try
            {
                DataRow dr = dataset.Tables["quanhe"].NewRow();
                dr["maquanhe"] = qh.MaQuanHe;
                dr["tenquanhe"] = qh.TenQuanHe;
                dataset.Tables["quanhe"].Rows.Add(dr);
                dataset.Tables["quanhe"].Rows.RemoveAt(dataset.Tables["quanhe"].Rows.Count - 1);
                sqlda.Update(dataset, "quanhe");
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
        public bool XoaQuanHe(int row)
        {
            try
            {
                dataset.Tables["quanhe"].Rows[row].Delete();
                sqlda.Update(dataset, "quanhe");
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return false;

        }
        public bool SuaQuanHe(QuanHe qh, int r)
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();

            }
            try
            {
                string sql = "update quanhe set  tenquanhe=@tenquanhe where maquanhe =@maquanhe";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@tenquanhe", qh.TenQuanHe.ToString());
                cmd.Parameters.AddWithValue("@madantoc", qh.MaQuanHe.ToString());
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return false;
        }
    }
}
