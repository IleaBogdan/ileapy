using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ileapy
{
    internal class Cache
    {
        public class CardInfo
        {
            public string CardNumber { get; set; }
            public double Amount { get; set; }
            public string ExpDate { get; set; }
            public string CVC { get; set; }
            public CardInfo(string cardNumber, double amount, string expDate, string cvc)
            {
                CardNumber = cardNumber;
                Amount = amount;
                ExpDate = expDate;
                CVC = cvc;
            }
            public static int checksum(string cnr)
            {
                // checksum is calculated as:
                // 1. reverse the string
                // 2. double every second digit
                // 3. find the difference to the closest multiple of 10 bigger then the number
                cnr = MyStrings.Reverse(cnr);
                int cs = 0;
                for (int i = 0; i < cnr.Length; ++i)
                {
                    if(i%2==0)cs+= (int)cnr[i];
                    else cs+= (((int)cnr[i]*2)/10+ ((int)cnr[i]*2)%10);
                }
                return 10-cs%10;
            }
            public static string generate_CVC(string cardNumber, string expirationDate)
            {
                string cleanCard = cardNumber.Replace(" ", "").Replace("-", "");

                // parse date (dd/MM/yyyy)
                string[] dateParts = expirationDate.Split('/');
                string dateCode = dateParts[2].Substring(2, 2) + dateParts[1]; // YYMM

                // take last 8 digits of card + date code
                string last8 = cleanCard.Length >= 8
                    ? cleanCard.Substring(cleanCard.Length - 8)
                    : cleanCard.PadLeft(8, '0');

                string combined = last8 + dateCode;

                int sum = 0;
                for (int i = 0; i < combined.Length; ++i)
                {
                    int digit = int.Parse(combined[i].ToString());
                    // double every second digit (like Luhn, but simpler)
                    if (i % 2 == 1)
                    {
                        digit *= 2;
                        if (digit > 9) digit = digit - 9;
                    }
                    sum += digit;
                }

                long cvc = (sum * 131) % 1000;
                return cvc.ToString("D3");
            }
            public static string generate_card_number()
            {
                // First Digit Industry
                // 4   Visa
                // 5   Mastercard
                // 6   Discover
                // 7   Petroleum / Future Industry Use
                // 8   Healthcare / Future Industry Use
                // 9   National assignment

                var rand = new Random();
                int IIN_idx=rand.Next(4, 7)-4;
                int[] IIN = { 402400, 222300, 622925, 706997, 800123, 987650};
                // The IIN is the first 6 digits of a card number
                // each payment network gives a bank an unique IIN
                // I made some random IIN's that fit each payment network's number gap
                string cnr = IIN[IIN_idx].ToString();
                for(int i = 0; i < 9; ++i)
                {
                    cnr += rand.Next(0, 10).ToString();
                }
                cnr += checksum(cnr).ToString();
                return cnr;
            }
            public CardInfo() {
                // the expDate should be 5 months after the date it was made.
                this.ExpDate = MyStrings.Reverse(MyStrings.Reverse(DateTime.Now.ToString("M/d/yyyy")).Substring(MyStrings.Reverse(DateTime.Now.ToString("M/d/yyyy")).IndexOf("/"))) + (Int32.Parse(MyStrings.Reverse(MyStrings.Reverse(DateTime.Now.ToString("M/d/yyyy")).Substring(0, MyStrings.Reverse(DateTime.Now.ToString("M/d/yyyy")).IndexOf("/")))) + 5).ToString();
                this.Amount = 0.0;
                // 16 digits number
                this.CardNumber = generate_card_number();
                // 3 digits number
                this.CVC = generate_CVC(this.CardNumber,this.ExpDate);
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

                //Console.WriteLine(cardsDetails);
                // Note: cards are splited with , from each other and the data of each card is splited with |
                string[]cards=cardsDetails.Split(',');
                if (cards == null) return;
                for(int i = 0; i < cards.Length; ++i)
                {
                    string[] card = cards[i].Split('|');
                    if (card==null) continue;
                    if (card.Length != 4) continue;
                    CardInfo c=new CardInfo(card[0], Convert.ToDouble(card[1]), card[2], card[3]);
                    //Console.WriteLine(card[0] + " " + card[1] + " "+card[2]+" " + card[3]);
                    card_list.Add(c);
                }
            }
        }
        public static void add_card()
        {
            card_list.Add(new CardInfo());
        }
    }
}
