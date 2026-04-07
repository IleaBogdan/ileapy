using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ileapy
{
    internal class Cache
    {
        public static string uname;
        public static string hpassword; // password hash
        public static bool IsLogin()
        {
            return false;
            // check if the file named .login exists in the current context
            try
            {
                string contents = File.ReadAllText(Path.GetFullPath(".login"));
                // Console.WriteLine(contents);
                string[]data=contents.Split('\n');
                //Console.WriteLine(data[0]);
                //Console.WriteLine(data[1]);
                if (data.Length<2)return false;
                
                // check uname:
                if (data[0] != null)
                {

                }
                else return false;
                    return true;
            }
            catch { return false; } // .login is not in the same folder as the exe or does not exist
        }
    }
}
