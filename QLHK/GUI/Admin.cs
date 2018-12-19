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
        CanBoBUS canbobus;
        CanBo canbo;
        public Sauwr()
        {
            InitializeComponent();
            nhanvienBUS = new NhanVienBUS();
            canbobus = new CanBoBUS();
            

        }
        
        private void LoadData()
        {
            switch (comboBox1.Text)
            {
                case "Cán bộ":
                        try
                        {
                            dataGridView1.DataSource = canbobus.GetAllCanBo().Tables["canbo"];
                            for (int i = 0; i < dataGridView1.Rows.Count; i++)
                            {
                                DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                                dataGridView1[dataGridView1.ColumnCount - 1, i] = linkCell;
                            }

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    break;
                case "Admin":
                    try
                    {
                        dataGridView1.DataSource = canbobus.GetAllCanBo().Tables["canbo"];
                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {
                            DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                            dataGridView1[dataGridView1.ColumnCount - 1, i] = linkCell;
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;
            }
            dataGridView1.DefaultCellStyle.ForeColor = Color.Black;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (comboBox1.Text)
            {
                case "Cán bộ":
                    {
                        try
                        {
                            if (e.ColumnIndex == dataGridView1.ColumnCount - 1)
                            {
                                string Task = dataGridView1.Rows[e.RowIndex].Cells[dataGridView1.ColumnCount - 1].Value.ToString();
                                if (Task == "Delete")
                                {
                                    if (MessageBox.Show("Bạn có chắc chắm muốn xóa không?", "Đang xóa...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                    {
                                        int rowIndex = e.RowIndex;
                                        canbobus.XoaCanBo(rowIndex);
                                    }
                                }
                                else if (Task == "Insert")
                                {
                                    int row = dataGridView1.Rows.Count - 2;

                                    canbo = new CanBo(dataGridView1.Rows[row].Cells["macanbo"].Value.ToString(), dataGridView1.Rows[row].Cells["tendangnhap"].Value.ToString(), dataGridView1.Rows[row].Cells["matkhau"].Value.ToString());
                                    canbobus.AddCanBo(canbo);
                                    dataGridView1.Rows.RemoveAt(dataGridView1.Rows.Count - 2);
                                    dataGridView1.Rows[e.RowIndex].Cells[dataGridView1.ColumnCount - 1].Value = "Delete";
                                }
                                else if (Task == "Update")
                                {
                                    int r = e.RowIndex;
                                    canbo = new CanBo(dataGridView1.Rows[r].Cells["macanbo"].Value.ToString(), dataGridView1.Rows[r].Cells["tendangnhap"].Value.ToString(), dataGridView1.Rows[r].Cells["matkhau"].Value.ToString());
                                    canbobus.SuaCanBo(canbo, r);
                                    dataGridView1.Rows[r].Cells[dataGridView1.ColumnCount - 1].Value = "Delete";
                                    LoadData();
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    break;
            }
            switch (comboBox1.Text)
            {
                case "Admin":
                    {
                        try
                        {
                            if (e.ColumnIndex == dataGridView1.ColumnCount - 1)
                            {
                                string Task = dataGridView1.Rows[e.RowIndex].Cells[dataGridView1.ColumnCount - 1].Value.ToString();
                                if (Task == "Delete")
                                {
                                    if (MessageBox.Show("Bạn có chắc chắm muốn xóa không?", "Đang xóa...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                    {
                                        int rowIndex = e.RowIndex;
                                        canbobus.XoaCanBo(rowIndex);
                                    }
                                }
                                else if (Task == "Insert")
                                {
                                    int row = dataGridView1.Rows.Count - 2;

                                    canbo = new CanBo(dataGridView1.Rows[row].Cells["macanbo"].Value.ToString(), dataGridView1.Rows[row].Cells["tendangnhap"].Value.ToString(), dataGridView1.Rows[row].Cells["matkhau"].Value.ToString());
                                    canbobus.AddCanBo(canbo);
                                    dataGridView1.Rows.RemoveAt(dataGridView1.Rows.Count - 2);
                                    dataGridView1.Rows[e.RowIndex].Cells[dataGridView1.ColumnCount - 1].Value = "Delete";
                                }
                                else if (Task == "Update")
                                {
                                    int r = e.RowIndex;
                                    canbo = new CanBo(dataGridView1.Rows[r].Cells["macanbo"].Value.ToString(), dataGridView1.Rows[r].Cells["tendangnhap"].Value.ToString(), dataGridView1.Rows[r].Cells["matkhau"].Value.ToString());
                                    canbobus.SuaCanBo(canbo, r);
                                    dataGridView1.Rows[r].Cells[dataGridView1.ColumnCount - 1].Value = "Delete";
                                    LoadData();
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    break;
            }

        }

        private void dataGridView1_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            try
            {
                int lastRow = dataGridView1.Rows.Count - 2;
                DataGridViewRow nRow = dataGridView1.Rows[lastRow];
                DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                dataGridView1[dataGridView1.ColumnCount - 1, lastRow] = linkCell;
                nRow.Cells["Delete"].Value = "Insert";
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int lastRow = e.RowIndex;
                DataGridViewRow nRow = dataGridView1.Rows[lastRow];
                DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                dataGridView1[dataGridView1.ColumnCount - 1, lastRow] = linkCell;
                nRow.Cells["Delete"].Value = "Update";
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
                    dataGridView1.DataSource = null;
                    dataGridView1.Rows.Clear();
                    LoadData();
        }

    }
}
