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
using MySql.Data.MySqlClient;

namespace app_srch_inst_APALLA
{
    public partial class frmSearch : Form
    {
        string connStr = "server=localhost; port=3306; database=dbltmidterm; uid=root; pwd=jerome15apalla";
        MySqlConnection conn;

        public frmSearch()
        {
            InitializeComponent();
        }

        private void btnMultiSearch_Click(object sender, EventArgs e)
        {
            string query = "SELECT stud_id, fname, lname, age, address, hobby FROM stud_records where stud_id='" + txtSearch.Text + "'";

            conn = new MySqlConnection(connStr);
            conn.Open();

            MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);

            DataTable dt = new DataTable();
            adapter.Fill(dt);

            grdResults.DataSource = dt;
            conn.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmHome backHome = new frmHome();
            backHome.ShowDialog();
        }
    }
}
