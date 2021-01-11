using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Win_Auto_Task
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (CheckInstance())
            {
                MessageBox.Show("该系统已经在运行中...", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Exit();
            }
            else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new frm_main());
            }
        }

        private static bool CheckInstance()
        {
            string procName = System.Diagnostics.Process.GetCurrentProcess().ProcessName;
            if ((System.Diagnostics.Process.GetProcessesByName(procName)).GetUpperBound(0) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
            // return false;  
        }
    }
}
