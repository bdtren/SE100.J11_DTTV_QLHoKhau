using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BUS;


namespace GUI
{
    public partial class Sauwr : DevExpress.XtraEditors.XtraForm
    {
        NhanVienBUS nhanvienBUS;
        public Sauwr()
        {
            InitializeComponent();
            nhanvienBUS = new NhanVienBUS();

        }
        
        private void LoadData()
        {
            try
            {
                //dataGridView1.DataSource = null;
                dataGridView1.DataSource = nhanvienBUS.GetAllNhanVien();
                   // dataset.Tables["tbl_students"];
                /*for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                    dataGridView1[5, i] = linkCell;
                }*/
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //dataGridView1.Rows[0].DefaultCellStyle.ForeColor = Color.Black;
            dataGridView1.DefaultCellStyle.ForeColor = Color.Black;
        }

        private void Sauwr_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
