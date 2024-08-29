using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TDEngineClient.Entity;

namespace TDEngineClient
{
    public partial class foption : Form
    {
        public SystemConfig Options { get; set; } = new SystemConfig();
        public foption(SystemConfig config)
        {
            InitializeComponent();
            Options = config;
        }

        private void foption_Load(object sender, EventArgs e)
        {
            chkColorKey.Checked = Options.ColoredKey;
            chkTip.Checked = Options.ShowTip;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Options.ColoredKey = chkColorKey.Checked;
            Options.ShowTip = chkTip.Checked;
        }
    }
}
