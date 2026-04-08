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
                if (data[0] == null || data[1]==null)
                {
                    return false;
                }
                if (data[0] == "" || data[1] == "")
                {
                    return false;
                }
                uname = data[0].Split(':')[1];
                hpassword = data[1].Split(':')[1];
                if(uname == null || hpassword == null) return false;
                if(uname == "" || hpassword == "") return false;
                var res=Program.GlobalDataManager.usersTableAdapter.CheckCredentials(uname, hpassword);
                //Console.WriteLine(res);
                return true;
            }
            catch { return false; } // .login is not in the same folder as the exe or does not exist
        }
        public static void save_credentials(string username, string hashed_password)
        {
            uname = username;
            hpassword = hashed_password;
            File.WriteAllText(".login","uname:"+uname+"\nhpass:"+hpassword);
        }
        public static void logout()
        {
            File.WriteAllText(".login", "");
        }
    }
}
