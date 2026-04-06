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
        private void ConvertButton_Click(object sender, EventArgs e)
        {
            double CRate = CurrencyConverter.CoinDiff("eur", "ron");
        }
    }
}
