
namespace TDEngineClient
{
    partial class fserver
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtServer = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnView = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAlias = new System.Windows.Forms.TextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnTest = new System.Windows.Forms.Button();
            this.chkSavePass = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // txtServer
            // 
            this.txtServer.Location = new System.Drawing.Point(127, 71);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(192, 25);
            this.txtServer.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Server";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(71, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Port";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(127, 116);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(192, 25);
            this.txtPort.TabIndex = 2;
            this.txtPort.Text = "6041";
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(127, 159);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(192, 25);
            this.txtUser.TabIndex = 0;
            this.txtUser.Text = "root";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(71, 162);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 15);
            this.label3.TabIndex = 1;
            this.label3.Text = "User";
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(127, 204);
            this.txtPass.Name = "txtPass";
            this.txtPass.PasswordChar = '*';
            this.txtPass.Size = new System.Drawing.Size(170, 25);
            this.txtPass.TabIndex = 2;
            this.txtPass.Text = "taosdata";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(71, 207);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "Pass";
            // 
            // btnView
            // 
            this.btnView.Location = new System.Drawing.Point(297, 203);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(24, 28);
            this.btnView.TabIndex = 4;
            this.btnView.Text = "👁";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            this.btnView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnView_MouseDown);
            this.btnView.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnView_MouseUp);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(63, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 15);
            this.label5.TabIndex = 6;
            this.label5.Text = "Alias";
            // 
            // txtAlias
            // 
            this.txtAlias.Location = new System.Drawing.Point(127, 31);
            this.txtAlias.Name = "txtAlias";
            this.txtAlias.Size = new System.Drawing.Size(192, 25);
            this.txtAlias.TabIndex = 5;
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(190, 293);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(107, 38);
            this.btnOk.TabIndex = 7;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(309, 291);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(101, 39);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(27, 294);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(101, 36);
            this.btnTest.TabIndex = 9;
            this.btnTest.Text = "Test";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // chkSavePass
            // 
            this.chkSavePass.AutoSize = true;
            this.chkSavePass.Checked = true;
            this.chkSavePass.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSavePass.Location = new System.Drawing.Point(127, 235);
            this.chkSavePass.Name = "chkSavePass";
            this.chkSavePass.Size = new System.Drawing.Size(166, 24);
            this.chkSavePass.TabIndex = 10;
            this.chkSavePass.Text = "Save Password";
            this.chkSavePass.UseVisualStyleBackColor = true;
            // 
            // fserver
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(443, 397);
            this.ControlBox = false;
            this.Controls.Add(this.chkSavePass);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtAlias);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtServer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "fserver";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Server";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.fserver_FormClosed);
            this.Load += new System.EventHandler(this.fserver_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtServer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtAlias;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.CheckBox chkSavePass;
    }
}