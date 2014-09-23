using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraBars;

namespace inacbg
{
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
           frmDataPeserta frm = new frmDataPeserta();
            frm.MdiParent=this;
            frm.Show();
            
            //FrmDokter
            //        .WindowState = FormWindowState.Maximized
            //        .MdiParent = Me
            //        .Show()
        }

        private void ribbon_Click(object sender, EventArgs e)
        {

        }
    }
}