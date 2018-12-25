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
    public class AdminDAO : DBConnection<Admin>
    {
        public AdminDAO(): base() {}

        public override DataSet getAll()
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                sqlda = new MySqlDataAdapter("SELECT *, 'Delete' as 'Change' FROM admin1", conn);
                cmdbuilder = new MySqlCommandBuilder(sqlda);
                sqlda.InsertCommand = cmdbuilder.GetInsertCommand();
                sqlda.UpdateCommand = cmdbuilder.GetUpdateCommand();
                sqlda.DeleteCommand = cmdbuilder.GetDeleteCommand();
                dataset = new DataSet();
                sqlda.Fill(dataset, "admin1");
                return dataset;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                
                return null;
            }
            finally
            {
                conn.Close();
            }
            
        }
        public override bool insert(Admin ad)
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                DataRow dr = dataset.Tables["admin1"].NewRow();
                dr["macanbo"] = ad.MaCanBo;
                dr["mabaomat"] = ad.MaBaoMat;
                dataset.Tables["admin1"].Rows.Add(dr);
                dataset.Tables["admin1"].Rows.RemoveAt(dataset.Tables["admin1"].Rows.Count - 1);
                sqlda.Update(dataset, "admin1");
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
        public override bool delete(int row)
        {
            try
            {
                dataset.Tables["admin1"].Rows[row].Delete();
                sqlda.Update(dataset, "admin1");
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return false;

        }
        public override bool update(Admin ad, int r)
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();

            }
            try
            {
                string sql = "update admin1 set mabaomat =@mabaomat where macanbo =@macanbo";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@mabaomat", ad.MaBaoMat.ToString());
                cmd.Parameters.AddWithValue("@macanbo", ad.MaCanBo.ToString());
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                conn.Close();
            }
            return false;
        }
        public override bool insert_table(Admin data)
        {
            throw new NotImplementedException();
        }
    }
}

