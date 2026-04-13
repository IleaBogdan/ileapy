using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ileapy
{
    internal class MyStrings
    {
        public static string split_Quotation(string data, ref int offset)
        {
            int q_start = data.IndexOf('"', offset);
            int q_end = data.IndexOf('"', q_start + 1);
            string q = data.Substring(q_start+1, q_end - q_start -1);
            offset = q_end + 1;
            return q;
        }
        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}
