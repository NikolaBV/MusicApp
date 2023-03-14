using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicApp
{
    public partial class SongsAdmin : Form
    {
        public SongsAdmin()
        {
            InitializeComponent();
        }

        private void SongsAdmin_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet1.Song' table. You can move, or remove it, as needed.
            this.songTableAdapter.Fill(this.dataSet1.Song);

        }

        private void GoToMenu_Click(object sender, EventArgs e)
        {
            AdminMenu am = new AdminMenu();
            am.Show();
            this.Hide();
        }
    }
}
