using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
                    Cache.init();
                    using (var homePage = new HomePage())
                    {
                        Application.Run(homePage);
                    }
                }
            }
        }
        public static string hash(string text) // password hashing (it is not true hashing but it is not plain text either)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(text);
            SHA256Managed hashstring = new SHA256Managed();
            byte[] hash = hashstring.ComputeHash(bytes);
            string hashString = string.Empty;
            foreach (byte x in hash)
            {
                hashString += String.Format("{0:x2}", x);
            }
            return hashString;
        }
    }
}
