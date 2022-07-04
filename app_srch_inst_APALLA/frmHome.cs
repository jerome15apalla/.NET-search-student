using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace app_srch_inst_APALLA
{
    public partial class frmHome : Form
    {
        public frmHome()
        {
            InitializeComponent();
        }
        private void btnInsert_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmInsert insert = new frmInsert();
            insert.ShowDialog();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmSearch search = new frmSearch();
            search.ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmEdit edit = new frmEdit();
            edit.ShowDialog();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmLogin logout = new frmLogin();
            logout.ShowDialog();
        }
    }
}
