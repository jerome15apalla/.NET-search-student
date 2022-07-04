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
    public partial class frmInsert : Form
    {
        string connStr = "server=localhost; port=3306; database=dbltmidterm; uid=root; pwd=jerome15apalla";
        MySqlConnection conn;

        public frmInsert()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            conn = new MySqlConnection(connStr);
            conn.Open();

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT INTO stud_records(`stud_id`,`fname`,`lname`,`age`,`address`,`hobby`)" +
                "VALUES('" + txtStud.Text + "','" + txtFname.Text + "','" + txtLname.Text + "','" + txtAge.Text + "','" + txtAddress.Text + "','" + txtHobby.Text + "')";
            cmd.ExecuteNonQuery();
            conn.Close();

            MessageBox.Show("Record added to the database","Success");
            txtStud.Clear();
            txtFname.Clear();
            txtLname.Clear();
            txtAge.Clear();
            txtAddress.Clear();
            txtHobby.Clear();

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtStud.Clear();
            txtFname.Clear();
            txtLname.Clear();
            txtAge.Clear();
            txtAddress.Clear();
            txtHobby.Clear();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmHome backHome = new frmHome();
            backHome.ShowDialog();
        }
    }
}
