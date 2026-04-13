using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ileapy
{
    internal class CurrencyIniter
    {
        public static void InitCurrecnys(
            int idx, 
            ref Dictionary<string, string> Currencys, 
            ref Dictionary<string, string> RevCurrencys,
            ref List<TabButtons> tabList,
            ref string Selected_Currency
        )
        {
            if (Currencys.Count == 0)
            { // check to only init the Currencys once and not overload them with to much data
                string data = CurrencyConverter.LoadCurrencys();
                int i = 0;
                while (true)
                {
                    try
                    {
                        string key = MyStrings.split_Quotation(data, ref i);
                        string val = MyStrings.split_Quotation(data, ref i);
                        if ("" == key) break;
                        if ("" == val) continue;
                        if (":" == val) continue;
                        if (": " == val) continue;
                        Currencys[key] = val;
                        RevCurrencys[val] = key;
                    }
                    catch (Exception err)
                    {
                        if (err is ArgumentOutOfRangeException) break;
                        Console.WriteLine(err.Message);
                        Environment.Exit(-2); // The program '[20996] ileapy.exe' has exited with code 4294967294 (0xfffffffe).
                    }
                }
            }
            //tabList[idx].Currency_ComboBox.Items.Clear();
            foreach (var e in Currencys)
            {
                //Console.WriteLine($"Key: {e.Key}, Value: {e.Value}");
                tabList[idx].Currency_ComboBox.Items.Add(e.Value);
            }
            tabList[idx].Currency_ComboBox.SelectedIndex = tabList[idx].Currency_ComboBox.FindString("Euro");
            Selected_Currency = "eur";
        }
        public static void InitCurrecnys(
            ref Dictionary<string, string> Currencys,
            ref Dictionary<string, string> RevCurrencys,
            ref List<TabButtons> tabList,
            ref string Selected_Currency,
            ref System.Windows.Forms.TabControl cardsTabControl
        )
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
                    if ("" == val) continue;
                    if (":" == val) continue;
                    if (": " == val) continue;
                    Currencys[key] = val;
                    RevCurrencys[val] = key;
                }
                catch (Exception err)
                {
                    if (err is ArgumentOutOfRangeException) break;
                    Console.WriteLine(err.Message);
                    Environment.Exit(-2); // The program '[20996] ileapy.exe' has exited with code 4294967294 (0xfffffffe).
                }
            }
            //tabList[this.cardsTabControl.SelectedIndex].Currency_ComboBox.Items.Clear();
            foreach (var e in Currencys)
            {
                //Console.WriteLine($"Key: {e.Key}, Value: {e.Value}");
                tabList[cardsTabControl.SelectedIndex].Currency_ComboBox.Items.Add(e.Value);
            }
            tabList[cardsTabControl.SelectedIndex].Currency_ComboBox.SelectedIndex = tabList[cardsTabControl.SelectedIndex].Currency_ComboBox.FindString("Euro");
            Selected_Currency = "eur";
        }
    }
}
