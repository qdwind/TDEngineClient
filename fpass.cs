using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TDEngineClient
{
    public partial class fpass : Form
    {
        public string Pass;
        public bool SavePass;


        public fpass()
        {
            InitializeComponent();
        }

        private void fpass_FormClosed(object sender, FormClosedEventArgs e)
        {
            Pass = txtPass.Text;
            SavePass = chkSavePass.Checked;
        }
    }
}
