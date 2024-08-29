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
using TDEngineClient.Services;

namespace TDEngineClient
{
    public partial class fserver : Form
    {
        public Server Server { get; } = new Server();

        public fserver(int langCode,Server svr=null)
        {
            InitializeComponent();
            if (svr != null)
                Server = svr;

            SetLanguage(langCode); //设置语言
        }

        private void btnView_Click(object sender, EventArgs e)
        {

        }


        private void btnView_MouseDown(object sender, MouseEventArgs e)
        {
            txtPass.PasswordChar = Convert.ToChar(0);
        }

        private void btnView_MouseUp(object sender, MouseEventArgs e)
        {
            txtPass.PasswordChar = '*';
        }

        private void fserver_Load(object sender, EventArgs e)
        {
            txtServer.Text = Server.IP;
            txtPort.Text = Server.Port>0? Server.Port.ToString():"6041";
            txtUser.Text = Server.Username;          
            txtAlias.Text = Server.AliasName;
            chkSavePass.Checked = Server.SavePass;
            if (Server.SavePass)
            {
                txtPass.Text = Server.Password;
            }
        }

        private void SaveServer()
        {
            Server.IP = txtServer.Text;
            Server.Port = int.TryParse(txtPort.Text, out int port) ? port : 0;
            Server.Username = txtUser.Text;
            Server.AliasName = txtAlias.Text;
            Server.SavePass = chkSavePass.Checked;
            if (chkSavePass.Checked)
            {
                Server.Password = txtPass.Text;
            }
            else
            {
                Server.Password = "";
            }
            if (string.IsNullOrEmpty(Server.Username))
            {
                Server.Url = $"https://{Server.IP}/rest/sql?token={Server.Password}"; //token模式
            }
            else
            {
                Server.Url = $"http://{Server.IP}:{Server.Port}/rest/sql"; //用户名模式
            }
        }



        private void fserver_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveServer();
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            SaveServer();
            var result = MyService.GetDbList(Server);
            if (result != null)
            {
                MessageBox.Show("Connect Success.", "Ok", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Connect Failed." , "Error", MessageBoxButtons.OK);
            }
        }


        private void SetLanguage(int lanCode)
        {
            this.Text = lanCode == 0 ? "Server Config" : "服务器设置";
            lblAlias.Text = lanCode == 0 ? "Alias" : "别名";
            lblServer.Text = lanCode == 0 ? "Server" : "服务器";
            lblUser.Text = lanCode == 0 ? "User" : "用户名";
            lblPass.Text = lanCode == 0 ? "Pass" : "密码";
            lblPort.Text = lanCode == 0 ? "Port" : "端口";
            chkSavePass.Text = lanCode == 0 ? "Save Password" : "保存密码";
            btnOk.Text = lanCode == 0 ? "Ok" : "确定";
            btnCancel.Text = lanCode == 0 ? "Cancel" : "取消";
            btnTest.Text = lanCode == 0 ? "Test" : "测试";

        }


    }
}
