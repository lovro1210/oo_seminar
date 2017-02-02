using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySeries.BaseLib;
using MySeries.Controllers;
using MySeries.Model;

namespace MySeries.Desktop
{
    public partial class formViewEpisode : Form, IShowEpisodeView
    {
        private UserEpisode _userEpisode;
        private EpisodeController _episodeController;
        public formViewEpisode(int id)
        {
            InitializeComponent();
            _episodeController = new EpisodeController();
            Episode episode = _episodeController.GetEpisodeById(id);
            label1.Text = episode.Name + " - " + episode.Series.Name;
            richTextBox1.Text = episode.Summary;
            _userEpisode = _episodeController.GetUserEpisode(Common.user, episode);
            richTextBox2.Text = _userEpisode.Comment;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _userEpisode.Comment = richTextBox2.Text;
            _episodeController.UpdateUserEpisode(_userEpisode);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            _userEpisode.Watched = checkBox1.Checked;
            _episodeController.UpdateUserEpisode(_userEpisode);
        }
    }
}
