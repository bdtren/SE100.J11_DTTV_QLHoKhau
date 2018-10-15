using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.ComponentModel.DataAnnotations;
using DevExpress.XtraBars;
using DTO;

namespace GUI_DX
{
    public partial class MainGUI : XtraForm
    {
        public MainGUI()
        {
            InitializeComponent();
            this.Text = BUS.Show.name;

            DataSet tables = DBConnection_MySQL.getData("show tables from dbquanlynhankhau");
            foreach (DataRow item in tables.Tables[0].Rows)
            {
                cbbTables.Items.Add(item[0].ToString());
            }
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    MySqlDataReader myReader = DBConnection_MySQL.Query_MySQL("SELECT * FROM TAIKHOAN");
            //    if (myReader.Read())
            //    {
            //        //tbContent.Text = myReader.GetString(1);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message + ((DBConnection_MySQL.ErrorString != "") ? "\n\n" + DBConnection_MySQL.ErrorString : ""));
            //}
            //finally
            //{
            //    DBConnection_MySQL.closeConnection();
            //}

            //string selected = cbbTables.GetItemText(cbbTables.SelectedItem);
            string selected = cbbTables.Text;
            if (string.IsNullOrWhiteSpace(selected))
            {
                return;
            }
            string query = "SELECT * FROM " + selected;
            DataSet ds = DBConnection_MySQL.getData(query);
            dgvContent.DataSource = ds.Tables[0];

        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = DBConnection_MySQL.getData(rtbQuery.Text);
                dgvQueryResult.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
