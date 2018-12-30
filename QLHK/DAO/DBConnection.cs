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
            string connString = "datasource=localhost;port=3306;username=root;password=;database=qlhk;SslMode=none;charset=utf8;";
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

        /// <summary>
        /// Static classes and variable to get data
        /// </summary>

        protected static string connStr = "datasource=localhost;port=3306;username=root;password=;database=qlhk;SslMode=none";
        protected static MySqlConnection connection = new MySqlConnection(connStr);
        private static string errorString = "";
        public static MySqlConnection getConnection()
        {
            return connection;
        }

        public static string ErrorString { get => errorString; }

        public static bool openConnection()
        {
            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                return true;
            }
            catch (Exception e)
            {
                errorString += e.Message + "\n\n";
                return false;
            }
        }

        public static bool closeConnection()
        {
            try
            {
                if (connection.State != ConnectionState.Closed)
                {
                    connection.Close();
                }
                return true;
            }
            catch (MySqlException ex)
            {
                errorString += ex.Message + "\n\n";
                return false;
            }
        }

        public static MySqlDataReader Query_MySQL(string query)
        {
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.CommandTimeout = 60;

            try
            {
                openConnection();

                MySqlDataReader myReader = cmd.ExecuteReader();
                //if (myReader.HasRows)
                //{
                //    return myReader;
                //}
                //return null;
                return myReader;
            }
            catch (Exception e)
            {
                return null;
            }
            //finally
            //{
            //    closeConnection();
            //}
        }

        public static DataSet getData(string query)
        {
            MySqlDataAdapter mDataAdapter = new MySqlDataAdapter(query, connection);
            DataSet Ds = new DataSet();

            try
            {
                openConnection();

                mDataAdapter.Fill(Ds);
                return Ds;
            }
            catch (Exception e)
            {
                errorString += e.Message + "\n\n";
                return null;
            }
            finally
            {
                closeConnection();
            }
        }



        public abstract DataSet getAll();
        public abstract bool insert(T data);//can bo thao tac
        public abstract bool insert_table(T data);//admin thao tac
        public abstract bool delete(int row);//admin thao tac
        public abstract bool update(T data, int r);
    }
}
