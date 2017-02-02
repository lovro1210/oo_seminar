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
    public partial class formViewSeries : Form, IShowSeriesView
    {
        private SeriesController _seriesController;
        private Series _series;
        public formViewSeries(int id)
        {
            InitializeComponent();
            _seriesController = new SeriesController();
            _series = _seriesController.GetSeriesById(id);
            label1.Text = _series.Name;
            richTextBox1.Text = _series.Summary;
            for (int i = 0; i < _series.Episodes.Count(); i++)
            {
                Episode episode = _series.Episodes[i];

                ListViewItem lvt = new ListViewItem(episode.Name);
                lvt.Name = _series.Id.ToString();
                listView1.Items.Add(lvt);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            _seriesController.UpdateSeriesSub(_series.Id, checkBox1.Checked);
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
                return;
            var newForm = new formViewEpisode(Int32.Parse(listView1.SelectedItems[0].Name));
            this.Hide();
            newForm.ShowDialog();
            this.Show();
        }
    }
}
