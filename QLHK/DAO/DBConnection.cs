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
    }
}
