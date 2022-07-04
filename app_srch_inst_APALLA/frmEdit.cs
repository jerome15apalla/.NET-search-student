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
    public partial class frmEdit : Form
    {
        string connStr = "server=localhost; port=3306; database=dbltmidterm; uid=root; pwd=jerome15apalla";
        MySqlConnection conn;

        public frmEdit()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            conn = new MySqlConnection(connStr);
            conn.Open();

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * FROM stud_records where stud_id='" + txtSearch.Text + "'";

            MySqlDataReader rdr = cmd.ExecuteReader();

            if (rdr.HasRows)
            {
                rdr.Read();

                txtStud.Text = rdr["stud_id"].ToString();
                txtFname.Text = rdr["fname"].ToString();
                txtLname.Text = rdr["lname"].ToString();
                txtAge.Text = rdr["age"].ToString();
                txtAddress.Text = rdr["address"].ToString();
                txtHobby.Text = rdr["hobby"].ToString();

                btnEdit.Enabled = true;

                MessageBox.Show("Student ID: " + txtStud.Text + " \nFirst Name:" + txtFname.Text +
                    "\nLast Name:" + txtLname.Text + "\nAge:" + txtAge.Text + "\nAddress:" + txtAddress.Text + "\nHobby:" + txtHobby.Text, "Search Results");
            }
            else
            {
                MessageBox.Show("Record not found", "Search Results", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            conn.Close();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
            txtFname.Enabled = true;
            txtLname.Enabled = true;
            txtAge.Enabled = true;
            txtAddress.Enabled = true;
            txtHobby.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            conn = new MySqlConnection(connStr);
            conn.Open();

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "UPDATE stud_records SET Fname='"+txtFname.Text+ "', Lname='" + txtLname.Text + "',Age='" + txtAge.Text + "',Address='" + txtAddress.Text + "',Hobby='" + txtHobby.Text + "'";
            cmd.ExecuteNonQuery();
            conn.Close();

            txtStud.Clear();
            txtFname.Clear();
            txtLname.Clear();
            txtAge.Clear();
            txtAddress.Clear();
            txtHobby.Clear();

            btnEdit.Enabled = false;
            btnSave.Enabled = false;
            txtFname.Enabled = false;
            txtLname.Enabled = false;
            txtAge.Enabled = false;
            txtAddress.Enabled = false;
            txtHobby.Enabled = false;

            MessageBox.Show("Record Updated Successfully","Update");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmHome backHome = new frmHome();
            backHome.ShowDialog();
        }
    }
}
