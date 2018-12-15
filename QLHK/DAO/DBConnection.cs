using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;

namespace DAO
{
    public class DBConnection
    {

        protected MySqlConnection conn;
        public DBConnection()
        {
            string host = "127.0.0.1";
            int port = 3306;
            string database = "qlhk";
            string username = "root";
            string password = "";
            String connString = "Server=" + host + ";Database=" + database
                + ";port=" + port + ";User Id=" + username + ";password=" + password;
            try
            {
                conn = new MySqlConnection(connString);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        MySqlDataAdapter sqlda;
        DataTable dataset = null;
        protected DataTable getQuery(string query)
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();

                }
                //sqlcommand = new MySqlCommand("SELECT * FROM qlhk.nhanvien", conn);
                //sqlAdapter.InsertCommand = sqlCommand.GetInsertCommand();
                //sqlAdapter.UpdateCommand = sqlCommand.GetUpdateCommand();
                //sqlAdapter.DeleteCommand = sqlCommand.GetDeleteCommand();
                sqlda = new MySqlDataAdapter(query, conn);
                dataset = new DataTable();
                sqlda.Fill(dataset);
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
