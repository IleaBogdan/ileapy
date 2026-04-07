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
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (!Cache.IsLogin())
            {
                // display login menu and stuff
                Application.Run(new LoginPage());
            }

                Application.Run(new HomePage());
        }
    }
}
