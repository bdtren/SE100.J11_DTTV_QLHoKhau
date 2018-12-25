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
    public class XaPhuongThiTranDAO:DBConnection<XaPhuongThiTranDTO>
    {
        public XaPhuongThiTranDAO() : base() { }

        public override DataSet getAll()
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                sqlda = new MySqlDataAdapter("SELECT *, 'Delete' as 'Change' FROM xaphuongthitran", conn);
                cmdbuilder = new MySqlCommandBuilder(sqlda);
                sqlda.InsertCommand = cmdbuilder.GetInsertCommand();
                sqlda.UpdateCommand = cmdbuilder.GetUpdateCommand();
                sqlda.DeleteCommand = cmdbuilder.GetDeleteCommand();
                dataset = new DataSet();
                sqlda.Fill(dataset, "xaphuongthitran");
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

        public override bool insert(XaPhuongThiTranDTO xaphuong)
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                DataRow dr = dataset.Tables["xaphuongthitran"].NewRow();
                dr["maxa"] = xaphuong.MaQH;
                dr["maqh"] = xaphuong.MaQH;
                dr["ten"] = xaphuong.Ten;
                dr["kieu"] = xaphuong.Kieu;

                dataset.Tables["xaphuongthitran"].Rows.Add(dr);
                dataset.Tables["v"].Rows.RemoveAt(dataset.Tables["xaphuongthitran"].Rows.Count - 1);
                sqlda.Update(dataset, "xaphuongthitran");
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
                dataset.Tables["xaphuongthitran"].Rows[row].Delete();
                sqlda.Update(dataset, "xaphuongthitran");
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return false;
        }

        public override bool update(XaPhuongThiTranDTO xaphuong, int r)
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();

            }
            try
            {
                string sql = "update xaphuongthitran set maxa =@maxa,  ten=@ten, kieu=@kieu, maqh =@mqah";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@maxa", xaphuong.MaQH.ToString());
                cmd.Parameters.AddWithValue("@maqh", xaphuong.MaQH.ToString());
                cmd.Parameters.AddWithValue("@ten", xaphuong.Ten.ToString());
                cmd.Parameters.AddWithValue("@kieu", xaphuong.Kieu.ToString());

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
    }
}
