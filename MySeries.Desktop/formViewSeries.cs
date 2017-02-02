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

namespace MySeries.Desktop
{
    public partial class formViewSeries : Form, IShowSeriesView
    {
        public formViewSeries(int id)
        {
            InitializeComponent();

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
