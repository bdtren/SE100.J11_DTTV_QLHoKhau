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

        protected MySqlDataAdapter sqlda;
        protected DataSet dataset = null;
        protected MySqlCommandBuilder cmdbuilder;
        protected void UpdateDataset(int rowindex)
        {
            dataset.Tables["nhanvien"].Rows[rowindex].Delete();
            sqlda.Update(dataset, "nhanvien");
        }
        protected DataSet getQuery(string query)
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();

                }
                sqlda = new MySqlDataAdapter(query, conn);
                cmdbuilder = new MySqlCommandBuilder(sqlda);
                sqlda.InsertCommand = cmdbuilder.GetInsertCommand();
                sqlda.UpdateCommand = cmdbuilder.GetUpdateCommand();
                sqlda.DeleteCommand = cmdbuilder.GetDeleteCommand();
                dataset = new DataSet();
                sqlda.Fill(dataset,"nhanvien");
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
