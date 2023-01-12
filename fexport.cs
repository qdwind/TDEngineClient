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
    public partial class fexport : Form
    {
        public string FolderName { get; set; } = "";
        public List<string> TableNames { get; set; } = new List<string>();

        public fexport(NodeItem item)
        {
            InitializeComponent();
            SetTables(item);
        }

        private void SetTables(NodeItem item)
        {
            chklist.Items.Clear();
            if (item.Table != null)
            {
                chklist.Items.Add(item.Table.ToString());
            }
            else if (item.STable != null)
            {
                foreach (var tb in item.STable.Tables)
                {
                    chklist.Items.Add(tb.ToString());
                }
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            var dlg = new FolderBrowserDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                txtSaveAs.Text = dlg.SelectedPath;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            FolderName = txtSaveAs.Text;
            TableNames.Clear();
            foreach (var item in chklist.CheckedItems)
            {
                TableNames.Add(item.ToString());
            }
            
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < chklist.Items.Count; i++)
            {
                chklist.SetItemChecked(i, chkAll.Checked);
            }
        }
    }
}
