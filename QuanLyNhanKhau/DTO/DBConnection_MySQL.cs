using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace DTO
{
    public class DBConnection_MySQL
    {
        static string MySQLConnectionString = "datasource=db4free.net;port=3306;username=dbquanlynhankhau;password=123Ren123;database=dbquanlynhankhau; old guids = true;";
        protected static MySqlConnection connection = new MySqlConnection(MySQLConnectionString);
        private static string errorString = "";

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

        public static MySqlDataReader Query(string query)
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

    }
}
