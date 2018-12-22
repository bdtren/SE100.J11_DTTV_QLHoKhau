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
    public class DanTocDAO: DBConnection
    {
        public DanTocDAO():base() { }
        public DataSet GetAllDanToc()
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();

                }
                sqlda = new MySqlDataAdapter("SELECT *, 'Delete' as 'Change' FROM dantoc", conn);
                cmdbuilder = new MySqlCommandBuilder(sqlda);
                sqlda.InsertCommand = cmdbuilder.GetInsertCommand();
                sqlda.UpdateCommand = cmdbuilder.GetUpdateCommand();
                sqlda.DeleteCommand = cmdbuilder.GetDeleteCommand();
                dataset = new DataSet();
                sqlda.Fill(dataset, "dantoc");
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
        public bool AddDanToc(DanToc dt)
        {
            try
            {
                DataRow dr = dataset.Tables["dantoc"].NewRow();
                dr["madantoc"] = dt.MaDanToc;
                dr["tendantoc"] = dt.TenDanToc;
                dataset.Tables["dantoc"].Rows.Add(dr);
                dataset.Tables["dantoc"].Rows.RemoveAt(dataset.Tables["dantoc"].Rows.Count - 1);
                sqlda.Update(dataset, "dantoc");
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
        public bool XoaDanToc(int row)
        {
            try
            {
                dataset.Tables["dantoc"].Rows[row].Delete();
                sqlda.Update(dataset, "dantoc");
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return false;

        }
        public bool SuaDanToc(DanToc dt, int r)
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();

            }
            try
            {
                string sql = "update dantoc set  tendantoc=@tendantoc where madantoc =@madantoc";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@tendantoc", dt.TenDanToc.ToString());
                cmd.Parameters.AddWithValue("@madantoc", dt.MaDanToc.ToString());
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
