using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;


namespace stand
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            UserLogin ul = new UserLogin();
            ul.ShowDialog();
        }
    }
}
