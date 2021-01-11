
namespace Win_Auto_Task
{
    partial class frm_main
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_main));
            this.gpbLinkDB_zb = new System.Windows.Forms.GroupBox();
            this.txbtime = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tsslblMsg = new System.Windows.Forms.Label();
            this.txbDbName_zb = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSaveSet_zb = new System.Windows.Forms.Button();
            this.btnLinkTest_zb = new System.Windows.Forms.Button();
            this.txbPwd_zb = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txbUserID_zb = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txbServerAddr = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Cancel_Checked = new System.Windows.Forms.Button();
            this.btn_end = new System.Windows.Forms.Button();
            this.btn_Refresh_Task = new System.Windows.Forms.Button();
            this.btn_Clear_Log = new System.Windows.Forms.Button();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.btn_run = new System.Windows.Forms.Button();
            this.btn_start = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.gpbLinkDB_zb.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpbLinkDB_zb
            // 
            this.gpbLinkDB_zb.Controls.Add(this.txbtime);
            this.gpbLinkDB_zb.Controls.Add(this.label5);
            this.gpbLinkDB_zb.Controls.Add(this.tsslblMsg);
            this.gpbLinkDB_zb.Controls.Add(this.txbDbName_zb);
            this.gpbLinkDB_zb.Controls.Add(this.label4);
            this.gpbLinkDB_zb.Controls.Add(this.btnSaveSet_zb);
            this.gpbLinkDB_zb.Controls.Add(this.btnLinkTest_zb);
            this.gpbLinkDB_zb.Controls.Add(this.txbPwd_zb);
            this.gpbLinkDB_zb.Controls.Add(this.label3);
            this.gpbLinkDB_zb.Controls.Add(this.txbUserID_zb);
            this.gpbLinkDB_zb.Controls.Add(this.label2);
            this.gpbLinkDB_zb.Controls.Add(this.txbServerAddr);
            this.gpbLinkDB_zb.Controls.Add(this.label1);
            this.gpbLinkDB_zb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpbLinkDB_zb.Location = new System.Drawing.Point(4, 4);
            this.gpbLinkDB_zb.Margin = new System.Windows.Forms.Padding(4);
            this.gpbLinkDB_zb.Name = "gpbLinkDB_zb";
            this.gpbLinkDB_zb.Padding = new System.Windows.Forms.Padding(4);
            this.gpbLinkDB_zb.Size = new System.Drawing.Size(991, 361);
            this.gpbLinkDB_zb.TabIndex = 4;
            this.gpbLinkDB_zb.TabStop = false;
            this.gpbLinkDB_zb.Text = "连锁数据库连接设置";
            // 
            // txbtime
            // 
            this.txbtime.Location = new System.Drawing.Point(181, 178);
            this.txbtime.Margin = new System.Windows.Forms.Padding(4);
            this.txbtime.Name = "txbtime";
            this.txbtime.Size = new System.Drawing.Size(232, 25);
            this.txbtime.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 182);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 15);
            this.label5.TabIndex = 11;
            this.label5.Text = "超时时间:";
            // 
            // tsslblMsg
            // 
            this.tsslblMsg.AutoSize = true;
            this.tsslblMsg.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tsslblMsg.Location = new System.Drawing.Point(4, 342);
            this.tsslblMsg.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.tsslblMsg.Name = "tsslblMsg";
            this.tsslblMsg.Size = new System.Drawing.Size(0, 15);
            this.tsslblMsg.TabIndex = 10;
            // 
            // txbDbName_zb
            // 
            this.txbDbName_zb.Location = new System.Drawing.Point(181, 69);
            this.txbDbName_zb.Margin = new System.Windows.Forms.Padding(4);
            this.txbDbName_zb.Name = "txbDbName_zb";
            this.txbDbName_zb.Size = new System.Drawing.Size(232, 25);
            this.txbDbName_zb.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 73);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "数据库名:";
            // 
            // btnSaveSet_zb
            // 
            this.btnSaveSet_zb.Location = new System.Drawing.Point(288, 234);
            this.btnSaveSet_zb.Margin = new System.Windows.Forms.Padding(4);
            this.btnSaveSet_zb.Name = "btnSaveSet_zb";
            this.btnSaveSet_zb.Size = new System.Drawing.Size(124, 30);
            this.btnSaveSet_zb.TabIndex = 7;
            this.btnSaveSet_zb.Text = "保存设置【&S】";
            this.btnSaveSet_zb.UseVisualStyleBackColor = true;
            this.btnSaveSet_zb.Click += new System.EventHandler(this.btnSaveSet_zb_Click);
            // 
            // btnLinkTest_zb
            // 
            this.btnLinkTest_zb.Location = new System.Drawing.Point(156, 234);
            this.btnLinkTest_zb.Margin = new System.Windows.Forms.Padding(4);
            this.btnLinkTest_zb.Name = "btnLinkTest_zb";
            this.btnLinkTest_zb.Size = new System.Drawing.Size(124, 30);
            this.btnLinkTest_zb.TabIndex = 6;
            this.btnLinkTest_zb.Text = "测试连接【&L】";
            this.btnLinkTest_zb.UseVisualStyleBackColor = true;
            this.btnLinkTest_zb.Click += new System.EventHandler(this.btnLinkTest_zb_Click);
            // 
            // txbPwd_zb
            // 
            this.txbPwd_zb.Location = new System.Drawing.Point(181, 142);
            this.txbPwd_zb.Margin = new System.Windows.Forms.Padding(4);
            this.txbPwd_zb.Name = "txbPwd_zb";
            this.txbPwd_zb.PasswordChar = '*';
            this.txbPwd_zb.Size = new System.Drawing.Size(232, 25);
            this.txbPwd_zb.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 146);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "密码:";
            // 
            // txbUserID_zb
            // 
            this.txbUserID_zb.Location = new System.Drawing.Point(181, 106);
            this.txbUserID_zb.Margin = new System.Windows.Forms.Padding(4);
            this.txbUserID_zb.Name = "txbUserID_zb";
            this.txbUserID_zb.Size = new System.Drawing.Size(232, 25);
            this.txbUserID_zb.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 109);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "用户名:";
            // 
            // txbServerAddr
            // 
            this.txbServerAddr.Location = new System.Drawing.Point(181, 33);
            this.txbServerAddr.Margin = new System.Windows.Forms.Padding(4);
            this.txbServerAddr.Name = "txbServerAddr";
            this.txbServerAddr.Size = new System.Drawing.Size(232, 25);
            this.txbServerAddr.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 37);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "服务器地址:";
            // 
            // btn_Cancel_Checked
            // 
            this.btn_Cancel_Checked.Location = new System.Drawing.Point(547, 10);
            this.btn_Cancel_Checked.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Cancel_Checked.Name = "btn_Cancel_Checked";
            this.btn_Cancel_Checked.Size = new System.Drawing.Size(100, 29);
            this.btn_Cancel_Checked.TabIndex = 6;
            this.btn_Cancel_Checked.Text = "取消全选";
            this.btn_Cancel_Checked.UseVisualStyleBackColor = true;
            this.btn_Cancel_Checked.Click += new System.EventHandler(this.btn_Cancel_Checked_Click);
            // 
            // btn_end
            // 
            this.btn_end.Location = new System.Drawing.Point(223, 10);
            this.btn_end.Margin = new System.Windows.Forms.Padding(4);
            this.btn_end.Name = "btn_end";
            this.btn_end.Size = new System.Drawing.Size(100, 29);
            this.btn_end.TabIndex = 5;
            this.btn_end.Text = "终止任务";
            this.btn_end.UseVisualStyleBackColor = true;
            this.btn_end.Click += new System.EventHandler(this.btn_end_Click);
            // 
            // btn_Refresh_Task
            // 
            this.btn_Refresh_Task.Location = new System.Drawing.Point(439, 10);
            this.btn_Refresh_Task.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Refresh_Task.Name = "btn_Refresh_Task";
            this.btn_Refresh_Task.Size = new System.Drawing.Size(100, 29);
            this.btn_Refresh_Task.TabIndex = 3;
            this.btn_Refresh_Task.Text = "刷新任务";
            this.btn_Refresh_Task.UseVisualStyleBackColor = true;
            this.btn_Refresh_Task.Click += new System.EventHandler(this.btn_Refresh_Task_Click);
            // 
            // btn_Clear_Log
            // 
            this.btn_Clear_Log.Location = new System.Drawing.Point(331, 10);
            this.btn_Clear_Log.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Clear_Log.Name = "btn_Clear_Log";
            this.btn_Clear_Log.Size = new System.Drawing.Size(100, 29);
            this.btn_Clear_Log.TabIndex = 2;
            this.btn_Clear_Log.Text = "清空日志";
            this.btn_Clear_Log.UseVisualStyleBackColor = true;
            this.btn_Clear_Log.Click += new System.EventHandler(this.btn_Clear_Log_Click);
            // 
            // timer2
            // 
            this.timer2.Interval = 1000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // btn_run
            // 
            this.btn_run.Location = new System.Drawing.Point(115, 10);
            this.btn_run.Margin = new System.Windows.Forms.Padding(4);
            this.btn_run.Name = "btn_run";
            this.btn_run.Size = new System.Drawing.Size(100, 29);
            this.btn_run.TabIndex = 1;
            this.btn_run.Text = "执行";
            this.btn_run.UseVisualStyleBackColor = true;
            this.btn_run.Click += new System.EventHandler(this.btn_run_Click);
            // 
            // btn_start
            // 
            this.btn_start.Location = new System.Drawing.Point(7, 10);
            this.btn_start.Margin = new System.Windows.Forms.Padding(4);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(100, 29);
            this.btn_start.TabIndex = 0;
            this.btn_start.Text = "开始服务";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_Cancel_Checked);
            this.panel1.Controls.Add(this.btn_end);
            this.panel1.Controls.Add(this.btn_Refresh_Task);
            this.panel1.Controls.Add(this.btn_Clear_Log);
            this.panel1.Controls.Add(this.btn_run);
            this.panel1.Controls.Add(this.btn_start);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(4, 4);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(991, 52);
            this.panel1.TabIndex = 4;
            // 
            // groupBox2
            // 
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(991, 100);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "任务";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Location = new System.Drawing.Point(4, 156);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(4);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(991, 209);
            this.richTextBox1.TabIndex = 3;
            this.richTextBox1.Text = "";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(4, 56);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(991, 100);
            this.panel2.TabIndex = 5;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.richTextBox1);
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage1.Size = new System.Drawing.Size(999, 369);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "服务";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1007, 398);
            this.tabControl1.TabIndex = 6;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.gpbLinkDB_zb);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage2.Size = new System.Drawing.Size(999, 369);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "设置";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(138, 24);
            this.toolStripMenuItem3.Text = "退出";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(135, 6);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(138, 24);
            this.toolStripMenuItem2.Text = "隐藏窗体";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(138, 24);
            this.toolStripMenuItem1.Text = "显示窗体";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.toolStripSeparator1,
            this.toolStripMenuItem3});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(139, 82);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "每日自动服务";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // frm_main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1007, 398);
            this.Controls.Add(this.tabControl1);
            this.Name = "frm_main";
            this.Text = "每日自动服务";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.auto_send_total_FormClosing);
            this.Load += new System.EventHandler(this.auto_send_total_Load);
            this.gpbLinkDB_zb.ResumeLayout(false);
            this.gpbLinkDB_zb.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gpbLinkDB_zb;
        private System.Windows.Forms.TextBox txbtime;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label tsslblMsg;
        private System.Windows.Forms.TextBox txbDbName_zb;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSaveSet_zb;
        private System.Windows.Forms.Button btnLinkTest_zb;
        private System.Windows.Forms.TextBox txbPwd_zb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txbUserID_zb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txbServerAddr;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Cancel_Checked;
        private System.Windows.Forms.Button btn_end;
        private System.Windows.Forms.Button btn_Refresh_Task;
        private System.Windows.Forms.Button btn_Clear_Log;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Button btn_run;
        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
    }
}

