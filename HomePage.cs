using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ileapy;

namespace ileapy
{
    public partial class HomePage : Form
    {
        Dictionary<string, string> Currencys = new Dictionary<string, string>();
        public HomePage()
        {
            InitializeComponent();
            MapCurrecnys();
            set_balance(1000000000.1);
        }
        private void MapCurrecnys()
        {
            string data = CurrencyConverter.LoadCurrencys();
            int i = 0;
            while (true)
            {
                try
                {
                    string key = MyStrings.split_Quotation(data, ref i);
                    string val = MyStrings.split_Quotation(data, ref i);
                    if ("" == key) break;
                    Currencys.Add(key, val);
                }
                catch (Exception err)
                {
                    if (err is ArgumentOutOfRangeException) break;
                    Environment.Exit(-1);
                }
            }
            //foreach (var ele in Currencys)
            //{
            //    Console.WriteLine($"Key: {ele.Key}, Value: {ele.Value}");
            //}
        }
        private void set_balance(double new_balance)
        {
            string new_text = Convert.ToDouble(String.Format("{0:0.00}", new_balance)).ToString();
            if (new_text[new_text.Length - 2] == '.') new_text+="0";
            if (new_text[new_text.Length - 3] != '.') new_text += ".00";
            this.balance_label.Text = new_text;
            this.balance_label.Left = (this.ClientSize.Width - this.balance_label.Width) / 2;
        }
        private void ConvertButton_Click(object sender, EventArgs e)
        {
            double CRate = CurrencyConverter.CoinDiff("eur", "ron");
        }
    }
}
