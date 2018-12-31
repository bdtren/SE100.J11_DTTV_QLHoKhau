using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class Home : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public Home()
        {
            InitializeComponent();
        }

        private void ribbonControl1_Click(object sender, EventArgs e)
        {

        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void barButtonItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void Canbodulieu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
        public void ThemForm()
        {
           /* fr_CBDuLieu cbdulieu_gui = new fr_CBDuLieu();
            int index = hamkiemtrtontai(tabControl1, hssv_gui);
            if (index >= 0)
            {
                tabControl1.TabIndex = index;
            }
            else
            {
                TabPage mytabpage = new TabPage(Text = hssv_gui.Text);
                mytabpage.BorderStyle = BorderStyle.Fixed3D;
                tabControl1.TabPages.Add(mytabpage);
                hssv_gui.TopLevel = false;
                hssv_gui.Parent = mytabpage;
                hssv_gui.Show();
                hssv_gui.Dock = DockStyle.Fill;
            }*/

        }
        int hamkiemtrtontai(TabControl tbc, Form frm)
        {
            for (int i = 0; i < tbc.TabCount; i++)
            {
                if (tbc.TabPages[i].Text.Trim() == frm.Text.Trim())
                    return i;
            }
            return -1;
        }
    }
}
