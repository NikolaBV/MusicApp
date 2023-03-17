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

            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\MusicAppDb.mdf;Integrated Security=True;Connect Timeout=30;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Replace the table name and column names with your own
                string query = "SELECT * FROM [User] WHERE Username=@Username AND Password=@Password";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Password", password);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    if (username == "admin" && password == "admin")
                    {
                        // Log in as an admin
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
                
                else
                {
                    MessageBox.Show("Incorrect credentials! Register or try to login again!");
                }
                /*
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
                */

            }

        }

        
    }
}
