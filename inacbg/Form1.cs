using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace inacbg
{

    public partial class frmDataPeserta : Form
    {
        string cnstr = System.Configuration.ConfigurationManager.ConnectionStrings["cnstr"].ToString();
MySqlConnection  con ;


        public frmDataPeserta()
        {
            InitializeComponent();
            con = new MySqlConnection(cnstr);

        }

        private void btnTampil_Click(object sender, EventArgs e)
        {
            string sql = "select*from users";
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(sql,con);
            da.Fill(dt);
            gridControl1.DataSource = dt;

            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "CSV File|*.csv|Pdf File|*.pdf";
            DialogResult answer = dlg.ShowDialog();
            string savePath;
            if (answer == System.Windows.Forms.DialogResult.OK)
            {              
                savePath = dlg.FileName;

                if (dlg.FilterIndex == 0)
                {
                    DevExpress.XtraPrinting.CsvExportOptions opt = new DevExpress.XtraPrinting.CsvExportOptions();
                    opt.Separator = ";";
                    gridControl1.ExportToCsv(savePath, opt);
                }

                if (dlg.FilterIndex ==1)
                    gridControl1.ExportToPdf (savePath);
                              
            }
                
            
        }

     
        private void btnShow_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = string.Format("CALL sp_select_datnkapst_byNokapst ('{0}')", textEdit1.Text); 
                DataTable dt = new DataTable();
                con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(sql, con);
                da.Fill(dt);
                con.Close();
                gridControl1.DataSource = dt;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
            
        }

        private void textEdit1_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {

                if (e.KeyChar == 13)
                //if (e.KeyChar == (char)Keys.Enter)
                {
                    string sql = string.Format("CALL sp_select_datnkapst_byNokapst ('{0}')", textEdit1.Text);
                    DataTable dt = new DataTable();
                    con.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter(sql, con);
                    da.Fill(dt);
                    con.Close();
                    gridControl1.DataSource = dt;
                } 
                //if (e.KeyChar == 13) { MessageBox.Show("Enter key pressed"); }
               

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }
    }
}
