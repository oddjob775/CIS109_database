using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace databaseLogin
{
    public partial class loginForm : Form
    {
        public loginForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection sqlcon = new SqlConnection(@"Data Source=ODDJOB775;Initial Catalog=userLogin;Integrated Security=True");
            string query = "select * from logins where username ='"+usernameText.Text.Trim()+ "'and password='" +passwordText.Text.Trim()+"'";
            SqlDataAdapter sda = new SqlDataAdapter(query, sqlcon);
            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);
            if (dtbl.Rows.Count ==1)
            {
                frmloggedin objfrmLoggedIn = new frmloggedin();
                this.Hide();
                objfrmLoggedIn.Show();
            }
            else
            {
                MessageBox.Show("Please check that your username and password credentials are correct");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
