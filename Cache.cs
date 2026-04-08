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
        public class CardInfo
        {
            public string CardNumber { get; set; }
            public double Amount { get; set; }
            public string ExpDate { get; set; }
            public CardInfo(string cardNumber, double amount, string expDate)
            {
                CardNumber = cardNumber;
                Amount = amount;
                ExpDate = expDate;
            }
        }
        public static string uname;
        public static int user_id;
        public static string hpassword; // password hash
        public static List<CardInfo> card_list=new List<CardInfo>();
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
        public static void init()
        {
            var res=Program.GlobalDataManager.usersTableAdapter.GetUserAndCardData(uname,hpassword);
            if (res.Rows.Count > 0)
            {
                var row=res.Rows[0];
                //Console.WriteLine(row["Id"]);
                user_id = (int)row["Id"];
                string cardsDetails = row["cards_details"]?.ToString();
                //Console.WriteLine(cardsDetails);
                //for (int i = 0; i < row.Table.Columns.Count; i++)
                //{
                //    Console.WriteLine($"{row.Table.Columns[i].ColumnName}: {row[i]}");
                //}

                // Note: cards are splited with , from each other and the data of each card is splited with |
                string[]cards=cardsDetails.Split(',');
                for(int i = 0; i < cards.Length; ++i)
                {
                    string[] card = cards[i].Split('|');
                    CardInfo c=new CardInfo(card[0], Convert.ToDouble(card[1]), card[2]);
                    card_list.Add(c);
                }
            }
        }
    }
}
