using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YoutubeExplode;
using YoutubeExplode.Videos.Streams;
using YoutubeExplode.Search;
using YoutubeExplode.Exceptions;
using YoutubeExplode.Common;
using NAudio.Wave;
using System.Net;

namespace MusicApp
{
    public partial class SongsAdmin : Form
    {
        Player player = new Player();
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

        private async void btnPlay_Click(object sender, EventArgs e)
        {
            player.Play();
        }

        private void Brouse_Click(object sender, EventArgs e)
        {
            using(OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Mp3 Files|*.mp3";
                if(ofd.ShowDialog() == DialogResult.OK)
                {
                    player.Open(ofd.FileName);
                }
            }
        }

        private void Stop_Click(object sender, EventArgs e)
        {
            player.Stop();

        }
    }
    
    
}
