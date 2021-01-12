using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml; 
using Newtonsoft.Json;
using Newtonsoft.Json.Linq; 

namespace Win_Auto_Task
{
    public partial class frm_main : Form
    {  
        //自动生成checkbox的位置参数
        private int row_count = 4; //一行生成几个
        private int col_interval = 20;//高度间隔
        private int row_interval = 160;//宽度间隔

        private int cb_size_weight = 150;//单个长度

        private static int section = 1000;//上传区间

        //定时参数
        private static int time_sum = 0;//时间总和
        private int max_sum = 86400;//最大时间总和（86400 = 1天）
        private int time_calibration = 1000;//校准一下服务器时间
        private int today = 0;

        private static string strSqlConn = string.Empty;
        private static DateTime dt;

        private static bool isrun = true;

        private cb_task ct_now = new cb_task();
        private CheckBox cb_now = new CheckBox();

        public string strSqlConnIndex_ZB
        {
            get
            {
                return strSqlConn;
            }
            set
            {
                strSqlConn = value;
            }
        }
         
        DataTable task_dt = new DataTable();

        public frm_main()
        {
            InitializeComponent();
        }

        #region 事件 
        private void auto_send_total_Load(object sender, EventArgs e)
        {
            try
            {
                InitTime();
                ReadXml();
                InitCB();
                InitTitle();
                btn_start_Click(null, null);
            }
            catch (Exception ex)
            {
                AddMessage("载入出错：" + ex.Message.ToString());
            }
        }
        private void btn_run_Click(object sender, EventArgs e)
        {
            Run_Inter();
        }
        private void btnLinkTest_zb_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConn = null;

            if (txbServerAddr.Text.Trim().Equals(string.Empty))
            {
                tsslblMsg.Text = "服务器地址不能为空,请检查!";

                // 若有错误 光标先定位到服务器地址选项 并全部选中状态
                txbServerAddr.Focus();
                //txbServerAddr_zb.SelectAll();

                // 退出程序
                return;
            }

            if (txbDbName_zb.Text.Trim().Equals(string.Empty))
            {
                tsslblMsg.Text = "数据库名称不能为空,请检查!";

                // 若有错误 光标先定位到服务器地址选项 并全部选中状态
                txbDbName_zb.Focus();
                //txbDbName_zb.SelectAll();

                // 退出程序
                return;
            }

            if (txbUserID_zb.Text.Trim().Equals(string.Empty))
            {
                tsslblMsg.Text = "用户名不能为空,请检查!";

                // 若有错误 光标先定位到服务器地址选项 并全部选中状态
                txbUserID_zb.Focus();
                //txbUserID_zb.SelectAll();

                // 退出程序
                return;
            }

            try
            {
                //strSqlConnIndex = "Data Source=" + txbServerAddr_zb.Text.Trim() + "; Initial Catalog=" + txbDbName_zb.Text.Trim()
                //                  + "; User ID=" + txbUserID_zb.Text.Trim() + "; Password=" + txbPwd_zb.Text;

                // 初始化连接地址 在加载时读取后 后续即可引用
                strSqlConnIndex_ZB = "Server = " + txbServerAddr.Text.Trim() + "; Uid= " + txbUserID_zb.Text.Trim()
                    + "; Pwd= " + txbPwd_zb.Text + "; Integrated Security = false; Database = " + txbDbName_zb.Text.Trim();

                sqlConn = new SqlConnection(strSqlConnIndex_ZB); // 需要考证 为何不能这么写 sqlConn.ConnectionString = strSqlConnIndex; 因为没有实例化不能用
                sqlConn.Open();

                //PubFun.connectionString = strSqlConnIndex_ZB;

                // 若无异常直接提示测试连接成功
                tsslblMsg.Text = "测试连接数据库成功！若尚未保存设置信息，请点击保存设置！";
                // 异常情况后字体颜色没有被初始化回来 这里初始一下
                tsslblMsg.ForeColor = Color.Blue;

            }
            catch (Exception ex)
            {
                tsslblMsg.Text = "程序异常： " + ex.Message;
                tsslblMsg.ForeColor = Color.Red;
            }
            finally
            {
                if (sqlConn != null)
                {
                    // 判断连接成功 调用关闭连接  也可以不判断直接关闭也不会报错
                    sqlConn.Close();
                }
            }
        }
        private void btnSaveSet_zb_Click(object sender, EventArgs e)
        {
            if (txbServerAddr.Text.Trim().Equals(string.Empty))
            {
                tsslblMsg.Text = "服务器地址不能为空,请检查!";

                // 若有错误 光标先定位到服务器地址选项 并全部选中状态
                txbServerAddr.Focus();
                //txbServerAddr_zb.SelectAll();

                // 退出程序
                return;
            }

            if (txbtime.Text.Trim().Equals(string.Empty))
            {
                tsslblMsg.Text = "超时时间不能为空,请检查!";
                txbtime.Focus();
            }

            int int_a = 0;
            if (!int.TryParse(txbtime.Text.Trim(), out int_a))
            {
                tsslblMsg.Text = "超时时间有误,请检查!";
                txbtime.Focus();
            }

            if (txbDbName_zb.Text.Trim().Equals(string.Empty))
            {
                tsslblMsg.Text = "数据库名称不能为空,请检查!";

                // 若有错误 光标先定位到服务器地址选项 并全部选中状态
                txbDbName_zb.Focus();
                //txbDbName_zb.SelectAll();

                // 退出程序
                return;
            }

            if (txbUserID_zb.Text.Trim().Equals(string.Empty))
            {
                tsslblMsg.Text = "用户名不能为空,请检查!";

                // 若有错误 光标先定位到服务器地址选项 并全部选中状态
                txbUserID_zb.Focus();
                //txbUserID_zb.SelectAll();

                // 退出程序
                return;
            }

            try
            {
                // 无异常则写入配置文件保存
                WriteXml();
                tsslblMsg.Text = "服务器连接设置保存成功！请重新启动应用程序！";

            }
            catch (Exception ex)
            {
                tsslblMsg.Text = "程序异常： " + ex.Message;
                tsslblMsg.ForeColor = Color.Red;
            }
        }
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Show(); //窗体显示
            WindowState = FormWindowState.Normal; //窗体状态默认大小
            Activate(); //激活窗体给予焦点
        }
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Hide(); //隐藏窗体 
        }
        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            //点击"是(YES)"退出程序
            if (MessageBox.Show("确定要退出程序?", "安全提示",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning)
                == DialogResult.Yes)
            {
                notifyIcon1.Visible = false; //设置图标不可见
                Close(); //关闭窗体
                Dispose(); //释放资源
                Application.Exit(); //关闭应用程序窗体
            }
        }
        private void btn_start_Click(object sender, EventArgs e)
        {
            if (btn_start.Text == "开始服务")
            {
                btn_start.Text = "关闭服务";
                timer2.Start();
            }
            else
            {
                btn_start.Text = "开始服务";
                timer2.Stop();
            }
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            time_sum++;

            DateTime time_now = DateTime.Now;
            int time_sum_temp = GetTime_Int(time_now);

            //校准流
            if (time_sum % time_calibration == 0 && time_sum != time_sum_temp)
            {
                for (int i = time_sum; i <= time_sum_temp; i++)
                {
                    Run_Tasks(i);
                }

                AddMessage(string.Format("时间校准 {0} -> {1} ", time_sum, time_sum_temp));
                time_sum = time_sum_temp;
            }
            else
            {
                Run_Tasks(time_sum);
            }

            if (time_sum >= max_sum)
            {
                time_sum = 0;
            }
        }
        private void btn_Clear_Log_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }
        private void btn_Refresh_Task_Click(object sender, EventArgs e)
        {
            InitCB();
        }
        private void auto_send_total_FormClosing(object sender, FormClosingEventArgs e)
        {
            //窗体关闭原因为单击"关闭"按钮或Alt+F4
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true; //取消关闭操作 表现为不关闭窗体
                Hide(); //隐藏窗体
            }
        }
        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show(); //窗体显示
            WindowState = FormWindowState.Normal; //窗体状态默认大小
            Activate(); //激活窗体给予焦点
        } 
        private void btn_Cancel_Checked_Click(object sender, EventArgs e)
        {
            InitCB(1);
        }
        #endregion

        #region 方法  
        private void btn_end_Click(object sender, EventArgs e)
        {
            AddMessage("这个功能还在开发中...");
            //isrun = false;
            //cts.Cancel();
            //AddMessage("任务终止！");
        }
        private void WriteXml()
        {
            XmlDocument xmlDoc = null;
            XmlNode xmlNod = null;

            //string strXmlFilePath = string.Empty;               //定义执行文件所在路径
            //string strXmlFileName = string.Empty;               //定义指定路径下的文件名

            // 获取应用程序的执行文件路径
            string strFilePathIndex = Application.ExecutablePath;

            // 获取文本文件完整路径
            string strFileNameIndex = Path.GetDirectoryName(strFilePathIndex) + "\\" + "Dock.xml";

            if (File.Exists(strFileNameIndex))
            {
                xmlDoc = new XmlDocument();
                xmlDoc.Load(strFileNameIndex);

                // 获取基本信息设置
                xmlNod = xmlDoc.DocumentElement["ConnectionString"].FirstChild;      // 有多个子节点才能设置 FirstNode

                // 设置服务器地址
                xmlNod.ChildNodes[0].InnerText = txbServerAddr.Text.Trim();

                // 设置数据库名称
                xmlNod.ChildNodes[1].InnerText = txbDbName_zb.Text.Trim();

                // 设置登陆数据库用户名
                xmlNod.ChildNodes[2].InnerText = txbUserID_zb.Text.Trim();

                // 设置用户名密码
                xmlNod.ChildNodes[3].InnerText = txbPwd_zb.Text.Trim();

                xmlNod.ChildNodes[4].InnerText = txbtime.Text.Trim();

                xmlDoc.Save(strFileNameIndex);
            }
        }
        private void ReadXml()
        {
            XmlDocument xmlDoc = null;
            XmlNode xmlNod = null;

            //string strXmlFilePath = string.Empty;               //定义执行文件所在路径
            //string strXmlFileName = string.Empty;               //定义指定路径下的文件名

            // 获取应用程序的执行文件路径
            string strFilePathIndex = Application.ExecutablePath;

            // 获取文本文件完整路径
            string strFileNameIndex = Path.GetDirectoryName(strFilePathIndex) + "\\" + "Dock.xml";

            if (File.Exists(strFileNameIndex))
            {
                xmlDoc = new XmlDocument();
                xmlDoc.Load(strFileNameIndex);

                // 读取基础设置信息
                xmlNod = xmlDoc.DocumentElement["BasicSettings"];

                // 获取基本连接信息 ConnectionString为节点元素时 需要读取到 FirstChild
                xmlNod = xmlDoc.DocumentElement["ConnectionString"].FirstChild;

                // 获取服务器地址
                txbServerAddr.Text = xmlNod.ChildNodes[0].InnerText;

                // 获取数据库名称
                txbDbName_zb.Text = xmlNod.ChildNodes[1].InnerText;

                // 获取登陆数据库用户名
                txbUserID_zb.Text = xmlNod.ChildNodes[2].InnerText;

                // 获取用户名密码
                txbPwd_zb.Text = xmlNod.ChildNodes[3].InnerText;

                txbtime.Text = xmlNod.ChildNodes[4].InnerText;

                xmlNod = xmlDoc.DocumentElement["ConnectionString"].FirstChild.NextSibling;

                if (xmlNod == null)
                {
                    return;
                }

                // 初始化连接地址 在加载时读取后 后续即可引用
                strSqlConnIndex_ZB = "Server = " + txbServerAddr.Text.Trim() + "; Uid= " + txbUserID_zb.Text.Trim()
                    + "; Pwd= " + txbPwd_zb.Text + "; Integrated Security = false; Database = " + txbDbName_zb.Text.Trim()
                    + "; Connection TimeOut = " + Convert.ToInt32(txbtime.Text) * 60;
                //timer1.Interval = int.Parse(txbtime.Text) * 1000 * 60;
            }

        }
        private void Run_Tasks(int time_sum_now)
        {
            for (int i = 0; i < task_dt.Rows.Count; i++)
            {
                int term = 600;
                DateTime time = DateTime.MinValue;

                int.TryParse(task_dt.Rows[i]["term"].ToString(), out term);
                DateTime.TryParse(task_dt.Rows[i]["term_start_time"].ToString(), out time);
                int term_start_time = GetTime_Int(time);

                if ((time_sum_now - term_start_time + max_sum) % term == 0 && time_sum_now >= term_start_time)
                {
                    Run_Inter(task_dt.Rows[i]["cb_code"].ToString());
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type">0 按配置配置check 1 全部不选取消全选 </param>
        private void InitCB(int type = 0)
        {
            groupBox2.Controls.Clear();
            //CBIntertask表结构详情请见海港存健康pdm
            string sql = "SELECT * FROM CBIntertask WHERE used = 1 order by Interid";
            task_dt = PubFun.Query_dt(sql, strSqlConnIndex_ZB);

            if (task_dt.Rows.Count == 0)
            {
                AddMessage("没有获取到数据库的配置，自动载入默认配置");

                task_dt = new DataTable();
                task_dt.Columns.Add("cb_code");
                task_dt.Columns.Add("cb_name");
                task_dt.Columns.Add("cb_check");
                task_dt.Columns.Add("term");
                task_dt.Columns.Add("is_remind");
                task_dt.Columns.Add("percentage_term"); 
                task_dt.Columns.Add("is_percentage");
                task_dt.Columns.Add("term_start_time");

                #region 默认配置

                DataRow dr = task_dt.NewRow();
                dr["cb_code"] = "cb1";
                dr["cb_name"] = "测试任务";
                dr["cb_check"] = "1";
                dr["term"] = 60000;
                dr["is_remind"] = "0";
                dr["percentage_term"] = "1";
                dr["is_percentage"] = "0";
                dr["term_start_time"] = "1900-01-01 01:00:00.000";
                task_dt.Rows.Add(dr);

                dr = task_dt.NewRow();
                dr["cb_code"] = "Print_Term";
                dr["cb_name"] = "打印任务";
                dr["cb_check"] = "1";
                dr["term"] = 1;
                dr["is_remind"] = "0";
                dr["percentage_term"] = "1";
                dr["is_percentage"] = "0";
                dr["term_start_time"] = "1900-01-01 01:00:00.000";
                task_dt.Rows.Add(dr);

                dr = task_dt.NewRow();
                dr["cb_code"] = "Task_1";
                dr["cb_name"] = "任务1";
                dr["cb_check"] = "1";
                dr["term"] = 86400;
                dr["is_remind"] = "0";
                dr["percentage_term"] = "1";
                dr["is_percentage"] = "0";
                dr["term_start_time"] = "1900-01-01 01:00:00.000";
                task_dt.Rows.Add(dr);


                dr = task_dt.NewRow();
                dr["cb_code"] = "Task_2";
                dr["cb_name"] = "任务2";
                dr["cb_check"] = "1";
                dr["term"] = 3600;
                dr["is_remind"] = "0";
                dr["percentage_term"] = "2";
                dr["is_percentage"] = "1";
                dr["term_start_time"] = "1900-01-01 01:00:00.000";
                task_dt.Rows.Add(dr);

                #endregion 
            }

            int cb_count = task_dt.Rows.Count;
              
            for (int i = 0; i < cb_count; i++)
            {
                int row = i / row_count;
                int col = i % row_count;
                CheckBox cb = new CheckBox();
                cb.Name = task_dt.Rows[i]["cb_code"].ToString();
                cb.Text = task_dt.Rows[i]["cb_name"].ToString();
                cb.Location = new Point(col_interval + row_interval * col, col_interval + col_interval * row);
                cb.Size = new Size(cb_size_weight, cb.Size.Height);

                if (task_dt.Rows[i]["cb_check"].ToString() == "1")
                { 
                    cb.Checked = true; 
                }

                if (type == 1)
                {
                    cb.Checked = false;
                }
                 
                int term = 1;
                int.TryParse(task_dt.Rows[i]["percentage_term"].ToString(), out term);

                cb.Tag = new cb_Tag(task_dt.Rows[i]["is_remind"].ToString(), task_dt.Rows[i]["is_percentage"].ToString(), term);

                groupBox2.Controls.Add(cb);
            }

            //计算显示的panel长度
            //1 50 2 70
            panel2.Size = new Size(panel2.Width, 3 * col_interval + ((cb_count - 1) / row_count) * col_interval);
        }
        private void InitTitle()
        {
            //string title = PubFun.GetSystemPar("cb_task_title");
            //notifyIcon1.Text = title;
        }
        private void Run_Inter()
        {
            isrun = true;
            foreach (var control in groupBox2.Controls)
            {
                if (control.GetType() == typeof(CheckBox))
                {
                    CheckBox cb_item = (CheckBox)control;
                    RunTask_Main(cb_item);
                }
            }
        }
        private void Run_Inter(string task)
        {
            isrun = true;
            foreach (var control in groupBox2.Controls)
            {
                if (control.GetType() == typeof(CheckBox))
                {
                    CheckBox cb_item = (CheckBox)control;
                    if (task == cb_item.Name)
                    {
                        RunTask_Main(cb_item);
                        break;
                    }
                }
            }
        }
        private void InitTime()
        {
            DateTime time = DateTime.Now;
            time_sum = GetTime_Int(time);
        }

        private int GetTime_Int(DateTime time)
        {
            return ((time.Hour * 60 + time.Minute) * 60 + time.Second) % max_sum;
        }

        CancellationTokenSource cts;
        private void RunTask_Main(CheckBox cb)
        {
            try
            {
                if (cb.Checked)
                {  
                    var function = Activator.CreateInstance(typeof(cb_task)) as cb_task;

                    Task t1 = new Task(() =>
                    {
                        System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
                        stopwatch.Start();

                        var method = function.GetType().GetMethod(cb.Name);
                        object result = method.Invoke(function, null);

                        stopwatch.Stop();
                        double time1 = stopwatch.Elapsed.TotalSeconds; //这里是输出的总运行秒数,精  

                        function.Percentage = 100;
                        string msg = result.ToString() + " 耗时：" + time1;
                        AddMessage(cb, msg);

                        if (cb.Tag != null)
                        {
                            if (((cb_Tag)cb.Tag).is_remind == "1")
                            {
                                //提醒到你要提醒的地方
                                //PubFun.Record_Diary_Day_Remind(cb.Name, msg);
                            }
                        }
                    });
                    t1.Start();

                    if (((cb_Tag)cb.Tag).is_percentage == "1")
                    {
                        Task t2 = new Task(() =>
                        {
                            Print_Percentage(function, cb, ((cb_Tag)cb.Tag).term);
                        });
                        t2.Start();
                    }
                }
            }
            catch (Exception ex)
            {
                AddMessage(cb.Text + "出错" + ex.Message.ToString());
                PubFun.WriteLog_Error(ex);
            }
        }  

        //打印任务进度
        private void Print_Percentage(cb_task ct, CheckBox cb, int term = 1)
        {
            int index = 0;
            while (ct.Percentage < 100)
            {
                AddMessage("系统正在执行任务:" + cb.Name + "_" + cb.Text + " ............." + ct.Percentage + "%");
                Thread.Sleep(1000 * term);
                if (ct.Percentage == 0)
                {
                    continue;
                }

                if (ct.Percentage == 100)
                {
                    AddMessage("系统正在执行任务:" + cb.Name + "_" + cb.Text + " ............." + ct.Percentage + "%");
                    return;
                }
            }
        }

        delegate void SetTextCallback(string text);

        delegate void Run_Task(string methodName);
        private void AddMessage(string str)
        {
            try
            {
                if (this.richTextBox1.InvokeRequired)
                {
                    SetTextCallback d = new SetTextCallback(AddMessage);
                    this.Invoke(d, new object[] { str });
                }
                else
                {
                    if (richTextBox1.Lines.Length > 5000)
                        richTextBox1.Clear();
                    this.richTextBox1.Text = "[" + DateTime.Now.ToString() + "]\r\n" + str + "\r\n" + richTextBox1.Text; ;
                    Application.DoEvents();
                }
            }
            catch { }
        }
        private void AddMessage(CheckBox cb, string str)
        {
            string str_prefix = cb.Name + "_" + cb.Text;
            str = "[" + str_prefix + "]:\r\n" + str + "\r\n";
            try
            {
                if (this.richTextBox1.InvokeRequired)
                {
                    SetTextCallback d = new SetTextCallback(AddMessage);
                    this.Invoke(d, new object[] { str });
                }
                else
                {
                    if (richTextBox1.Lines.Length > 5000)
                        richTextBox1.Clear();
                    this.richTextBox1.Text = "[" + DateTime.Now.ToString() + "]\r\n" + str + "\r\n" + richTextBox1.Text + "\r\n"; ;
                    Application.DoEvents();
                }
            }
            catch { }
        }
        #endregion

        public class cb_Tag
        {
            public string is_remind = "0";
            public string is_percentage = "0";
            public int term = 1;

            public cb_Tag(string is_remind, string is_percentage, int term)
            {
                this.is_remind = is_remind;
                this.is_percentage = is_percentage;
                this.term = term;
            }
        }

        //代办任务
        public class cb_task
        {
            //进度百分比 （若要实现实时进度，请在各个任务功能中变更Percentage的值，最大100，适用于比较慢的服务）
            public int Percentage = 0;

            //测试
            public string cb1()
            {
                int index = 0;
                while (index++ < 10)
                {
                    cb_task cb = new cb_task();
                    Thread.Sleep(100);
                    Percentage++;
                }

                MessageBox.Show("测试任务执行成功！");

                return "cb1success";
            }

            //打印
            public string Print_Term()
            {
                return DateTime.Now + "\r\n" + time_sum;
            }

            public string Task_1()
            {
                //可以放点薅羊毛的代码
                return "签到完成";
            }

            public string Task_2()
            {
                //可以放点下载数据，比如基金股票比特币等

                int index = 0;
                while (index++ < 100)
                {
                    cb_task cb = new cb_task();
                    Thread.Sleep(200);
                    Percentage++;
                }

                return "下载完成";
            }
        } 
    }
}
