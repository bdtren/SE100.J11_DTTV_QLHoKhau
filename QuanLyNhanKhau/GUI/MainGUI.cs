using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Web;
using MySql.Data.MySqlClient;
using DTO;
using BUS;

namespace GUI
{
    public partial class MainGUI : Form
    {
        public MainGUI()
        {
            InitializeComponent();
            this.Text = BUS.Show.name;
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlDataReader myReader = DBConnection_MySQL.Query("SELECT * FROM TAIKHOAN");
                if (myReader.Read())
                {
                    tbContent.Text = myReader.GetString(1);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ((DBConnection_MySQL.ErrorString != "") ? "\n\n" + DBConnection_MySQL.ErrorString : ""));
            }
            finally
            {
                DBConnection_MySQL.closeConnection();
            }

            DataSet ds = DBConnection_MySQL.getData("SELECT * FROM TAIKHOAN");
            dgvContent.DataSource = ds.Tables[0];

        }
    }
}
