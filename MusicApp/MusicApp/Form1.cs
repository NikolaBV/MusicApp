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

namespace MusicApp
{
    public partial class Login : Form
    {
        public SqlConnection connectionString = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\MusicAppDb.mdf;Integrated Security=True;Connect Timeout=30");
        public Login()
        {
            InitializeComponent();
        }

        private void Register_Click(object sender, EventArgs e)
        {
            Register register = new Register();
            register.Show();
            this.Hide();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string password = txtPasswordLog.Text;
            string username = txtUsernameLog.Text;

            try
            {
                if (username.Equals("admin") && password.Equals("admin"))
                {
                    AdminMenu am = new AdminMenu();
                    am.Show();
                    this.Hide();
                }
                else
                {
                    UserMenu um = new UserMenu();
                    um.Show();
                    this.Hide();
                }
            }
            catch
            {
                MessageBox.Show("err");
            }
        }

        
    }
}
