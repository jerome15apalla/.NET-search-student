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
    public partial class frmLogin : Form
    {
        string connStr = "server=localhost; port=3306; database=dbltmidterm; uid=root; pwd=jerome15apalla";
        MySqlConnection conn;
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            conn = new MySqlConnection(connStr);
            conn.Open();

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from accounts where uname='" + txtUname.Text + "' and pword='" + txtPword.Text + "'";

            MySqlDataReader rdr = cmd.ExecuteReader();

            if (rdr.HasRows)
            {
                MessageBox.Show("Login Successful!", "Login", MessageBoxButtons.OK,MessageBoxIcon.Information);
                conn.Close();

                this.Hide();
                frmHome home = new frmHome();
                home.ShowDialog();
            }
            else
            {
                MessageBox.Show("Login Failed! Username or Password is invalid!", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
