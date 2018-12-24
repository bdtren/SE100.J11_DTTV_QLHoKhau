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
    public abstract class DBConnection<T>
    {

        protected MySqlConnection conn;
        public DBConnection()
        {
            //string host = "127.0.0.1";
            //int port = 3306;
            //string database = "qlhk";
            //string username = "root";
            //string password = "";
            ////String connString = "Server=" + host + ";Database=" + database
            //    + ";port=" + port + ";User Id=" + username + ";password=" + password;
            string connString = "datasource=localhost;port=3306;username=root;password=;database=qlhk;SslMode=none";
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

        public abstract DataSet getAll();
        public abstract bool insert(T data);
        public abstract bool delete(int row);
        public abstract bool update(T data, int r);
    }
}
