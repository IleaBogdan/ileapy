using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ileapy
{
    internal static class Program
    {
        public static DataManager GlobalDataManager { get; private set; }
        public static bool program_state = true;
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            GlobalDataManager = new DataManager();
            while (program_state)
            {
                if (!Cache.IsLogin())
                {
                    using (var loginPage = new LoginPage())
                    {
                        Application.Run(loginPage);
                        if (!Cache.IsLogin())
                        {
                            // User closed login page without logging in
                            return;
                        }
                    }
                }

                if (Cache.IsLogin())
                {
                    using (var homePage = new HomePage())
                    {
                        Application.Run(homePage);
                    }
                }
            }
        }
    }
}
