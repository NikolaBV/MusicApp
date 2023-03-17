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
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void musicLabel_Click(object sender, EventArgs e)
        {

        }

        private void Register_Load(object sender, EventArgs e)
        {

        }

        private void Register_Click(object sender, EventArgs e)
        {
            if (CheckIfUserExists(txtUsernameReg.Text))
            {
                MessageBox.Show("There is existing user!");
            }
            else
            {
                RegisterUser(txtUsernameReg.Text, txtPasswordReg.Text);
            }
        }
        private void RegisterUser(string username, string password)
        {
            using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\MusicAppDb.mdf;Integrated Security=True;Connect Timeout=30;"))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("INSERT INTO [User] (Username, Password) VALUES (@Username, @Password)", connection);

                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Password", password);

                command.ExecuteNonQuery();

                connection.Close();
            }
            MessageBox.Show("Succsesful register!");
            Login login = new Login();
            login.Show();
            this.Hide();
        }
        private bool CheckIfUserExists(string username)
        {
            bool userExists = false;

            using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\MusicAppDb.mdf;Integrated Security=True;Connect Timeout=30;"))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM [User] WHERE Username = @Username", connection);

                command.Parameters.AddWithValue("@Username", username);

                int count = (int)command.ExecuteScalar();

                if (count > 0)
                {
                    userExists = true;
                }

                connection.Close();
            }

            return userExists;
        }

    }
}
